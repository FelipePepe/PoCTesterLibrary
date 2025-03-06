using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LibraryLoader
{
    public class XmlHelper
    {
        public static string GenerateXmlTemplate<T>() where T : new()
        {
            // Crear e inicializar la instancia del DTO
            T instance = new T();
            InitializeProperties(instance);

            // Serializar el objeto a XML
            var xmlSerializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (var stringWriter = new StringWriterUtf8())
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                xmlSerializer.Serialize(xmlWriter, instance);
                return stringWriter.ToString();
            }
        }

        private static void InitializeProperties<T>(T obj)
        {
            var properties = obj.GetType().GetProperties();

            if (properties.Length == 0)
            {
                Console.WriteLine(properties[0].Name + " no tiene propiedades públicas.");
                return;
            }

            foreach (var property in properties)
            {
                
                if (property.CanWrite)
                {
                    if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    {
                        // Crear una instancia para propiedades complejas
                        var instance = Activator.CreateInstance(property.PropertyType);
                        InitializeProperties(instance); // Recursividad
                        property.SetValue(obj, instance);
                    }
                    else if (property.PropertyType.IsGenericType &&
                             property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Inicializar listas y agregar un ejemplo
                        var listType = property.PropertyType.GetGenericArguments()[0];
                        var listInstance = Activator.CreateInstance(typeof(List<>).MakeGenericType(listType));
                        property.SetValue(obj, listInstance);

                        // Crear un elemento de ejemplo
                        var exampleItem = Activator.CreateInstance(listType);
                        InitializeProperties(exampleItem); // Inicializar subpropiedades del elemento
                        ((System.Collections.IList)listInstance).Add(exampleItem);
                    }
                    else
                    {
                        // Establecer un valor predeterminado
                        property.SetValue(obj, GetDefaultValue(property.PropertyType));
                    }
                }
            }
        }

        private static object GetDefaultValue(Type type)
        {
            if (type == typeof(string)) return "RELLENAR"; // Para propiedades de texto
            if (type.IsValueType) return Activator.CreateInstance(type); // Valores por defecto
            return null; // Para tipos de referencia
        }
    }

    // Clase para codificación UTF-8
    public class StringWriterUtf8 : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
