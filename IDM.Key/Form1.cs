using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
            if(Properties.Settings.Default.lang =="en")
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
            else
            {
                MessageBox.Show("Tenga en cuenta al registrar IDM con este programa"
                                + Environment.NewLine
                                + Environment.NewLine
                                + "1.- A veces la activación puede fallar."
                                + Environment.NewLine
                                + "2.- A veces IDM puede desactivarse después de unos días después de la activación, por lo que debe activarse nuevamente."
                                + Environment.NewLine
                                + "3.- No promuevo el uso de software pirata, recuerde que el tiempo del desarrollador también tiene un costo."
                                + Environment.NewLine
                                + Environment.NewLine
                                + "¿Cómo usar correctamente?"
                                + Environment.NewLine
                                + Environment.NewLine
                                + "1.- Ejecute la opción 'Reiniciar prueba / activación'"
                                + Environment.NewLine
                                + "2.- Ejecute la opción 'Congelar prueba'"
                                + Environment.NewLine
                                + "3.- Ejecute la opción 'Activar'"
                                + Environment.NewLine
                                + Environment.NewLine
                                + "Importante: Si aparece el cuadro de diálogo de falla de activación de IDM, repita este proceso nuevamente."
                                ,
                                "IDM.Key"
                                ,
                                MessageBoxButtons.OK
                                ,
                                MessageBoxIcon.Information);
            }
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            // Muestra el menú en la posición del botón
            Point pos = btnLanguage.PointToScreen(new Point(0, btnLanguage.Height));
            contextLang.Show(pos);
        }

        private void SetLanguage(string languageCode)
        {
            CultureInfo cultureInfo = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        private void RefreshUI()
        {
            btnCancel.Text = GetResourceString("cancel");
            btnActivate.Text = GetResourceString("activate");
            btnFreeze.Text = GetResourceString("freeze");
            btnReset.Text = GetResourceString("reset");
            label1.Text = GetResourceString("optionMenu");
            btnReadme.Text = GetResourceString("readme");
        }
        private string GetResourceString(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("en");

            Properties.Settings.Default.lang = "en";
            Properties.Settings.Default.Save();

            RefreshUI();
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("es");

            Properties.Settings.Default.lang = "es";
            Properties.Settings.Default.Save();

            RefreshUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetLanguage(Properties.Settings.Default.lang);
            RefreshUI();

            Text = "IDM.Key " + Application.ProductVersion.ToString();
        }
    }
}
