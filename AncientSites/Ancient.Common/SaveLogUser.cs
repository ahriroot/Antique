using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ancient.Models;

namespace Ancient.Common
{
    public class SaveLogUser
    {
        public static User saveLogUser = new User()
        {
            UserID = 0,
            UserNAme = "",
            UserPhone = "",
            UserPwd = ""
        };
    }
}
