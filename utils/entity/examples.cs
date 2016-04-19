using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace model.entity
{
    using model.table;
    using model.utils;

    public partial class entityProvider 
    {
        public List<examples> selectExamples(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from examples ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,configs_charId ,parms_charId ,number ,type ,example ,optionA ,optionB ,optionC ,optionD ,aCountent ,bCountent ,cCountent ,dCountent ");
            sbSQL.Append(" from examples ");

            String whereSQL = String.Empty;
            IDbDataParameter[] parameter = query.instance().builderParameter(out whereSQL, param);

            StringBuilder pageSQL = new StringBuilder();
            pageIndex = pageIndex > 0 ? pageIndex - 1 : 0;
            if (pageIndex > 0)
            {
                pageSQL.Append(" and intId > ");
                pageSQL.AppendFormat(" ( select max(intId) from (select top {0} intId from area {1} order by intId ) as dataList ) ", pageIndex * pageSize, whereSQL);
            }

            StringBuilder orderSQL = new StringBuilder();
            orderSQL.AppendFormat(" order by {0} ", String.IsNullOrEmpty(orderString) ? "intId asc" : orderString);

            List<examples> listExamplesModel = new List<examples>();
            examples examplesModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                examplesModel = new examples();
                examplesModel.intId = dr.GetInt32(0);
                examplesModel.charId = dr.GetGuid(1).ToString();
                examplesModel.configs_charId = dr.GetGuid(2).ToString();
                examplesModel.parms_charId = dr.GetGuid(3).ToString();
                examplesModel.number = dr.GetString(4);
                examplesModel.type = dr.GetInt16(5);
                examplesModel.example = dr.GetString(6);
                examplesModel.optionA = dr.GetInt16(7);
                examplesModel.optionB = dr.GetInt16(8);
                examplesModel.optionC = dr.GetInt16(9);
                examplesModel.optionD = dr.GetInt16(10);
                examplesModel.aCountent = dr.GetString(11);
                examplesModel.bCountent = dr.GetString(12);
                examplesModel.cCountent = dr.GetString(13);
                examplesModel.dCountent = dr.GetString(14);
                listExamplesModel.Add(examplesModel);
            }
            dr.Close();

            return listExamplesModel;
        }

        public examples selectExamplesByCharId(String charId)
        {
            examples examplesModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,configs_charId ,parms_charId ,number ,type ,example ,optionA ,optionB ,optionC ,optionD ,aCountent ,bCountent ,cCountent ,dCountent ");
            sbSQL.Append(" from examples ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                examplesModel = new examples();
                examplesModel.intId = dr.GetInt32(0);
                examplesModel.charId = dr.GetGuid(1).ToString();
                examplesModel.configs_charId = dr.GetGuid(2).ToString();
                examplesModel.parms_charId = dr.GetGuid(3).ToString();
                examplesModel.number = dr.GetString(4);
                examplesModel.type = dr.GetInt16(5);
                examplesModel.example = dr.GetString(6);
                examplesModel.optionA = dr.GetInt16(7);
                examplesModel.optionB = dr.GetInt16(8);
                examplesModel.optionC = dr.GetInt16(9);
                examplesModel.optionD = dr.GetInt16(10);
                examplesModel.aCountent = dr.GetString(11);
                examplesModel.bCountent = dr.GetString(12);
                examplesModel.cCountent = dr.GetString(13);
                examplesModel.dCountent = dr.GetString(14);
            }
            dr.Close();
            return examplesModel;
        }

        public Int32 insertExamples(examples examplesModel)
        {
            return query.instance().insert(examplesModel);
        }

        public Int32 updateExamples(examples examplesModel)
        {
            return query.instance().update(examplesModel);
        }

        public Int32 deleteExamples(examples examplesModel)
        {
            return query.instance().delete(examplesModel);
        }
    }
}
