using System;
using System.Web;

namespace view
{
    public partial class login : viewGuest
    {
        protected String account = String.Empty, password = String.Empty, keep = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["logout"]))
            {
                Session.Remove("tempUser");
            }

            if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0] == "1")
            {
                Response.Redirect("../system/mainframe.html");
            }

            HttpCookie cookies = Request.Cookies.Get("keepLine");
            if (cookies != null)
            {
                account = Server.HtmlEncode(cookies["account"]);
                password = Server.HtmlEncode(cookies["password"]);
                keep = !String.IsNullOrEmpty(account) ? "checked=\"checked\"" : "";
            }
        }
    }
}