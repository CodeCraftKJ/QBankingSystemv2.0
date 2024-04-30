using QBankingSystemv2._0.Classes.Transactions;
using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static partial class TransactionManager
    {
        public static void ExecuteTransaction(Transaction transaction, int userID)
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            if (!IsUserAccount(userID, transaction.SourceAccountID))
            {
                Console.WriteLine("Error: Source account does not belong to the user.");
                return;
            }

            if (!IsAccountExists(transaction.DestinationAccountID))
            {
                Console.WriteLine("Error: Destination account does not exist.");
                return;
            }

            string query = @"BEGIN TRANSACTION; " +
                           "INSERT INTO QPayTransactions (TransactionID, SourceAccountID, DestinationAccountID, TransactionType, Amount, TransactionDate, Description) " +
                           "VALUES (@TransactionID, @SourceAccountID, @DestinationAccountID, @TransactionType, @Amount, @TransactionDate, @Description); " +
                           "UPDATE QPayAccounts SET Balance = Balance - @Amount WHERE AccountID = @SourceAccountID; " +
                           "UPDATE QPayAccounts SET Balance = Balance + @Amount WHERE AccountID = @DestinationAccountID; " +
                           "COMMIT;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                command.Parameters.AddWithValue("@SourceAccountID", transaction.SourceAccountID);
                command.Parameters.AddWithValue("@DestinationAccountID", transaction.DestinationAccountID);
                command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                command.Parameters.AddWithValue("@Description", transaction.Description);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
private static bool IsUserAccount(int userID, string accountID)
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE UserID = @UserID AND AccountID = @AccountID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private static bool IsAccountExists(string accountID)
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE AccountID = @AccountID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
