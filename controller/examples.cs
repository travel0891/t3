using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public examples selectExamplesByCharId(examples model)
        {
            return entityProvider.instance().selectExamplesByCharId(model.charId);
        }

        public List<examples> selectExamples()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectExamples(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        public List<examples> selectExamples(Int32 top)
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectExamples(top, 1, out dataCount, out pageCount, " intId desc ", null);
        }

        public Boolean doExamples(Int32 type, examples model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertExamples(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateExamples(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteExamples(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}