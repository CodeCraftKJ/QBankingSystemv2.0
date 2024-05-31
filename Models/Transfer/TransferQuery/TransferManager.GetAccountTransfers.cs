using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public static partial class TransactionManager
    {
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
                            reader["Description"].ToString(),
                            Convert.ToDateTime(reader["TransactionDate"])
                        );
                        accountTransfers.Add((transaction, isOutgoing));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to get account transfers: " + ex.Message);
                }
            }

            return accountTransfers;
        }
    }
}
