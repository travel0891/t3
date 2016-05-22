using System;
using controller;
using model.table;
using System.Text;
using System.Collections.Generic;

namespace view
{
    public partial class linetest : viewGuest
    {
        protected StringBuilder sbHTML1,sbHTML2;
        protected Int32 tempCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML1 = new StringBuilder();
            sbHTML1.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<examples> listModel = controllerProvider.instance().selectExamples(20);
            sbHTML2 = new StringBuilder();
            foreach (examples item in listModel)
            {
                tempCount++;
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML1.Append("<tr>");
                sbHTML1.AppendFormat("<td colspan=\"4\" class=\"text-left\" style=\"color:#259;\"><strong>{0}、{1}</strong></td>", tempCount, item.example);
                sbHTML1.Append("</tr>");
                sbHTML1.Append("<tr>");
                sbHTML1.AppendFormat("<td style=\"width:25%\"><label><input value=\"A\" type=\"radio\" name=\"{1}\"> {0}</label></td>", item.aCountent, item.charId, item.intId);
                sbHTML1.AppendFormat("<td style=\"width:25%\"><label><input value=\"B\" type=\"radio\" name=\"{1}\"> {0}</label></td>", item.bCountent, item.charId, item.intId);
                sbHTML1.AppendFormat("<td style=\"width:25%\"><label><input value=\"C\" type=\"radio\" name=\"{1}\"> {0}</label></td>", item.cCountent, item.charId, item.intId);
                sbHTML1.AppendFormat("<td style=\"width:25%\"><label><input value=\"D\" type=\"radio\" name=\"{1}\"> {0}</label></td>", item.dCountent, item.charId, item.intId);
                sbHTML1.Append("</tr>");

                String tempStr = String.Empty;
                if (item.optionA == 1)
                {
                    tempStr = "A";
                }
                if (item.optionB == 1)
                {
                    tempStr = "B";
                }
                if (item.optionC == 1)
                {
                    tempStr = "C";
                }
                if (item.optionD == 1)
                {
                    tempStr = "D";
                }
              
                sbHTML2.AppendFormat("{0}={1}&", item.charId, tempStr);
            }
            if (listModel.Count == 0)
            {
                sbHTML1.Append("<tr>");
                sbHTML1.Append("<td><small>暂无数据</small></td>");
                sbHTML1.Append("</tr>");
            }
            sbHTML1.Append("</table>");
            hiValidateTest.Value = sbHTML2.ToString();
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