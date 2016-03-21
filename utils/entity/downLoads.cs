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
        public List<downLoads> selectDownLoads(downLoads whereModel, Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount)
        {
            String dataCountSQL = " select count(1) from downLoads ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,documents_charId ,students_charId ,createTime ");
            sbSQL.Append(" from downLoads ");

            StringBuilder whereSQL = new StringBuilder();
            whereSQL.Append(" where 1 = @where ");
            if (whereModel != null)
            {
                if (!String.IsNullOrEmpty(whereModel.students_charId))
                {
                    whereSQL.Append(" and students_charId = @students_charId ");
                }
                if (!String.IsNullOrEmpty(whereModel.documents_charId))
                {
                    whereSQL.Append(" and documents_charId = @documents_charId ");
                }
            }

            StringBuilder pageSQL = new StringBuilder();
            pageIndex = pageIndex > 0 ? pageIndex - 1 : 0;
            if (pageIndex > 0)
            {
                pageSQL.Append(" and intId > ");
                pageSQL.AppendFormat(" ( select max(intId) from (select top {0} intId from area {1} order by intId ) as dataList ) ", pageIndex * pageSize, whereSQL.ToString());
            }

            StringBuilder orderSQL = new StringBuilder();
            orderSQL.Append(" order by intId ");

            IDbDataParameter[] parameter = {
                                           new SqlParameter("where","1"),
                                           new SqlParameter("students_charId",whereModel == null? (Object)DBNull.Value:whereModel.students_charId == null ? (Object)DBNull.Value : whereModel.students_charId),
                                           new SqlParameter("documents_charId",whereModel == null? (Object)DBNull.Value:whereModel.documents_charId == null ? (Object)DBNull.Value : whereModel.documents_charId)
            };

            List<downLoads> listDownLoadsModel = new List<downLoads>();
            downLoads downLoadsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL.ToString(), parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL.ToString() + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                downLoadsModel = new downLoads();
                downLoadsModel.intId = dr.GetInt32(0);
                downLoadsModel.charId = dr.GetGuid(1).ToString();
                downLoadsModel.documents_charId = dr.GetGuid(2).ToString();
                downLoadsModel.students_charId = dr.GetGuid(3).ToString();
                downLoadsModel.createTime = dr.GetDateTime(4);
                listDownLoadsModel.Add(downLoadsModel);
            }
            dr.Close();

            return listDownLoadsModel;
        }

        public downLoads selectDownLoadsByCharId(String charId)
        {
            downLoads downLoadsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,documents_charId ,students_charId ,createTime ");
            sbSQL.Append(" from downLoads ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                downLoadsModel = new downLoads();
                downLoadsModel.intId = dr.GetInt32(0);
                downLoadsModel.charId = dr.GetGuid(1).ToString();
                downLoadsModel.documents_charId = dr.GetGuid(2).ToString();
                downLoadsModel.students_charId = dr.GetGuid(3).ToString();
                downLoadsModel.createTime = dr.GetDateTime(4);
            }
            dr.Close();
            return downLoadsModel;
        }

        public Int32 insertDownLoads(downLoads downLoadsModel)
        {
            return query.instance().insert(downLoadsModel);
        }

        public Int32 updateDownLoads(downLoads downLoadsModel)
        {
            return query.instance().update(downLoadsModel);
        }

        public Int32 deleteDownLoads(downLoads downLoadsModel)
        {
            return query.instance().delete(downLoadsModel);
        }
    }
}
