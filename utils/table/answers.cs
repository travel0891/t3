using System;

namespace model.table
{
    using model.utils;

    public class answers : baseTable
    {
        /// <summary> 
        ///  问题charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String questions_charId { get; set; }

        /// <summary> 
        ///  回答内容 NVARCHAR 2000   
        /// </summary> 
        public String answer { get; set; }

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
