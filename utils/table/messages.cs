using System;

namespace model.table
{
    using model.utils;

    public class messages : baseTable
    {
        /// <summary> 
        ///  VARCHAR 200    
        /// </summary> 
        public String title { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? createTime { get; set; }

        /// <summary> 
        ///  VARCHAR 2000    允许NULL
        /// </summary> 
        public String reply { get; set; }

        /// <summary> 
        ///  DATETIME 8    允许NULL
        /// </summary> 
        public DateTime? replyTime { get; set; }
    }
}
