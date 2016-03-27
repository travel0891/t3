using System;
using System.Collections.Generic;
using System.Web;

namespace view.controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public documents selectDocumentsByCharId(documents model)
        {
            return entityProvider.instance().selectDocumentsByCharId(model.charId);
        }

        public List<documents> selectDocuments()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectDocuments(null, Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        /// <summary>
        /// doDocuments
        /// </summary>
        /// <param name="type">1 insert 2 update 3 delete</param>
        /// <param name="model">Documents</param>
        /// <returns>Boolean</returns>
        public Boolean doDocuments(Int32 type, documents model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertDocuments(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateDocuments(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteDocuments(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}