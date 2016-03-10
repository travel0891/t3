using System;
using System.Collections.Generic;
using System.Web;

namespace view.model
{
    using utils;

    public class userid : baseTable
    {
        public String name { get; set; }
        public String password { get; set; }
        public DateTime? createTime { get; set; }
        public Int16 super { get; set; }
        public Int16 status { get; set; }
    }
}