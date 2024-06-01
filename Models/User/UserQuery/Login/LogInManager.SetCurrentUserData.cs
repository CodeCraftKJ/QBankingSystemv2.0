using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Models.User.UserQuery.Login
{
    public static class UserDataManager
    {
        public static void SetCurrentUserData(string username)
        {
            try
            {
                string connectionString = ConfigurationManager.GetConnectionString();

                using SqlConnection connection = new(connectionString);
                string query = "SELECT * FROM QPayUsers WHERE Username = @Username";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    global::User.UserID = Convert.ToInt32(reader["UserID"]);
                    global::User.Username = reader["Username"].ToString();
                    global::User.MaterialStatus = reader["MaterialStatus"].ToString();
                    global::User.Address = reader["Address"].ToString();
                    global::User.BirthDate = string.IsNullOrEmpty(reader["BirthDate"].ToString()) ? "Brak danych" : DateTime.Parse(reader["BirthDate"].ToString()).ToShortDateString();
                    global::User.Email = reader["Email"].ToString();
                    global::User.Pesel = reader["Pesel"].ToString();
                    global::User.Phone = reader["Phone"].ToString();
                    global::User.LastName = reader["LastName"].ToString();
                    global::User.FirstName = reader["FirstName"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
