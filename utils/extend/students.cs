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
        public students selectStudentsByAccount(students model)
        {
            students studentsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,account ,password ,name ,number ,gender ,classes ,createTime ,super ,status ");
            sbSQL.Append(" from students ");
            sbSQL.Append(" where account = @account and super = @super and status = @status ");
            IDbDataParameter[] parameter = { 
                                            new SqlParameter("account", model.account)
                                            , new SqlParameter("super", model.super)
                                            , new SqlParameter("status", model.status)
            };
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

        public students selectStudents(students model)
        {
            students studentsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,account ,password ,name ,number ,gender ,classes ,createTime ,super ,status ");
            sbSQL.Append(" from students ");
            sbSQL.Append(" where account = @account and password = @password and super = @super and status = @status ");
            IDbDataParameter[] parameter = { 
                                            new SqlParameter("account", model.account)
                                            , new SqlParameter("password", model.password)
                                            , new SqlParameter("super", model.super)
                                            , new SqlParameter("status", model.status)
            };
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
    }
}