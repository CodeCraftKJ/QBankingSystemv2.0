using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Classes.Transactions;
using QBankingSystemv2._0.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class Account : Form
    {
        private IAccount _account;

        public Account(IAccount account)
        {
            InitializeComponent();
            _account = account;
            AccountBox.Text = account.AccountID;
            AccountName.Text = account.AccountName;
            LoadTransfers(); 
        }

        private void LoadTransfers()
        {
            TransfersList.Items.Clear();
            List<(Transaction, bool)> accountTransfers = TransactionManager.GetAccountTransfers(_account.AccountID);
            if (accountTransfers != null && accountTransfers.Count > 0)
            {
                decimal totalBalance = 0;

                foreach (var transferTuple in accountTransfers)
                {
                    Transaction transaction = transferTuple.Item1;
                    bool isOutgoing = transferTuple.Item2;
                    decimal amount = isOutgoing ? -transaction.Amount : transaction.Amount;
                    totalBalance += amount;

                    string transferType = isOutgoing ? "-" : "+";
                    string transferInfo = $"{transferType} Amount: {transaction.Amount}, Date: {transaction.TransactionDate}";
                    TransfersList.Items.Add(transferInfo);
                }

                LastBalance.Text = totalBalance.ToString();
                Balance.Text = _account.Balance.ToString();
            }
            else
            {
                TransfersList.Items.Add("No transfers available.");
                LastBalance.Text = "0";
                Balance.Text = _account.Balance.ToString();
            }
        }



        private void TransfersBtn_Click(object sender, System.EventArgs e)
        {

        }

        private void TransfersFromFileBtn_Click(object sender, System.EventArgs e)
        {

        }

        private void LoansBtn_Click(object sender, System.EventArgs e)
        {

        }

        private void HistoryToFile_Click(object sender, System.EventArgs e)
        {

        }
    }
}
