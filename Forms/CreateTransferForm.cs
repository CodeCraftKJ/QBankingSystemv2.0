﻿using FluentValidation.Results;
using QBankingSystemv2._0.Models.Transfer.Transfer;
using QBankingSystemv2._0.Models.Transfer.TransferValidation;
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

        private void CreateTransferButton_Click(object sender, EventArgs e)
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
                string sourceAccountID = sourceAccountComboBox.Text;
                string destinationAccountID = destinationAccountComboBox.Text;
                string transactionType = transferTypeComboBox.Text;
                decimal amount = decimal.Parse(amountTextBox.Text);
                string description = descriptionTextBox.Text;

                Transfer transaction = new(sourceAccountID, destinationAccountID, transactionType, amount, description, DateTime.Now);

                try
                {
                    TransferManager.ExecuteTransaction(transaction, User.UserID);
                    MessageBox.Show("Transfer Executed Successfully!.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:." + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please correct the errors in the form.");
            }
        }

        private void AmountTextBox_TextChanged_1(object sender, EventArgs e)
        {
            amountValidator.ValidateAndShowMessage(amountTextBox);
        }

        private void DescriptionTextBox_TextChanged_1(object sender, EventArgs e)
        {
            descriptionValidator.ValidateAndShowMessage(descriptionTextBox);
        }

        private void SourceAccountComboBox_TextChanged(object sender, EventArgs e)
        {
            sourceAccountValidator.ValidateAndShowMessage(sourceAccountComboBox);
        }

        private void DestinationAccountComboBox_TextChanged(object sender, EventArgs e)
        {
            destinationAccountValidator.ValidateAndShowMessage(destinationAccountComboBox);
        }

        private void TransferTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            transferTypeValidator.ValidateAndShowMessage(transferTypeComboBox);
        }
    }
}
