using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

public static class AccountRegistrationManager
{
    public static void RegisterAccount(string accountName, string accountType, string currency, decimal initialBalance,
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
                }
                else
                {
                    MessageBox.Show("Failed to register account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    private static int GenerateAccountID(string accountType)
    {
        string prefix = GetAccountTypePrefix(accountType);
        string randomDigits = GenerateRandomDigits(8);

        string accountIDString = prefix + randomDigits;
        int accountID = int.Parse(accountIDString);

        return accountID;
    }

    private static string GetAccountTypePrefix(string accountType)
    {
        switch (accountType)
        {
            case "Savings Account":
                return "1";
            case "Checking Account":
                return "2";
            case "Loan Account":
                return "9";
            default:
                return "0";
        }
    }

    private static string GenerateRandomDigits(int length)
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            sb.Append(random.Next(10).ToString());
        }
        return sb.ToString();
    }

}
