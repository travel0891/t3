using System;
using System.Collections.Generic;

using System.Text;

namespace view
{
    using controller;
    using model.table;

    public partial class qanda_action : viewBase
    {
        protected String selectSelected1 = String.Empty, selectSelected2 = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                qandas editModel = new qandas();
                editModel.charId = Request.QueryString["charId"];
                qandas readModel = controllerProvider.instance().selectQandasByCharId(editModel);
                number.Value = readModel.number;
                qanda.Value = readModel.qanda;

                selectSelected1 = readModel.configs_charId;
                selectSelected2 = readModel.parms_charId;

                hiContents.Value = readModel.qaCountent;
                StringBuilder tempSelect = new StringBuilder();
                Object[] whereObj = { "and", "configs_charId", "=", readModel.configs_charId };
                List<parms> tempModel = controllerProvider.instance().selectParms(whereObj);

                tempSelect.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"{1}\" placeholder=\"{2}\">", "parmsCharId", "form-control", "必选");
                foreach (parms item in tempModel)
                {
                    tempSelect.AppendFormat("<option {0} ", selectSelected2 == item.charId ? "selected=\"selected\"" : null);
                    tempSelect.AppendFormat("value=\"{0}\">{1}", item.charId, item.chapter);
                    tempSelect.Append("</option>");
                }
                tempSelect.Append("<select>");

                parmList.InnerHtml = tempSelect.ToString();
            }

            StringBuilder sbSelect = new StringBuilder();
            List<configs> listModel = controllerProvider.instance().selectConfigs();
            sbSelect.AppendFormat("<select id=\"{0}\" name=\"{0}\" class=\"{1}\" placeholder=\"{2}\">", "configsCharId", "form-control", "必选");
            sbSelect.Append("<option value=\"\">请选择</option>");
            foreach (configs item in listModel)
            {
                sbSelect.AppendFormat("<option {0} ", selectSelected1 == item.charId ? "selected=\"selected\"" : null);
                sbSelect.AppendFormat("value=\"{0}\">{1}", item.charId, item.type);
                sbSelect.Append("</option>");
            }
            sbSelect.Append("<select>");
            configList.InnerHtml = sbSelect.ToString();
        }
    }
}