using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Ancient.Models;

namespace Ancient.DAL
{
    public class FeedbackService
    {
        /// <summary>
        /// 读取反馈信息
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>反馈信息</returns>
        public Feedback DALReadFeedback(Feedback objFeedback)
        {
            string sql = "select FeedbackID,FeedbackUserId,FeedbackPoetryId,FeedbackContent from FeedbackTB where FeedbackUserId=@FeedbackUserId and FeedbackPoetryId=@FeedbackPoetryId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FeedbackUserId",objFeedback.FeedbackUserId),
                new SqlParameter("@FeedbackPoetryId",objFeedback.FeedbackPoetryId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objFeedback.FeedbackID = Convert.ToInt32(objReader["FeedbackID"].ToString());
                objFeedback.FeedbackUserId = Convert.ToInt32(objReader["FeedbackUserId"].ToString());
                objFeedback.FeedbackPoetryId = Convert.ToInt32(objReader["FeedbackPoetryId"].ToString());
                objFeedback.FeedbackContent = objReader["FeedbackContent"].ToString();
            }
            else
            {
                objFeedback = null;
            }
            objReader.Close();
            return objFeedback;
        }

        /// <summary>
        /// 保存反馈信息
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int DALSaveFeedback(Feedback objFeedback)
        {
            string sql = "insert into FeedbackTB(FeedbackUserId,FeedbackPoetryId,FeedbackContent)";
            sql += " values(@FeedbackUserId,@FeedbackPoetryId,@FeedbackContent)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FeedbackUserId",objFeedback.FeedbackUserId),
                new SqlParameter("@FeedbackPoetryId",objFeedback.FeedbackPoetryId),
                new SqlParameter("@FeedbackContent",objFeedback.FeedbackContent)
            };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 更改反馈信息
        /// </summary>
        /// <param name="objFeedback">反馈信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int DALUpdateFeedback(Feedback objFeedback)
        {
            string sql = "update FeedbackTB set FeedbackContent=@FeedbackContent where FeedbackUserId=@FeedbackUserId and FeedbackPoetryId=@FeedbackPoetryId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@FeedbackUserId",objFeedback.FeedbackUserId),
                new SqlParameter("@FeedbackPoetryId",objFeedback.FeedbackPoetryId),
                new SqlParameter("@FeedbackContent",objFeedback.FeedbackContent)
            };
            return SQLHelper.Update(sql, param);
        }
    }
}
