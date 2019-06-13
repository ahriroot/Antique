using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ancient.Common;
using Ancient.Models;
using Ancient.BLL;
using System.Configuration;

namespace AncientSites
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetConnStr();
            LogUserInfo();
        }

        #region 连接字符串
        StringProtect objStringProtect = new StringProtect();
        void GetConnStr()
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SaveConnStr.connStr = objStringProtect.Decrypt(connString, "QWER");
        }
        #endregion

        #region 用户操作
        void LogUserInfo()
        {
            if(SaveLogUser.saveLogUser.UserID != 0)
            {
                this.btnHead01.Text = SaveLogUser.saveLogUser.UserNAme;
                this.btnHead02.Text = "退出";
            }
        }

        protected void btnHead01_Click(object sender, EventArgs e)
        {
            if (this.btnHead01.Text.Equals("登陆"))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnHead02_Click(object sender, EventArgs e)
        {
            switch (this.btnHead02.Text)
            {
                case "注册":
                    Response.Redirect("Regedit.aspx");
                    break;
                case "退出":
                    SaveLogUser.saveLogUser.UserID = 0;
                    SaveLogUser.saveLogUser.UserNAme = "";
                    SaveLogUser.saveLogUser.UserPhone = "";
                    SaveLogUser.saveLogUser.UserPwd = "";
                    Response.Redirect("Index.aspx");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 保存变量
        PoetryManager objPoetryManager = new PoetryManager();
        ReadAndWrite objReadAndWrite = new ReadAndWrite();
        CommonCSS obj = new CommonCSS();//封装CSS样式
        static List<Poetry> allList = new List<Poetry>();//保存所有诗词
        static List<Poetry> localList = new List<Poetry>();//保存当前分页诗词
        static List<string> strList1 = new List<string>();//保存内容
        static List<string> strList2 = new List<string>();//保存翻译
        static List<string> strList3 = new List<string>();//保存注释
        static string title = "Kong";//保存题目
        static int poetryId = 0;//保存题目
        static string str = "kong";//保存赏析
        static int numCurrent = 1, numTotal = 1;//保存页码
        #endregion

        void Select()
        {
            if (allList.Count > 20 && allList.Count <= 40)
            {
                this.btnUpperPage.Visible = true;
                this.btnLowerPage.Visible = true;
                Index.numTotal = 2;
                if (Index.numCurrent > 0 && Index.numCurrent <= Index.numTotal)
                {
                    switch (Index.numCurrent)
                    {
                        case 1:
                            localList.Clear();
                            for (int i = 0; i < 20; i++)
                            {
                                localList.Add(allList[i]);
                            }
                            ShowBtn(localList);
                            break;
                        case 2:
                            localList.Clear();
                            for (int i = 20; i < allList.Count; i++)
                            {
                                localList.Add(allList[i]);
                            }
                            for (int i = 0; i < 40 - allList.Count; i++)
                            {
                                localList.Add(new Poetry() { PoetryName = "  " });
                            }
                            ShowBtn(localList);
                            break;
                        default:
                            break;
                    }
                }
                this.showPage.InnerText = Index.numCurrent + "/" + Index.numTotal;
            }
            else if (allList.Count <= 20)
            {
                localList.Clear();
                for (int i = 0; i < allList.Count; i++)
                {
                    localList.Add(allList[i]);
                }
                for (int i = 0; i < 20 - allList.Count; i++)
                {
                    localList.Add(new Poetry() { PoetryName = "  " });
                }
                ShowBtn(localList);
                this.btnUpperPage.Visible = false;
                this.btnLowerPage.Visible = false;
                this.showPage.InnerText = "  ";
            }
            else
            {
                this.btnUpperPage.Visible = true;
                this.btnLowerPage.Visible = true;
                Index.numTotal = 3;
                if (Index.numCurrent > 0 && Index.numCurrent <= Index.numTotal)
                {
                    switch (Index.numCurrent)
                    {
                        case 1:
                            localList.Clear();
                            for (int i = 0; i < 20; i++)
                            {
                                localList.Add(allList[i]);
                            }
                            ShowBtn(localList);
                            break;
                        case 2:
                            localList.Clear();
                            for (int i = 20; i < allList.Count; i++)
                            {
                                localList.Add(allList[i]);
                            }
                            for (int i = 0; i < 40 - allList.Count; i++)
                            {
                                localList.Add(new Poetry() { PoetryName = "  " });
                            }
                            ShowBtn(localList);
                            break;
                        case 3:
                            localList.Clear();
                            for (int i = 40; i < allList.Count; i++)
                            {
                                localList.Add(allList[i]);
                            }
                            for (int i = 0; i < 60 - allList.Count; i++)
                            {
                                localList.Add(new Poetry() { PoetryName = "  " });
                            }
                            ShowBtn(localList);
                            break;
                        default:
                            break;
                    }
                }
                this.showPage.InnerText = Index.numCurrent + "/" + Index.numTotal;
            }
        }//分页显示题目

        void ShowBtn(List<Poetry> portionList)
        {
            this.btnPoetry001.Text = portionList[0].PoetryName;
            this.btnPoetry002.Text = portionList[1].PoetryName;
            this.btnPoetry003.Text = portionList[2].PoetryName;
            this.btnPoetry004.Text = portionList[3].PoetryName;
            this.btnPoetry005.Text = portionList[4].PoetryName;
            this.btnPoetry006.Text = portionList[5].PoetryName;
            this.btnPoetry007.Text = portionList[6].PoetryName;
            this.btnPoetry008.Text = portionList[7].PoetryName;
            this.btnPoetry009.Text = portionList[8].PoetryName;
            this.btnPoetry010.Text = portionList[9].PoetryName;
            this.btnPoetry011.Text = portionList[10].PoetryName;
            this.btnPoetry012.Text = portionList[11].PoetryName;
            this.btnPoetry013.Text = portionList[12].PoetryName;
            this.btnPoetry014.Text = portionList[13].PoetryName;
            this.btnPoetry015.Text = portionList[14].PoetryName;
            this.btnPoetry016.Text = portionList[15].PoetryName;
            this.btnPoetry017.Text = portionList[16].PoetryName;
            this.btnPoetry018.Text = portionList[17].PoetryName;
            this.btnPoetry019.Text = portionList[18].PoetryName;
            this.btnPoetry020.Text = portionList[19].PoetryName;
        }//显示题目

        #region 内容,翻译,注释,赏析
        public void AddCode()
        {
            this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
            for (int i = 0; i < strList1.Count; i++)
            {
                this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
            }
            this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
            this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
        }//内容

        static int flag1 = 0, flag2 = 0;

        void ShowTranslation()
        {
            if (Index.title.Equals("Kong"))
            {
                Response.Write("<script>alert('没有内容!')</script>");
            }
            else
            {
                if (flag2 == 0)
                {
                    if (flag1 == 0)
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p2(strList2[i]);
                            this.btnTranslation.BackColor = System.Drawing.Color.Gray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag1 = 1;
                    }
                    else
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag1 = 0;
                    }
                }
                else
                {
                    if (flag1 == 0)
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p2(strList2[i]);
                            this.content.InnerHtml += obj.CSS_p3(strList3[i]);
                            this.btnTranslation.BackColor = System.Drawing.Color.Gray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag1 = 1;
                    }
                    else
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p3(strList3[i]);
                            this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag1 = 0;
                    }
                }
            }
        }//翻译

        void ShowCommentaries()
        {
            if (Index.title.Equals("Kong"))
            {
                Response.Write("<script>alert('没有内容!')</script>");
            }
            else
            {
                if (flag1 == 0)
                {
                    if (flag2 == 0)
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p3(strList3[i]);
                            this.btnCommentaries.BackColor = System.Drawing.Color.Gray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag2 = 1;
                    }
                    else
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag2 = 0;
                    }
                }
                else
                {
                    if (flag2 == 0)
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p2(strList2[i]);
                            this.content.InnerHtml += obj.CSS_p3(strList3[i]);
                            this.btnCommentaries.BackColor = System.Drawing.Color.Gray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag2 = 1;
                    }
                    else
                    {
                        this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                        for (int i = 0; i < strList1.Count; i++)
                        {
                            this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                            this.content.InnerHtml += obj.CSS_p2(strList2[i]);
                            this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                        }
                        this.content.InnerHtml += "<br/><br/>";
                        Index.flag2 = 0;
                    }
                }
            }
        }//注释

        protected void btnInAppreciation()
        {
            this.tiMu.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
            this.neiRong.InnerHtml = obj.CSS_p1(str);
        }//赏析
        #endregion

        protected void btnTranslation_Click(object sender, EventArgs e)
        {
            ShowTranslation();
        }//翻译按钮

        protected void btnCommentaries_Click(object sender, EventArgs e)
        {
            ShowCommentaries();
        }//注释按钮

        #region 选择查看 20
        protected void btnPoetry001_Click1(object sender, EventArgs e)
        {
            if (this.btnPoetry001.Text != "  ")
            {
                title = this.btnPoetry001.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[0].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[0].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[0].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[0].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[0].PoetryID;
                ShowColletImg(localList[0].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry002_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry002.Text != "  ")
            {
                title = this.btnPoetry002.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[1].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[1].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[1].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[1].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[1].PoetryID;
                ShowColletImg(localList[1].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry003_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry003.Text != "  ")
            {
                title = this.btnPoetry003.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[2].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[2].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[2].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[2].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[2].PoetryID;
                ShowColletImg(localList[2].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry004_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry004.Text != "  ")
            {
                title = this.btnPoetry004.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[3].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[3].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[3].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[3].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[3].PoetryID;
                ShowColletImg(localList[3].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry005_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry005.Text != "  ")
            {
                title = this.btnPoetry005.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[4].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[4].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[4].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[4].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[4].PoetryID;
                ShowColletImg(localList[4].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry006_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry006.Text != "  ")
            {
                title = this.btnPoetry006.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[5].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[5].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[5].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[5].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[5].PoetryID;
                ShowColletImg(localList[5].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry007_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry007.Text != "  ")
            {
                title = this.btnPoetry007.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[6].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[6].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[6].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[6].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[6].PoetryID;
                ShowColletImg(localList[6].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry008_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry008.Text != "  ")
            {
                title = this.btnPoetry008.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[7].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[7].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[7].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[7].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[7].PoetryID;
                ShowColletImg(localList[7].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry009_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry009.Text != "  ")
            {
                title = this.btnPoetry009.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[8].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[8].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[8].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[8].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[8].PoetryID;
                ShowColletImg(localList[8].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry010_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry010.Text != "  ")
            {
                title = this.btnPoetry010.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[9].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[9].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[9].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[9].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[9].PoetryID;
                ShowColletImg(localList[9].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry011_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry011.Text != "  ")
            {
                title = this.btnPoetry011.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[10].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[10].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[10].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[10].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[10].PoetryID;
                ShowColletImg(localList[10].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry012_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry012.Text != "  ")
            {
                title = this.btnPoetry012.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[11].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[11].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[11].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[11].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[11].PoetryID;
                ShowColletImg(localList[11].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry013_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry013.Text != "  ")
            {
                title = this.btnPoetry013.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[12].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[12].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[12].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[12].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[12].PoetryID;
                ShowColletImg(localList[12].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry014_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry014.Text != "  ")
            {
                title = this.btnPoetry014.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[13].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[13].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[13].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[13].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[13].PoetryID;
                ShowColletImg(localList[13].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry015_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry015.Text != "  ")
            {
                title = this.btnPoetry015.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[14].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[14].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[14].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[14].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[14].PoetryID;
                ShowColletImg(localList[14].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry016_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry016.Text != "  ")
            {
                title = this.btnPoetry016.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[15].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[15].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[15].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[15].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[15].PoetryID;
                ShowColletImg(localList[15].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry017_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry017.Text != "  ")
            {
                title = this.btnPoetry017.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[16].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[16].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[16].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[16].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[16].PoetryID;
                ShowColletImg(localList[16].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry018_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry018.Text != "  ")
            {
                title = this.btnPoetry018.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[17].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[17].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[17].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[17].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[17].PoetryID;
                ShowColletImg(localList[17].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry019_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry019.Text != "  ")
            {
                title = this.btnPoetry019.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[18].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[18].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[18].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[18].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[18].PoetryID;
                ShowColletImg(localList[18].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnPoetry020_Click(object sender, EventArgs e)
        {
            if (this.btnPoetry020.Text != "  ")
            {
                title = this.btnPoetry020.Text;
                strList1 = objReadAndWrite.ReadStreamList(localList[19].PoetryContent);
                strList2 = objReadAndWrite.ReadStreamList(localList[19].PoetryYi);
                strList3 = objReadAndWrite.ReadStreamList(localList[19].PoetryZhu);
                str = objReadAndWrite.ReadStream(localList[19].PoetryShang);
                this.content.InnerHtml = "<h1 style=" + "text-align:center;" + ">" + title + "</h1>";
                for (int i = 0; i < strList1.Count; i++)
                {
                    this.content.InnerHtml += obj.CSS_p1("<br/>" + strList1[i]);
                }
                flag1 = 0; flag2 = 0;
                this.btnTranslation.BackColor = System.Drawing.Color.LightGray;
                this.btnCommentaries.BackColor = System.Drawing.Color.LightGray;
                this.content.InnerHtml += "<br/><br/>";
                btnInAppreciation();
                Index.poetryId = localList[19].PoetryID;
                ShowColletImg(localList[19].PoetryID);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('这是空的')", true);
            }
        }

        protected void btnUpperPage_Click(object sender, EventArgs e)
        {
            if(Index.numCurrent > 0)
            {
                Index.numCurrent -= 1;
                Select();
            }
        }//上一页

        protected void btnLowerPage_Click(object sender, EventArgs e)
        {
            if (Index.numCurrent < Index.numTotal)
            {
                Index.numCurrent += 1;
                Select();
            }
        }//下一页

        protected void btnPoetess_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('诗人简介！')", true);
        }
        
        #endregion
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            switch (this.ddlSearch.SelectedIndex)
            {
                case 0:
                    allList = objPoetryManager.BLLSelectByAuthor(this.txtSearch.Text);
                    if (allList.Count > 0)
                    {
                        this.poetessPoetry.InnerText = this.txtSearch.Text + "诗集";
                        this.btnPoetess.Text = this.txtSearch.Text;
                    }
                    Select();
                    break;
                case 1:
                    allList = objPoetryManager.BLLSelectByPoetryName(this.txtSearch.Text);
                    Select();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }//搜索

        #region 按类别查找
        protected void btnPoetrySpring_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectBySeason("春");
            Select();
        }

        protected void btnPoetrySummer_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectBySeason("夏");
            Select();
        }
        
        protected void btnPoetryAutumn_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectBySeason("秋");
            Select();
        }

        protected void btnPoetryWinter_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectBySeason("冬");
            Select();
        }

        protected void btnFeature01_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("柳");
            Select();
        }

        protected void btnFeature02_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("莲");
            Select();
        }

        protected void btnFeature03_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("山");
            Select();
        }

        protected void btnFeature04_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("水");
            Select();
        }

        protected void btnFeature05_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("露");
            Select();
        }

        protected void btnFeature06_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("风");
            Select();
        }

        protected void btnFeature07_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("雨");
            Select();
        }

        protected void btnFeature08_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("雪");
            Select();
        }

        protected void btnFeature09_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("莺");
            Select();
        }

        protected void btnFeature10_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("鹰");
            Select();
        }
        
        protected void btnFeature11_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("燕");
            Select();
        }

        protected void btnFeature12_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByFeature("雁");
            Select();
        }
        protected void btnFeature13_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByClass("事");
            Select();
        }

        protected void btnFeature14_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByClass("情");
            Select();
        }

        protected void btnFeature15_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByClass("别");
            Select();
        }

        protected void btnFeature16_Click(object sender, EventArgs e)
        {
            allList = objPoetryManager.BLLSelectByClass("景");
            Select();
        }
        #endregion

        #region 显示反馈信息
        FeedbackManager objFeedbackManager = new FeedbackManager();
        protected void btnSendFeedback_Click(object sender, EventArgs e)
        {
            if (SaveLogUser.saveLogUser.UserID == 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Index.poetryId != 0)
                {
                    Feedback objFeedback1 = new Feedback()
                    {
                        FeedbackUserId = SaveLogUser.saveLogUser.UserID,
                        FeedbackPoetryId = Index.poetryId
                    };
                    Feedback objFeedback2 = new Feedback()
                    {
                        FeedbackUserId = SaveLogUser.saveLogUser.UserID,
                        FeedbackPoetryId = Index.poetryId,
                        FeedbackContent = this.txtFeedback.Text
                    };
                    objFeedback1 = objFeedbackManager.BLLReadFeedback(objFeedback1);
                    if (objFeedback1 != null)
                    {
                        if (objFeedbackManager.BLLUpdateFeedback(objFeedback2) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交成功!')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交失败!')", true);
                        }
                    }
                    else
                    {
                        if (objFeedbackManager.BLLSaveFeedback(objFeedback2) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交成功!')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('提交失败!')", true);
                        }
                    }
                }
            }
        }//反馈信息
        #endregion

        #region 显示收藏信息
        CollectManager objCollectManager = new CollectManager();
        protected void imgBtnCollection_Click(object sender, ImageClickEventArgs e)
        {
            switch (this.imgBtnCollection.ImageUrl)
            {
                case "~/images/starNo.png":
                    if (SaveLogUser.saveLogUser.UserID == 0)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        if (Index.poetryId != 0)
                        {
                            Collect objCollect2 = new Collect()
                            {
                                CollectPoetryId = Index.poetryId,
                                CollectUserId = SaveLogUser.saveLogUser.UserID
                            };
                            if(objCollectManager.BLLSaveCollect(objCollect2) == 1)
                            {
                                this.imgBtnCollection.ImageUrl = "~/images/starYes.png";
                            }
                        }
                    }
                    break;
                case "~/images/starYes.png":
                    Collect objCollect1 = new Collect()
                    {
                        CollectPoetryId = Index.poetryId,
                        CollectUserId = SaveLogUser.saveLogUser.UserID
                    };
                    if (objCollectManager.BLLDeleteCollect(objCollect1) == 1)
                    {
                        this.imgBtnCollection.ImageUrl = "~/images/starNo.png";
                    }
                    break;
                default:
                    break;
            }
        }

        void ShowColletImg(int poetryIda)
        {
            if (SaveLogUser.saveLogUser.UserID != 0)
            {
                Collect objCollect = new Collect()
                {
                    CollectPoetryId = poetryIda,
                    CollectUserId = SaveLogUser.saveLogUser.UserID
                };
                if (objCollectManager.BLLReadCollect(objCollect))
                {
                    this.imgBtnCollection.ImageUrl = "~/images/starYes.png";
                }
                else
                {
                    this.imgBtnCollection.ImageUrl = "~/images/starNo.png";
                }
            }
        }//显示收藏图片
#endregion
    }
}