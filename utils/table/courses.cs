using System;

namespace model.table
{
    using model.utils;

    public class courses : baseTable
    {
        /// <summary> 
        /// 课题编号 VARCHAR 12   
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        /// 标题 NVARCHAR 100   
        /// </summary> 
        public String title { get; set; }

        /// <summary> 
        /// 创建时间 DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime createTime { get; set; }

        /// <summary> 
        /// 课件内容 NVARCHAR 2000   
        /// </summary> 
        public String contents { get; set; }

        /// <summary> 
        /// 更新时间 DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime? updateTime { get; set; }
    }
}
