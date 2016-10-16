using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace AutoLotDisconnectedLayer
{
    public class InventoryDALDisLayer
    {
        // Field data.
        private string cnString = string.Empty;
        private SqlDataAdapter dAdapt = null;

        public InventoryDALDisLayer(string connectionString)
        {
            cnString = connectionString;

            // Configure the SqlDataAdapter.
            ConfigureAdapter(out dAdapt);
        }

        private void ConfigureAdapter(out SqlDataAdapter dAdapt)
        {
            // Create the adapter and set up the SelectCommand.
            dAdapt = new SqlDataAdapter("Select * From Inventory", cnString);

            // Obtain the remaining command objects dynamically at runtime
            // using the SqlCommandBuilder.
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
        }

        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            dAdapt.Fill(inv);
            return inv;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            dAdapt.Update(modifiedTable);
        }
    }
}
