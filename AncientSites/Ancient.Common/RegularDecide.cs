using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ancient.Common
{
    public class RegularDecide
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="regularExpress">正则表达式</param>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckData(string regularExpress, string str)
        {
            Regex regex = new Regex(regularExpress);
            if (regex.IsMatch(str))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 正则表达式(邮箱)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckEmail(string str)
        {
            return this.BeginCheckData("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$", str);
        }

        /// <summary>
        /// 正则表达式(纯数字)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckOnlyNum(string str)
        {
            return this.BeginCheckData(@"^\d+$", str);
        }

        /// <summary>
        /// 正则表达式(整数或小数)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckFloatNum(string str)
        {
            int x = this.BeginCheckData(@"^\d+$", str);
            int y = this.BeginCheckData(@"^\d+(\.\d+)?$", str);
            if (x != 0 || y != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 正则表达式(纯汉字)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckChinese(string str)
        {
            return this.BeginCheckData("^[\u4e00-\u9fa5]{0,}$", str);
        }

        /// <summary>
        /// 正则表达式(英文加数字)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckEnglishNum(string str)
        {
            return this.BeginCheckData("^[A-Za-z0-9]{4,40}$", str);
        }

        /// <summary>
        /// 正则表达式(域名)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckDomainName(string str)
        {
            return this.BeginCheckData("[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(/.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+/.?", str);
        }

        /// <summary>
        /// 正则表达式(手机号)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckPhone(string str)
        {
            return this.BeginCheckData(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$", str);
        }

        /// <summary>
        /// 正则表达式(身份证号15&18)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckIdentificationCard(string str)
        {
            return this.BeginCheckData(@"^\d{15}|\d{18}$", str);
        }

        /// <summary>
        /// 正则表达式(强密码-大写字母，小写字母，数字)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckStrongPwd(string str)
        {
            return this.BeginCheckData(@"^(?=.*\d)(?=.*[a - z])(?=.*[A - Z]).{8,10}$", str);
        }

        /// <summary>
        /// 正则表达式(腾讯QQ)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckTencentQQ(string str)
        {
            return this.BeginCheckData("[1-9][0-9]{4,}", str);
        }

        /// <summary>
        /// 正则表达式(邮政编码)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckPostalCode(string str)
        {
            return this.BeginCheckData(@"[1-9]\d{5}(?!\d)", str);
        }

        /// <summary>
        /// 正则表达式(IP地址)
        /// </summary>
        /// <param name="str">要比较字符串</param>
        /// <returns></returns>
        public int BeginCheckIPAddress(string str)
        {
            return this.BeginCheckData("((?:(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d)\\.){3}(?:25[0-5]|2[0-4]\\d|[01]?\\d?\\d))", str);
        }
    }
}
