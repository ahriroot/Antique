using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ancient.BLL;
using Ancient.Models;
using Ancient.Common;

namespace AncientSites
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UserManager objUser1Manager = new UserManager();
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User objUser1 = new Ancient.Models.User()
            {
                UserNAme=this.txtUserName.Text,
                UserPwd=this.txtPassWord.Text
            };
            User objUser2 = new Ancient.Models.User()
            {
                UserPhone = this.txtUserName.Text,
                UserPwd = this.txtPassWord.Text
            };
            objUser1 = objUser1Manager.DALUserLoginByUserName(objUser1);
            objUser2 = objUser1Manager.DALUserLoginByUserPhone(objUser2);
            if (objUser1 == null && objUser2 == null)
            {
                if (objUser1 == null)
                {
                    Response.Write("<script>alert('用户名或密码错误!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('手机号或密码错误!')</script>");
                }
            }
            else
            {
                SaveLogUser.saveLogUser = objUser1;
                Response.Redirect("Index.aspx");
            }
        }
    }
}