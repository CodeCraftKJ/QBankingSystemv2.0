
using QBankingSystemv2._0.Classes.Transactions;
using QBankingSystemv2._0.Classes.DatabaseManager;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class CreateTransferForm : Form
    {

        public CreateTransferForm()
        {
            InitializeComponent();
        }

        private void createTransferButton_Click(object sender, EventArgs e)
        {


                string sourceAccountID = sourceAccountComboBox.SelectedItem.ToString();
                string destinationAccountID = destinationAccountComboBox.SelectedItem.ToString();
                string transactionType = transferTypeComboBox.SelectedItem.ToString();
                decimal amount = decimal.Parse(amountTextBox.Text);
                string description = descriptionTextBox.Text;
                Transaction transaction = new Transaction(sourceAccountID, destinationAccountID, transactionType, amount, description);
                TransactionManager.SaveTransaction(transaction);
            

        }
    }
}
