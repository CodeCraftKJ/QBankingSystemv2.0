using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Interfaces;
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
            textUserName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            textBoxUsername.Text = CurrentUser.Username;
            textMatrialStatus.Text = CurrentUser.MaterialStatus;
            textAddress.Text = CurrentUser.Address;
            textBirth.Text = CurrentUser.BirthDate;
            textEmail.Text = CurrentUser.Email;
            textPesel.Text = CurrentUser.Pesel;
            textPhone.Text = CurrentUser.Phone;

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
            CurrentUser.Clear();
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
            userAccounts = AccountManager.GetUserAccounts(CurrentUser.UserID);
            BankAccounts.Items.Clear();
            foreach (IAccount account in userAccounts)
            {
                BankAccounts.Items.Add(account.AccountName+"-   -"+account.AccountID);
            }
        }

    }
}
