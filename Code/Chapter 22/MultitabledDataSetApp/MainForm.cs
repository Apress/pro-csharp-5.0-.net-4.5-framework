using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace MultitabledDataSetApp
{
    public partial class MainForm : Form
    {
        // Form wide DataSet.
        private DataSet autoLotDS = new DataSet("AutoLot");

        // Make use of command builders to simplify data adapter configuration.
        private SqlCommandBuilder sqlCBInventory;
        private SqlCommandBuilder sqlCBCustomers;
        private SqlCommandBuilder sqlCBOrders;

        // Our data adapters (for each table).
        private SqlDataAdapter invTableAdapter;
        private SqlDataAdapter custTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        // Form wide connection string.
        private string cnStr = string.Empty;

        #region Ctor logic
        public MainForm()
        {
            InitializeComponent();

            // Get connection string.
            cnStr =
              ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Create adapters.
            invTableAdapter = new SqlDataAdapter("Select * from Inventory", cnStr);
            custTableAdapter = new SqlDataAdapter("Select * from Customers", cnStr);
            ordersTableAdapter = new SqlDataAdapter("Select * from Orders", cnStr);

            // Autogenerate commands.
            sqlCBInventory = new SqlCommandBuilder(invTableAdapter);
            sqlCBOrders = new SqlCommandBuilder(ordersTableAdapter);
            sqlCBCustomers = new SqlCommandBuilder(custTableAdapter);

            // Add tables to DS.
            invTableAdapter.Fill(autoLotDS, "Inventory");
            custTableAdapter.Fill(autoLotDS, "Customers");
            ordersTableAdapter.Fill(autoLotDS, "Orders");

            // Build relations between tables.
            BuildTableRelationship();

            // Bind to grids
            dataGridViewInventory.DataSource = autoLotDS.Tables["Inventory"];
            dataGridViewCustomers.DataSource = autoLotDS.Tables["Customers"];
            dataGridViewOrders.DataSource = autoLotDS.Tables["Orders"];
        }
        #endregion

        #region Build table relationships
        private void BuildTableRelationship()
        {
            // Create CustomerOrder data relation object.
            DataRelation dr = new DataRelation("CustomerOrder",
                 autoLotDS.Tables["Customers"].Columns["CustID"],
                 autoLotDS.Tables["Orders"].Columns["CustID"]);
            autoLotDS.Relations.Add(dr);

            // Create InventoryOrder data relation object.
            dr = new DataRelation("InventoryOrder",
                 autoLotDS.Tables["Inventory"].Columns["CarID"],
                 autoLotDS.Tables["Orders"].Columns["CarID"]);
            autoLotDS.Relations.Add(dr);
        }
        #endregion

        #region Update Tables
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                invTableAdapter.Update(autoLotDS, "Inventory");
                custTableAdapter.Update(autoLotDS, "Customers");
                ordersTableAdapter.Update(autoLotDS, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Get Order Details
        private void btnGetOrderInfo_Click(object sender, System.EventArgs e)
        {
            string strOrderInfo = string.Empty;
            DataRow[] drsCust = null;
            DataRow[] drsOrder = null;

            // Get the customer ID in the text box.
            int custID = int.Parse(this.txtCustID.Text);

            // Now based on custID, get the correct row in Customers table.
            drsCust = autoLotDS.Tables["Customers"].Select(string.Format("CustID = {0}", custID));
            strOrderInfo += string.Format("Customer {0}: {1} {2}\n",
              drsCust[0]["CustID"].ToString(),
              drsCust[0]["FirstName"].ToString().Trim(),
              drsCust[0]["LastName"].ToString().Trim());

            // Navigate from customer table to order table.
            drsOrder = drsCust[0].GetChildRows(autoLotDS.Relations["CustomerOrder"]);

            // Loop through all orders for this customer.
            foreach (DataRow order in drsOrder)
            {
                strOrderInfo += string.Format("----\nOrder Number: {0}\n", order["OrderID"]);

                // Get the car referenced by this order.
                DataRow[] drsInv = order.GetParentRows(autoLotDS.Relations["InventoryOrder"]);

                // Get info for (SINGLE) car info for this order.
                DataRow car = drsInv[0];
                strOrderInfo += string.Format("Make: {0}\n", car["Make"]);
                strOrderInfo += string.Format("Color: {0}\n", car["Color"]);
                strOrderInfo += string.Format("Pet Name: {0}\n", car["PetName"]);
            }

            MessageBox.Show(strOrderInfo, "Order Details");
        }
        #endregion
    }
}