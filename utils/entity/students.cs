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
        public List<students> selectStudents(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from students ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,account ,password ,name ,number ,gender ,classes ,createTime ,super ,status ");
            sbSQL.Append(" from students ");

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
            orderSQL.AppendFormat(" order by {0} ", String.IsNullOrEmpty(orderString) ? "super desc , intId asc" : orderString);

            List<students> listStudentsModel = new List<students>();
            students studentsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                studentsModel = new students();
                studentsModel.intId = dr.GetInt32(0);
                studentsModel.charId = dr.GetGuid(1).ToString();
                studentsModel.account = dr.GetString(2);
                studentsModel.password = dr.GetString(3);
                studentsModel.name = dr.GetString(4);
                studentsModel.number = dr.GetString(5);
                studentsModel.gender = dr.GetInt16(6);
                studentsModel.classes = dr.GetString(7);
                studentsModel.createTime = dr.GetDateTime(8);
                studentsModel.super = dr.GetInt16(9);
                studentsModel.status = dr.GetInt16(10);
                listStudentsModel.Add(studentsModel);
            }
            dr.Close();

            return listStudentsModel;
        }

        public students selectStudentsByCharId(String charId)
        {
            students studentsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,account ,password ,name ,number ,gender ,classes ,createTime ,super ,status ");
            sbSQL.Append(" from students ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                studentsModel = new students();
                studentsModel.intId = dr.GetInt32(0);
                studentsModel.charId = dr.GetGuid(1).ToString();
                studentsModel.account = dr.GetString(2);
                studentsModel.password = dr.GetString(3);
                studentsModel.name = dr.GetString(4);
                studentsModel.number = dr.GetString(5);
                studentsModel.gender = dr.GetInt16(6);
                studentsModel.classes = dr.GetString(7);
                studentsModel.createTime = dr.GetDateTime(8);
                studentsModel.super = dr.GetInt16(9);
                studentsModel.status = dr.GetInt16(10);
            }
            dr.Close();
            return studentsModel;
        }

        public Int32 insertStudents(students studentsModel)
        {
            return query.instance().insert(studentsModel);
        }

        public Int32 updateStudents(students studentsModel)
        {
            return query.instance().update(studentsModel);
        }

        public Int32 deleteStudents(students studentsModel)
        {
            return query.instance().delete(studentsModel);
        }
    }
}
