using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace LibraryLoader
{
    public class Loader
    {
        private Assembly currentAssembly;

        public string CallToString(object obj)
        {
            if (obj == null)
            {
                return "null";
            }

            if (obj.GetType().IsPrimitive || obj.GetType() == typeof(string))
            {
                return obj.ToString();
            }

            var type = obj.GetType();
            var properties = type.GetProperties();

            StringBuilder sb = new StringBuilder();
            sb.Append(type.Name + " { ");

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                sb.Append($"{property.Name}: {value ?? "null"}, ");
            }

            // Eliminar la coma y espacio extra al final
            if (sb.Length > 2)
            {
                sb.Length -= 2;
            }

            sb.Append(" }");

            return sb.ToString();
        }

        public List<MethodInfo> GetMethods(String pathLibrary)
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            try
            {
                currentAssembly = Assembly.LoadFrom(pathLibrary);
            }
            catch (BadImageFormatException)
            {
                throw new Exception("The file is not a valid library");
            }
            catch (FileNotFoundException)
            {
                throw new Exception("The file was not found");
            }

            foreach (Type type in currentAssembly.GetTypes())
            {
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    if (!method.IsSpecialName)
                    {
                        methods.Add(method);
                    }
                }
            }

            return methods;

        }

        public object LaunchMethod(MethodInfo method, object[] parameters, string pathXML = "")
        {
            object instancia = null;
            if (!method.IsStatic)
            {
                // Se recomienda asegurarse de que el tipo tenga un constructor por defecto.
                instancia = Activator.CreateInstance(method.DeclaringType);
            }

            object result;
            try
            {
                result = method.Invoke(instancia, parameters);
            }
            catch (Exception)
            {
                throw;
            }

            if (!string.IsNullOrEmpty(pathXML) && result != null)
            {
                string xmlResult = SerializeToXml(result);

                File.WriteAllText(pathXML, xmlResult);
            }

            return result;
        }

        public string SerializeToXml(object obj)
        {
            if (obj == null)
            {
                return "<null />";
            }

            // Obtenemos el tipo del objeto
            Type objType = obj.GetType();

            // Crea el XmlSerializer con el tipo dinámico
            XmlSerializer serializer = new XmlSerializer(objType);

            // Usamos StringWriter para capturar el resultado XML en una cadena
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();  // Devuelve la cadena XML
            }
        }
    }
}
