<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AncientSites.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>古风余韵</title>
    <link href="css/Index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <%--整体布局 START--%>
         <div id="globalBox">
             <%--头部 START--%>
            <div id="header">
                <div id="headHeader">
                    <div id="btnHeadBox" style="position:absolute; left: 1720px; top: 15px;">
                        <asp:Button ID="btnHead01" runat="server" Text="登陆" BackColor="#CBCACD" BorderStyle="None" Font-Bold="True" Font-Size="Medium" OnClick="btnHead01_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnHead02" runat="server" Text="注册" BackColor="#CBCACD" BorderStyle="None" Font-Bold="True" Font-Size="Medium" OnClick="btnHead02_Click" />
                    </div>
                </div>
                <div id="headBottom">
                    <div id="search">
                        <asp:DropDownList ID="ddlSearch" runat="server" Font-Size="30px">
                            <asp:ListItem>按诗人</asp:ListItem>
                            <asp:ListItem>按诗名</asp:ListItem>
                            <asp:ListItem>按特征</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSearch" runat="server" BorderStyle="None" Font-Size="25px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="查找" BorderStyle="None" Font-Size="X-Large" OnClick="btnSearch_Click" />&nbsp;
                    </div>
                </div>
            </div>
             <%--头部 END--%>
             <%--中间 START--%>
            <div id="center">
                <div id="centerLeft">
                    <br /><br /><br /><br /><br /><br />
                        <ul runat="server" id="poetryClass">
                            <li>
                                <asp:Button ID="btnPoetrySpring" runat="server" Text="春" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnPoetrySpring_Click" />
                                <asp:Button ID="btnPoetrySummer" runat="server" Text="夏" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnPoetrySummer_Click" />
                                <asp:Button ID="btnPoetryAutumn" runat="server" Text="秋" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnPoetryAutumn_Click" />
                                <asp:Button ID="btnPoetryWinter" runat="server" Text="冬" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnPoetryWinter_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature01" runat="server" Text="柳" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature01_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnFeature02" runat="server" Text="莲" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature02_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature03" runat="server" Text="山" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature03_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnFeature04" runat="server" Text="水" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature04_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature05" runat="server" Text="露" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature05_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnFeature06" runat="server" Text="风" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature06_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature07" runat="server" Text="雨" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature07_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnFeature08" runat="server" Text="雪" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature08_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature09" runat="server" Text="莺" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature09_Click" />
                                <asp:Button ID="btnFeature10" runat="server" Text="鹰" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature10_Click" />
                                <asp:Button ID="btnFeature11" runat="server" Text="燕" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature11_Click" />
                                <asp:Button ID="btnFeature12" runat="server" Text="雁" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature12_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature13" runat="server" Text="叙事" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature13_Click" />&nbsp;
                                <asp:Button ID="btnFeature14" runat="server" Text="抒情" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature14_Click" /></li>
                            <li></li>
                            <li>
                                <asp:Button ID="btnFeature15" runat="server" Text="送别" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature15_Click" />&nbsp;
                                <asp:Button ID="btnFeature16" runat="server" Text="写景" BorderStyle="None" Font-Bold="True" Font-Size="20pt" ForeColor="#3399FF" OnClick="btnFeature16_Click" /></li>
                        </ul>
                    <br /><br />
                </div>
                <div id="lineOne"></div>
                <div id="centerMiddle" runat="server">
                    <br />
                    <h1 runat="server" id="poetessPoetry"> </h1>
                    <br />
                    <asp:Button ID="btnPoetess" runat="server" Text=" " BackColor="#656565" BorderStyle="None" Font-Bold="True" Font-Size="24px" ForeColor="#33CCFF" Height="32px" OnClick="btnPoetess_Click" Width="141px" />
                    <br /><br />
                    <ul runat="server" id="allUl">
                        <li></li>
                        <li></li>
                        <li><asp:Button ID="btnPoetry001" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry001_Click1" /></li>
                        <li><asp:Button ID="btnPoetry002" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry002_Click" /></li>
                        <li><asp:Button ID="btnPoetry003" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry003_Click" /></li>
                        <li><asp:Button ID="btnPoetry004" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry004_Click" /></li>
                        <li><asp:Button ID="btnPoetry005" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry005_Click" /></li>
                        <li><asp:Button ID="btnPoetry006" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry006_Click" /></li>
                        <li><asp:Button ID="btnPoetry007" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry007_Click" /></li>
                        <li><asp:Button ID="btnPoetry008" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry008_Click" /></li>
                        <li><asp:Button ID="btnPoetry009" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry009_Click" /></li>
                        <li><asp:Button ID="btnPoetry010" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry010_Click" /></li>
                        <li><asp:Button ID="btnPoetry011" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry011_Click" /></li>
                        <li><asp:Button ID="btnPoetry012" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry012_Click" /></li>
                        <li><asp:Button ID="btnPoetry013" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry013_Click" /></li>
                        <li><asp:Button ID="btnPoetry014" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry014_Click" /></li>
                        <li><asp:Button ID="btnPoetry015" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry015_Click" /></li>
                        <li><asp:Button ID="btnPoetry016" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry016_Click" /></li>
                        <li><asp:Button ID="btnPoetry017" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry017_Click" /></li>
                        <li><asp:Button ID="btnPoetry018" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry018_Click" /></li>
                        <li><asp:Button ID="btnPoetry019" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry019_Click" /></li>
                        <li><asp:Button ID="btnPoetry020" runat="server" Text="  " BackColor="#2F2F2F" BorderStyle="None" Font-Size="20px" ForeColor="White" OnClick="btnPoetry020_Click" /></li>
                        <li></li>
                        <li></li>
                    </ul>
                    <br /><br /><br />
                        <asp:Button ID="btnUpperPage" runat="server" BackColor="#2F2F2F" BorderStyle="None" Height="27px" Width="72px" ForeColor="White" OnClick="btnUpperPage_Click" Text="←" Font-Size="X-Large" Visible="False" />
                        &nbsp;
                    <span class="spanPage" id="showPage" runat="server">  </span>&nbsp;
                        <asp:Button ID="btnLowerPage" runat="server" Text="→" BackColor="#2F2F2F" BorderStyle="None" Height="27px" Width="72px" ForeColor="White" OnClick="btnLowerPage_Click" Font-Size="X-Large" Visible="False" />                    
                </div>
                <div id="lineTwo"></div>
                <div id="centerRight" runat="server">
                    <div id="btnBox" runat="server">&nbsp;
                        <asp:Button ID="btnTranslation" runat="server" Text="译" OnClick="btnTranslation_Click" BorderStyle="None" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCommentaries" runat="server" Text="注" BorderStyle="None" OnClick="btnCommentaries_Click" />
                        &nbsp;&nbsp;
                        <input type="button" id="btnAppreciation" value="赏" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnCollection" runat="server" Width="30px" Height="25px" ImageUrl="~/images/starNo.png" OnClick="imgBtnCollection_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" id="btnFeedback" value="反馈" />
                    </div>
                    <div id="content" runat="server">

                    </div>
                </div>
            </div>
             <%--中间 END--%>
             <%--尾部 START--%>
            <div id="footer">

            </div>
             <%--尾部 END--%>
        </div>
        <%--整体布局 END--%>
        <%--赏析 START--%>
        <div class="box" id="appreciation" runat="server">
            <div id="tiMu" runat="server">

            </div>
            <div id="biaoTi">
                <input type="button" id="btnHide" value="×" />
            </div>
            <div id="neiRong" runat="server">

            </div>
        </div>
        <%--赏析 END--%>
        <%--反馈 START--%>
        <div class="box2" id="feedback" runat="server">
            <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btnSendFeedback" runat="server" Text="提交" OnClick="btnSendFeedback_Click" />
        </div>
        <%--反馈 END--%>
    </form>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/Index.js"></script>
    <script>
        $(function () {
            $("#btnAppreciation").click(function () {
                $("#appreciation").toggle("slow");
            });
            $("#btnHide").click(function () {
                $("#appreciation").toggle("slow");
            });
            $("#btnFeedback").click(function () {
                $("#feedback").toggle("slow");
            });
        });
    </script>
</body>
</html>