using QBankingSystemv2._0.Models.Account.Account;
using QBankingSystemv2._0.Models.Account.AccountQuery;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class ProfileAccountForm : Form
    {
        public List<IAccount> userAccounts;
        public ProfileAccountForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            textUserName.Text = User.FirstName + " " + User.LastName;
            textBoxUsername.Text = User.Username;
            textMatrialStatus.Text = User.MaterialStatus;
            textAddress.Text = User.Address;
            textBirth.Text = User.BirthDate;
            textEmail.Text = User.Email;
            textPesel.Text = User.Pesel;
            textPhone.Text = User.Phone;

            RefreshAccountList();
        }


        private void LoansBtn_Click(object sender, EventArgs e)
        {
            LoanAccount loanForm = new();
            loanForm.FormClosed += (s, args) => RefreshAccountList();
            loanForm.Show();
        }

        private void TransfersBtn_Click(object sender, EventArgs e)
        {
            CreateTransferForm transferForm = new();
            transferForm.FormClosed += (s, args) => RefreshAccountList();
            transferForm.Show();
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            CreateAccountForm accountForm = new();
            accountForm.FormClosed += (s, args) => RefreshAccountList();
            accountForm.Show();
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            User.Clear();
            WelcomeForm welcomeForm = new();
            welcomeForm.Show();
            this.Close();
        }

        private void BankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BankAccounts.SelectedItem is string selectedItem)
            {
                string[] parts = selectedItem.Split("-   -");
                if (parts.Length == 2)
                {
                    string accountName = parts[0];
                    string accountID = parts[1];
                    IAccount selectedAccount = GetUserAccountByNameAndID(accountName, accountID);
                    if (selectedAccount != null)
                    {
                        Account accountForm = new(selectedAccount);
                        accountForm.Show();
                    }
                }
            }
        }

        private IAccount GetUserAccountByNameAndID(string accountName, string accountID)
        {
            foreach (IAccount account in userAccounts)
            {
                if (account.AccountName == accountName && account.AccountID == accountID)
                {
                    return account;
                }
            }
            return null;
        }


        public void RefreshAccountList()
        {
            userAccounts = AccountManager.GetUserAccounts(User.UserID);
            BankAccounts.Items.Clear();
            foreach (IAccount account in userAccounts)
            {
                BankAccounts.Items.Add(account.AccountName + "-   -" + account.AccountID);
            }
        }

    }
}
