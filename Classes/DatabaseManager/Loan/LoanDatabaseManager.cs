using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QBankingSystemv2._0.Classes.Transactions;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static class LoanDatabaseManager
    {
        private static int userID;

        public static void Initialize(int currentUserID)
        {
            userID = currentUserID;
        }

        public static void TakeLoan(string toAccount, decimal loanAmount, decimal loanInterestRate, string currency)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.GetConnectionString()))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int loanAccountID = CreateLoanAccount(connection, transaction, currency, loanAmount);
                    CreateNewLoan(connection, transaction, loanAccountID, loanAmount, loanInterestRate);
                    TransactionManager.ExecuteTransaction(new Transaction(loanAccountID.ToString(), toAccount, "Loan", loanAmount, "Loan taken", DateTime.Now), userID);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Failed to take loan: " + ex.Message);
                }
            }
        }

        private static int CreateLoanAccount(SqlConnection connection, SqlTransaction transaction, string currency, decimal loanAmount)
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

        private static void CreateNewLoan(SqlConnection connection, SqlTransaction transaction, int loanAccountID, decimal loanAmount, decimal loanInterestRate)
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

        public static List<Loan> GetLoansForUser()
        {
            List<Loan> loans = new List<Loan>();

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
                    loans.Add(new Loan { LoanID = loanID, LoanAmount = loanAmount, InterestRate = interestRate });
                }
            }

            return loans;
        }
    }
}
