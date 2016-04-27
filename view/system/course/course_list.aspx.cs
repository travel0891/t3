using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace view
{
    using model.table;
    using controller;

    public partial class course_list : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append("<table id=\"tableList\" class=\"table table-striped\" cellspacing=\"0\" width=\"100%\">");
            sbHTML.Append("<thead>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<th>类型</th>");
            sbHTML.Append("<th>章节</th>");
            sbHTML.Append("<th>编号</th>");
            sbHTML.Append("<th>标题</th>");
            sbHTML.Append("<th>内容</th>");
            sbHTML.Append("<th class=\"tac\">创建时间</th>");
            sbHTML.Append("<th class=\"tac\">最后更新</th>");
            sbHTML.Append("<th class=\"tac\">操作</th>");
            sbHTML.Append("</thead>");
            sbHTML.Append("<tbody>");
            List<courses> listModel = controllerProvider.instance().selectCourses();
            foreach (courses item in listModel)
            {
                configs configModel = controllerProvider.instance().selectConfigsByCharId(item.configs_charId);
                parms parmModel = controllerProvider.instance().selectParmsByCharId(item.parms_charId);

                sbHTML.Append("<tr>");
                sbHTML.AppendFormat("<td>{0}</td>", configModel == null ? "-" : configModel.type);
                sbHTML.AppendFormat("<td>{0}</td>", parmModel == null ? "-" : parmModel.chapter);
                sbHTML.AppendFormat("<td>{0}</td>", item.number);
                sbHTML.AppendFormat("<td>{0}</td>", item.title);
                sbHTML.AppendFormat("<td title=\"" + clearHTML(item.contents) + "\">{0}</td>", clearHTML(item.contents).Length > 25 ? clearHTML(item.contents).Substring(0, 25) + " ..." : clearHTML(item.contents));
                sbHTML.AppendFormat("<td class=\"tac\">{0}</td>", item.createTime);
                sbHTML.AppendFormat("<td class=\"tac\">{0}</td>", item.updateTime == item.createTime ? "-" : item.updateTime.ToString());
                sbHTML.AppendFormat("<td class=\"tac\">");
                sbHTML.AppendFormat("<a href=\"course_action.aspx?charId={0}\" class=\"btn btn-primary btn-sm\">编辑</a>", item.charId);
                sbHTML.AppendFormat("<a href=\"javascript:del('{0}');\" class=\"ml6 btn btn-default btn-sm\">删除</a>", item.charId);
                sbHTML.AppendFormat("</td>");
                sbHTML.Append("</tr>");
            }
            sbHTML.Append("</tbody>");
            sbHTML.Append("</table>");
            dataList.InnerHtml = sbHTML.ToString();
        }

        private String clearHTML(String Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
    }
}