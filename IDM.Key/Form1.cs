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
        // Crear una instancia de la codificación deseada (por ejemplo, UTF-8)
        Encoding encoding = Encoding.UTF8;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnFreeze_Click(object sender, EventArgs e)
        {
            richSalida.Clear();
            // Leer el contenido del archivo de recursos
            string scriptTemplate = Properties.Resources.com;


            // Crear un archivo CMD temporal en la carpeta temporal del sistema
            string tempFolder = Path.GetTempPath();
            string cmdFile = Path.Combine(tempFolder, "mi_script.cmd");
            File.WriteAllText(cmdFile, scriptTemplate);

            // Configurar el proceso para ejecutar el archivo CMD
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"/c \"{cmdFile}\" /frz" // /c ejecuta el comando y sale
            };

            // Iniciar el proceso de forma asincrónica
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.OutputDataReceived += (s, args) =>
                {
                    // Este evento se dispara cuando se recibe una nueva línea de salida
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        // Actualizar el RichTextBox en el hilo de la interfaz de usuario
                        richSalida.BeginInvoke(new Action(() =>
                        {
                            // Convertir el texto a bytes utilizando la codificación
                            byte[] bytes = encoding.GetBytes(args.Data);

                            // Convertir los bytes de nuevo a una cadena utilizando la misma codificación
                            string textoDecodificado = encoding.GetString(bytes);

                            richSalida.AppendText(textoDecodificado + Environment.NewLine);

                            // Hacer un scroll automático hacia abajo
                            richSalida.SelectionStart = richSalida.Text.Length;
                            richSalida.ScrollToCaret();
                        }));
                    }
                };
                btnFreeze.Enabled = false;
                btnReset.Enabled = false;

                process.Start();
                process.BeginOutputReadLine();

                // Esperar a que termine el proceso de forma asincrónica
                await Task.Run(() =>
                {
                    process.WaitForExit();
                    btnFreeze.Enabled = true;
                    btnReset.Enabled = true;
                    btnActivate.Enabled = true;
                });
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new about().ShowDialog();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            richSalida.Clear();

            // Leer el contenido del archivo de recursos
            string scriptTemplate = Properties.Resources.com;


            // Crear un archivo CMD temporal en la carpeta temporal del sistema
            string tempFolder = Path.GetTempPath();
            string cmdFile = Path.Combine(tempFolder, "mi_script.cmd");
            File.WriteAllText(cmdFile, scriptTemplate);

            // Configurar el proceso para ejecutar el archivo CMD
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"/c \"{cmdFile}\" /res" // /c ejecuta el comando y sale
            };

            // Iniciar el proceso de forma asincrónica
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.OutputDataReceived += (s, args) =>
                {
                    // Este evento se dispara cuando se recibe una nueva línea de salida
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        // Actualizar el RichTextBox en el hilo de la interfaz de usuario
                        richSalida.BeginInvoke(new Action(() =>
                        {
                            // Convertir el texto a bytes utilizando la codificación
                            byte[] bytes = encoding.GetBytes(args.Data);

                            // Convertir los bytes de nuevo a una cadena utilizando la misma codificación
                            string textoDecodificado = encoding.GetString(bytes);

                            richSalida.AppendText(textoDecodificado + Environment.NewLine);

                            // Hacer un scroll automático hacia abajo
                            richSalida.SelectionStart = richSalida.Text.Length;
                            richSalida.ScrollToCaret();
                        }));
                    }
                };
                btnReset.Enabled = false;

                process.Start();
                process.BeginOutputReadLine();

                // Esperar a que termine el proceso de forma asincrónica
                await Task.Run(() =>
                {
                    process.WaitForExit();
                    btnReset.Enabled = true;
                    btnFreeze.Enabled = true;
                });
            }
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            richSalida.Clear();

            // Leer el contenido del archivo de recursos
            string scriptTemplate = Properties.Resources.com;


            // Crear un archivo CMD temporal en la carpeta temporal del sistema
            string tempFolder = Path.GetTempPath();
            string cmdFile = Path.Combine(tempFolder, "mi_script.cmd");
            File.WriteAllText(cmdFile, scriptTemplate);

            // Configurar el proceso para ejecutar el archivo CMD
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"/c \"{cmdFile}\" /act" // /c ejecuta el comando y sale
            };

            // Iniciar el proceso de forma asincrónica
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.OutputDataReceived += (s, args) =>
                {
                    // Este evento se dispara cuando se recibe una nueva línea de salida
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        // Actualizar el RichTextBox en el hilo de la interfaz de usuario
                        richSalida.BeginInvoke(new Action(() =>
                        {
                            // Convertir el texto a bytes utilizando la codificación
                            byte[] bytes = encoding.GetBytes(args.Data);

                            // Convertir los bytes de nuevo a una cadena utilizando la misma codificación
                            string textoDecodificado = encoding.GetString(bytes);

                            richSalida.AppendText(textoDecodificado + Environment.NewLine);

                            // Hacer un scroll automático hacia abajo
                            richSalida.SelectionStart = richSalida.Text.Length;
                            richSalida.ScrollToCaret();
                        }));
                    }
                };
                btnFreeze.Enabled = false;
                btnReset.Enabled = false;
                btnActivate.Enabled = false;

                process.Start();
                process.BeginOutputReadLine();

                // Esperar a que termine el proceso de forma asincrónica
                await Task.Run(() =>
                {
                    process.WaitForExit();
                    btnFreeze.Enabled = true;
                    btnReset.Enabled = true;
                    btnActivate.Enabled = true;
                });
            }
        }

        private void btnReadme_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Take into account when registering IDM with this program"
                + Environment.NewLine 
                + Environment.NewLine
                + "1.- Sometimes activation may fail."
                + Environment.NewLine
                + "2.- Sometimes IDM can be deactivated after a few days after activation, so it must be activated again."
                + Environment.NewLine
                + "3- I do not promote the use of pirated software, remember that the developer's time also has a cost."
                + Environment.NewLine
                + Environment.NewLine
                + "How to use correctly?"
                + Environment.NewLine
                + Environment.NewLine
                + "1.- Execute the 'Reset trial / activation' option"
                + Environment.NewLine
                + "2.- Run the 'Freeze trial' option"
                + Environment.NewLine
                + "3.- Run the 'Activate' option"
                + Environment.NewLine
                + Environment.NewLine
                + "Important: If the IDM activation failure dialog appears, repeat this process again."
                ,
                "IDM.Key"
                ,
                MessageBoxButtons.OK
                ,
                MessageBoxIcon.Information);
        }
    }
}
