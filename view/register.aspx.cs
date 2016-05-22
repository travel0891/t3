using System;
using System.Web;
using System.Text;
using model.table;
using controller;
using System.Collections.Generic;

namespace view
{
    public partial class register : viewGuest
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbSelect = new StringBuilder();
            List<classes> listModel = controllerProvider.instance().selectClasses();
            sbSelect.AppendFormat("<select name=\"{0}\" class=\"{1}\" placeholder=\"{2}\">", "classes", "form-control", "必选");
            sbSelect.Append("<option value=\"\">请选择班级</option>");
            foreach (classes item in listModel)
            {
                sbSelect.AppendFormat("<option value=\"{0}\">{0}</option>", item.classler);
            }
            sbSelect.Append("<select>");
            clsList.InnerHtml = sbSelect.ToString();
        }
    }
}