using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    using model.table;
    using view.controller;

    public partial class document_action : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            //{
            //    documents editModel = new documents();
            //    editModel.charId = Request.QueryString["charId"];
            //    documents readModel = controllerProvider.instance().selectDocumentsByCharId(editModel);
            //    number.Value = readModel.number;
            //    title.Value = readModel.title;
            //    hiTitle.Value = readModel.title;
            //    hiUrl.Value = readModel.url;
            //}
        }
    }
}