using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetBrowserStats_Click(object sender, EventArgs e)
    {
        string theInfo = "";
        theInfo += string.Format("<li>Is the client AOL? {0}</li>",
          Request.Browser.AOL);
        theInfo += string.Format("<li>Does the client support ActiveX? {0}</li>",
          Request.Browser.ActiveXControls);
        theInfo += string.Format("<li>Is the client a Beta? {0}</li>",
          Request.Browser.Beta);
        theInfo += string.Format("<li>Does the client support Java Applets? {0}</li>",
          Request.Browser.JavaApplets);
        theInfo += string.Format("<li>Does the client support Cookies? {0}</li>",
          Request.Browser.Cookies);
        theInfo += string.Format("<li>Does the client support VBScript? {0}</li>",
          Request.Browser.VBScript);
        lblOutput.Text = theInfo;
    }

}