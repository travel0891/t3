using System;

namespace model.table
{
    using model.utils;

    public class documents : baseTable
    {
        /// <summary> 
        ///  UNIQUEIDENTIFIER 16
        /// </summary> 
        public String configs_charId { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16
        /// </summary> 
        public String parms_charId { get; set; }

        /// <summary> 
        /// 文档编号 VARCHAR 12    
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        /// 文档名称 NVARCHAR 100    
        /// </summary> 
        public String title { get; set; }

        /// <summary> 
        /// 文档类型 VARCHAR 8    
        /// </summary> 
        public String type { get; set; }

        /// <summary> 
        /// 文档大小 INT 4    
        /// </summary> 
        public Int32 size { get; set; }

        /// <summary> 
        /// 下载地址 VARCHAR 200    
        /// </summary> 
        public String url { get; set; }

        /// <summary> 
        ///  DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? createTime { get; set; }

        /// <summary> 
        /// 更新时间 DATETIME 8 (getdate())   
        /// </summary> 
        public DateTime? updateTime { get; set; }
    }
}
