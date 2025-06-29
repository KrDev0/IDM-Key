using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDM.Key
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();

            setLang(Properties.Settings.Default.lang);
        }

        private void setLang(string lang)
        {
            if (lang == "en")
            {
                Text = "About";
                label2.Text = "Version: 1.2 H: 1.3.146";
                label3.Text = "Date: 29/06/2025";
                label4.Text = "Dev by: KrDev - Christian Romero";
                label6.Text = "Icon by: Internet Download Manager";
                label7.Text = "The icon of this app is property of Internet Download Manager (Tonec FZE).";
                label8.Text = "Original registration script in ";
                label5.Text = "This app is free, do not pay to use it";
            }
            else
            {
                Text = "Acerca de";
                label2.Text = "Versión: 1.3 H: 1.3.146";
                label3.Text = "Fecha: 29/06/2025";
                label4.Text = "Desarrollado por: KrDev - Christian Romero";
                label6.Text = "Icono por: Internet Download Manager";
                label7.Text = "El icono de esta aplicación es propiedad de Internet Download Manager (Tonec FZE).";
                label8.Text = "Script de registro original en ";
                label5.Text = "Esta aplicación es gratuita, no pagues por usarla";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Coporton/IDM-Activation-Script");
        }
    }
}
