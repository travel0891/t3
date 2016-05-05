using System;

namespace model.table
{
    using model.utils;

    public class qandas : baseTable
    {
        /// <summary> 
        ///  VARCHAR 12    
        /// </summary> 
        public String number { get; set; }

        /// <summary> 
        ///  NVARCHAR 100    
        /// </summary> 
        public String qanda { get; set; }

        /// <summary> 
        ///  NVARCHAR 2000    
        /// </summary> 
        public String qaCountent { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String configs_charId { get; set; }

        /// <summary> 
        ///  UNIQUEIDENTIFIER 16    
        /// </summary> 
        public String parms_charId { get; set; }
    }
}
