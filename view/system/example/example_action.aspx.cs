using System;

namespace view
{
    using controller;
    using model.table;
    using System.Text;
    using System.Collections.Generic;

    public partial class example_action : viewBase
    {
        protected String checkJs = String.Empty, selectSelected1 = String.Empty, selectSelected2 = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                examples editModel = new examples();
                editModel.charId = Request.QueryString["charId"];
                examples readModel = controllerProvider.instance().selectExamplesByCharId(editModel);
                number.Value = readModel.number;
                example.Value = readModel.example;
                aCountent.Value = readModel.aCountent;
                bCountent.Value = readModel.bCountent;
                cCountent.Value = readModel.cCountent;
                dCountent.Value = readModel.dCountent;

                if (readModel.optionA == 1)
                {
                    checkJs = "optionA";
                }
                else if (readModel.optionB == 1)
                {
                    checkJs = "optionB";
                }
                else if (readModel.optionC == 1)
                {
                    checkJs = "optionC";
                }
                else if (readModel.optionD == 1)
                {
                    checkJs = "optionD";
                }

                if (!String.IsNullOrEmpty(checkJs))
                {
                    checkJs = " $(\"#" + checkJs + "\").attr(\"checked\",\"checked\");";
                }

                selectSelected1 = readModel.configs_charId;
                selectSelected2 = readModel.parms_charId;

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