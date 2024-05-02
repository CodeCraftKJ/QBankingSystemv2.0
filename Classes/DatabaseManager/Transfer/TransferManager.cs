using QBankingSystemv2._0.Classes.Transactions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static partial class TransactionManager
    {
        public static void ExecuteTransaction(Transaction transaction, int userID)
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (!IsUserAccount(connection, userID, transaction.SourceAccountID))
                {
                    MessageBox.Show("Error: Source account does not belong to the user.");
                    return;
                }

                if (!IsAccountExists(connection, transaction.DestinationAccountID))
                {
                    MessageBox.Show("Error: Destination account does not exist.");
                    return;
                }

                if (!CheckBalanceAndTransferLimit(connection, transaction.SourceAccountID, transaction.Amount))
                {
                    MessageBox.Show("Error: Insufficient balance or transfer limit exceeded.");
                    return;
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

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static List<(Transaction, bool)> GetAccountTransfers(string accountID)
        {
            List<(Transaction, bool)> accountTransfers = new List<(Transaction, bool)>();

            string connectionString = ConfigurationManager.GetConnectionString();

            string query = @"SELECT * FROM QPayTransactions WHERE SourceAccountID = @AccountID OR DestinationAccountID = @AccountID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string sourceAccountID = reader["SourceAccountID"].ToString();
                        string destinationAccountID = reader["DestinationAccountID"].ToString();

                        bool isOutgoing = sourceAccountID == accountID;
                        Transaction transaction = new Transaction(
                            sourceAccountID,
                            destinationAccountID,
                            reader["TransactionType"].ToString(),
                            Convert.ToDecimal(reader["Amount"]),
                            reader["Description"].ToString()
                        );
                        accountTransfers.Add((transaction, isOutgoing));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return accountTransfers;
        }

        private static bool IsUserAccount(SqlConnection connection, int userID, string accountID)
        {
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE UserID = @UserID AND AccountID = @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@AccountID", accountID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private static bool IsAccountExists(SqlConnection connection, string accountID)
        {
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE AccountID = @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", accountID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private static bool CheckBalanceAndTransferLimit(SqlConnection connection, string accountID, decimal amount)
        {
            string query = "SELECT Balance, TransferLimit FROM QPayAccounts WHERE AccountID = @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", accountID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    decimal balance = reader.GetDecimal(0);
                    decimal transferLimit = reader.GetDecimal(1);
                    return balance >= amount && transferLimit >= amount;
                }
            }

            return false;
        }
    }
}
