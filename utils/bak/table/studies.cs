using System;

namespace model.table
{
    using model.utils;

    public class studies : baseTable
    {
        /// <summary> 
        ///  UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String courses_charId { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime? createTime { get; set; }
    }
}
