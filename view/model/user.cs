using System;
using System.Collections.Generic;
using System.Web;

namespace view.model
{
    using utils;

    public class user : baseTable
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private Int32 age;

        public Int32 Age
        {
            get { return age; }
            set { age = value; }
        }

        private DateTime? updateTime;

        public DateTime? UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        } 
    }
}