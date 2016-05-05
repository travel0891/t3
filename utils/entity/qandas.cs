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
        public List<qandas> selectQandas(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from qandas ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,number ,qanda ,qaCountent ,configs_charId ,parms_charId ");
            sbSQL.Append(" from qandas ");

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

            List<qandas> listQandasModel = new List<qandas>();
            qandas qandasModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                qandasModel = new qandas();
                qandasModel.intId = dr.GetInt32(0);
                qandasModel.charId = dr.GetGuid(1).ToString();
                qandasModel.number = dr.GetString(2);
                qandasModel.qanda = dr.GetString(3);
                qandasModel.qaCountent = dr.GetString(4);
                qandasModel.configs_charId = dr.GetGuid(5).ToString();
                qandasModel.parms_charId = dr.GetGuid(6).ToString();
                listQandasModel.Add(qandasModel);
            }
            dr.Close();

            return listQandasModel;
        }

        public qandas selectQandasByCharId(String charId)
        {
            qandas qandasModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,number ,qanda ,qaCountent ,configs_charId ,parms_charId ");
            sbSQL.Append(" from qandas ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                qandasModel = new qandas();
                qandasModel.intId = dr.GetInt32(0);
                qandasModel.charId = dr.GetGuid(1).ToString();
                qandasModel.number = dr.GetString(2);
                qandasModel.qanda = dr.GetString(3);
                qandasModel.qaCountent = dr.GetString(4);
                qandasModel.configs_charId = dr.GetGuid(5).ToString();
                qandasModel.parms_charId = dr.GetGuid(6).ToString();
            }
            dr.Close();
            return qandasModel;
        }

        public Int32 insertQandas(qandas qandasModel)
        {
            return query.instance().insert(qandasModel);
        }

        public Int32 updateQandas(qandas qandasModel)
        {
            return query.instance().update(qandasModel);
        }

        public Int32 deleteQandas(qandas qandasModel)
        {
            return query.instance().delete(qandasModel);
        }
    }
}
