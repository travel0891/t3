using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model.table;
using controller;
using System.Text;

namespace view
{
    public partial class courseDetails : viewGuest
    {
        protected String number, title, hiContents, selectSelected1, selectSelected2, tempConfig, tempParm, tempTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                courses editModel = new courses();
                editModel.charId = Request.QueryString["charId"];
                courses readModel = controllerProvider.instance().selectCoursesByCharId(editModel);
                number = readModel.number;
                title = readModel.title;
                hiContents = readModel.contents;
                tempConfig = controllerProvider.instance().selectConfigsByCharId(readModel.configs_charId).type;
                tempParm = controllerProvider.instance().selectParmsByCharId(readModel.parms_charId).chapter;
                tempTime = readModel.updateTime.ToString();
            }
        }

        protected String getUserInfo(String sessionString)
        {
            students studentModel = new students();
            studentModel.charId = sessionString.Split(',')[1];
            studentModel = controllerProvider.instance().selectStudentsByCharId(studentModel);

            if (Convert.ToInt16(studentModel.super) == 0)
            {
                return studentModel.classes + "." + studentModel.name;
            }
            else
            {
                return "管理员";
            }
        }
    }
}