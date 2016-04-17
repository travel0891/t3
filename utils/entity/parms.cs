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
        public List<parms> selectParms(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from parms ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,configs_charId ,chapter ,createTime ");
            sbSQL.Append(" from parms ");

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

            List<parms> listParmsModel = new List<parms>();
            parms parmsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                parmsModel = new parms();
                parmsModel.intId = dr.GetInt32(0);
                parmsModel.charId = dr.GetGuid(1).ToString();
                parmsModel.configs_charId = dr.GetGuid(2).ToString();
                parmsModel.chapter = dr.GetString(3);
                parmsModel.createTime = dr.GetDateTime(4);
                listParmsModel.Add(parmsModel);
            }
            dr.Close();

            return listParmsModel;
        }

        public parms selectParmsByCharId(String charId)
        {
            parms parmsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,configs_charId ,chapter ,createTime ");
            sbSQL.Append(" from parms ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                parmsModel = new parms();
                parmsModel.intId = dr.GetInt32(0);
                parmsModel.charId = dr.GetGuid(1).ToString();
                parmsModel.configs_charId = dr.GetGuid(2).ToString();
                parmsModel.chapter = dr.GetString(3);
                parmsModel.createTime = dr.GetDateTime(4);
            }
            dr.Close();
            return parmsModel;
        }

        public Int32 insertParms(parms parmsModel)
        {
            return query.instance().insert(parmsModel);
        }

        public Int32 updateParms(parms parmsModel)
        {
            return query.instance().update(parmsModel);
        }

        public Int32 deleteParms(parms parmsModel)
        {
            return query.instance().delete(parmsModel);
        }
    }
}
