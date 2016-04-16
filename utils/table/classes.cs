using System;

namespace model.table
{
    using model.utils;

    public class classes : baseTable
    {
        /// <summary> 
        ///  DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? createTime { get; set; }

        /// <summary> 
        ///  NVARCHAR 20    
        /// </summary> 
        public String classler { get; set; }
    }
}
