using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoLotDAL;

namespace AutoLotEDM_GUI
{
    public partial class MainForm : Form
    {
        AutoLotEntities context = new AutoLotEntities(); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Bind the ObjectSet<Inventory> collection to the grid.
            gridInventory.DataSource = context.Inventories;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Data saved!");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Dispose();
        }
    }
}
