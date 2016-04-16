using System;
using System.Collections.Generic;
using System.Web;

namespace view.controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public classes selectClassesByCharId(classes model)
        {
            return entityProvider.instance().selectClassesByCharId(model.charId);
        }

        public List<classes> selectClasses()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectClasses(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        /// <summary>
        /// doClasses
        /// </summary>
        /// <param name="type">1 insert 2 update 3 delete</param>
        /// <param name="model">classes</param>
        /// <returns>Boolean</returns>
        public Boolean doClasses(Int32 type, classes model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertClasses(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateClasses(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteClasses(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}