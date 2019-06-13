using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Ancient.Models;

namespace Ancient.DAL
{
    /// <summary>
    /// 诗词数据访问类
    /// </summary>
    public class PoetryService
    {
        /// <summary>
        /// 通过诗人查询诗词
        /// </summary>
        /// <param name="authorName">诗人名</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> DALSelectByAuthor(string authorName)
        {
            string sql = "select PoetryID,PoetryAuthor,PoetryName,PoetrySeason,PoetryFeature,PoetryClass,PoetryContent,PoetryZhu,PoetryYi,PoetryShang from PoetryTB where PoetryAuthor=@PoetryAuthor";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PoetryAuthor",authorName)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            List<Poetry> list = new List<Poetry>();
            while (objReader.Read())
            {
                list.Add(new Poetry()
                {
                    PoetryID = Convert.ToInt32(objReader["PoetryID"].ToString()),
                    PoetryAuthor = objReader["PoetryAuthor"].ToString(),
                    PoetryName = objReader["PoetryName"].ToString(),
                    PoetrySeason = objReader["PoetrySeason"].ToString(),
                    PoetryFeature = objReader["PoetryFeature"].ToString(),
                    PoetryClass = objReader["PoetryClass"].ToString(),
                    PoetryContent = objReader["PoetryContent"].ToString(),
                    PoetryZhu = objReader["PoetryZhu"].ToString(),
                    PoetryYi = objReader["PoetryYi"].ToString(),
                    PoetryShang = objReader["PoetryShang"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 通过诗名查询诗词(模糊查询)
        /// </summary>
        /// <param name="poetryName">诗名</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> DALSelectByPoetryName(string poetryName)
        {
            string sql = "select PoetryID,PoetryAuthor,PoetryName,PoetrySeason,PoetryFeature,PoetryClass,PoetryContent,PoetryZhu,PoetryYi,PoetryShang from PoetryTB where PoetryName like @PoetryName";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PoetryName","%"+poetryName+"%")
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            List<Poetry> list = new List<Poetry>();
            while (objReader.Read())
            {
                list.Add(new Poetry()
                {
                    PoetryID = Convert.ToInt32(objReader["PoetryID"].ToString()),
                    PoetryAuthor = objReader["PoetryAuthor"].ToString(),
                    PoetryName = objReader["PoetryName"].ToString(),
                    PoetrySeason = objReader["PoetrySeason"].ToString(),
                    PoetryFeature = objReader["PoetryFeature"].ToString(),
                    PoetryClass = objReader["PoetryClass"].ToString(),
                    PoetryContent = objReader["PoetryContent"].ToString(),
                    PoetryZhu = objReader["PoetryZhu"].ToString(),
                    PoetryYi = objReader["PoetryYi"].ToString(),
                    PoetryShang = objReader["PoetryShang"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 通过季节查询诗词
        /// </summary>
        /// <param name="season">季节</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> DALSelectBySeason(string season)
        {
            string sql = "select PoetryID,PoetryAuthor,PoetryName,PoetrySeason,PoetryFeature,PoetryClass,PoetryContent,PoetryZhu,PoetryYi,PoetryShang from PoetryTB where PoetrySeason=@PoetrySeason";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PoetrySeason",season)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            List<Poetry> list = new List<Poetry>();
            while (objReader.Read())
            {
                list.Add(new Poetry()
                {
                    PoetryID = Convert.ToInt32(objReader["PoetryID"].ToString()),
                    PoetryAuthor = objReader["PoetryAuthor"].ToString(),
                    PoetryName = objReader["PoetryName"].ToString(),
                    PoetrySeason = objReader["PoetrySeason"].ToString(),
                    PoetryFeature = objReader["PoetryFeature"].ToString(),
                    PoetryClass = objReader["PoetryClass"].ToString(),
                    PoetryContent = objReader["PoetryContent"].ToString(),
                    PoetryZhu = objReader["PoetryZhu"].ToString(),
                    PoetryYi = objReader["PoetryYi"].ToString(),
                    PoetryShang = objReader["PoetryShang"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 通过特征查询诗词(模糊查询)
        /// </summary>
        /// <param name="feature">特征</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> DALSelectByFeature(string feature)
        {
            string sql = "select PoetryID,PoetryAuthor,PoetryName,PoetrySeason,PoetryFeature,PoetryClass,PoetryContent,PoetryZhu,PoetryYi,PoetryShang from PoetryTB where PoetryFeature like @PoetryFeature";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PoetryFeature","%"+feature+"%")
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            List<Poetry> list = new List<Poetry>();
            while (objReader.Read())
            {
                list.Add(new Poetry()
                {
                    PoetryID = Convert.ToInt32(objReader["PoetryID"].ToString()),
                    PoetryAuthor = objReader["PoetryAuthor"].ToString(),
                    PoetryName = objReader["PoetryName"].ToString(),
                    PoetrySeason = objReader["PoetrySeason"].ToString(),
                    PoetryFeature = objReader["PoetryFeature"].ToString(),
                    PoetryClass = objReader["PoetryClass"].ToString(),
                    PoetryContent = objReader["PoetryContent"].ToString(),
                    PoetryZhu = objReader["PoetryZhu"].ToString(),
                    PoetryYi = objReader["PoetryYi"].ToString(),
                    PoetryShang = objReader["PoetryShang"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 通过类别查询诗词(模糊查询)
        /// </summary>
        /// <param name="objClass">类别</param>
        /// <returns>诗词集合</returns>
        public List<Poetry> DALSelectByClass(string objClass)
        {
            string sql = "select PoetryID,PoetryAuthor,PoetryName,PoetrySeason,PoetryFeature,PoetryClass,PoetryContent,PoetryZhu,PoetryYi,PoetryShang from PoetryTB where PoetryClass like @PoetryClass";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PoetryClass","%"+objClass+"%")
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            List<Poetry> list = new List<Poetry>();
            while (objReader.Read())
            {
                list.Add(new Poetry()
                {
                    PoetryID = Convert.ToInt32(objReader["PoetryID"].ToString()),
                    PoetryAuthor = objReader["PoetryAuthor"].ToString(),
                    PoetryName = objReader["PoetryName"].ToString(),
                    PoetrySeason = objReader["PoetrySeason"].ToString(),
                    PoetryFeature = objReader["PoetryFeature"].ToString(),
                    PoetryClass = objReader["PoetryClass"].ToString(),
                    PoetryContent = objReader["PoetryContent"].ToString(),
                    PoetryZhu = objReader["PoetryZhu"].ToString(),
                    PoetryYi = objReader["PoetryYi"].ToString(),
                    PoetryShang = objReader["PoetryShang"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
    }
}

