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
        /// <param name="keepConnectionAlive">Keep the connection alive. It will be re-used and delete later if you pass true, then false</param>
        /// <returns>What the database return, stocked in a list</returns>
        private MySqlConnection mySqlConnection;
        public List<Dictionary<string, string>> Query(string query, Dictionary<string, string> sqlParams = null, bool keepConnectionAlive = false)
        {
            if (mySqlConnection == null)
            {
                mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
                mySqlConnection.Open();
            }
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            
            List<Dictionary<string, string>> output = new List<Dictionary<string, string>>();
            if (sqlParams != null)
            {
                foreach (KeyValuePair<string, string> placeholderWithValue in sqlParams)
                {
                    // = bindValue in PDO
                    object value;
                    if (int.TryParse(placeholderWithValue.Value, out _))
                    {
                        value = Convert.ToInt32(placeholderWithValue.Value);
                    }
                    else
                    {
                        value = placeholderWithValue.Value;
                    }
                    mySqlCommand.Parameters.AddWithValue(placeholderWithValue.Key, value);
                }
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
                if (!keepConnectionAlive)
                {
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }

            return output;
        }
    }

}
