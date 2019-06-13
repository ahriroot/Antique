using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Ancient.Common;

namespace Ancient.DAL
{
    public class SQLHelper
    {
        /// <summary>
        /// 执行 insert、update、delete 类型的操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Update(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(SaveConnStr.connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);//添加参数数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //此处内容添加到日志......
                throw new Exception("执行public static int Update(string sql, SqlParameter[] param)时出现异常" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 执行返回单一结果的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object GetStringResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(SaveConnStr.connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);//添加参数数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //此处内容添加到日志......
                throw new Exception("执行public static object GetStringResult(string sql, SqlParameter[] param)时出现异常" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 返回一个结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(SaveConnStr.connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);//添加参数数组
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //此处内容添加到日志......
                throw new Exception("执行public static int Update(string sql, SqlParameter[] param)时出现异常" + ex.Message);
            }

        }
    }
}
