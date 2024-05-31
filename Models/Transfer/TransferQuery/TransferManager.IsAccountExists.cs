using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public static partial class TransferManager
    {
        private static bool IsAccountExists(SqlConnection connection, string accountID)
        {
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE AccountID = @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", accountID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }
}