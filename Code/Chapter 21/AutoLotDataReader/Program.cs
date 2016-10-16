using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");

            // Create a connection string via the builder object.
            SqlConnectionStringBuilder cnStrBuilder =
              new SqlConnectionStringBuilder();
            cnStrBuilder.InitialCatalog = "AutoLot";
            cnStrBuilder.DataSource = @"(local)\SQLEXPRESS";
            cnStrBuilder.ConnectTimeout = 30;
            cnStrBuilder.IntegratedSecurity = true;

            // Create an open a connection.
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnStrBuilder.ConnectionString;
                cn.Open();
                ShowConnectionStatus(cn);

                // Create a SQL command object.
                string strSQL = "Select * From Inventory;Select * from Customers";

                using (SqlCommand myCommand = new SqlCommand(strSQL, cn))
                {
                    #region iterate over the inventory & customers
                    // Obtain a data reader a la ExecuteReader().
                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        do
                        {
                            while (myDataReader.Read())
                            {
                                Console.WriteLine("***** Record *****");
                                for (int i = 0; i < myDataReader.FieldCount; i++)
                                {
                                    Console.WriteLine("{0} = {1}",
                                      myDataReader.GetName(i),
                                      myDataReader.GetValue(i).ToString());
                                }
                                Console.WriteLine();
                            }
                        } while (myDataReader.NextResult());
                    }
                    #endregion
                }
            }
            Console.ReadLine();
        }

        #region Helper function
        static void ShowConnectionStatus(SqlConnection cn)
        {
            // Show various stats about current connection object.
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine("Database location: {0}", cn.DataSource);
            Console.WriteLine("Database name: {0}", cn.Database);
            Console.WriteLine("Timeout: {0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection state: {0}\n", cn.State.ToString());
        }
        #endregion
    }
}
