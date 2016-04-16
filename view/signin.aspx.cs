using System;
using System.Web;

namespace view
{
    public partial class signin : viewBase
    {
        protected String account = String.Empty, password = String.Empty, keep = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookies = Request.Cookies.Get("keepLineStu");
            if (cookies != null)
            {
                account = Server.HtmlEncode(cookies["account"]);
                password = Server.HtmlEncode(cookies["password"]);
                keep = !String.IsNullOrEmpty(account) ? "checked=\"checked\"" : "";
            }
        }
    }
}