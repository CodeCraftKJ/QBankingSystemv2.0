using Newtonsoft.Json.Linq;
using System;
using System.IO;

public static class ConfigurationManager
{
    private static string _connectionString;

    public static string GetConnectionString()
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            LoadConfiguration();
        }
        return _connectionString;
    }

    private static void LoadConfiguration()
    {
        try
        {
            string jsonFilePath = "./appsettings.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            JObject jsonObj = JObject.Parse(jsonContent);
            _connectionString = (string)jsonObj["ConnectionStrings"]["MainDatabaseConnection"];
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("FileNotFound: The appsettings.json file was not found.");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("JSONFormatError: " + ex.Message);
            throw;
        }
    }
}
