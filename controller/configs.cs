using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public configs selectConfigsByCharId(configs model)
        {
            return entityProvider.instance().selectConfigsByCharId(model.charId);
        }

        public configs selectConfigsByCharId(String charId)
        {
            return entityProvider.instance().selectConfigsByCharId(charId);
        }

        public List<configs> selectConfigs()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectConfigs(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        public Boolean doConfig(Int32 type, configs model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertConfigs(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateConfigs(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteConfigs(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}