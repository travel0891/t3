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
        public List<answers> selectAnswers(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from answers ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,questions_charId ,answer ,students_charId ,createTime ");
            sbSQL.Append(" from answers ");

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

            List<answers> listAnswersModel = new List<answers>();
            answers answersModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                answersModel = new answers();
                answersModel.intId = dr.GetInt32(0);
                answersModel.charId = dr.GetGuid(1).ToString();
                answersModel.questions_charId = dr.GetGuid(2).ToString();
                answersModel.answer = dr.GetString(3);
                answersModel.students_charId = dr.GetGuid(4).ToString();
                answersModel.createTime = dr.GetDateTime(5);
                listAnswersModel.Add(answersModel);
            }
            dr.Close();

            return listAnswersModel;
        }

        public answers selectAnswersByCharId(String charId)
        {
            answers answersModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,questions_charId ,answer ,students_charId ,createTime ");
            sbSQL.Append(" from answers ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                answersModel = new answers();
                answersModel.intId = dr.GetInt32(0);
                answersModel.charId = dr.GetGuid(1).ToString();
                answersModel.questions_charId = dr.GetGuid(2).ToString();
                answersModel.answer = dr.GetString(3);
                answersModel.students_charId = dr.GetGuid(4).ToString();
                answersModel.createTime = dr.GetDateTime(5);
            }
            dr.Close();
            return answersModel;
        }

        public Int32 insertAnswers(answers answersModel)
        {
            return query.instance().insert(answersModel);
        }

        public Int32 updateAnswers(answers answersModel)
        {
            return query.instance().update(answersModel);
        }

        public Int32 deleteAnswers(answers answersModel)
        {
            return query.instance().delete(answersModel);
        }
    }
}
