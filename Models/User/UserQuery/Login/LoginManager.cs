using System.Data.SqlClient;
namespace QBankingSystemv2._0.Models.User.UserQuery.Login
{
    static class LoginManager
    {
        public static bool ValidateLogin(string username, string password)
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                string query = "SELECT PasswordHash FROM QPayHarshedPasswords WHERE UserId = (SELECT UserId FROM QPayUsers WHERE UserName = @UserName)";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@UserName", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string storedPasswordHash = reader["PasswordHash"].ToString();
                    return password == storedPasswordHash;
                }
            }
            return false;
        }
    }
}
