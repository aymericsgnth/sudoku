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
    public class DB
    {
        DataSet ds;
        public DB()
        {
            ds = new DataSet();
        }

        public List<object[]> Query(string query, Dictionary<string, string> sqlParams )
        {
            MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            List<object[]> output = new List<object[]>();
            foreach (KeyValuePair<string, string > placeholderWithValue in sqlParams)
            {
                mySqlCommand.Parameters.AddWithValue(placeholderWithValue.Key, placeholderWithValue.Value);
            }
            try
            {
                try
                {
                    
                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            object[] current =  new object[reader.FieldCount];
                            reader.GetValues(current);
                            output.Add(current);
                        }
                    }
                }
                finally
                {
                    mySqlCommand.Dispose();
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
            catch (MySqlException)
            {

                throw;
            }
            return output;
        }
    }

}
