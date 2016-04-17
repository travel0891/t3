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
        public List<configs> selectConfigs(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from configs ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,type ,createTime ");
            sbSQL.Append(" from configs ");

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

            List<configs> listConfigsModel = new List<configs>();
            configs configsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                configsModel = new configs();
                configsModel.intId = dr.GetInt32(0);
                configsModel.charId = dr.GetGuid(1).ToString();
                configsModel.type = dr.GetString(2);
                configsModel.createTime = dr.GetDateTime(3);
                listConfigsModel.Add(configsModel);
            }
            dr.Close();

            return listConfigsModel;
        }

        public configs selectConfigsByCharId(String charId)
        {
            configs configsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,type ,createTime ");
            sbSQL.Append(" from configs ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                configsModel = new configs();
                configsModel.intId = dr.GetInt32(0);
                configsModel.charId = dr.GetGuid(1).ToString();
                configsModel.type = dr.GetString(2);
                configsModel.createTime = dr.GetDateTime(3);
            }
            dr.Close();
            return configsModel;
        }

        public Int32 insertConfigs(configs configsModel)
        {
            return query.instance().insert(configsModel);
        }

        public Int32 updateConfigs(configs configsModel)
        {
            return query.instance().update(configsModel);
        }

        public Int32 deleteConfigs(configs configsModel)
        {
            return query.instance().delete(configsModel);
        }
    }
}
