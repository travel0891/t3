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
        public List<courses> selectCourses(courses whereModel, Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from courses ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,number ,title ,createTime ,contents ,updateTime ");
            sbSQL.Append(" from courses ");

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

            List<courses> listCoursesModel = new List<courses>();
            courses coursesModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                coursesModel = new courses();
                coursesModel.intId = dr.GetInt32(0);
                coursesModel.charId = dr.GetGuid(1).ToString();
                coursesModel.number = dr.GetString(2);
                coursesModel.title = dr.GetString(3);
                coursesModel.createTime = dr.GetDateTime(4);
                coursesModel.contents = dr.GetString(5);
                coursesModel.updateTime = dr.GetDateTime(6);
                listCoursesModel.Add(coursesModel);
            }
            dr.Close();

            return listCoursesModel;
        }

        public courses selectCoursesByCharId(String charId)
        {
            courses coursesModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,number ,title ,createTime ,contents ,updateTime ");
            sbSQL.Append(" from courses ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                coursesModel = new courses();
                coursesModel.intId = dr.GetInt32(0);
                coursesModel.charId = dr.GetGuid(1).ToString();
                coursesModel.number = dr.GetString(2);
                coursesModel.title = dr.GetString(3);
                coursesModel.createTime = dr.GetDateTime(4);
                coursesModel.contents = dr.GetString(5);
                coursesModel.updateTime = dr.GetDateTime(6);
            }
            dr.Close();
            return coursesModel;
        }

        public Int32 insertCourses(courses coursesModel)
        {
            return query.instance().insert(coursesModel);
        }

        public Int32 updateCourses(courses coursesModel)
        {
            return query.instance().update(coursesModel);
        }

        public Int32 deleteCourses(courses coursesModel)
        {
            return query.instance().delete(coursesModel);
        }
    }
}
