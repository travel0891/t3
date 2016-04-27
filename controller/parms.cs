using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public parms selectParmsByCharId(parms model)
        {
            return entityProvider.instance().selectParmsByCharId(model.charId);
        }

        public parms selectParmsByCharId(String charId)
        {
            return entityProvider.instance().selectParmsByCharId(charId);
        }

        public List<parms> selectParms()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectParms(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        public List<parms> selectParms(params Object[] whereParms)
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectParms(Int32.MaxValue, 1, out dataCount, out pageCount, null, whereParms);
        }

        public String maxNumber(params String[] tabelName)
        {
            return entityProvider.instance().maxNumber(tabelName);
        }

        public Boolean doParm(Int32 type, parms model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertParms(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateParms(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteParms(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}