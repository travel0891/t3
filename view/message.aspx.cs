using System;
using System.Collections.Generic;
using System.Text;
using controller;
using model.table;

namespace view
{
    public partial class message : viewGuest
    {
        protected StringBuilder sbHTML1;
        protected Int32 tempCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sbHTML1 = new StringBuilder();
            sbHTML1.Append("<table class=\"table table-hover\" cellspacing=\"0\" width=\"100%\">");
            List<messages> listModel1 = controllerProvider.instance().selectMessages();
            foreach (messages item in listModel1)
            {
                tempCount++;
                sbHTML1.Append("<tr>");
                students inModel = new students();
                inModel.charId = item.students_charId;
                students tempModel = controllerProvider.instance().selectStudentsByCharId(inModel);
                sbHTML1.AppendFormat("<td class=\"text-left\" style=\"width:45px\"><span class=\"label label-warning\">提问</span>");

                if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0] == "1")
                {
                    sbHTML1.AppendFormat("<td class=\"text-left\" title=\"{2}\" style=\"color:#259;\"><strong>{1}</strong> <a href=\"javascript:doDel('{0}','{2}');\">[ 删除提问 ]</a></td>", item.charId, str(item.title, 50), item.title.Replace("'", null));
                }
                else
                {
                    sbHTML1.AppendFormat("<td class=\"text-left\" title=\"{2}\" style=\"color:#259;\"><strong>{1}</strong></td>", item.charId, str(item.title, 50), item.title);
                }
                sbHTML1.AppendFormat("<td class=\"text-right\"><b>{0}.{1} {2}</b></td>", tempModel.classes, tempModel.name, item.createTime.ToString());
                sbHTML1.Append("</tr>");
                sbHTML1.Append("<tr>");
                sbHTML1.AppendFormat("<td class=\"text-left\" style=\"width:45px\"><span class=\"label label-success\">回答</span>");
                if (item.replyTime == item.createTime)
                {
                    if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0] == "1")
                    {
                        sbHTML1.AppendFormat("<td colspan=\"2\" class=\"text-left\"><a href=\"javascript:doAdd('{0}');\">[ 立即回答 ]</a></td>", item.charId);
                    }
                    else
                    {
                        sbHTML1.AppendFormat("<td colspan=\"2\" class=\"text-left\"><b>暂无回答</b></td>", item.charId);
                    }
                }
                else
                {
                    if (Session["tempUser"] != null && Session["tempUser"].ToString().Split(',')[0]=="1")
                    {
                        sbHTML1.AppendFormat("<td colspan=\"2\">{1} <b>管理员 {2}</b> <a href=\"javascript:doEdit('{0}','{1}');\">[ 编辑回答 ]</a></td>", item.charId, item.reply.Replace("'",null), item.replyTime);
                    }
                    else
                    {
                        sbHTML1.AppendFormat("<td colspan=\"2\">{1} <b>管理员 {2}</b></td>", item.charId, item.reply, item.replyTime);
                    }
                }
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

        private String str(String str, Int32 len)
        {
            return str.Length > len ? str.Substring(0, len - 2) + "..." : str;
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