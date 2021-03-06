﻿using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public messages selectExamplesByCharId(messages model)
        {
            return entityProvider.instance().selectMessagesByCharId(model.charId);
        }

        public List<messages> selectMessages()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectMessages(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        public List<messages> selectMessages(Int32 top)
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectMessages(top, 1, out dataCount, out pageCount, " intId desc ", null);
        }

        public Boolean doMessages(Int32 type, messages model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertMessages(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateMessages(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteMessages(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}