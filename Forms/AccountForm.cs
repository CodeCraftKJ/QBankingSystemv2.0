using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Classes.Transactions;
using QBankingSystemv2._0.Interfaces;

namespace QBankingSystemv2._0.Forms
{
    public partial class Account : Form
    {
        private IAccount _account;
        private List<(Transaction, bool)> _accountTransfers;

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
            _accountTransfers = TransactionManager.GetAccountTransfers(_account.AccountID);
            if (_accountTransfers != null && _accountTransfers.Count > 0)
            {
                decimal totalBalance = 0;

                foreach (var transferTuple in _accountTransfers)
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

        private void HistoryToFile_Click(object sender, EventArgs e)
        {
            if (_accountTransfers == null || _accountTransfers.Count == 0)
            {
                MessageBox.Show("No transfers to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = $"TransfersHistory_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string filePath = Path.Combine(downloadFolderPath, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var transferTuple in _accountTransfers)
                    {
                        Transaction transaction = transferTuple.Item1;
                        bool isOutgoing = transferTuple.Item2;
                        string transferType = isOutgoing ? "OUTGOING" : "INCOMING";
                        string transferDirection = isOutgoing ? "TO: " : "FROM: ";

                        string transferInfo = $"Transaction Type: {transferType}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}," +
                            $" {transferDirection} {(isOutgoing ? transaction.DestinationAccountID : transaction.SourceAccountID)}";

                        writer.WriteLine(transferInfo);
                    }
                }

                MessageBox.Show($"Sved to: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TransfersFromFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Select a file with transfer information";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        string sourceAccountID = parts[0].Split(':')[1].Trim();
                        string destinationAccountID = parts[1].Split(':')[1].Trim();
                        decimal amount = decimal.Parse(parts[2].Split(':')[1].Trim());
                        DateTime transactionDate = DateTime.Parse(parts[3].Split(':')[1].Trim());
                        string description = parts[4].Split(':')[1].Trim();

                        Transaction transaction = new Transaction(sourceAccountID, destinationAccountID, "Transfer", amount, description);
                        TransactionManager.ExecuteTransaction(transaction, CurrentUser.UserID);
                    }
                    LoadTransfers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while processing transfers from the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void TransfersBtn_Click(object sender, EventArgs e)
        {
            CreateTransferForm transferForm = new();
            transferForm.FormClosed += (s, args) => LoadTransfers();
            transferForm.Show();
        }

        private void LoansBtn_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
