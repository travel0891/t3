using System;

namespace model.table
{
    using model.utils;

    public class answers : baseTable
    {
        /// <summary> 
        ///  UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String questions_charId { get; set; }

        /// <summary> 
        ///  NVARCHAR 2000   
        /// </summary> 
        public String answer { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime createTime { get; set; }
    }
}
