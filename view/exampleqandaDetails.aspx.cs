using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model.table;
using controller;

namespace view
{
    public partial class exampleqandaDetails : viewGuest
    {
        protected String number, exampleqanda, aCountent, bCountent, cCountent, dCountent, hiContents, checkJs, tempConfig, tempParm;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId1"]))
            {
                examples editModel = new examples();
                editModel.charId = Request.QueryString["charId1"];
                examples readModel = controllerProvider.instance().selectExamplesByCharId(editModel);
                number = readModel.number;
                exampleqanda = readModel.example;
                aCountent = readModel.aCountent;
                bCountent = readModel.bCountent;
                cCountent = readModel.cCountent;
                dCountent = readModel.dCountent;
                if (readModel.optionA == 1)
                {
                    checkJs = "A";
                }
                else if (readModel.optionB == 1)
                {
                    checkJs = "B";
                }
                else if (readModel.optionC == 1)
                {
                    checkJs = "C";
                }
                else if (readModel.optionD == 1)
                {
                    checkJs = "D";
                }
                tempConfig = controllerProvider.instance().selectConfigsByCharId(readModel.configs_charId).type;
                tempParm = controllerProvider.instance().selectParmsByCharId(readModel.parms_charId).chapter;
            }

            if (!String.IsNullOrEmpty(Request.QueryString["charId2"]))
            {
                qandas editModel = new qandas();
                editModel.charId = Request.QueryString["charId2"];
                qandas readModel = controllerProvider.instance().selectQandasByCharId(editModel);
                number = readModel.number;
                exampleqanda = readModel.qanda;
                tempConfig = controllerProvider.instance().selectConfigsByCharId(readModel.configs_charId).type;
                tempParm = controllerProvider.instance().selectParmsByCharId(readModel.parms_charId).chapter;
                hiContents = readModel.qaCountent;
            }
        }

        protected String getUserInfo(String sessionString)
        {
            students studentModel = new students();
            studentModel.charId = sessionString.Split(',')[1];
            studentModel = controllerProvider.instance().selectStudentsByCharId(studentModel);

            if (Convert.ToInt16(studentModel.super) == 0)
            {
                return studentModel.classes + "." + studentModel.name;
            }
            else
            {
                return "管理员";
            }
        }
    }
}