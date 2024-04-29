using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QBankingSystemv2._0.Classes.Accounts;
using QBankingSystemv2._0.Interfaces;

namespace QBankingSystemv2._0.Classes.DatabaseManager
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

                        if (accountType == "Savings Account")
                        {
                            userAccounts.Add(new SavingsAccount(accountName,accountID, currency, balance, depositLimit, withdrawalLimit, transferLimit));
                        }
                        else if (accountType == "Checking Account")
                        {
                            userAccounts.Add(new CheckingAccount(accountName,accountID, currency, balance, depositLimit, withdrawalLimit, transferLimit));
                        }
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
