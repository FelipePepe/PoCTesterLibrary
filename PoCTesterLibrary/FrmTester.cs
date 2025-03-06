using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LibraryLoader;
using LoggerManager;

namespace PoCTesterLibrary
{
    public partial class FrmTester : Form
    {
        private static readonly ILogger _logger = LoggerFactory.CreateLogger();
        private OpenFileDialog openFileDialogDLL = new OpenFileDialog();

        public FrmTester()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga la DLL y muestra los métodos en el ListBox del panel izquierdo.
        /// </summary>
        private void btnLoadDLL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPathDLL.Text))
            {
                openFileDialogDLL.InitialDirectory = Path.GetDirectoryName(txtPathDLL.Text);
            }
            openFileDialogDLL.Filter = "Archivos DLL|*.dll";
            openFileDialogDLL.Title = "Selecciona una DLL";

            if (openFileDialogDLL.ShowDialog() == DialogResult.OK)
            {
                txtPathDLL.Text = openFileDialogDLL.FileName;

                try
                {
                    LibraryLoader.Loader loader = new LibraryLoader.Loader();
                    List<MethodInfo> methods = loader.GetMethods(txtPathDLL.Text);
                    lstMethods.Items.Clear();
                    methods.ForEach(method => lstMethods.Items.Add(method));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la DLL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Al hacer doble clic en un método, se lanza el formulario para definir los parámetros y se invoca el método.
        /// </summary>
        private void lstMethods_DoubleClick(object sender, EventArgs e)
        {
            LaunchSelectedMethod();
        }

        private void LaunchSelectedMethod()
        {
            if (lstMethods.SelectedItems.Count > 0)
            {
                MethodInfo method = (MethodInfo)lstMethods.SelectedItems[0];
                object[] parametros = null;

                if (method.GetParameters().Length > 0)
                {
                    using (FormParametros frmParametros = new FormParametros(method.GetParameters()))
                    {
                        if (frmParametros.ShowDialog() == DialogResult.OK)
                        {
                            parametros = frmParametros.Argumentos;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                try
                {
                    Loader loader = new Loader();
                    object result = loader.LaunchMethod(method, parametros);

                    if (result != null)
                    {
                        string mensaje = loader.CallToString(result);
                        MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Método invocado con éxito sin retorno.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al invocar el método: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Carga el archivo XML y muestra su contenido en el TextBox de la pestaña "Entrada XML".
        /// </summary>
        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Archivos XML|*.xml",
                Title = "Selecciona un archivo XML"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string xmlContent = File.ReadAllText(ofd.FileName);
                txtXML.Text = xmlContent;
                // Aquí se puede llamar a ConvertirXMLaDTO para convertir el XML a DTO
                // Ejemplo:
                //object dto = ConvertirXMLaDTO(xmlContent, typeof(MiDTO));
                // txtSalida.Text = "DTO creado desde XML:\n" + dto.ToString();
            }
        }

        // Ejemplo genérico para convertir XML a DTO mediante XmlSerializer.
        private T ConvertirXMLaDTO<T>(string xmlContent)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xmlContent))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir XML a DTO: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        private Type GetSelectedDtoType()
        {
            // Aquí, asumo que tienes un ComboBox con nombres de clases o algo similar
            var selectedItem = lstMethods.SelectedItem as MethodInfo; // O como sea que almacenes el nombre del tipo

            if (selectedItem == null)
            {
                return null; // Si no hay selección, devolver null
            }

            ParameterInfo[] parameters = selectedItem.GetParameters();
            if (parameters != null && parameters.Length > 0)
            {
                // Aquí puedes buscar el tipo por su nombre
                return parameters[0].ParameterType;
            }
            else
            {
                return null;
            }
        }


        private void lstMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el tipo dinámico
            Type dtoType = GetSelectedDtoType();
            if (dtoType == null)
            {
                MessageBox.Show("Tipo de DTO no encontrado.");
                return;
            }

            // Obtener el método genérico
            MethodInfo method = typeof(LibraryLoader.XmlHelper).GetMethod("GenerateXmlTemplate", BindingFlags.Static | BindingFlags.Public);

            // Asegúrate de que el método no sea null
            if (method == null)
            {
                MessageBox.Show("No se encontró el método GenerateXmlTemplate.");
                return;
            }

            // Crear el método genérico con el tipo dinámico
            MethodInfo genericMethod = method.MakeGenericMethod(dtoType);

            // Invocar el método genérico y obtener el resultado
            string result = (string)genericMethod.Invoke(null, null);

            // Mostrar o trabajar con el resultado
            txtXML.Text = result;

        }

    }
}
