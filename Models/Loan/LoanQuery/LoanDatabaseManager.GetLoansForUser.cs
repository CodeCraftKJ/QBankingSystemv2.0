using System.Collections.Generic;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Loan.Loan
{
    public static partial class LoanDatabaseManager
    {
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
