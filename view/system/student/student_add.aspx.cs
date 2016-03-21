using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    using controller;
    using model.table;

    public partial class student_add : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 300; i++)
            {
                students model = new students();
                model.account = "account" + i;
                model.password = new Random().Next(100000, 999999).ToString();
                model.name = "user" + i;
                model.number = new Random().Next(1000, 9999).ToString();
                model.gender = Convert.ToInt16(i / 2);
                model.classes = "主任办";
                model.createTime = DateTime.Now;
                model.super = 0;
                model.status = 0;
                controllerProvider.instance().doStudent(1, model);
            }

            for (int i = 1; i <= 300; i++)
            {
                Random r = new Random();
                students m = new students();
                m.intId = i;
                m.number = "account" + r.Next(1000, 9999);
                m.password = r.Next(100000, 999999).ToString();
                m.gender = Convert.ToInt16(r.Next(0, 2));
                controllerProvider.instance().doStudent(2, m);
            }
        }
    }
}