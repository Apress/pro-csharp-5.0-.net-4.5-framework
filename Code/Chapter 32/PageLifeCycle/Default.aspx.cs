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
    public _Default()
    {
        // Explicitly hook into the Load and Unload events.
        this.Load +=new EventHandler(Page_Load);
        this.Unload += new EventHandler(Page_Unload);
        this.Error += new EventHandler(_Default_Error);
    }

    void _Default_Error(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Write("I am sorry...I can't find a required file.<br>");
        Response.Write(string.Format("The error was: <b>{0}</b>",
            Server.GetLastError().Message));
        Server.ClearError();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Load event fired!");
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // No longer possible to emit data to the HTTP
        // response, so we will write to a local file.
        System.IO.File.WriteAllText(@"C:\MyLog.txt", "Page unloading!");
    }

    protected void btnPostback_Click(object sender, EventArgs e)
    {
        // Nothing happens here, this is just to ensure a 
        // postback to the page. 
    }
    protected void btnTriggerError_Click(object sender, EventArgs e)
    {
        System.IO.File.ReadAllText(@"C:\IDontExist.txt");
    }
}