using System;

namespace model.table
{
    using model.utils;

    public class configs : baseTable
    {
        /// <summary> 
        ///  NVARCHAR 50    
        /// </summary> 
        public String type { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? createTime { get; set; }
    }
}
