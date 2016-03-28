using System;

namespace model.table
{
    using model.utils;

    public class exams : baseTable
    {
        /// <summary> 
        /// 考试场景 UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String tempAction { get; set; }

        /// <summary> 
        /// 题目charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String examples_charId { get; set; }

        /// <summary> 
        /// 学生charId UNIQUEIDENTIFIER 16   
        /// </summary> 
        public String students_charId { get; set; }

        /// <summary> 
        /// 开始时间 DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime? createTime { get; set; }

        /// <summary> 
        /// 得分 SMALLINT 2 ((0))  
        /// </summary> 
        public Int16 score { get; set; }

        /// <summary> 
        /// 更新时间 DATETIME 8 (getdate())  
        /// </summary> 
        public DateTime? updateTime { get; set; }
    }
}
