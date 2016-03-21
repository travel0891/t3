using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    using controller;
    using model.table;
    using System.Text;
    using System.Threading;

    public partial class student_add : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbNO = new StringBuilder();
            for (int i = 1; i <= 110; i++)
            {
                Random rn = new Random();
                Int32 temp1 = rn.Next(100000, 999999);
                Int32 temp2 = rn.Next(1000, 9999);
                Int32 temp3 = rn.Next(1, 3);
                // Thread.Sleep(101);

                sbNO.AppendFormat("{0} - {1} - {2}<br/>", temp1, temp2, temp3);

                students model = new students();
                model.account = "account" + i;
                model.password = temp1.ToString();
                model.name = "user" + i;
                model.number = temp2.ToString();
                model.gender = Convert.ToInt16(temp3);
                model.classes = "主任办";
                // model.createTime = DateTime.Now;
                model.super = 0;
                model.status = 0;
                // controllerProvider.instance().doStudent(1, model);
            }

            //for (int i = 1; i <= 300; i++)
            //{
            //    Random r = new Random();
            //    students m = new students();
            //    m.intId = i;
            //    m.number = "account" + r.Next(1000, 9999);
            //    m.password = r.Next(100000, 999999).ToString();
            //    m.gender = Convert.ToInt16(r.Next(0, 2));
            //    controllerProvider.instance().doStudent(2, m);
            //}
            // Response.Write(sbNO.ToString());
            // Response.End();
        }
    }
}