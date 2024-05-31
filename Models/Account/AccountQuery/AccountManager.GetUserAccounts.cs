using QBankingSystemv2._0.Models.Account.Account;
using QBankingSystemv2._0.Models.Account.Account.AccountTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Account.AccountQuery
{
    public static class AccountManager
    {
        public static List<IAccount> GetUserAccounts(int userID)
        {
            List<IAccount> userAccounts = new List<IAccount>();

            string connectionString = ConfigurationManager.GetConnectionString();
            string query = "SELECT * FROM QPayAccounts WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string accountName = reader["AccountName"].ToString();
                        string accountID = reader["AccountID"].ToString();
                        string accountType = reader["AccountType"].ToString();
                        string currency = reader["Currency"].ToString();
                        decimal balance = Convert.ToDecimal(reader["Balance"]);
                        decimal depositLimit = Convert.ToDecimal(reader["DepositLimit"]);
                        decimal withdrawalLimit = Convert.ToDecimal(reader["WithdrawalLimit"]);
                        decimal transferLimit = Convert.ToDecimal(reader["TransferLimit"]);

                        userAccounts.Add(new SavingsAccount(accountName, accountID, currency, balance, depositLimit, withdrawalLimit, transferLimit));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return userAccounts;
        }
    }
}
