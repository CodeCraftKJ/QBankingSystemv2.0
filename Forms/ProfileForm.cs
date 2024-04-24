using System;
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
            textLastName.Text = CurrentUser.LastName;
            textFirstName.Text = CurrentUser.FirstName;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            
        }

        private void UserImage_Click(object sender, EventArgs e)
        {
            
        }
    }
}
