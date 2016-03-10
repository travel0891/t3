using System;
using System.Collections.Generic;
using System.Web;

namespace view.controller
{
    using utils;
    using view.model;

    public class c_user
    {
        public static List<user> userList(Int32 a, Int32 b, out Int32 sqlSum)
        {
            List<user> listModel = new List<user>();

            user model = new user();
            model.Name = "foreach";
            model.Age = query.GetInstance().scalarInt(" select " + a + "*" + b + " ", null);
            model.UpdateTime = DateTime.Parse(query.GetInstance().scalarString(" select getdate() ", null));

            listModel.Add(model);

            sqlSum = model.Age;

            return listModel;
        }
    }
}