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
        public List<questions> selectQuestions(questions whereModel, Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount)
        {
            String dataCountSQL = " select count(1) from questions ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,number ,question ,students_charId ,createTime ");
            sbSQL.Append(" from questions ");

            StringBuilder whereSQL = new StringBuilder();
            whereSQL.Append(" where 1 = @where ");
            if (whereModel != null)
            {
                if (!String.IsNullOrEmpty(whereModel.students_charId))
                {
                    whereSQL.Append(" and students_charId = @students_charId ");
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
                                           new SqlParameter("students_charId",whereModel == null? (Object)DBNull.Value:whereModel.students_charId == null ? (Object)DBNull.Value : whereModel.students_charId)
            };

            List<questions> listQuestionsModel = new List<questions>();
            questions questionsModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL.ToString(), parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL.ToString() + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                questionsModel = new questions();
                questionsModel.intId = dr.GetInt32(0);
                questionsModel.charId = dr.GetGuid(1).ToString();
                questionsModel.number = dr.GetString(2);
                questionsModel.question = dr.GetString(3);
                questionsModel.students_charId = dr.GetGuid(4).ToString();
                questionsModel.createTime = dr.GetDateTime(5);
                listQuestionsModel.Add(questionsModel);
            }
            dr.Close();

            return listQuestionsModel;
        }

        public questions selectQuestionsByCharId(String charId)
        {
            questions questionsModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,number ,question ,students_charId ,createTime ");
            sbSQL.Append(" from questions ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                questionsModel = new questions();
                questionsModel.intId = dr.GetInt32(0);
                questionsModel.charId = dr.GetGuid(1).ToString();
                questionsModel.number = dr.GetString(2);
                questionsModel.question = dr.GetString(3);
                questionsModel.students_charId = dr.GetGuid(4).ToString();
                questionsModel.createTime = dr.GetDateTime(5);
            }
            dr.Close();
            return questionsModel;
        }

        public Int32 insertQuestions(questions questionsModel)
        {
            return query.instance().insert(questionsModel);
        }

        public Int32 updateQuestions(questions questionsModel)
        {
            return query.instance().update(questionsModel);
        }

        public Int32 deleteQuestions(questions questionsModel)
        {
            return query.instance().delete(questionsModel);
        }
    }
}