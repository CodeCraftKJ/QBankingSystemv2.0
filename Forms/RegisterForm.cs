using System;
using System.Windows.Forms;
using QBankingSystemv2._0.ValidationClasses;

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
            TextBox textBox = (TextBox)sender;
            new UsernameValidator().ValidateAndShowMessage(textBox);
        }

        private void FirstnameTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new FirstnameValidator().ValidateAndShowMessage(textBox);
        }

        private void LastnameTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new LastnameValidator().ValidateAndShowMessage(textBox);
        }

        private void PhoneTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PhoneValidator().ValidateAndShowMessage(textBox);
        }

        private void PeselTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PeselValidator().ValidateAndShowMessage(textBox);
        }

        private void PinTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PinValidator().ValidateAndShowMessage(textBox);
        }

        private void EmailTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new EmailValidator().ValidateAndShowMessage(textBox);
        }

        private void DateOfBirthTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new DateOfBirthValidator().ValidateAndShowMessage(textBox);
        }

        private void AdressTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new AddressValidator().ValidateAndShowMessage(textBox);
        }

        private void MatrialStatusTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new MaterialStatusValidator().ValidateAndShowMessage(textBox);
        }

        private void PasswordTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PasswordValidator().ValidateAndShowMessage(textBox);
        }

        private void RepeatePasswordTextChanged(object sender, EventArgs e)
        {
            TextBox repeatPasswordTextBox = (TextBox)sender;
            new RepeatPasswordValidator().ValidateAndShowMessage(textBoxPassword, repeatPasswordTextBox);
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {

        }
    }
}
