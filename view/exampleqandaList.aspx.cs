using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using model.table;
using controller;

namespace view
{
    public partial class exampleqandaList : viewGuest
    {
        protected StringBuilder sbHTML3;
        protected Int32 tempCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML3 = new StringBuilder();
            sbHTML3.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<examples> listModel3 = controllerProvider.instance().selectExamples(5);
            foreach (examples item in listModel3)
            {
                tempCount++;
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML3.Append("<tr>");
                sbHTML3.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML3.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML3.AppendFormat("<td class=\"text-left\"><a href=\"exampleqandaDetails.aspx?charId1={0}\">{1}</a></td>", item.charId, item.example);
                sbHTML3.AppendFormat("<td class=\"text-right\"><span class=\"label label-danger\">选择题</span></td>");
                sbHTML3.Append("</tr>");
            }

            List<qandas> listModel4 = controllerProvider.instance().selectQandas(5);
            foreach (qandas item in listModel4)
            {
                tempCount++;
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML3.Append("<tr>");
                sbHTML3.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML3.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML3.AppendFormat("<td class=\"text-left\"><a href=\"exampleqandaDetails.aspx?charId2={0}\">{1}</a></td>", item.charId, item.qanda);
                sbHTML3.AppendFormat("<td class=\"text-right\"><span class=\"label label-warning\">问答题</span></td>");
                sbHTML3.Append("</tr>");
            }

            if (listModel3.Count == 0 && listModel4.Count == 0)
            {
                sbHTML3.Append("<tr>");
                sbHTML3.Append("<td><small>暂无数据</small></td>");
                sbHTML3.Append("</tr>");
            }
            sbHTML3.Append("</table>");
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