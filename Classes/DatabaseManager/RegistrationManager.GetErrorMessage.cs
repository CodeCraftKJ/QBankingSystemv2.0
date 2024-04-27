using System.Data.SqlClient;

namespace QBankingSystemv2._0.Classes.DatabaseManager
{
    public static partial class RegistrationManager
    {
        private static string GetErrorMessage(SqlException ex)
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
    }
}
