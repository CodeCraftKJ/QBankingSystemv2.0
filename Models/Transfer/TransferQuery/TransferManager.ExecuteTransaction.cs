using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public static partial class TransferManager
    {
        public static void ExecuteTransaction(Transfer transaction, int userID)
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (!IsUserAccount(connection, userID, transaction.SourceAccountID))
                {
                    throw new Exception("Source account does not belong to the user.");
                }

                if (!IsAccountExists(connection, transaction.DestinationAccountID))
                {
                    throw new Exception("Destination account does not exist.");
                }

                if (!CheckBalanceAndTransferLimit(connection, transaction.SourceAccountID, transaction.Amount))
                {
                    throw new Exception("Insufficient balance or transfer limit exceeded.");
                }

                string query = @"BEGIN TRANSACTION; " +
                               "INSERT INTO QPayTransactions (TransactionID, SourceAccountID, DestinationAccountID, TransactionType, Amount, TransactionDate, Description) " +
                               "VALUES (@TransactionID, @SourceAccountID, @DestinationAccountID, @TransactionType, @Amount, @TransactionDate, @Description); " +
                               "UPDATE QPayAccounts SET Balance = Balance - @Amount WHERE AccountID = @SourceAccountID; " +
                               "UPDATE QPayAccounts SET Balance = Balance + @Amount WHERE AccountID = @DestinationAccountID; " +
                               "COMMIT;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                command.Parameters.AddWithValue("@SourceAccountID", transaction.SourceAccountID);
                command.Parameters.AddWithValue("@DestinationAccountID", transaction.DestinationAccountID);
                command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                command.Parameters.AddWithValue("@Description", transaction.Description);

                command.ExecuteNonQuery();
            }
        }
    }
}
