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
        public List<documents> selectDocuments(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from documents ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,configs_charId ,parms_charId ,number ,title ,type ,size ,url ,createTime ,updateTime ");
            sbSQL.Append(" from documents ");

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

            List<documents> listDocumentsModel = new List<documents>();
            documents documentsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                documentsModel = new documents();
                documentsModel.intId = dr.GetInt32(0);
                documentsModel.charId = dr.GetGuid(1).ToString();
                documentsModel.configs_charId = dr.GetGuid(2).ToString();
                documentsModel.parms_charId = dr.GetGuid(3).ToString();
                documentsModel.number = dr.GetString(4);
                documentsModel.title = dr.GetString(5);
                documentsModel.type = dr.GetString(6);
                documentsModel.size = dr.GetInt32(7);
                documentsModel.url = dr.GetString(8);
                documentsModel.createTime = dr.GetDateTime(9);
                documentsModel.updateTime = dr.GetDateTime(10);
                listDocumentsModel.Add(documentsModel);
            }
            dr.Close();

            return listDocumentsModel;
        }

        public documents selectDocumentsByCharId(String charId)
        {
            documents documentsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,configs_charId ,parms_charId ,number ,title ,type ,size ,url ,createTime ,updateTime ");
            sbSQL.Append(" from documents ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                documentsModel = new documents();
                documentsModel.intId = dr.GetInt32(0);
                documentsModel.charId = dr.GetGuid(1).ToString();
                documentsModel.configs_charId = dr.GetGuid(2).ToString();
                documentsModel.parms_charId = dr.GetGuid(3).ToString();
                documentsModel.number = dr.GetString(4);
                documentsModel.title = dr.GetString(5);
                documentsModel.type = dr.GetString(6);
                documentsModel.size = dr.GetInt32(7);
                documentsModel.url = dr.GetString(8);
                documentsModel.createTime = dr.GetDateTime(9);
                documentsModel.updateTime = dr.GetDateTime(10);
            }
            dr.Close();
            return documentsModel;
        }

        public Int32 insertDocuments(documents documentsModel)
        {
            return query.instance().insert(documentsModel);
        }

        public Int32 updateDocuments(documents documentsModel)
        {
            return query.instance().update(documentsModel);
        }

        public Int32 deleteDocuments(documents documentsModel)
        {
            return query.instance().delete(documentsModel);
        }
    }
}
