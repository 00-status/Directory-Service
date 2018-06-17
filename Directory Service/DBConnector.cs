using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Directory_Service
{
    class DBConnector
    {
        // Actual connection to the DB
        public MySqlConnection connection;
        
        /// <summary>
        /// Will attempt to connect to a MySql database with the given parameters
        /// </summary>
        /// <param name="server">The IP address of the server to connect to.</param>
        /// <param name="database">The name of the Database to be connecting to.</param>
        /// <param name="username">The name of the user that will be connecting.</param>
        /// <param name="pass">The password for the given user.</param>
        public void ConnectToDB(string server, string database, string username, string pass)
        {
            string connectionString = "SERVER=" + server + ";"
                + "Port=3306" + ";"
                + "DATABASE=" + database + ";"
                + "UID=" + username + ";"
                + "Pwd=" + pass + ";"
                + "SslMode=none" + ";";
            connection = new MySqlConnection(connectionString);

            try
            {
                // Attempt to open a connection
                connection.Open();
                // tell the user their information was correct
                Console.WriteLine("Successfully connected to " + connection.Database);
                connection.Close();
            }
            catch (Exception ex)
            {
                if (ex is MySqlException || ex is ArgumentException)
                {
                    // If the connection throws an exception then display an error message
                    Console.WriteLine("Could not connect to database.");
                    // Set the connection to be null
                    connection = null;
                }
            }
        }

        public List<string[]> GetTableEntries(string tableName)
        {
            // Create a query
            string query = "SELECT * FROM  `" + tableName + "` WHERE 1";
            // A list to hold an array of strings
            // The strings are cells of the table
            List<string[]> rows = new List<string[]>();

            if (connection != null)
            {
                // A counter to keep track of how many times to loop through the "cols" and "temp" arrays
                int loopCount = 0;
                // The number of columns in this particular table
                int colCount = 0;

                connection.Open();

                // Create a command from the query and the connection
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Create a data adapter to handle the SQL statement
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                // Create a data table so we can interact with the document
                DataTable dataTable = new DataTable(tableName);

                try
                {
                    // Fill the data table with information
                    adapter.Fill(dataTable);
                }
                catch (MySqlException) // If something terrible happens
                {
                    // Tell the user something went wrong
                    Console.WriteLine("The table provided does not exist.");
                    // Close the connection
                    connection.Close();
                    // Return an empty list
                    return new List<string[]>();
                }

                // Get the number of columns in the table
                colCount = dataTable.Columns.Count;

                // Add the table's headers to the row list
                string[] headers;
                headers = new string[colCount];
                // Loop through each column and add each header to the array of headers.
                foreach (var header in dataTable.Columns)
                {
                    headers[loopCount++] = header.ToString();
                }
                // Reset the loopCount
                loopCount = 0;
                // Add the headers to the List of rows
                rows.Add(headers);

                // Add each row to the list of rows
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] temp = new string[colCount];
                    foreach (var col in row.ItemArray)
                    {
                        temp[loopCount++] = col + "";
                    }
                    loopCount = 0;
                    // Add the row to the list of rows
                    rows.Add(temp);
                }

                // Close the db connection
                connection.Close();
            }
            else
            {
                Console.WriteLine("Database Connection not set.");
            }
            return rows;
        }
    }
}
