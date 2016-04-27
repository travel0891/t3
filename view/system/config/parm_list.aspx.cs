using System;
using System.Collections.Generic;
using System.Text;

namespace view
{
    using model.table;
    using controller;

    public partial class parm_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["parmName"]) && !String.IsNullOrEmpty(Request["configCharId"]))
            {
                parms model = new parms();
                model.configs_charId = Request["configCharId"];
                model.chapter = Request["parmName"];
                controllerProvider.instance().doParm(1, model);
            }

            StringBuilder sbHTML = new StringBuilder();
            List<configs> listConfig = controllerProvider.instance().selectConfigs();
            if (listConfig.Count == 0)
            {
                sbHTML.AppendFormat("<li><a data-charid=\"{0}|{1}\" href=\"javascript:void(0);\">{1}</a></li>", "00000000-0000-0000-0000-000000000000", "暂无类型");
            }
            else
            {
                foreach (configs config in listConfig)
                {
                    sbHTML.AppendFormat("<li><a data-charid=\"{0}|{1}\" href=\"javascript:void(0);\">{1}</a></li>", config.charId, config.type);
                }
            }
            selectList.InnerHtml = sbHTML.ToString();

            sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>类型</th>");
            sbHTML.Append("<th>章节</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<parms> listModel = controllerProvider.instance().selectParms();
            foreach (parms item in listModel)
            {
                configs tempModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", tempModel == null ? "-" : tempModel.type);
                sbHTML.AppendFormat("<td>{0}</td>", item.chapter);
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