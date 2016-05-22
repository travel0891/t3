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
        public List<messages> selectMessages(Int32 pageSize, Int32 pageIndex, out Int32 dataCount, out Int32 pageCount, String orderString, params Object[] param)
        {
            String dataCountSQL = " select count(1) from messages ";

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select ");
            sbSQL.AppendFormat(" {0} ", pageSize > 0 ? " top " + pageSize : null);
            sbSQL.Append(" intId, charId ");
            sbSQL.Append(" ,title ,students_charId ,createTime ,reply ,replyTime ");
            sbSQL.Append(" from messages ");

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

            List<messages> listMessagesModel = new List<messages>();
            messages messagesModel = null;

            dataCount = query.instance().scalarInt(dataCountSQL + whereSQL, parameter);
            pageCount = (Int32)Math.Ceiling((Double)dataCount / (Double)pageSize);

            IDataReader dr = query.instance().dataReader(sbSQL.ToString() + whereSQL + pageSQL.ToString() + orderSQL.ToString(), parameter);
            while (dr.Read())
            {
                messagesModel = new messages();
                messagesModel.intId = dr.GetInt32(0);
                messagesModel.charId = dr.GetGuid(1).ToString();
                messagesModel.title = dr.GetString(2);
                messagesModel.students_charId = dr.GetGuid(3).ToString();
                messagesModel.createTime = dr.GetDateTime(4);
                messagesModel.reply = dr.GetString(5);
                messagesModel.replyTime = dr.GetDateTime(6);
                listMessagesModel.Add(messagesModel);
            }
            dr.Close();

            return listMessagesModel;
        }

        public messages selectMessagesByCharId(String charId)
        {
            messages messagesModel = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select intId, charId ");
            sbSQL.Append(" ,title ,students_charId ,createTime ,reply ,replyTime ");
            sbSQL.Append(" from messages ");
            sbSQL.Append(" where charId = @charId ");
            IDbDataParameter[] parameter = { new SqlParameter("charId", charId) }; 
            IDataReader dr = query.instance().dataReader(sbSQL.ToString(), parameter);
            if (dr.Read())
            {
                messagesModel = new messages();
                messagesModel.intId = dr.GetInt32(0);
                messagesModel.charId = dr.GetGuid(1).ToString();
                messagesModel.title = dr.GetString(2);
                messagesModel.students_charId = dr.GetGuid(3).ToString();
                messagesModel.createTime = dr.GetDateTime(4);
                messagesModel.reply = dr.GetString(5);
                messagesModel.replyTime = dr.GetDateTime(6);
            }
            dr.Close();
            return messagesModel;
        }

        public Int32 insertMessages(messages messagesModel)
        {
            return query.instance().insert(messagesModel);
        }

        public Int32 updateMessages(messages messagesModel)
        {
            return query.instance().update(messagesModel);
        }

        public Int32 deleteMessages(messages messagesModel)
        {
            return query.instance().delete(messagesModel);
        }
    }
}
