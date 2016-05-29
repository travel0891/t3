using System;
using System.Collections.Generic;
using System.Text;

namespace view
{
    using controller;
    using model.table;

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
            List<students> listModel = controllerProvider.instance().selectStudents(0);
            foreach (students item in listModel)
            {
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", item.number);
                sbHTML.AppendFormat("<td>{0}</td>", item.name);
                sbHTML.AppendFormat("<td>{0}</td>", genderString(item.gender));
                sbHTML.AppendFormat("<td>{0}</td>", item.classes);
                sbHTML.AppendFormat("<td>{0}</td>", item.account);
                sbHTML.AppendFormat("<td>{0}</td>", item.password);
                sbHTML.AppendFormat("<td>{0}</td>", item.super == 0 ? "学生" : "管理员");
                sbHTML.AppendFormat("<td class=\"tac\">");
                sbHTML.AppendFormat("<a href=\"{0}_action.aspx?charId={1}\" class=\"btn btn-primary btn-sm\">编辑</a>", item.super == 0 ? "student" : "manager", item.charId);
                sbHTML.AppendFormat("<a href=\"javascript:del('{0}');\" class=\"ml6 btn btn-default btn-sm\">删除</a>", item.charId);
                sbHTML.AppendFormat("</td>");
                sbHTML.Append("</tr>");
            }
            sbHTML.Append("</tbody>");
            sbHTML.Append("</table>");
            dataList.InnerHtml = sbHTML.ToString();
        }
        private String genderString(Int16 index)
        {
            switch (index)
            {
                case 1:
                    return "男";
                case 2:
                    return "女";
                default:
                    return "-";
            }
        }
    }
}