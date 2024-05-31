using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public static partial class TransferManager
    {
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
