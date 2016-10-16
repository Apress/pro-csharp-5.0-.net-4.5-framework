using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private void ListControlsInPanel()
    {
        string theInfo = "";
        theInfo = string.Format("<b>Does the panel have controls? {0} </b><br/>",
          myPanel.HasControls());

        // Get all controls in the panel.
        foreach (Control c in myPanel.Controls)
        {
            if (!object.ReferenceEquals(c.GetType(),
              typeof(System.Web.UI.LiteralControl)))
            {
                theInfo += "***************************<br/>";
                theInfo += string.Format("Control Name? {0} <br/>", c.ToString());
                theInfo += string.Format("ID? {0} <br>", c.ID);
                theInfo += string.Format("Control Visible? {0} <br/>", c.Visible);
                theInfo += string.Format("ViewState? {0} <br/>", c.EnableViewState);
            }
        }
        lblControlInfo.Text = theInfo;
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        ListControlsInPanel();
    }
    protected void btnClearPanel_Click(object sender, System.EventArgs e)
    {
        // Clear all content from the panel, then re-list items.
        myPanel.Controls.Clear();
        ListControlsInPanel();
    }

    protected void btnAddWidgets_Click(object sender, System.EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            // Assign an ID so we can get
            // the text value out later
            // using the incoming form data.
            TextBox t = new TextBox();
            t.ID = string.Format("newTextBox{0}", i);
            myPanel.Controls.Add(t);
            ListControlsInPanel();
        }
    }

    protected void btnGetTextData_Click(object sender, System.EventArgs e)
    {
        // Get teach text box by name.
        string lableData = string.Format("<li>{0}</li><br/>",
          Request.Form.Get("newTextBox0"));
        lableData += string.Format("<li>{0}</li><br/>",
          Request.Form.Get("newTextBox1"));
        lableData += string.Format("<li>{0}</li><br/>",
          Request.Form.Get("newTextBox2"));
        lblTextBoxData.Text = lableData;
    }
}
