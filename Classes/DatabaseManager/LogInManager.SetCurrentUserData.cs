using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static class UserDataManager
    {
        public static void SetCurrentUserData(string username)
        {
            try
            {
                string connectionString = ConfigurationManager.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM QPayUsers WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentUser.UserID = Convert.ToInt32(reader["UserID"]);
                            CurrentUser.Username = reader["Username"].ToString();
                            CurrentUser.MaterialStatus = reader["MaterialStatus"].ToString();
                            CurrentUser.Address = reader["Address"].ToString();
                            CurrentUser.BirthDate = reader["BirthDate"].ToString();
                            CurrentUser.Email = reader["Email"].ToString();
                            CurrentUser.Pesel = reader["Pesel"].ToString();
                            CurrentUser.Phone = reader["Phone"].ToString();
                            CurrentUser.LastName = reader["LastName"].ToString();
                            CurrentUser.FirstName = reader["FirstName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
