using System;

namespace view
{
    using model.table;
    using view.controller;

    public partial class document_action : viewBase
    {
        protected String fileA = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                String tempUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("/system") + 1);
                documents editModel = new documents();
                editModel.charId = Request.QueryString["charId"];
                documents readModel = controllerProvider.instance().selectDocumentsByCharId(editModel);
                number.Value = readModel.number;
                title.Value = readModel.title;
                size.Value = readModel.size.ToString();
                fileA = "<a href=\"javascript:void(0);\" onclick=\"javascript:window.open('" + tempUrl + readModel.url + "')\" class=\"btn btn-success btn-sm\">点击下载 大小 " + readModel.size + "KB 类型 " + readModel.type + "</a>";
            }
        }
    }
}