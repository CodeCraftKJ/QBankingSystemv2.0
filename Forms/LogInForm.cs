using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Models.User.User;
using QBankingSystemv2._0.Models.User.UserValidation;
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

        private void openRegisterAccount(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
            registerForm.FormClosed += (s, args) => this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            new PasswordValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            new UsernameValidator().ValidateAndShowMessage((TextBox)sender);
        }
        private void logInButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = RegistrationManager.HashPassword(txtPassword.Text);

            if (LoginManager.ValidateLogin(username, password))
            {
                UserDataManager.SetCurrentUserData(username);
                ProfileAccountForm profileAccountForm = new ProfileAccountForm();
                this.Hide();
                profileAccountForm.Show();
                profileAccountForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }



    }

}
