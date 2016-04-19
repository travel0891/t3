using System;

namespace model.table
{
    using model.utils;

    public class examples : baseTable
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
        /// 习题编号 VARCHAR 12    
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        /// 1.单选2多选 SMALLINT 2 ((1))   
        /// </summary> 
        public Int16 type { get; set; }

        /// <summary> 
        /// 题目 NVARCHAR 200    
        /// </summary> 
        public String example { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))   
        /// </summary> 
        public Int16 optionA { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))   
        /// </summary> 
        public Int16 optionB { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))   
        /// </summary> 
        public Int16 optionC { get; set; }

        /// <summary> 
        ///  SMALLINT 2 ((0))   
        /// </summary> 
        public Int16 optionD { get; set; }

        /// <summary> 
        ///  NVARCHAR 200    
        /// </summary> 
        public String aCountent { get; set; }

        /// <summary> 
        ///  NVARCHAR 200    
        /// </summary> 
        public String bCountent { get; set; }

        /// <summary> 
        ///  NVARCHAR 200    
        /// </summary> 
        public String cCountent { get; set; }

        /// <summary> 
        ///  NVARCHAR 200    
        /// </summary> 
        public String dCountent { get; set; }
    }
}
