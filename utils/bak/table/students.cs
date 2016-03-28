using System;

namespace model.table
{
    using model.utils;

    public class students : baseTable
    {
        /// <summary> 
        /// 登录账号 NVARCHAR 50   
        /// </summary> 
        public String account { get; set; }

        /// <summary> 
        /// 登录密码 VARCHAR 200   
        /// </summary> 
        public String password { get; set; }

        /// <summary> 
        /// 姓名 NVARCHAR 20   
        /// </summary> 
        public String name { get; set; }

        /// <summary> 
        /// 学号 VARCHAR 12   
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        /// 性别 SMALLINT 2   
        /// </summary> 
        public Int16 gender { get; set; }

        /// <summary> 
        /// 班级 NVARCHAR 20   
        /// </summary> 
        public String classes { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime? createTime { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))  
        /// </summary> 
        public Int16 super { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))  
        /// </summary> 
        public Int16 status { get; set; }
    }
}
