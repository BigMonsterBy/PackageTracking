using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageTracking.App
{
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void ClearInputButton_Click(object sender, EventArgs e)
        {
            loginTxtBox.Text = "";
            passTxtBox.Text = "";
        }

        private void ShowErrorMessageBox()
        {
            MessageBox.Show("Неверный логин или пароль.", "Ошибка!", MessageBoxButtons.OK);
        }
    }
}
