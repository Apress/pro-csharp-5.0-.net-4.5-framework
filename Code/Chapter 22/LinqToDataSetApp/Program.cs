using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

// Location of strongly typed data containers.
using AutoLotDAL; 

// Location of strongly typed data adapters.
using AutoLotDAL.AutoLotDataSetTableAdapters; 

namespace LinqToDataSetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over DataSet *****\n");

            // Get a strongly typed DataTable containing the current Inventory
            // of the AutoLot database.
            AutoLotDataSet dal = new AutoLotDataSet();
            InventoryTableAdapter da = new InventoryTableAdapter();
            AutoLotDataSet.InventoryDataTable data = da.GetData();

            // Print all car ids.
            PrintAllCarIDs(data);
            Console.WriteLine();

            // Show all red cars.
            ShowRedCars(data);
            Console.WriteLine();

            BuildDataTableFromQuery(data);
            Console.WriteLine();

            Console.ReadLine();
        }

        #region Print all Car IDs.
        static void PrintAllCarIDs(DataTable  data)
        {
            // Get enumerable version of DataTable.
            EnumerableRowCollection enumData = data.AsEnumerable();

            // Print the car ID values.
            foreach (DataRow r in enumData)
                Console.WriteLine("Car ID = {0}", r["CarID"]);
        }
        #endregion

        #region Show red cars
        static void ShowRedCars(DataTable data)
        {
            // Project a new result set containing
            // the ID/Make for rows where Color == Red.
            var cars = from car in data.AsEnumerable()
                       where
                         car.Field<string>("Color") == "Red"
                       select new
                       {
                           ID = car.Field<int>("CarID"),
                           Make = car.Field<string>("Make")
                       };


            Console.WriteLine("Here are the red cars we have in stock:");
            foreach (var item in cars)
            {
                Console.WriteLine("-> CarID = {0} is {1}", item.ID, item.Make);
            }
        }
        #endregion

        #region DataTable from Query
        static void BuildDataTableFromQuery(DataTable data)
        {
            var cars = from car in data.AsEnumerable()
                       where
                         car.Field<int>("CarID") > 5
                       select car;

            // Use this result set to build a new DataTable.
            DataTable newTable = cars.CopyToDataTable();

            // Print the DataTable.
            for (int curRow = 0; curRow < newTable.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < newTable.Columns.Count; curCol++)
                {
                    Console.Write(newTable.Rows[curRow][curCol].ToString().Trim() + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
