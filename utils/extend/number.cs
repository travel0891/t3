using System;
using System.Text;

namespace model.entity
{
    using model.utils;

    public partial class entityProvider
    {
        public String maxNumber(params String[] tabelName)
        {
            StringBuilder sbMAX = new StringBuilder();
            if (tabelName != null && tabelName.Length == 5)
            {
                for (int i = 0; i < tabelName.Length; i++)
                {
                    Int32 tempId = 0;
                    if (i == tabelName.Length - 1)
                    {
                        tempId = query.instance().scalarInt(" select intId from " + tabelName[i] + " order by intId desc ", null) + 1;
                    }
                    else
                    {
                        tempId = query.instance().scalarInt(" select intId from " + tabelName[i] + " where charId = '" + tabelName[i + 1] + "'", null);
                    }
                    i++;
                    String tempString = tempId.ToString().Length == 1 ? "0" + tempId : tempId.ToString();
                    sbMAX.AppendFormat("{0}", tempString);
                }
            }
            return sbMAX.ToString();
        }
    }
}