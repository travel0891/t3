using System;

namespace view
{
    using controller;
    using model.table;

    public partial class example_action : viewBase
    {
        protected String checkJs = String.Empty;

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
                else if(readModel.optionB == 1)
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
            }
        }
    }
}