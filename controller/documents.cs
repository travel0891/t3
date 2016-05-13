using System;
using System.Collections.Generic;
using System.Web;

namespace controller
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
            return entityProvider.instance().selectDocuments(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        public List<documents> selectDocuments(Int32 top)
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectDocuments(top, 1, out dataCount, out pageCount, " updateTime desc ", null);
        }

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