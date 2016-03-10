using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    using model;
    using controller;
    using System.Text;

    public partial class index : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbHTML = new StringBuilder();
            Int32 sum = 0, sqlSum = 0;

            Random random = new Random();
            for (int i = 1; i <= 1000; i++)
            {
                Int32 a = random.Next(100, 999), b = random.Next(100, 999);

                foreach (user item in c_user.userList(a, b, out sqlSum))
                {
                    sum = a * b;
                    sbHTML.AppendFormat(" id {4} {0} + {1} = {2} {5} {6} {3} ", a, b, item.Age, "<br/>", i, sqlSum, item.UpdateTime);
                }
            }

            Response.Write(sbHTML.ToString());
        }
    }
}