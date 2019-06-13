using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ancient.Common;
using Ancient.Models;
using Ancient.BLL;

namespace AncientSites
{
    public partial class Regedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        RegularDecide objRegularDecide = new RegularDecide();
        UserManager objUserManager = new UserManager();

        protected void btnRegedit_Click1(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Equals(string.Empty))
            {
                Response.Write("<script>alert('请输入用户名!')</script>");
                this.txtUserName.Focus();
            }
            else if (this.txtPassWord.Text.Equals(string.Empty))
            {
                Response.Write("<script>alert('请输入密码!')</script>");
                this.txtPassWord.Focus();
            }
            else if (this.txtPhoneNum.Text.Equals(string.Empty))
            {
                Response.Write("<script>alert('请输入手机号!')</script>");
                this.txtPhoneNum.Focus();
            }
            else if (!this.txtPassWord.Text.Equals(this.txtRepPwd.Text))
            {
                Response.Write("<script>alert('两次密码不一致!')</script>");
                this.txtRepPwd.Focus();
            }
            else
            {
                if (objRegularDecide.BeginCheckPhone(this.txtPhoneNum.Text) == 1)
                {
                    User objUser = new User()
                    {
                        UserNAme = this.txtUserName.Text,
                        UserPwd = this.txtPassWord.Text,
                        UserPhone = this.txtPhoneNum.Text
                    };
                    if (objUserManager.BLLRepeat1(objUser) == true)
                    {
                        Response.Write("<script>alert('已存在该用户名!')</script>");
                    }
                    else if (objUserManager.BLLRepeat2(objUser) == true)
                    {
                        Response.Write("<script>alert('该手机号已注册!')</script>");
                    }
                    else
                    {
                        if (objUserManager.BLLSaveRegedit(objUser) == 1)
                        {
                            Response.Write("<script>alert('注册成功!')</script>");
                            this.txtUserName.Text = string.Empty;
                            this.txtPassWord.Text = string.Empty;
                            this.txtRepPwd.Text = string.Empty;
                            this.txtPhoneNum.Text = string.Empty;
                            //Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('注册失败!')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('请输入正确手机号!')</script>");
                }
            }
        }
    }
}