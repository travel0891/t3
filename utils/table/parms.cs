using System;

namespace model.table
{
    using model.utils;

    public class parms : baseTable
    {
        /// <summary> 
        ///  UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String configs_charId { get; set; }

        /// <summary> 
        ///  NVARCHAR 50    
        /// </summary> 
        public String chapter { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? createTime { get; set; }
    }
}
