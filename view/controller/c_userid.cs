using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace view.controller
{
    using model;
    using utils;

    public class c_userid
    {
        public List<userid> selectUserid()
        {
            List<userid> lsUser = new List<userid>();

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId,charId ");
            sbSQL.Append(" ,name,password ");
            sbSQL.Append(" ,createTime,super,status ");
            sbSQL.Append(" from userid ");

            IDataReader dr = query.GetInstance().dataReader(sbSQL.ToString(), null);
            userid mUser = null;
            while (dr.Read())
            {
                mUser = new userid();
                mUser.intId = Convert.ToInt32(dr["intId"]);
                mUser.charId = dr["charId"].ToString();
                mUser.name = dr["name"].ToString();
                mUser.password = dr["password"].ToString();
                mUser.createTime = Convert.ToDateTime(dr["createTime"]);
                mUser.super = Convert.ToInt16(dr["super"]);
                mUser.status = Convert.ToInt16(dr["status"]);
                lsUser.Add(mUser);
            }
            dr.Close();

            return lsUser;
        }

        public userid existsUser(userid model)
        {
            userid mUser = new userid();

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId,charId ");
            sbSQL.Append(" ,name,password ");
            sbSQL.Append(" ,createTime,super,status ");
            sbSQL.Append(" from userid where ");
            sbSQL.Append(" name = @name and status = 0 ");
            IDbDataParameter[] parameter = { new SqlParameter("name", model.name) };

            IDataReader dr = query.GetInstance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                mUser.intId = Convert.ToInt32(dr["intId"]);
                mUser.charId = dr["charId"].ToString();
                mUser.name = dr["name"].ToString();
                mUser.password = dr["password"].ToString();
                mUser.createTime = Convert.ToDateTime(dr["createTime"]);
                mUser.super = Convert.ToInt16(dr["super"]);
                mUser.status = Convert.ToInt16(dr["status"]);
            }
            else
            {
                mUser.intId = 0;
            }
            dr.Close();
            return mUser;
        }

        public userid selectUser(userid model)
        {
            userid mUser = new userid();

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId,charId ");
            sbSQL.Append(" ,name,password ");
            sbSQL.Append(" ,createTime,super,status ");
            sbSQL.Append(" from userid where ");
            sbSQL.Append(" name = @name and password = @password ");
            sbSQL.Append(" and super = @super and status = @status ");
            IDbDataParameter[] parameter ={
                                           new SqlParameter("name",model.name),
                                           new SqlParameter("password",model.password),
                                           new SqlParameter("super",model.super),
                                           new SqlParameter("status",model.status)
            };

            IDataReader dr = query.GetInstance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                mUser.intId = Convert.ToInt32(dr["intId"]);
                mUser.charId = dr["charId"].ToString();
                mUser.name = dr["name"].ToString();
                mUser.password = dr["password"].ToString();
                mUser.createTime = Convert.ToDateTime(dr["createTime"]);
                mUser.super = Convert.ToInt16(dr["super"]);
                mUser.status = Convert.ToInt16(dr["status"]);
            }
            else
            {
                mUser.intId = 0;
            }
            dr.Close();
            return mUser;
        }

        public Int32 insertUser(userid model)
        {
            return query.GetInstance().insert(model);
        }

        public Int32 updateUser(userid model)
        {
            return query.GetInstance().update(model);
        }
    }
}