using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Configuration;

namespace Sudoku
{
    /*
     * Aymeric Siegenthaler
     * DB.cs
     * Database class
     * V1
     */
    public class DB
    {
        /// <summary>
        /// Execute a query to the dabase and return result
        /// </summary>
        /// <param name="query">The SQL Query</param>
        /// <param name="sqlParams">The parameters</param>
        /// <returns>What the database return, stocked in a list</returns>

        public List<Dictionary<string, string>> Query(string query, Dictionary<string, string> sqlParams)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();
            foreach (KeyValuePair<string, string> placeholderWithValue in sqlParams)
            {
                // = bindValue in PDO
                mySqlCommand.Parameters.AddWithValue(placeholderWithValue.Key, placeholderWithValue.Value);
            }

            try
            {

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        object[] currentValues = new object[reader.FieldCount];
                        reader.GetValues(currentValues);
                        Dictionary<string, string> currentList = new Dictionary<string, string>();
                        // emulate the fetchAssoc 
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            currentList.Add(reader.GetName(i), currentValues[i].ToString());
                        }
                        output.Add(currentList);
                    }
                }
            }
            finally
            {
                // delete all Objects
                mySqlCommand.Dispose();
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }

            return output;
        }
    }

}
