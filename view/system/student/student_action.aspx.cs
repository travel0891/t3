using System;

namespace view
{
    using controller;
    using model.table;

    public partial class student_action : viewBase
    {
        protected String superCheckbox = String.Empty, genderSelect = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                students editModel = new students();
                editModel.charId = Request.QueryString["charId"];
                students readModel = controllerProvider.instance().selectStudentsByCharId(editModel);
                account.Value = readModel.account;
                password.Value = readModel.password;
                number.Value = readModel.number;
                name.Value = readModel.name;
                classes.Value = readModel.classes;
                superCheckbox = readModel.super > 0 ? "checked=\"checked\"" : null;
                genderSelect = readModel.gender == 1 ? "selected=\"selected\"" : null;
            }
        }
    }
}