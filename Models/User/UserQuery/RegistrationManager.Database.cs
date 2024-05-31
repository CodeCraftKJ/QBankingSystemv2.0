using System;
using System.Data.SqlClient;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static partial class RegistrationManager
    {
        private static string RegisterUserInDatabase()
        {
            string connectionString = ConfigurationManager.GetConnectionString();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string tableName = "QPayUsers";
                    string query = $"INSERT INTO {tableName} (PIN, Pesel, Phone, LastName, FirstName, UserName, MaterialStatus, Address, BirthDate, Email) " +
                                    "VALUES (@PIN, @Pesel, @Phone, @LastName, @FirstName, @UserName, @MaterialStatus, @Address, @BirthDate, @Email); SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new(query, connection, transaction);
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

                    int userId = Convert.ToInt32(command.ExecuteScalar());

                    string hashedPassword = HashPassword(_textBoxPassword.Text);
                    string hashedPasswordQuery = $"INSERT INTO QPayHarshedPasswords (UserId, PasswordHash) VALUES (@UserId, @PasswordHash)";
                    SqlCommand hashedPasswordCommand = new(hashedPasswordQuery, connection, transaction);
                    hashedPasswordCommand.Parameters.AddWithValue("@UserId", userId);
                    hashedPasswordCommand.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    hashedPasswordCommand.ExecuteNonQuery();

                    transaction.Commit();
                    return "";
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    return GetErrorMessage(ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "An error occurred while registering user in the database: " + ex.Message;
                }
            }
        }
    }
}
