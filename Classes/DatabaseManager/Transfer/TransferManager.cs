using QBankingSystemv2._0.Classes.Transactions;
using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static class TransactionManager
    {
        public static void SaveTransaction(Transaction transaction)
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string query = @"INSERT INTO Transactions (TransactionID, SourceAccountID, DestinationAccountID, TransactionType, Amount, TransactionDate, Description) 
                             VALUES (@TransactionID, @SourceAccountID, @DestinationAccountID, @TransactionType, @Amount, @TransactionDate, @Description)";

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
    }
}
