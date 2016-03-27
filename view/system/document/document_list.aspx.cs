using System;
using System.Collections.Generic;

using System.Text;

namespace view
{
    using model.table;
    using view.controller;

    public partial class document_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String tempUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("/system") + 1);

            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>编号</th>");
            sbHTML.Append("<th>名称</th>");
            sbHTML.Append("<th class=\"tac\">类型</th>");
            sbHTML.Append("<th class=\"tar\">大小(KB)</th>");
            sbHTML.Append("<th class=\"tac\">创建时间</th>");
            // sbHTML.Append("<th class=\"tac\">最后更新</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<documents> listModel = controllerProvider.instance().selectDocuments();
            foreach (documents item in listModel)
            {
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", item.number);
                sbHTML.AppendFormat("<td>{0}</td>", item.title);
                sbHTML.AppendFormat("<td class=\"tac\">{0}</td>", item.type);
                sbHTML.AppendFormat("<td class=\"tar\">{0}</td>", item.size.ToString("#,##0"));
                sbHTML.AppendFormat("<td class=\"tac\">{0}</td>", item.createTime);
                // sbHTML.AppendFormat("<td class=\"tac\">{0}</td>", item.updateTime == item.createTime ? "-" : item.updateTime.ToString());
                sbHTML.AppendFormat("<td class=\"tac\">");
                // sbHTML.AppendFormat("<a href=\"document_action.aspx?charId={0}\" class=\"btn btn-primary btn-sm\">编辑</a>", item.charId);

                sbHTML.Append("<div class=\"btn-group\">");
                sbHTML.AppendFormat("<button type=\"button\" onclick=\"javascript:{0}\" class=\"btn btn-success btn-sm\">下载</button>", "window.open('" + tempUrl + item.url + "')");
                sbHTML.Append("<a class=\"btn btn-success dropdown-toggle btn-sm\" data-toggle=\"dropdown\">");
                sbHTML.Append("<span class=\"caret\"></span>");
                sbHTML.Append("<span class=\"sr-only\">Toggle Dropdown</span>");
                sbHTML.Append("</a>");
                sbHTML.Append("<ul class=\"dropdown-menu\">");
                sbHTML.AppendFormat("<li><a href=\"javascript:;\" onclick=\"javascript:layer.alert('{0}');\">查看下载地址</button></a>", tempUrl + item.url);
                sbHTML.Append("</ul>");
                sbHTML.Append("</div>");

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