using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0
{
    public static partial class RegistrationManager
    {
        private static string RegisterUserInDatabase()
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string tableName = "QPayUsers";
                string query = $"INSERT INTO {tableName} (PIN, Pesel, Phone, LastName, FirstName, UserName, MaterialStatus, Address, BirthDate, Email) " +
                               "VALUES (@PIN, @Pesel, @Phone, @LastName, @FirstName, @UserName, @MaterialStatus, @Address, @BirthDate, @Email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PIN", _textPIN.Text);
                command.Parameters.AddWithValue("@Pesel", _textPesel.Text);
                command.Parameters.AddWithValue("@Phone", _textPhone.Text);
                command.Parameters.AddWithValue("@LastName", _textLastName.Text);
                command.Parameters.AddWithValue("@FirstName", _textFirstName.Text);
                command.Parameters.AddWithValue("@UserName", _textUserName.Text);
                command.Parameters.AddWithValue("@MaterialStatus", _textMatrialStatus.Text);
                command.Parameters.AddWithValue("@Address", _textAddress.Text);
                command.Parameters.AddWithValue("@BirthDate", DateTime.Parse(_textBirth.Text));
                command.Parameters.AddWithValue("@Email", _textEmail.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0 ? "" : "Failed to register user in the database.";
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 2601:
                        case 2627:
                            if (ex.Message.Contains("Phone"))
                                return "There is already an account registered with this phone number. Please use a different phone number.";
                            else if (ex.Message.Contains("Pesel"))
                                return "There is already an account registered with this PESEL number. Please use a different PESEL number.";
                            else if (ex.Message.Contains("Email"))
                                return "There is already an account registered with this email address. Please use a different email address.";
                            else if (ex.Message.Contains("UserName"))
                                return "This username is already taken. Please choose a different username.";
                            else
                                return "An error occurred while registering user in the database: " + ex.Message;
                        default:
                            return "An error occurred while registering user in the database: " + ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return "An error occurred while registering user in the database: " + ex.Message;
                }
            }
        }
    }
}