using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Extensions
{
    /// <summary>
    /// Extension class for database operations.
    /// Provides methods to validate connection strings and perform other database-related tasks.
    /// </summary>
    public static class DbService
    {
        
        /// <summary>
        /// Retrieves all table names from the specified SQL Server database.
        /// This method uses Dapper to execute a SQL query and return the results as a list of strings.
        /// </summary>
        /// <param name="_connectionString"></param>
        /// <param name="_tableName"></param>
        /// <param name="_filePath"></param>
        /// <returns></returns>
        public static bool ExportTableToCsv(string _connectionString, string _tableName, string _filePath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = $"SELECT * FROM {_tableName}";
                    var data = connection.Query(query).ToList();

                    if (data.Count == 0)
                    {
                        Console.WriteLine("No data found in the table.");
                        return false;
                    }

                    Console.WriteLine(data.Count + " Records Fetched from Table \n");

                    var columns = ((IDictionary<string, object>)data.First()).Keys.ToList();

                    using (StreamWriter writer = new StreamWriter(_filePath))
                    {
                        writer.WriteLine(string.Join(",", columns));

                        foreach (var row in data)
                        {
                            var rowData = (IDictionary<string, object>)row;
                            writer.WriteLine(string.Join(",", columns.Select(col => $"\"{rowData[col]?.ToString().Replace("\"", "\"\"")}\"")));
                        }
                    }
                }

                Console.WriteLine($"File created at: {_filePath}");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error exporting to CSV: " + e.Message);
                return false;
            }
        }
        
        /// <summary>
        /// Retrieves all table names from the specified SQL Server database.
        /// </summary>
        /// <param name="_conectionString"></param>
        /// <returns></returns>
        public static List<string> GetAllTheTablesExistsInDatabase(string _conectionString)
        {
            using (SqlConnection connection = new SqlConnection(_conectionString))
            {
                connection.Open();
                return connection.Query<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'").ToList();
            }
        }

        /// <summary>
        /// Validates a SQL Server connection string by attempting to open a connection.
        /// If the connection is successful, the connection string is considered valid.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static bool IsValidConnectionString(string connectionString)
        {
             try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                return true; 
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
