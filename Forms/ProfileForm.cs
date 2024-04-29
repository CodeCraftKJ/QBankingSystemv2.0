﻿using QBankingSystemv2._0.Classes.DatabaseManager;
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
            
        }

        private void TransfersBtn_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            CreateAccountForm accountForm = new CreateAccountForm();
            accountForm.FormClosed += (s, args) => RefreshAccountList();
            accountForm.Show();
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        private void BankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = BankAccounts.SelectedItem as string;
            if (selectedItem != null)
            {
                string[] parts = selectedItem.Split(' ');
                if (parts.Length == 2)
                {
                    string accountName = parts[0];
                    string accountID = parts[1];
                    IAccount selectedAccount = GetUserAccountByNameAndID(accountName, accountID);
                    if (selectedAccount != null)
                    {
                        AccountForm accountForm = new AccountForm(selectedAccount);
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
                BankAccounts.Items.Add(account.AccountName+" "+account.AccountID);
            }
        }

    }
}
