using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
    public partial class MainForm : Form
    {
        // A collection of Car objects.
        List<Car> listCars = new List<Car>();

        // Inventory information
        DataTable inventoryTable = new DataTable();

        // View of the DataTable.
        DataView yugosOnlyView;

        public MainForm()
        {
            InitializeComponent();

            // Fill the list with some cars.
            listCars = new List<Car> 
            {
                new Car { ID = 100, PetName = "Chucky", Make = "BMW", Color = "Green" },
                new Car { ID = 101, PetName = "Tiny", Make = "Yugo", Color = "White" },
                new Car { ID = 102, PetName = "Ami", Make = "Jeep", Color = "Tan" },
                new Car { ID = 103, PetName = "Pain Inducer", Make = "Caravan", Color = "Pink" },
                new Car { ID = 104, PetName = "Fred", Make = "BMW", Color = "Green" },
                new Car { ID = 105, PetName = "Sidd", Make = "BMW", Color = "Black" },
                new Car { ID = 106, PetName = "Mel", Make = "Firebird", Color = "Red" },
                new Car { ID = 107, PetName = "Sarah", Make = "Colt", Color = "Black" },
            };

            CreateDataTable();

            // Make a view.
            CreateDataView();

        }

        #region Create the data table
        void CreateDataTable()
        {
            // Create table schema.
            DataColumn carIDColumn = new DataColumn("ID", typeof(int));
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, 
                carColorColumn, carPetNameColumn });

            // Iterate over the array list to make rows.
            foreach (Car c in listCars)
            {
                DataRow newRow = inventoryTable.NewRow();
                newRow["ID"] = c.ID;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                inventoryTable.Rows.Add(newRow);
            }

            // Bind the DataTable to the carInventoryGridView.
            carInventoryGridView.DataSource = inventoryTable;
        }
        #endregion

        #region Delete row
        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            try
            {
                // Find the correct row to delete.
                DataRow[] rowToDelete = inventoryTable.Select(string.Format("ID={0}", int.Parse(txtCarToRemove.Text)));
                
                // Delete it!
                rowToDelete[0].Delete();
                inventoryTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Display petnames for makes
        private void btnDisplayMakes_Click(object sender, EventArgs e)
        {
            // Build a filter based on user input.
            string filterStr = string.Format("Make= '{0}'", txtMakeToView.Text);

            // Find all rows matching the filter.
            DataRow[] makes = inventoryTable.Select(filterStr);

            // Show what we got!
            if (makes.Length == 0)
                MessageBox.Show("Sorry, no cars...", "Selection error!");
            else
            {
                string strMake = null;
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["PetName"] + "\n";
                }
                // Now show all matches in a message box.
                MessageBox.Show(strMake,
                  string.Format("We have {0}s named:", txtMakeToView.Text));
            }
        }
        #endregion

        #region Change makes
        // Find the rows you want to edit with a filter.
        private void btnChangeMakes_Click(object sender, EventArgs e)
        {
            // Make sure user has not lost his or her mind.
            if (DialogResult.Yes ==
              MessageBox.Show("Are you sure?? BMWs are much nicer than Yugos!",
                "Please Confirm!", MessageBoxButtons.YesNo))
            {
                // Build a filter.
                string filterStr = "Make='BMW'";
                string strMake = string.Empty;

                // Find all rows matching the filter.
                DataRow[] makes = inventoryTable.Select(filterStr);

                // Change all Beemers to Yugos!
                for (int i = 0; i < makes.Length; i++)
                {
                    makes[i]["Make"] = "Yugo";
                }
            }
        }
        #endregion

        #region Make a view
        private void CreateDataView()
        {
            // Set the table that is used to construct this view.
            yugosOnlyView = new DataView(inventoryTable);

            // Now configure the views using a filter.
            yugosOnlyView.RowFilter = "Make = 'Yugo'";

            // Bind to the new grid.
            dataGridYugosView.DataSource = yugosOnlyView;
        }
        #endregion
    }
}
