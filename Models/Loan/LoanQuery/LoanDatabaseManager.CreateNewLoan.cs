using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Loan.Loan
{
    public static partial class LoanDatabaseManager
    {

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
    }
}
