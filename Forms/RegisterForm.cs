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

        private void usernameTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new UsernameValidator().ValidateAndShowMessage(textBox);
        }

        private void firstnameTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new FirstnameValidator().ValidateAndShowMessage(textBox);
        }

        private void lastnameTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new LastnameValidator().ValidateAndShowMessage(textBox);
        }

        private void phoneTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PhoneValidator().ValidateAndShowMessage(textBox);
        }

        private void peselTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PeselValidator().ValidateAndShowMessage(textBox);
        }

        private void pinTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new PinValidator().ValidateAndShowMessage(textBox);
        }

        private void emailTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            new EmailValidator().ValidateAndShowMessage(textBox);
        }

        private void dateOfBirthTextChanged(object sender, EventArgs e)
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

    }
}
