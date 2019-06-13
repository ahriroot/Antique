using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Ancient.Models;

namespace Ancient.DAL
{
    /// <summary>
    /// 用户数据访问类
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 判断是否存在用户名
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>是否存在</returns>
        public bool DALRepeat1(User objUser)
        {
            string sql = "select UserID,UserNAme,UserPwd,UserPhone from UserTB where UserNAme=@UserNAme";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserNAme",objUser.UserNAme)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objReader.Close();
                return true;
            }
            else
            {
                objReader.Close();
                return false;
            }
        }

        /// <summary>
        /// 判断手机号是否已注册
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>是否存在</returns>
        public bool DALRepeat2(User objUser)
        {
            string sql = "select UserID,UserNAme,UserPwd,UserPhone from UserTB where UserPhone=@UserPhone";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserPhone",objUser.UserPhone)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objReader.Close();
                return true;
            }
            else
            {
                objReader.Close();
                return false;
            }
        }

        /// <summary>
        /// 保存注册信息
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>1:成功;2:失败</returns>
        public int DALSaveRegedit(User objUser)
        {
            string sql = "insert into UserTB(UserNAme,UserPwd,UserPhone)";
            sql += " values(@UserNAme,@UserPwd,@UserPhone)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserNAme",objUser.UserNAme),
                new SqlParameter("@UserPwd",objUser.UserPwd),
                new SqlParameter("@UserPhone",objUser.UserPhone)
            };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 根据用户名登陆数据访问
        /// </summary>
        /// <param name="objUser">待登陆用户</param>
        /// <returns>登陆者信息</returns>
        public User DALUserLoginByUserName(User objUser)
        {
            string sql = "select UserID,UserNAme,UserPwd,UserPhone from UserTB where UserNAme=@UserNAme and UserPwd=@UserPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserNAme",objUser.UserNAme),
                new SqlParameter("@UserPwd",objUser.UserPwd)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objUser.UserID = Convert.ToInt32(objReader["UserID"].ToString());
                objUser.UserNAme = objReader["UserNAme"].ToString();
                objUser.UserPwd = objReader["UserPwd"].ToString();
                objUser.UserPhone = objReader["UserPhone"].ToString();
            }
            else
            {
                objUser = null;
            }
            objReader.Close();
            return objUser;
        }

        /// <summary>
        /// 根据手机号登陆数据访问
        /// </summary>
        /// <param name="objUser">待登陆用户</param>
        /// <returns>登陆者信息</returns>
        public User DALUserLoginByUserPhone(User objUser)
        {
            string sql = "select UserID,UserNAme,UserPwd,UserPhone from UserTB where UserPhone=@UserPhone and UserPwd=@UserPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserPhone",objUser.UserPhone),
                new SqlParameter("@UserPwd",objUser.UserPwd)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objUser.UserID = Convert.ToInt32(objReader["UserID"].ToString());
                objUser.UserNAme = objReader["UserNAme"].ToString();
                objUser.UserPwd = objReader["UserPwd"].ToString();
                objUser.UserPhone = objReader["UserPhone"].ToString();
            }
            else
            {
                objUser = null;
            }
            objReader.Close();
            return objUser;
        }
    }
}
