using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace view
{
    using model.table;
    using controller;

    public partial class student_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>学号</th>");
            sbHTML.Append("<th>姓名</th>");
            sbHTML.Append("<th>性别</th>");
            sbHTML.Append("<th>班级</th>");
            sbHTML.Append("<th>账号</th>");
            sbHTML.Append("<th>密码</th>");
            sbHTML.Append("<th>角色</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<students> listModel = controllerProvider.instance().selectStudents();
            foreach (students item in listModel)
            {
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", item.number);
                sbHTML.AppendFormat("<td>{0}</td>", item.name);
                sbHTML.AppendFormat("<td>{0}</td>", item.gender == 1 ? "男" : "女");
                sbHTML.AppendFormat("<td>{0}</td>", item.classes);
                sbHTML.AppendFormat("<td>{0}</td>", item.account);
                sbHTML.AppendFormat("<td>{0}</td>", item.password);
                sbHTML.AppendFormat("<td>{0}</td>", item.super == 0 ? "普通" : "管理员");
                sbHTML.AppendFormat("<td class=\"tac\">");
                sbHTML.AppendFormat("<a href=\"student_action.aspx?charId={0}\" class=\"btn btn-primary btn-sm\">编辑</a>", item.charId);
                sbHTML.AppendFormat("<a href=\"javascript:del('{0}');\" class=\"ml6 btn btn-default btn-sm\">删除</a>", item.charId);
                sbHTML.AppendFormat("</td>");
                sbHTML.Append("</tr>");
            }
            sbHTML.Append("</tbody>");
            sbHTML.Append("</table>");
            dataList.InnerHtml = sbHTML.ToString();
        }
    }
}