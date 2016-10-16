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

    }
    protected void btnCookie_Click(object sender, EventArgs e)
    {
        // Make a new (temp) cookie.
        HttpCookie theCookie =
             new HttpCookie(txtCookieName.Text,
             txtCookieValue.Text);
        theCookie.Expires = DateTime.Parse("03/24/2009");
        Response.Cookies.Add(theCookie);
    }

    protected void btnShowCookie_Click(object sender, EventArgs e)
    {
        string cookieData = "";
        foreach (string s in Request.Cookies)
        {
            cookieData +=
                 string.Format("<li><b>Name</b>: {0}, <b>Value</b>: {1}</li>",
                      s, Request.Cookies[s].Value);
        }
        lblCookieData.Text = cookieData;
    }
}