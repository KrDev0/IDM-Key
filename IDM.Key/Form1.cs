using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDM.Key
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Set First Name","IDM.Rey", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Set Email", "IDM.Rey", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("The registration process will start, a cmd window will open, do [not close it once the registration is completed] it will close automatically"
                , "No Close CMD Windows", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string tempFolderPath = Path.GetTempPath();
            string cmdFilePath = Path.Combine(tempFolderPath, "cmd_idman.cmd");

            string cmdTemplate = Properties.Resources.com;

            // Reemplazar {0}, {1}, {2} en el contenido del archivo CMD con los valores de los TextBox
            cmdTemplate = cmdTemplate.Replace("{0}", textBox1.Text)
                                     .Replace("{1}", textBox2.Text)
                                     .Replace("{2}", textBox3.Text);

            // Guardar el contenido modificado en el archivo CMD
            File.WriteAllText(cmdFilePath, cmdTemplate);

            // Ejecutar el archivo CMD sin mostrar una ventana de línea de comandos
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C \"{cmdFilePath}\" /act",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            btnStart.Enabled = false;
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();
            }
            btnStart.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new about().ShowDialog();
        }
    }
}
