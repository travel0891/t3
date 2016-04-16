using System;
using System.Collections.Generic;
using System.Text;

namespace view
{
    using controller;
    using model.table;
   
    public partial class student_action : viewBase
    {
        protected String superCheckbox = String.Empty, genderSelect = String.Empty, passwordInput = String.Empty, selectSelected = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                students editModel = new students();
                editModel.charId = Request.QueryString["charId"];
                students readModel = controllerProvider.instance().selectStudentsByCharId(editModel);
                account.Value = readModel.account;
                passwordInput = readModel.password;
                number.Value = readModel.number;
                name.Value = readModel.name;
                selectSelected = readModel.classes;
                superCheckbox = readModel.super > 0 ? "checked=\"checked\"" : null;
                genderSelect = readModel.gender == 1 ? "selected=\"selected\"" : null;
            }

            StringBuilder sbSelect = new StringBuilder();
            List<classes> listModel = controllerProvider.instance().selectClasses();
            sbSelect.AppendFormat("<select name=\"{0}\" class=\"{1}\" placeholder=\"{2}\">", "classes", "form-control", "必选");
            sbSelect.Append("<option value=\"\">请选择</option>");
            foreach (classes item in listModel)
            {
                sbSelect.AppendFormat("<option {0} ", selectSelected == item.classler ? "selected=\"selected\"" : null);
                sbSelect.AppendFormat("value=\"{0}\">{0}", item.classler);
                sbSelect.Append("</option>");
            }
            sbSelect.Append("<select>");
            clsList.InnerHtml = sbSelect.ToString();
        }
    }
}