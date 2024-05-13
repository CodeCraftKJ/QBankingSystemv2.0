using QBankingSystemv2._0.Classes.DatabaseManager;
using QBankingSystemv2._0.Classes.Transactions;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class LoanAccount : Form
    {
        private int userID;
        private int loanAmount;
        private int loanInterestRate;

        public LoanAccount()
        {
            InitializeComponent();
            this.userID = CurrentUser.UserID;
            this.loanAmount = loanAmountTrackBar.Value;
            this.loanInterestRate = loanInterestRateTrackBar.Value; 
            UpdateLoanAmountLabel();
            UpdateLoanInterestRateLabel();
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            int loanAccountID = CreateLoanAccount(TxtBoxCurrency.Text);
            string toAccount = toAccount1.Text;
            CreateNewLoan(loanAccountID, TxtBoxCurrency.Text);
            decimal loanAmount = loanAmountTrackBar.Value;
            decimal loanInterestRate = loanInterestRateTrackBar.Value;
            TransactionManager.ExecuteTransaction(new Transaction(loanAccountID.ToString(), toAccount, "Loan", loanAmount, "Loan taken"), CurrentUser.UserID);
            RefreshLoanList();
        }

        private void repayLoanButton_Click(object sender, EventArgs e)
        {
            if (!HasLoan())
            {
                MessageBox.Show("You don't have a loan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private decimal GetRemainingBalance()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT RemainingBalance FROM QPayLoans WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                connection.Open();
                return (decimal)command.ExecuteScalar();
            }
        }

        private void UpdateLoanAmountLabel()
        {
            loanAmountLabel.Text = $"Loan Amount: {loanAmount:C}";
        }

        private void UpdateLoanInterestRateLabel()
        {
            loanInterestRateLabel.Text = $"Interest Rate: {loanInterestRate}%";
        }

        private bool HasLoan()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT COUNT(*) FROM QPayLoans WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }


        private int CreateLoanAccount(string currency)
        {
            AccountRegistrationManager.RegisterAccount("Loan Account", "Loan Account", currency, loanAmount, 9999999, 9999999, 9999999, userID);
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT AccountID FROM QPayAccounts WHERE UserID = @UserID AND AccountType = 'Loan Account'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        private void CreateNewLoan(int loanAccountID, string currency)
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string insertQuery = "INSERT INTO QPayLoans (UserID, LoanAmount, InterestRate, RemainingBalance, LoanAccountID) VALUES (@UserID, @LoanAmount, @InterestRate, 0, @LoanAccountID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@LoanAmount", loanAmount);
                command.Parameters.AddWithValue("@InterestRate", loanInterestRate);
                command.Parameters.AddWithValue("@LoanAccountID", loanAccountID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void RefreshLoanList()
        {
            transferList.Items.Clear();
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT LoanID, LoanAmount, InterestRate FROM QPayLoans WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int loanID = reader.GetInt32(0);
                    decimal loanAmount = reader.GetDecimal(1);
                    decimal interestRate = reader.GetDecimal(2);
                    transferList.Items.Add($"LoanID: {loanID}, Loan Amount: {loanAmount:C}, Interest Rate: {interestRate}%");
                }
            }
        }

        private void loanAmountTrackBar_Scroll(object sender, EventArgs e)
        {
            loanAmount = loanAmountTrackBar.Value;
            loanAmountLabel.Text = $"Loan Amount: {loanAmount:C}";
        }


        private void loanInterestRateTrackBar_Scroll(object sender, EventArgs e)
        {
            loanInterestRate = loanInterestRateTrackBar.Value;
            loanInterestRateLabel.Text = $"Interest Rate: {loanInterestRate}%";
        }

    }
}
