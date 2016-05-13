using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model.table;
using System.Text;
using controller;
using System.Text.RegularExpressions;

namespace view
{
    public partial class index : viewGuest
    {
        protected StringBuilder sbHTML1, sbHTML2, sbHTML3;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML1 = new StringBuilder();
            sbHTML1.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<courses> listModel1 = controllerProvider.instance().selectCourses(5);
            foreach (courses item in listModel1)
            {
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML1.Append("<tr>");
                sbHTML1.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML1.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML1.AppendFormat("<td class=\"text-left\"><a href=\"\">{0}</a></td>", item.title);
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

            sbHTML2 = new StringBuilder();
            sbHTML2.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<documents> listModel2 = controllerProvider.instance().selectDocuments(5);
            foreach (documents item in listModel2)
            {
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML2.Append("<tr>");
                sbHTML2.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML2.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML2.AppendFormat("<td class=\"text-left\"><a href=\"\">{0}</a></td>", item.title);//<span class=\"label label-warning\">{1}</span> item.type
                // sbHTML2.AppendFormat("<td class=\"text-right\"><span class=\"label label-default\">{0} KB</span></td>", item.size.ToString("#,##0"));
                sbHTML2.AppendFormat("<td class=\"text-right\">上传于 {0}</td>", item.updateTime.ToString());
                sbHTML2.Append("</tr>");
            }
            if (listModel2.Count == 0)
            {
                sbHTML2.Append("<tr>");
                sbHTML2.Append("<td><small>暂无数据</small></td>");
                sbHTML2.Append("</tr>");
            }
            sbHTML2.Append("</table>");

            sbHTML3 = new StringBuilder();
            sbHTML3.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<examples> listModel3 = controllerProvider.instance().selectExamples(5);
            foreach (examples item in listModel3)
            {
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML3.Append("<tr>");
                sbHTML3.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML3.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML3.AppendFormat("<td class=\"text-left\"><a href=\"\">{0}</a></td>", item.example);
                sbHTML3.AppendFormat("<td class=\"text-right\"><span class=\"label label-danger\">选择题</span></td>");
                sbHTML3.Append("</tr>");
            }

            List<qandas> listModel4 = controllerProvider.instance().selectQandas(5);
            foreach (qandas item in listModel4)
            {
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML3.Append("<tr>");
                sbHTML3.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML3.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                sbHTML3.AppendFormat("<td class=\"text-left\"><a href=\"\">{0}</a></td>", item.qanda);
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