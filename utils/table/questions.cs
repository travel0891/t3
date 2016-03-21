using System;

namespace model.table
{
    using model.utils;

    public class questions : baseTable
    {
        /// <summary> 
        /// 问题编号 VARCHAR 12   
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        ///  问题内容 NVARCHAR 2000   
        /// </summary> 
        public String question { get; set; }

        /// <summary> 
        ///  学生charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime createTime { get; set; }
    }
}
