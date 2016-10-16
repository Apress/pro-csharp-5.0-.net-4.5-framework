using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Fill ListBox dynamically!
            myListBox.Items.Add("Item One");
            myListBox.Items.Add("Item Two");
            myListBox.Items.Add("Item Three");
            myListBox.Items.Add("Item Four");
        }
    }
    protected void btnPostback_Click(object sender, EventArgs e)
    {
        // No-op. This is just here to allow a post back.
    }
    protected void btnAddToVS_Click(object sender, EventArgs e)
    {
        ViewState["CustomViewStateItem"] = "Some user data";
        lblVSValue.Text = (string)ViewState["CustomViewStateItem"];
    }
}