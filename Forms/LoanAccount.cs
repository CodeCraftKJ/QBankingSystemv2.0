using QBankingSystemv2._0.Models.Loan.Loan;
using System;
using System.Windows.Forms;
using FluentValidation.Results;
using System.Configuration;

namespace QBankingSystemv2._0.Forms
{
    public partial class LoanAccount : Form
    {
        private LoanValidator loanValidator;

        public LoanAccount()
        {
            InitializeComponent();
            LoanDatabaseManager.Initialize(User.UserID);
            RefreshLoanList();
            loanValidator = new LoanValidator();
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            var loanInput = new LoanInput
            {
                ToAccount = toAccount1.Text,
                LoanAmount = loanAmountTrackBar.Value,
                LoanInterestRate = loanInterestRateTrackBar.Value,
                Currency = TxtBoxCurrency.Text
            };

            ValidationResult result = loanValidator.ValidateAndShowMessage(toAccount1, loanInput);

            if (result.IsValid)
            {
                try
                {
                    LoanDatabaseManager.TakeLoan(loanInput.ToAccount, loanInput.LoanAmount, loanInput.LoanInterestRate, loanInput.Currency);
                    RefreshLoanList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshLoanList()
        {
            transferList.Items.Clear();
            var loans = LoanDatabaseManager.GetLoansForUser();
            foreach (var loan in loans)
            {
                transferList.Items.Add($"LoanID: {loan.LoanID}, Loan Amount: {loan.LoanAmount:C}, Interest Rate: {loan.InterestRate}%");
            }
        }

        private void CalculateAndDisplayLoanCost()
        {
            decimal loanCost = loanAmountTrackBar.Value * loanInterestRateTrackBar.Value / 100;
            loanCostLabel.Text = $"Loan Cost: {loanCost:C}";
        }

        private void loanAmountTrackBar_Scroll(object sender, EventArgs e)
        {
            loanAmountLabel.Text = $"Loan Amount: {loanAmountTrackBar.Value:C}";
            CalculateAndDisplayLoanCost();
        }

        private void loanInterestRateTrackBar_Scroll(object sender, EventArgs e)
        {
            loanInterestRateLabel.Text = $"Interest Rate: {loanInterestRateTrackBar.Value}%";
            CalculateAndDisplayLoanCost();
        }
    }
}
