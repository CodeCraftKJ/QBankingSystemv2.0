using System.Windows.Forms;

namespace QBankingSystemv2._0
{
    public static partial class RegistrationManager
    {
        private static TextBox _textPIN;
        private static TextBox _textPesel;
        private static TextBox _textPhone;
        private static TextBox _textLastName;
        private static TextBox _textFirstName;
        private static TextBox _textUserName;
        private static TextBox _textRepeatPassword;
        private static TextBox _textBoxPassword;
        private static TextBox _textMatrialStatus;
        private static TextBox _textAddress;
        private static TextBox _textBirth;
        private static TextBox _textEmail;


        public static void Initialize(
            TextBox textPIN, TextBox textPesel, TextBox textPhone,
            TextBox textLastName, TextBox textFirstName, TextBox textUserName,
            TextBox textRepeatPassword, TextBox textBoxPassword,
            TextBox textMatrialStatus, TextBox textAddress,
            TextBox textBirth, TextBox textEmail)
        {
            _textPIN = textPIN;
            _textPesel = textPesel;
            _textPhone = textPhone;
            _textLastName = textLastName;
            _textFirstName = textFirstName;
            _textUserName = textUserName;
            _textRepeatPassword = textRepeatPassword;
            _textBoxPassword = textBoxPassword;
            _textMatrialStatus = textMatrialStatus;
            _textAddress = textAddress;
            _textBirth = textBirth;
            _textEmail = textEmail;

            if (!IsValid()) return;
            string errorMessage = RegisterUserInDatabase();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
