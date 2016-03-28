using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class login : viewBase
    {
        protected String account = String.Empty, password = String.Empty, keep = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
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