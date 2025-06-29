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
    public partial class setupNames : Form
    {
        public setupNames()
        {
            InitializeComponent();
            RefreshUI();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show(GetResourceString("errorEmptyFields"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void RefreshUI()
        {
            btnCancel.Text = GetResourceString("cancelBtn");
            lblFname.Text = GetResourceString("fname");
            lblLname.Text = GetResourceString("lname");
            Text = GetResourceString("titleCustom");
        }

        private string GetResourceString(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

    }
}
