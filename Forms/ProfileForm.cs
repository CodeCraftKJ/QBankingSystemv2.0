using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class ProfileAccountForm : Form
    {

        public ProfileAccountForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            textUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            textBoxUsername.Text = CurrentUser.Username;
            textMatrialStatus.Text = CurrentUser.MaterialStatus;
            textAddress.Text = CurrentUser.Address;
            textBirth.Text = CurrentUser.BirthDate;
            textEmail.Text = CurrentUser.Email;
            textPesel.Text = CurrentUser.Pesel;
            textPhone.Text = CurrentUser.Phone;
        }

        private void LoansBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void TransfersBtn_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            CreateAccountForm accountForm = new CreateAccountForm();
            accountForm.Show();
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }
    }
}
