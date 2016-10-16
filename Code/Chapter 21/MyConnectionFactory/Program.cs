using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Need these to get definitions of common interfaces,
// and various connection objects for our test.
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;

namespace MyConnectionFactory
{
    // A list of possible providers.
    enum DataProvider
    { SqlServer, OleDb, Odbc, None }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Very Simple Connection Factory *****\n");

            // Read the provider key.
            string dataProvString = ConfigurationManager.AppSettings["provider"];

            // Transform string to enum.
            DataProvider dp = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProvString))
                dp = (DataProvider)Enum.Parse(typeof(DataProvider), dataProvString);
            else
                Console.WriteLine("Sorry, no provider exists!");

            // Get a specific connection.
            IDbConnection myCn = GetConnection(dp);
            if (myCn != null)
                Console.WriteLine("Your connection is a {0}", myCn.GetType().Name);

            // Open, use, and close connection...

            Console.ReadLine();
        }

        #region Get Connection helper function
        // This method returns a specific connection object
        // based on the value of a DataProvider enum.
        static IDbConnection GetConnection(DataProvider dp)
        {
            IDbConnection conn = null;
            switch (dp)
            {
                case DataProvider.SqlServer:
                    conn = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    conn = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    conn = new OdbcConnection();
                    break;
            }
            return conn;
        }
        #endregion
    }
}
