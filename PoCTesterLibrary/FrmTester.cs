using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using LibraryLoader;

namespace PoCTesterLibrary
{
    public partial class FrmTester : Form
    {
        public FrmTester()
        {
            InitializeComponent();
        }

        private void btnLoadLibrary_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPathLibrary.Text))
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(txtPathLibrary.Text);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathLibrary.Text = openFileDialog1.FileName;
                LibraryLoader.Loader loader = new LibraryLoader.Loader();
                List<MethodInfo> lstMethodsLoader = null;
                try
                {
                    // Load the library
                    lstMethodsLoader = loader.GetMethods(txtPathLibrary.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show the methods
                lstMethodsLoader.ForEach(delegate (MethodInfo method)
                {
                    lstMethods.Items.Add(method);
                });

            }

        }

        private void lstMethods_DoubleClick(object sender, EventArgs e)
        {
            LaunchSelectedMethod();
        }

        private void LaunchSelectedMethod()
        {
            if (lstMethods.SelectedItems.Count > 0)
            {
                MethodInfo method = (MethodInfo)lstMethods.SelectedItems[0];
                FormParametros frmParametros = null;

                if (method.GetParameters().Length > 0)
                {
                    // Show the parameters form
                    frmParametros = new FormParametros(method.GetParameters());
                }
                if (frmParametros != null && frmParametros.ShowDialog() == DialogResult.OK)
                {
                    Loader loader = new Loader();
                    try
                    {
                        object[] parametros = frmParametros.Argumentos;
                        object result = loader.LaunchMethod(method, parametros, @"c:\temp\prueba.xml");
                        string mensaje = result != null ? loader.CallToString(result) : "Método invocado con éxito sin retorno.";
                        MessageBox.Show(mensaje, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al invocar el método: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (frmParametros == null)
                {
                    Loader loader = new Loader();
                    try
                    {
                        object result = loader.LaunchMethod(method, null);
                        string mensaje = result != null ? loader.CallToString(result) : "Método invocado con éxito sin retorno.";
                        MessageBox.Show(mensaje, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al invocar el método: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
