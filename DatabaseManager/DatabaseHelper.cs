using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QBankingSystemv2._0
{
    public static class DatabaseHelper
    {
        public static async Task<bool> IsDatabaseReadyAsync()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string[] requiredTables = { "QPayUsers" };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    foreach (string tableName in requiredTables)
                    {
                        string query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int count = (int)await command.ExecuteScalarAsync();
                            if (count == 0)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
