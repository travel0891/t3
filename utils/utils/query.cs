using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace model.utils
{
    public class query
    {
        private static readonly String IDENTITY1 = "intId", IDENTITY2 = "charId", AUTOFIEID = "createTime";

        public Int32 insert(baseTable table)
        {
            StringBuilder temp1 = new StringBuilder(), temp2 = new StringBuilder();
            String commandText = String.Empty;
            List<IDbDataParameter> lsParameter = new List<IDbDataParameter>();
            Type type = table.GetType();

            foreach (PropertyInfo field in type.GetProperties())
            {
                if (field.GetValue(table, null) != null && field.Name != IDENTITY1 && field.Name != IDENTITY2)
                {
                    temp1.Append(field.Name + ",");
                    temp2.Append("@" + field.Name + ",");
                    if (field.Name == AUTOFIEID)
                    {
                        lsParameter.Add(new SqlParameter("@" + field.Name, "getdate()"));
                    }
                    else
                    {
                        lsParameter.Add(new SqlParameter("@" + field.Name, field.GetValue(table, null)));
                    }
                }
            }

            IDbDataParameter[] parameter = lsParameter.ToArray();

            commandText = String.Format("insert into {0}({1}) values ({2});"
                , type.Name
                , temp1.ToString().Trim(',')
                , temp2.ToString().Trim(','));

            return helper.instance().ExecuteNonQuery(helper.connectionString, commandText, null, parameter, CommandType.Text);
        }

        public Int32 update(baseTable table)
        {
            StringBuilder temp1 = new StringBuilder();
            String commandText = String.Empty;
            List<IDbDataParameter> lsParameter = new List<IDbDataParameter>();

            Type type = table.GetType();

            foreach (PropertyInfo field in type.GetProperties())
            {
                if (field.GetValue(table, null) != null)
                {
                    if (field.Name != IDENTITY1 && field.Name != IDENTITY2 && field.Name != AUTOFIEID)
                    {
                        temp1.Append(field.Name + " = @" + field.Name + ",");
                    }
                    if (field.Name != AUTOFIEID)
                    {
                        lsParameter.Add(new SqlParameter("@" + field.Name, field.GetValue(table, null)));
                    }
                }
            }

            IDbDataParameter[] parameter = lsParameter.ToArray();

            commandText = String.Format(" update {0} set {1} where {2} = @{2} "
                , type.Name
                , temp1.ToString().Trim(',')
                , IDENTITY2);

            return helper.instance().ExecuteNonQuery(helper.connectionString, commandText, null, parameter, CommandType.Text);
        }

        public Int32 delete(baseTable table)
        {
            String commandText = String.Empty;

            Type type = table.GetType();

            IDbDataParameter[] parameter = { new SqlParameter("@" + IDENTITY2, table.charId) };

            commandText = String.Format(" delete from {0} where {1} = @{1} "
                  , type.Name
                  , IDENTITY2);

            return helper.instance().ExecuteNonQuery(helper.connectionString, commandText, null, parameter, CommandType.Text);
        }

        public IDataReader dataReader(String commandText, IDbDataParameter[] dataParameter)
        {
            return helper.instance().ExecuteReader(helper.connectionString, commandText, dataParameter, CommandType.Text);
        }

        public DataSet dataSet(String commandText, IDbDataParameter[] dataParameter)
        {
            return helper.instance().ExecuteDataSet(helper.connectionString, commandText, dataParameter, CommandType.Text);
        }

        public String scalarString(String commandText, IDbDataParameter[] dataParameter)
        {
            return helper.instance().ExecuteScalarToString(helper.connectionString, commandText, dataParameter, CommandType.Text);
        }

        public Int32 scalarInt(String commandText, IDbDataParameter[] dataParameter)
        {
            return helper.instance().ExecuteScalarToInt(helper.connectionString, commandText, dataParameter, CommandType.Text);
        }

        public IDbDataParameter[] builderParameter(out String whereSQL, params Object[] pars)
        {
            StringBuilder sbSQL = new StringBuilder();
            List<IDbDataParameter> listParameter = new List<IDbDataParameter>();
            if (pars != null && pars.Length > 0 && pars.Length % 4 == 0)
            {
                for (int i = 0; i < pars.Length; i++)
                {
                    sbSQL.Append((i > 0 ? pars[i] : "where") + " " + pars[i + 1] + " " + pars[i + 2] + " @" + pars[i + 1] + " ");
                    listParameter.Add(new SqlParameter(pars[i + 1].ToString(), pars[i + 3]));
                    i += 3;
                }
            }
            whereSQL = sbSQL.ToString();
            return listParameter.ToArray();
        }

        private static query q = null;

        public static query instance()
        {
            return q == null ? new query() : q;
        }
    }
}