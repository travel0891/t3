using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using model.table;

namespace view
{
    public partial class documentList : viewGuest
    {
        protected StringBuilder sbHTML2;
        protected Int32 tempCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML2 = new StringBuilder();
            sbHTML2.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<documents> listModel2 = controllerProvider.instance().selectDocuments();
            foreach (documents item in listModel2)
            {
                tempCount++;
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);
                sbHTML2.Append("<tr>");
                sbHTML2.AppendFormat("<td style=\"width:100px\">{0}</td>", item.number);
                sbHTML2.AppendFormat("<td style=\"width:160px\" class=\"text-left\"><span class=\"label label-primary\">{0}</span> <span class=\"label label-info\">{1}</span></td>", configModel == null ? "-" : configModel.type, parmModel == null ? "-" : parmModel.chapter);
                if (Session["tempUser"] == null)
                {
                    sbHTML2.AppendFormat("<td class=\"text-left\"><a title=\"大小 {3} KB\" href=\"javascript:alert('您还未登录，无法下载！');\">{1}.{2}</a></td>", item.charId, item.title, item.type, item.size);
                }
                else
                {
                    sbHTML2.AppendFormat("<td class=\"text-left\"><a title=\"大小 {3} KB\" target=\"_blank\" href=\"{4}\">{1}.{2}</a></td>", item.charId, item.title, item.type, item.size, item.url);
                }
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