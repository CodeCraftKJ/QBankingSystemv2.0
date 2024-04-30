using FluentValidation.Results;
using QBankingSystemv2._0.Classes.Transactions;
using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.ValidationClasses;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class CreateTransferForm : Form
    {
        private SourceAccountValidator sourceAccountValidator;
        private DestinationAccountValidator destinationAccountValidator;
        private TransferTypeValidator transferTypeValidator;
        private AmountValidator amountValidator;
        private DescriptionValidator descriptionValidator;

        public CreateTransferForm()
        {
            InitializeComponent();
            InitializeValidators();
        }

        private void InitializeValidators()
        {
            sourceAccountValidator = new SourceAccountValidator();
            destinationAccountValidator = new DestinationAccountValidator();
            transferTypeValidator = new TransferTypeValidator();
            amountValidator = new AmountValidator();
            descriptionValidator = new DescriptionValidator();
        }

        private void createTransferButton_Click(object sender, EventArgs e)
        {
            ValidationResult sourceAccountValidationResult = sourceAccountValidator.ValidateAndShowMessage(sourceAccountComboBox);
            ValidationResult destinationAccountValidationResult = destinationAccountValidator.ValidateAndShowMessage(destinationAccountComboBox);
            ValidationResult transferTypeValidationResult = transferTypeValidator.ValidateAndShowMessage(transferTypeComboBox);
            ValidationResult amountValidationResult = amountValidator.ValidateAndShowMessage(amountTextBox);
            ValidationResult descriptionValidationResult = descriptionValidator.ValidateAndShowMessage(descriptionTextBox);

            if (sourceAccountValidationResult.IsValid && destinationAccountValidationResult.IsValid &&
                transferTypeValidationResult.IsValid && amountValidationResult.IsValid &&
                descriptionValidationResult.IsValid)
            {
                string sourceAccountID = sourceAccountComboBox.SelectedItem.ToString();
                string destinationAccountID = destinationAccountComboBox.SelectedItem.ToString();
                string transactionType = transferTypeComboBox.SelectedItem.ToString();
                decimal amount = decimal.Parse(amountTextBox.Text);
                string description = descriptionTextBox.Text;

                Transaction transaction = new Transaction(sourceAccountID, destinationAccountID, transactionType, amount, description);

                TransactionManager.ExecuteTransaction(transaction,CurrentUser.UserID);

                MessageBox.Show("Transfer created successfully!");
            }
            else
            {
                MessageBox.Show("Please correct the errors in the form.");
            }
        }

        private void amountTextBox_TextChanged_1(object sender, EventArgs e)
        {
            amountValidator.ValidateAndShowMessage(amountTextBox);
        }

        private void descriptionTextBox_TextChanged_1(object sender, EventArgs e)
        {
            descriptionValidator.ValidateAndShowMessage(descriptionTextBox);
        }

        private void sourceAccountComboBox_TextChanged(object sender, EventArgs e)
        {
            sourceAccountValidator.ValidateAndShowMessage(sourceAccountComboBox);
        }

        private void destinationAccountComboBox_TextChanged(object sender, EventArgs e)
        {
            destinationAccountValidator.ValidateAndShowMessage(destinationAccountComboBox);
        }

        private void transferTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            transferTypeValidator.ValidateAndShowMessage(transferTypeComboBox);
        }
    }
}
