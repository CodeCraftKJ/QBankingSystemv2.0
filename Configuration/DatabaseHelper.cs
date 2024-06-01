using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QBankingSystemv2._0.Configuration
{
    public static class DatabaseHelper
    {
        public enum DatabaseError
        {
            None,
            ConnectionError,
            StructureError,
            IPPermissionError,
            UnknownError
        }

        public static async Task<(bool, DatabaseError)> IsDatabaseReadyAsync()
        {
            string connectionString = ConfigurationManager.GetConnectionString();
            string[] requiredTables = { "QPayUsers", "QPayHarshedPasswords", "QPayLogTable", "QPayLoans", "QPayTransactions", "QPayAccounts" };
            try
            {
                using SqlConnection connection = new(connectionString);
                await connection.OpenAsync();

                foreach (string tableName in requiredTables)
                {
                    string query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
                    using SqlCommand command = new(query, connection);
                    int count = (int)await command.ExecuteScalarAsync();
                    if (count == 0)
                    {
                        return (false, DatabaseError.StructureError);
                    }
                }

                return (true, DatabaseError.None);
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                return (false, DatabaseError.ConnectionError);
            }
            catch (SqlException ex) when (ex.Number == 18456)
            {
                return (false, DatabaseError.IPPermissionError);
            }
            catch (Exception)
            {
                return (false, DatabaseError.UnknownError);
            }
        }
    }
}
