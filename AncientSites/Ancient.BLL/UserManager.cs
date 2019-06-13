using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ancient.DAL;
using Ancient.Models;

namespace Ancient.BLL
{
    /// <summary>
    /// 用户业务逻辑类
    /// </summary>
    public class UserManager
    {
        UserService objUserService = new UserService();

        /// <summary>
        /// 判断是否存在用户名
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>是否存在</returns>
        public bool BLLRepeat1(User objUser)
        {
            return objUserService.DALRepeat1(objUser);
        }

        /// <summary>
        /// 判断手机号是否已注册
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>是否存在</returns>
        public bool BLLRepeat2(User objUser)
        {
            return objUserService.DALRepeat2(objUser);
        }

        /// <summary>
        /// 保存注册信息
        /// </summary>
        /// <param name="objUser">待注册用户</param>
        /// <returns>1:成功;2:失败</returns>
        public int BLLSaveRegedit(User objUser)
        {
            return objUserService.DALSaveRegedit(objUser);
        }

        /// <summary>
        /// 根据用户名登陆逻辑处理
        /// </summary>
        /// <param name="objUser">待登陆用户</param>
        /// <returns>登陆者信息</returns>
        public User DALUserLoginByUserName(User objUser)
        {
            return objUserService.DALUserLoginByUserName(objUser);
        }

        /// <summary>
        /// 根据手机号登陆逻辑处理
        /// </summary>
        /// <param name="objUser">待登陆用户</param>
        /// <returns>登陆者信息</returns>
        public User DALUserLoginByUserPhone(User objUser)
        {
            return objUserService.DALUserLoginByUserPhone(objUser);
        }
    }
}
