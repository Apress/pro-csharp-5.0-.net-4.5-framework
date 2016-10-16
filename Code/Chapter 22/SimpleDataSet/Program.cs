using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

namespace SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with DataSets *****\n");

            // Create the DataSet object and add a few properties.
            DataSet carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "Mikko’s Hot Tub Super Store";

            FillDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);
            SaveAndLoadAsXml(carsInventoryDS);
            SaveAndLoadAsBinary(carsInventoryDS);
            Console.ReadLine();
        }

        #region Print DataSet
        static void PrintDataSet(DataSet ds)
        {
            // Print out any name and extended properties. 
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine();

            #region Using rows / columns
            //foreach (DataTable dt in ds.Tables)
            //{
            //    Console.WriteLine("=> {0} Table:", dt.TableName);

            //    // Print out the column names.
            //    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            //    {
            //        Console.Write(dt.Columns[curCol].ColumnName + "\t");
            //    }
            //    Console.WriteLine("\n----------------------------------");

            //    // Print the DataTable.
            //    for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            //    {
            //        for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            //        {
            //            Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            #endregion

            #region using DataTableReader
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dt.TableName);

                // Print out the column names.
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName.Trim() + "\t");
                }
                Console.WriteLine("\n----------------------------------");

                // Call our new helper method.
                PrintTable(dt);
            }
            #endregion
        }
        #endregion

        #region Print DataTable
        static void PrintTable(DataTable dt)
        {
            // Get the DataTableReader type.
            DataTableReader dtReader = dt.CreateDataReader();

            // The DataTableReader works just like the DataReader.
            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }
        #endregion

        #region Fill DataSet object
        static void FillDataSet(DataSet ds)
        {
            // Create data columns that map to the 
            // 'real' columns in the Inventory table 
            // of the AutoLot database.
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.Caption = "Car ID";
            carIDColumn.ReadOnly = true;
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            carIDColumn.Unique = true;
            carIDColumn.AutoIncrement = true;
            carIDColumn.AutoIncrementSeed = 0;
            carIDColumn.AutoIncrementStep = 1;

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            // Now add DataColumns to a DataTable.
            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            // Now add some rows to the Inventory Table.
            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            // Column 0 is the autoincremented ID field, 
            // so start at 1.
            carRow[1] = "Saab";
            carRow[2] = "Red";
            carRow[3] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            // Mark the primary key of this table.
            inventoryTable.PrimaryKey = new DataColumn[] { inventoryTable.Columns[0] };

            // Finally, add our table to the DataSet.
            ds.Tables.Add(inventoryTable);
        }
        #endregion

        #region Fun with row state
        private static void ManipulateDataRowState()
        {
            // Create a temp DataTable for testing.
            DataTable temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            // RowState = Detached. 
            DataRow row = temp.NewRow();
            Console.WriteLine("After calling NewRow(): {0}", row.RowState);

            // RowState = Added.
            temp.Rows.Add(row);
            Console.WriteLine("After calling Rows.Add(): {0}", row.RowState);

            // RowState = Added.
            row["TempColumn"] = 10;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            // RowState = Unchanged.
            temp.AcceptChanges();
            Console.WriteLine("After calling AcceptChanges: {0}", row.RowState);

            // RowState = Modified.
            row["TempColumn"] = 11;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            // RowState = Deleted.
            temp.Rows[0].Delete();
            Console.WriteLine("After calling Delete: {0}", row.RowState);
        }
        #endregion

        #region Save as XML
        static void SaveAndLoadAsXml(DataSet carsInventoryDS)
        {
            // Save this DataSet as XML.
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");

            // Clear out DataSet.
            carsInventoryDS.Clear();

            // Load DataSet from XML file.
            carsInventoryDS.ReadXml("carsDataSet.xml");
        } 

        #endregion

        #region Save as Binary
        static void SaveAndLoadAsBinary(DataSet carsInventoryDS)
        {
            // Set binary serialization flag.
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;

            // Save this DataSet as binary.
            FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(fs, carsInventoryDS);
            fs.Close();

            // Clear out DataSet.
            carsInventoryDS.Clear();

            // Load DataSet from binary file.
            fs = new FileStream("BinaryCars.bin", FileMode.Open);
            DataSet data = (DataSet)bFormat.Deserialize(fs);
        }
        #endregion
    }
}
