using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class ProfileAccountForm : Form
    {

        public ProfileAccountForm()
        {
            InitializeComponent();
            textUserName.Text = CurrentUser.FirstName + " "+ CurrentUser.LastName;
            textBoxUsername.Text = CurrentUser.Username;
            textMatrialStatus.Text = CurrentUser.MaterialStatus;
            textAddress.Text = CurrentUser.Address;
            textBirth.Text = CurrentUser.BirthDate;
            textEmail.Text = CurrentUser.Email;
            textPesel.Text = CurrentUser.Pesel;
            textPhone.Text = CurrentUser.Phone;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            
        }

        private void UserImage_Click(object sender, EventArgs e)
        {
            
        }

        private void logOutClick(object sender, EventArgs e)
        {

        }

        private void BankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
