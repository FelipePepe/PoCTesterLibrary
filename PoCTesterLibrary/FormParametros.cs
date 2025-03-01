using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PoCTesterLibrary
{
    public partial class FormParametros : Form
    {
        public object[] Argumentos { get; private set; }
        private ParameterInfo[] parametros;

        public FormParametros(ParameterInfo[] parametros)
        {
            InitializeComponent();
            this.parametros = parametros;
            Argumentos = new object[parametros.Length];
            GenerarControles();
        }

        private void GenerarControles()
        {
            int y = 20;
            for (int i = 0; i < parametros.Length; i++)
            {
                Label lbl = new Label()
                {
                    Text = parametros[i].Name + " (" + parametros[i].ParameterType.Name + "):",
                    Left = 10,
                    Top = y,
                    Width = 200
                };
                this.Controls.Add(lbl);

                Control inputControl = CrearControlEntrada(parametros[i].ParameterType);
                if (inputControl != null)
                {
                    inputControl.Left = 220;
                    inputControl.Top = y;
                    inputControl.Width = 200;
                    inputControl.Tag = parametros[i];
                    this.Controls.Add(inputControl);
                    y += 30;
                }
            }

            Button btnAceptar = new Button()
            {
                Text = "Aceptar",
                Left = 220,
                Top = y + 10,
                Width = 100
            };
            btnAceptar.Click += BtnAceptar_Click;
            this.Controls.Add(btnAceptar);

            this.Height = y + 80;
        }

        private Control CrearControlEntrada(Type tipo)
        {
            if (tipo == typeof(string))
            {
                return new TextBox();
            }
            else if (tipo.IsPrimitive || tipo == typeof(decimal))  // Soporte para números
            {
                TextBox numericTextBox = new TextBox();
                numericTextBox.KeyPress += (sender, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
                    {
                        e.Handled = true;
                    }
                };
                return numericTextBox;
            }
            else if (tipo.IsEnum)
            {
                ComboBox combo = new ComboBox();
                combo.DataSource = Enum.GetValues(tipo);
                return combo;
            }
            else if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(List<>))
            {
                Button btnSubForm = new Button()
                {
                    Text = "Definir " + tipo.Name
                };
                btnSubForm.Click += (sender, e) =>
                {
                    Type itemType = tipo.GetGenericArguments()[0]; // Tipo de elemento de la lista

                    // Crear un ParameterInfo adecuado para este tipo de elemento
                    PropertyInfo prop = new PropertyInfoWrapper(itemType); // Debemos tener un PropertyInfo, no solo el tipo

                    FormParametros subForm = new FormParametros(new[] { new ParameterInfoWrapper(prop) });

                    if (subForm.ShowDialog() == DialogResult.OK)
                    {
                        // Crear instancia de List<T>
                        var listType = typeof(List<>).MakeGenericType(itemType);
                        var listInstance = Activator.CreateInstance(listType);

                        for (int i = 0; i < subForm.Argumentos.Length; i++)
                        {
                            listType.GetMethod("Add").Invoke(listInstance, new[] { subForm.Argumentos[i] });
                        }

                        btnSubForm.Tag = listInstance;
                    }
                };
                return btnSubForm;
            }
            else if (tipo.IsClass)
            {
                Button btnSubForm = new Button()
                {
                    Text = "Definir " + tipo.Name
                };
                btnSubForm.Click += (sender, e) =>
                {
                    PropertyInfo[] propiedades = tipo.GetProperties();
                    FormParametros subForm = new FormParametros(propiedades.Select(p => new ParameterInfoWrapper(p)).ToArray());
                    if (subForm.ShowDialog() == DialogResult.OK)
                    {
                        object instancia = Activator.CreateInstance(tipo);
                        for (int i = 0; i < propiedades.Length; i++)
                        {
                            if (propiedades[i].CanWrite)
                            {
                                propiedades[i].SetValue(instancia, subForm.Argumentos[i]);
                            }
                            else
                            {
                                Console.WriteLine("La propiedad " + propiedades[i].Name + " no es editable.");
                            }
                        }

                        btnSubForm.Tag = instancia;
                    }
                };
                return btnSubForm;
            }
            return null;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Control control = this.Controls[i];

                    if (index >= Argumentos.Length) break; // Evita el desbordamiento

                    if (control is TextBox txt && txt.Tag is ParameterInfo param)
                    {
                        if (string.IsNullOrWhiteSpace(txt.Text))
                        {
                            Argumentos[index] = null; // O un valor por defecto según el tipo
                        }
                        else
                        {
                            Argumentos[index] = Convert.ChangeType(txt.Text, param.ParameterType);
                        }
                        index++;
                    }
                    else if (control is ComboBox combo && combo.Tag is ParameterInfo paramEnum)
                    {
                        Argumentos[index] = Enum.Parse(paramEnum.ParameterType, combo.SelectedItem.ToString());
                        index++;
                    }
                    else if (control is Button btn && btn.Tag != null)
                    {
                        Argumentos[index] = btn.Tag;
                        index++;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conversión de parámetros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class ParameterInfoWrapper : ParameterInfo
    {
        private PropertyInfo propiedad;

        public ParameterInfoWrapper(PropertyInfo propiedad)
        {
            this.propiedad = propiedad;
        }

        public override string Name => propiedad.Name;
        public override Type ParameterType => propiedad.PropertyType;
    }
}
