using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public qandas selectQandasByCharId(qandas model)
        {
            return entityProvider.instance().selectQandasByCharId(model.charId);
        }

        public List<qandas> selectQandas()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectQandas(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        /// <summary>
        /// doQandas
        /// </summary>
        /// <param name="type">1 insert 2 update 3 delete</param>
        /// <param name="model">Qandas</param>
        /// <returns>Boolean</returns>
        public Boolean doQandas(Int32 type, qandas model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertQandas(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateQandas(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteQandas(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}