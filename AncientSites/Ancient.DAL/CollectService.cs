using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Ancient.Models;

namespace Ancient.DAL
{
    public class CollectService
    {
        /// <summary>
        /// 读取收藏信息
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>true:是;false:否</returns>
        public bool DALReadCollect(Collect objCollect)
        {
            string sql = "select CollectID,CollectUserId,CollectPoetryId from CollectTB where CollectUserId=@CollectUserId and CollectPoetryId=@CollectPoetryId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CollectUserId",objCollect.CollectUserId),
                new SqlParameter("@CollectPoetryId",objCollect.CollectPoetryId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存收藏信息
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int DALSaveCollect(Collect objCollect)
        {
            string sql = "insert into CollectTB(CollectUserId,CollectPoetryId)";
            sql += " values(@CollectUserId,@CollectPoetryId)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CollectUserId",objCollect.CollectUserId),
                new SqlParameter("@CollectPoetryId",objCollect.CollectPoetryId)
            };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 删除收藏信息
        /// </summary>
        /// <param name="objCollect">收藏信息</param>
        /// <returns>1:成功;0:失败</returns>
        public int DALDeleteCollect(Collect objCollect)
        {
            string sql = "delete from CollectTB where CollectUserId=@CollectUserId and CollectPoetryId=@CollectPoetryId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CollectUserId",objCollect.CollectUserId),
                new SqlParameter("@CollectPoetryId",objCollect.CollectPoetryId)
            };
            return SQLHelper.Update(sql, param);
        }
    }
}
