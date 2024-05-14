using System;
using System.Windows.Forms;
using QBankingSystemv2._0.Classes.DatabaseManager;

namespace QBankingSystemv2._0.Forms
{
    public partial class LoanAccount : Form
    {
        public LoanAccount()
        {
            InitializeComponent();
            LoanDatabaseManager.Initialize(CurrentUser.UserID);
            RefreshLoanList();
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            string toAccount = toAccount1.Text;
            decimal loanAmount = loanAmountTrackBar.Value;
            decimal loanInterestRate = loanInterestRateTrackBar.Value;
            string currency = TxtBoxCurrency.Text;

            try
            {
                LoanDatabaseManager.TakeLoan(toAccount, loanAmount, loanInterestRate, currency);
                RefreshLoanList();
                CalculateAndDisplayLoanCost(loanAmount, loanInterestRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CalculateAndDisplayLoanCost(decimal loanAmount, decimal loanInterestRate)
        {
            decimal loanCost = loanAmount * loanInterestRate / 100;
            loanCostLabel.Text = $"Loan Cost: {loanCost:C}";
        }

        private void loanAmountTrackBar_Scroll(object sender, EventArgs e)
        {
            loanAmountLabel.Text = $"Loan Amount: {loanAmountTrackBar.Value:C}";
        }

        private void loanInterestRateTrackBar_Scroll(object sender, EventArgs e)
        {
            loanInterestRateLabel.Text = $"Interest Rate: {loanInterestRateTrackBar.Value}%";
        }
    }
}
