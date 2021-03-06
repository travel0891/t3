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
        public List<exams> selectExams(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from exams ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,tempAction ,examples_charId ,students_charId ,createTime ,score ,updateTime ");
            sbSQL.Append(" from exams ");

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

            List<exams> listExamsModel = new List<exams>();
            exams examsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                examsModel = new exams();
                examsModel.intId = dr.GetInt32(0);
                examsModel.charId = dr.GetGuid(1).ToString();
                examsModel.tempAction = dr.GetGuid(2).ToString();
                examsModel.examples_charId = dr.GetGuid(3).ToString();
                examsModel.students_charId = dr.GetGuid(4).ToString();
                examsModel.createTime = dr.GetDateTime(5);
                examsModel.score = dr.GetInt16(6);
                examsModel.updateTime = dr.GetDateTime(7);
                listExamsModel.Add(examsModel);
            }
            dr.Close();

            return listExamsModel;
        }

        public exams selectExamsByCharId(String charId)
        {
            exams examsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,tempAction ,examples_charId ,students_charId ,createTime ,score ,updateTime ");
            sbSQL.Append(" from exams ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                examsModel = new exams();
                examsModel.intId = dr.GetInt32(0);
                examsModel.charId = dr.GetGuid(1).ToString();
                examsModel.tempAction = dr.GetGuid(2).ToString();
                examsModel.examples_charId = dr.GetGuid(3).ToString();
                examsModel.students_charId = dr.GetGuid(4).ToString();
                examsModel.createTime = dr.GetDateTime(5);
                examsModel.score = dr.GetInt16(6);
                examsModel.updateTime = dr.GetDateTime(7);
            }
            dr.Close();
            return examsModel;
        }

        public Int32 insertExams(exams examsModel)
        {
            return query.instance().insert(examsModel);
        }

        public Int32 updateExams(exams examsModel)
        {
            return query.instance().update(examsModel);
        }

        public Int32 deleteExams(exams examsModel)
        {
            return query.instance().delete(examsModel);
        }
    }
}
