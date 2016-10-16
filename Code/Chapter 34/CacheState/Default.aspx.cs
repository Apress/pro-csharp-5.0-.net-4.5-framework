using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using AutoLotConnectedLayer;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carsGridView.DataSource = (DataSet)Cache["AppDataSet"];
            carsGridView.DataBind();
        }
    }
    protected void btnAddCar_Click(object sender, EventArgs e)
    {
        // Update the Inventory table
        // and call RefreshGrid().
        InventoryDAL dal = new InventoryDAL();
        dal.OpenConnection(@"Data Source=(local)\SQLEXPRESS;" +
          "Initial Catalog=AutoLot;Integrated Security=True");
        dal.InsertAuto(int.Parse(txtCarID.Text), txtCarColor.Text,
          txtCarMake.Text, txtCarPetName.Text);
        dal.CloseConnection();
        RefreshGrid();

    }
    private void RefreshGrid()
    {
        InventoryDAL dal = new InventoryDAL();
        dal.OpenConnection(@"Data Source=(local)\SQLEXPRESS;" +
          "Initial Catalog=AutoLot;Integrated Security=True");
        DataTable theCars = dal.GetAllInventoryAsDataTable();
        dal.CloseConnection();

        carsGridView.DataSource = theCars;
        carsGridView.DataBind();
    }
}