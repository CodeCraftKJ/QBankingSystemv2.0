using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public static partial class TransferManager
    {

        private static bool IsUserAccount(SqlConnection connection, int userID, string accountID)
        {
            string query = "SELECT COUNT(*) FROM QPayAccounts WHERE UserID = @UserID AND AccountID = @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@AccountID", accountID);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }
}
