using System;
using System.Collections.Generic;
using System.Text;

namespace view
{
    using model.table;
    using view.controller;

    public partial class config_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["configName"]))
            {
                configs model = new configs();
                model.type = Request["configName"];
                controllerProvider.instance().doConfig(1, model);
            }

            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>类型</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<configs> listModel = controllerProvider.instance().selectConfigs();
            foreach (configs item in listModel)
            {
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", item.type);
                sbHTML.AppendFormat("<td class=\"tac\">");
                sbHTML.AppendFormat("<a href=\"javascript:del('{0}');\" class=\"btn btn-default btn-sm\">删除</a>", item.charId);
                sbHTML.AppendFormat("</td>");
                sbHTML.Append("</tr>");
            }
            sbHTML.Append("</tbody>");
            sbHTML.Append("</table>");
            dataList.InnerHtml = sbHTML.ToString();
        }
    }
}