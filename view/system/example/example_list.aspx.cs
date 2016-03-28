﻿using System;
using System.Collections.Generic;
using System.Text;

namespace view
{
    using model.table;
    using view.controller;

    public partial class example_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>编号</th>");
            sbHTML.Append("<th>题目</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<examples> listModel = controllerProvider.instance().selectExamples();
            foreach (examples item in listModel)
            {
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", item.number);
                sbHTML.AppendFormat("<td title=\"" + item.example + "\">{0}</td>", item.example.Length > 50 ? item.example.Substring(0, 50) + "..." : item.example);
                sbHTML.AppendFormat("<td class=\"tac\">");
                //sbHTML.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"javascript:layer.alert('{0}');\" class=\"btn btn-success btn-sm\">查看</a>", item.charId);
                sbHTML.AppendFormat("<a href=\"example_action.aspx?charId={0}\" class=\"btn btn-primary btn-sm\">编辑</a>", item.charId);//ml6
                sbHTML.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"javascript:del('{0}');\" class=\"ml6 btn btn-default btn-sm\">删除</a>", item.charId);
                sbHTML.AppendFormat("</td>");
                sbHTML.Append("</tr>");
            }
            sbHTML.Append("</tbody>");
            sbHTML.Append("</table>");
            dataList.InnerHtml = sbHTML.ToString();
        }
    }
}