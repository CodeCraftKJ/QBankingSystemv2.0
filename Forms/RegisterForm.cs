using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Models.User.UserValidation;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void UsernameTextChanged(object sender, EventArgs e)
        {
            new UsernameValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void FirstnameTextChanged(object sender, EventArgs e)
        {
            new FirstnameValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void LastnameTextChanged(object sender, EventArgs e)
        {
            new LastnameValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void PhoneTextChanged(object sender, EventArgs e)
        {
            new PhoneValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void PeselTextChanged(object sender, EventArgs e)
        {
            new PeselValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void PinTextChanged(object sender, EventArgs e)
        {
            new PinValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void EmailTextChanged(object sender, EventArgs e)
        {
            new EmailValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void DateOfBirthTextChanged(object sender, EventArgs e)
        {
            new DateOfBirthValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void AdressTextChanged(object sender, EventArgs e)
        {
            new AddressValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void MatrialStatusTextChanged(object sender, EventArgs e)
        {
            new MaterialStatusValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void PasswordTextChanged(object sender, EventArgs e)
        {
            new PasswordValidator().ValidateAndShowMessage((TextBox)sender);
        }

        private void RepeatePasswordTextChanged(object sender, EventArgs e)
        {
            new RepeatPasswordValidator().ValidateAndShowMessage(textBoxPassword, (TextBox)sender);
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            if (!RegistrationManager.InitializeAndRun(textPIN, textPesel, textPhone, textLastName, textFirstName, textUserName,
                     textRepeatPassword, textBoxPassword, textMatrialStatus, textAddress,
                     textBirth, textEmail)) return;
            WelcomeForm welcomeForm = new();
            welcomeForm.Activated += (sender, e) => this.Hide();
            welcomeForm.ShowDialog();
        }

    }
}
