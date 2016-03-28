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
        public List<studies> selectStudies(studies whereModel, Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from studies ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,courses_charId ,students_charId ,createTime ");
            sbSQL.Append(" from studies ");

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

            List<studies> listStudiesModel = new List<studies>();
            studies studiesModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                studiesModel = new studies();
                studiesModel.intId = dr.GetInt32(0);
                studiesModel.charId = dr.GetGuid(1).ToString();
                studiesModel.courses_charId = dr.GetGuid(2).ToString();
                studiesModel.students_charId = dr.GetGuid(3).ToString();
                studiesModel.createTime = dr.GetDateTime(4);
                listStudiesModel.Add(studiesModel);
            }
            dr.Close();

            return listStudiesModel;
        }

        public studies selectStudiesByCharId(String charId)
        {
            studies studiesModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,courses_charId ,students_charId ,createTime ");
            sbSQL.Append(" from studies ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                studiesModel = new studies();
                studiesModel.intId = dr.GetInt32(0);
                studiesModel.charId = dr.GetGuid(1).ToString();
                studiesModel.courses_charId = dr.GetGuid(2).ToString();
                studiesModel.students_charId = dr.GetGuid(3).ToString();
                studiesModel.createTime = dr.GetDateTime(4);
            }
            dr.Close();
            return studiesModel;
        }

        public Int32 insertStudies(studies studiesModel)
        {
            return query.instance().insert(studiesModel);
        }

        public Int32 updateStudies(studies studiesModel)
        {
            return query.instance().update(studiesModel);
        }

        public Int32 deleteStudies(studies studiesModel)
        {
            return query.instance().delete(studiesModel);
        }
    }
}
