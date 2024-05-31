using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.AccountDB
{
    public static partial class AccountRegistrationManager
    {
        public static int RegisterAccount(string accountName, string accountType, string currency, decimal initialBalance,
                                            decimal depositLimit, decimal withdrawalLimit, decimal transferLimit, int userID)
        {
            int accountID = GenerateAccountID(accountType);

            string connectionString = ConfigurationManager.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO QPayAccounts (UserID, AccountID, AccountName, AccountType, Balance, Currency, DepositLimit, WithdrawalLimit, TransferLimit, CreatedAt, Status) 
                             VALUES (@UserID, @AccountID, @AccountName, @AccountType, @InitialBalance, @Currency, @DepositLimit, @WithdrawalLimit, @TransferLimit, GETDATE(), 'Active')";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@AccountName", accountName);
                command.Parameters.AddWithValue("@AccountType", accountType);
                command.Parameters.AddWithValue("@InitialBalance", initialBalance);
                command.Parameters.AddWithValue("@Currency", currency);
                command.Parameters.AddWithValue("@DepositLimit", depositLimit);
                command.Parameters.AddWithValue("@WithdrawalLimit", withdrawalLimit);
                command.Parameters.AddWithValue("@TransferLimit", transferLimit);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account registered successfully!");
                        return accountID;
                    }
                    else
                    {
                        MessageBox.Show("Failed to register account.");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return -1;
                }
            }
        }
    }
}