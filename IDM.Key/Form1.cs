using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
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
                });
            }
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            btnActivate.Enabled = false;
            richSalida.Clear();

            try
            {
                string tempDir = Path.Combine(Path.GetTempPath(), "com_" + Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(tempDir);

                byte[] zipBytes = Properties.Resources.cmd;
                await Task.Run(() =>
                {
                    using (var ms = new MemoryStream(zipBytes))
                    using (var zip = new ZipArchive(ms))
                    {
                        zip.ExtractToDirectory(tempDir);
                    }
                });

                string fName = string.Empty;
                string lName = string.Empty;

                using (var setupForm = new setupNames())
                {
                    if (setupForm.ShowDialog(this) == DialogResult.OK)
                    {
                        fName = setupForm.txtFname.Text.Trim();
                        lName = setupForm.txtLname.Text.Trim();
                    }
                    else
                        return;
                }

                string scriptPath = Path.Combine(tempDir, "com.cmd");
                if (!File.Exists(scriptPath))
                {
                    MessageBox.Show("No se encontró el script dentro del ZIP.");
                    return;
                }

                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WorkingDirectory = tempDir,
                    Arguments = $"/C \"\"{scriptPath}\"\"",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var proc = new Process { StartInfo = psi, EnableRaisingEvents = true };

                void AppendLine(string line)
                {
                    if (!IsDisposed)
                        BeginInvoke((Action)(() =>
                            richSalida.AppendText(line + Environment.NewLine)));
                }

                proc.OutputDataReceived += (s, ev) => { if (ev.Data != null) AppendLine(ev.Data); };
                proc.ErrorDataReceived += (s, ev) => { if (ev.Data != null) AppendLine("[ERR] " + ev.Data); };

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                await proc.StandardInput.WriteLineAsync(fName);
                await proc.StandardInput.WriteLineAsync(lName);
                proc.StandardInput.Close(); 

                await Task.Run(() => proc.WaitForExit());

                AppendLine("--- LISTO - DONE ---");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error:\n{ex.Message}");
            }
            finally
            {
                btnActivate.Enabled = true;
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
            //btnFreeze.Text = GetResourceString("freeze");
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

        private void richSalida_TextChanged(object sender, EventArgs e)
        {
            if (richSalida.Text.Length > 0)
            {
                string replace = "[ERR] ERROR: No es compatible la redirecciÃ³n de entradas, saliendo inmediatamente";
                string replace2 = "[32m ";
                string replace3 = "[0m";
                string replace4 = "del proceso.";
                if (richSalida.Text.Contains(replace))
                {
                    richSalida.Text = richSalida.Text.Replace(replace, string.Empty);
                    richSalida.Text = richSalida.Text.Replace(replace2, string.Empty);
                    richSalida.Text = richSalida.Text.Replace(replace3, string.Empty);
                    richSalida.Text = richSalida.Text.Replace(replace4, string.Empty);
                }
            }
        }

    }
}
