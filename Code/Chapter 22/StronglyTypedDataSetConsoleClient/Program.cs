using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoLotDAL;
using AutoLotDAL.AutoLotDataSetTableAdapters;

namespace StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strongly Typed DataSets *****\n");

            // Caller creates the DataSet object.
            AutoLotDataSet.InventoryDataTable table = 
                new AutoLotDataSet.InventoryDataTable();

            // Inform adapter of the Select command text and connection.
            InventoryTableAdapter dAdapt =
               new InventoryTableAdapter();

            // Fill our DataSet with a new table, named Inventory.
            dAdapt.Fill(table);
            PrintInventory(table);
            Console.WriteLine();

            // Add rows, update and reprint. 
            AddRecords(table, dAdapt);
            table.Clear();
            dAdapt.Fill(table);
            PrintInventory(table);
            Console.WriteLine();

            // Remove rows we just made and reprint.
            RemoveRecords(table, dAdapt);
            table.Clear();
            dAdapt.Fill(table);
            PrintInventory(table);
            Console.WriteLine();

            CallStoredProc();
            Console.ReadLine();
        }

        #region Remove records
        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable tb, InventoryTableAdapter dAdapt)
        {
            try
            {
                AutoLotDataSet.InventoryRow rowToDelete = tb.FindByCarID(999);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
                rowToDelete = tb.FindByCarID(888);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        #endregion

        #region Print the table data.
        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            // Print out the column names.
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n----------------------------------");

            // Print the DataTable.
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Add records.
        public static void AddRecords(AutoLotDataSet.InventoryDataTable tb, InventoryTableAdapter dAdapt)
        {
            try
            {
                // Get a new strongly typed row from the table.
                AutoLotDataSet.InventoryRow newRow = tb.NewInventoryRow();

                // Fill row with some sample data.
                newRow.CarID = 999;
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Saku";

                // Insert the new row.
                tb.AddInventoryRow(newRow);

                // Add one more row, using overloaded Add method.
                tb.AddInventoryRow(12345, "Yugo", "Green", "Zippy");

                // Update database.
                dAdapt.Update(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Call stored proc.
        public static void CallStoredProc()
        {
            try
            {
                QueriesTableAdapter q = new QueriesTableAdapter();
                Console.Write("Enter ID of car to look up: ");
                string carID = Console.ReadLine();
                string carName = "";
                q.GetPetName(int.Parse(carID), ref carName);
                Console.WriteLine("CarID {0} has the name of {1}", carID, carName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
