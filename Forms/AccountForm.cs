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
            LoadTransfers(); 
        }

        private void LoadTransfers()
        {
            TransfersList.Items.Clear();
            List<Transaction> accountTransfers = TransactionManager.GetAccountTransfers(_account.AccountID);
            if (accountTransfers != null && accountTransfers.Count > 0)
            {
            foreach (var transfer in accountTransfers)
                {
                    string transferInfo = $" Amount: {transfer.Amount}, Date: {transfer.TransactionDate}";
                    TransfersList.Items.Add(transferInfo);
                }
            }
            else
            {
                TransfersList.Items.Add("No transfers available.");
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

        private void G_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
