using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class LoanAccount : Form
    {
        private decimal loanAmount;

        public LoanAccount(decimal loanAmount)
        {
            InitializeComponent();
            this.loanAmount = loanAmount;
            UpdateLoanAmountLabel();
        }

        private void UpdateLoanAmountLabel()
        {
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement taking a loan
        }

        private void calculateLoanButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement loan calculator
        }

        private void loanInterestRateTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void loanAmountTrackBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
