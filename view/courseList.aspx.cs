using System;
using System.Collections.Generic;
using System.Text;
using controller;
using model.table;

namespace view
{
    public partial class courseList : viewGuest
    {
        protected StringBuilder sbHTML1;
        protected Int32 tempCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML1 = new StringBuilder();
            sbHTML1.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<courses> listModel1 = controllerProvider.instance().selectCourses();
            foreach (courses item in listModel1)
            {
                tempCount++;
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML1.Append("<tr>");
                sbHTML1.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML1.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML1.AppendFormat("<td class=\"text-left\"><a href=\"courseDetails.aspx?charId={0}\">{1}</a></td>", item.charId, item.title);
                sbHTML1.AppendFormat("<td class=\"text-right\">更新于 {0}</td>", item.updateTime.ToString());
                sbHTML1.Append("</tr>");
            }
            if (listModel1.Count == 0)
            {
                sbHTML1.Append("<tr>");
                sbHTML1.Append("<td><small>暂无数据</small></td>");
                sbHTML1.Append("</tr>");
            }
            sbHTML1.Append("</table>");
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