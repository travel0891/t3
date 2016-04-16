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
        public List<classes> selectClasses(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from classes ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,createTime ,classler ");
            sbSQL.Append(" from classes ");

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

            List<classes> listClassesModel = new List<classes>();
            classes classesModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                classesModel = new classes();
                classesModel.intId = dr.GetInt32(0);
                classesModel.charId = dr.GetGuid(1).ToString();
                classesModel.createTime = dr.GetDateTime(2);
                classesModel.classler = dr.GetString(3);
                listClassesModel.Add(classesModel);
            }
            dr.Close();

            return listClassesModel;
        }

        public classes selectClassesByCharId(String charId)
        {
            classes classesModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,createTime ,classler ");
            sbSQL.Append(" from classes ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                classesModel = new classes();
                classesModel.intId = dr.GetInt32(0);
                classesModel.charId = dr.GetGuid(1).ToString();
                classesModel.createTime = dr.GetDateTime(2);
                classesModel.classler = dr.GetString(3);
            }
            dr.Close();
            return classesModel;
        }

        public Int32 insertClasses(classes classesModel)
        {
            return query.instance().insert(classesModel);
        }

        public Int32 updateClasses(classes classesModel)
        {
            return query.instance().update(classesModel);
        }

        public Int32 deleteClasses(classes classesModel)
        {
            return query.instance().delete(classesModel);
        }
    }
}
