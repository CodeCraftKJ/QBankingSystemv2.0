using FluentValidation.Results;
using QBankingSystemv2._0.ValidationClasses;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class CreateAccountForm : Form
    {
        private AccountTypeValidator accountTypeValidator;
        private CurrencyValidator currencyValidator;
        private DepositLimitValidator depositLimitValidator;
        private WithdrawalLimitValidator withdrawalLimitValidator;
        private TransferLimitValidator transferLimitValidator;
        private AccountNameValidator accountNameValidator;
        private InitialBalanceValidator initialBalanceValidator;

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void createAccountForm_Load(object sender, EventArgs e)
        {
            accountTypeValidator = new AccountTypeValidator();
            currencyValidator = new CurrencyValidator();
            depositLimitValidator = new DepositLimitValidator();
            withdrawalLimitValidator = new WithdrawalLimitValidator();
            transferLimitValidator = new TransferLimitValidator();
            accountNameValidator = new AccountNameValidator();
            initialBalanceValidator = new InitialBalanceValidator();
        }

        private void accountNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidationResult result = accountNameValidator.ValidateAndShowMessage(accountNameTextBox);
            createButton.Enabled = result.IsValid;
        }

        private void accountTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationResult result = accountTypeValidator.ValidateAndShowMessage(accountTypeComboBox);
            createButton.Enabled = result.IsValid;
        }

        private void currencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationResult result = currencyValidator.ValidateAndShowMessage(currencyComboBox);
            createButton.Enabled = result.IsValid;
        }

        private void depositLimitTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidationResult result = depositLimitValidator.ValidateAndShowMessage(depositLimitTextBox);
            createButton.Enabled = result.IsValid;
        }

        private void withdrawalLimitTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidationResult result = withdrawalLimitValidator.ValidateAndShowMessage(withdrawalLimitTextBox);
            createButton.Enabled = result.IsValid;
        }

        private void transferLimitTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidationResult result = transferLimitValidator.ValidateAndShowMessage(transferLimitTextBox);
            createButton.Enabled = result.IsValid;
        }

        private void initialBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidationResult result = initialBalanceValidator.ValidateAndShowMessage(initialBalanceTextBox);
            createButton.Enabled = result.IsValid;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ValidationResult accountNameValidationResult = accountNameValidator.ValidateAndShowMessage(accountNameTextBox);
            ValidationResult accountTypeValidationResult = accountTypeValidator.ValidateAndShowMessage(accountTypeComboBox);
            ValidationResult currencyValidationResult = currencyValidator.ValidateAndShowMessage(currencyComboBox);
            ValidationResult depositLimitValidationResult = depositLimitValidator.ValidateAndShowMessage(depositLimitTextBox);
            ValidationResult withdrawalLimitValidationResult = withdrawalLimitValidator.ValidateAndShowMessage(withdrawalLimitTextBox);
            ValidationResult transferLimitValidationResult = transferLimitValidator.ValidateAndShowMessage(transferLimitTextBox);

            if (accountNameValidationResult.IsValid && accountTypeValidationResult.IsValid &&
                currencyValidationResult.IsValid && depositLimitValidationResult.IsValid &&
                withdrawalLimitValidationResult.IsValid && transferLimitValidationResult.IsValid)
            {
                string accountName = accountNameTextBox.Text;
                string accountType = accountTypeComboBox.SelectedItem.ToString();
                string currency = currencyComboBox.SelectedItem.ToString();
                decimal initialBalance = decimal.Parse(initialBalanceTextBox.Text);
                decimal depositLimit = decimal.Parse(depositLimitTextBox.Text);
                decimal withdrawalLimit = decimal.Parse(withdrawalLimitTextBox.Text);
                decimal transferLimit = decimal.Parse(transferLimitTextBox.Text);
                int userID = CurrentUser.UserID;
                AccountRegistrationManager.RegisterAccount(accountName, accountType, currency, initialBalance,
                                                           depositLimit, withdrawalLimit, transferLimit, userID);

                MessageBox.Show("Account created successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please correct the errors in the form.");
            }
        }
    }
}
