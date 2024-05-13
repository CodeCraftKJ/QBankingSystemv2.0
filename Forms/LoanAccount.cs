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
            RefreshLoanList();
        }

        private void takeLoanButton_Click(object sender, EventArgs e)
        {
            string toAccount = toAccount1.Text;
            decimal loanAmount = loanAmountTrackBar.Value;
            decimal loanInterestRate = loanInterestRateTrackBar.Value;
            string currency = TxtBoxCurrency.Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int loanAccountID = CreateLoanAccount(connection, transaction, currency, loanAmount);
                    CreateNewLoan(connection, transaction, loanAccountID, loanAmount, loanInterestRate);
                    TransactionManager.ExecuteTransaction(new Transaction(loanAccountID.ToString(), toAccount, "Loan", loanAmount, "Loan taken", DateTime.Now), CurrentUser.UserID);
                    transaction.Commit();
                    RefreshLoanList();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int CreateLoanAccount(SqlConnection connection, SqlTransaction transaction, string currency, decimal loanAmount)
        {
            try
            {
                int loanAccountID = AccountRegistrationManager.RegisterAccount("Loan Account", "Loan Account", currency, loanAmount, 999999, 999999, 999999, userID);
                return loanAccountID;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create loan account: " + ex.Message);
            }
        }

        private void CreateNewLoan(SqlConnection connection, SqlTransaction transaction, int loanAccountID, decimal loanAmount, decimal loanInterestRate)
        {
            try
            {
                string insertQuery = "INSERT INTO QPayLoans (UserID, LoanAmount, InterestRate, RemainingBalance, LoanAccountID) VALUES (@UserID, @LoanAmount, @InterestRate, 0, @LoanAccountID)";
                SqlCommand command = new SqlCommand(insertQuery, connection, transaction);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@LoanAmount", loanAmount);
                command.Parameters.AddWithValue("@InterestRate", loanInterestRate);
                command.Parameters.AddWithValue("@LoanAccountID", loanAccountID);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new loan: " + ex.Message);
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
