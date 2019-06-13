using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ancient.Models
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [Serializable]
    public class User
    {
        public int UserID { get; set; }
        public string UserNAme { get; set; }
        public string UserPwd { get; set; }
        public string UserPhone { get; set; }
    }
}
