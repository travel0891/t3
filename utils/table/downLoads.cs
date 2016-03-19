using System;

namespace model.table
{
    using model.utils;

    public class downLoads : baseTable
    {
        /// <summary> 
        /// 下载文档charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String documents_charId { get; set; }

        /// <summary> 
        /// 学生charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        /// 下载时间 DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime createTime { get; set; }
    }
}
