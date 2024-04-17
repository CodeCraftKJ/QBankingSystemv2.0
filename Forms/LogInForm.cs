using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void logInButtonClicked(object sender, EventArgs e)
        {

        }

        private void openRegisterForm(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
            registerForm.FormClosed += (s, args) => this.Close();
        }


    }
}
