using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view.manage
{
    public partial class login : viewBase
    {
        protected String name = String.Empty, password = String.Empty, keep = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookies = Request.Cookies.Get("keepLine");
            if (cookies != null)
            {
                name = Server.HtmlEncode(cookies["name"]);
                password = Server.HtmlEncode(cookies["password"]);
                keep = !String.IsNullOrEmpty(name) ? "checked=\"checked\"" : "";
            }
        }
    }
}