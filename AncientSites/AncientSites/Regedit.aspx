<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Regedit.aspx.cs" Inherits="AncientSites.Regedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/LogAndReg.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginBox">
        <div id="center">
            <br /><br /><br /><br />
            <span class="info">&#12288;用户名：</span><asp:TextBox ID="txtUserName" runat="server" Height="29px" Width="250px" Font-Size="Medium"></asp:TextBox><br /><br />
            <span class="info">&#12288;&#12288;密码：</span><asp:TextBox ID="txtPassWord" runat="server" Height="29px" Width="250px" Font-Size="Medium"></asp:TextBox><br /><br />
            <span class="info">确认密码：</span><asp:TextBox ID="txtRepPwd" runat="server" Height="29px" Width="250px" Font-Size="Medium"></asp:TextBox><br /><br />
            <span class="info">&#12288;&#12288;手机：</span><asp:TextBox ID="txtPhoneNum" runat="server" Height="29px" Width="250px" Font-Size="Medium"></asp:TextBox><br /><br />
            <asp:Button ID="btnRegedit" runat="server" Text="注  册" BorderStyle="None" Height="40px" Width="240px" BackColor="#8B2AFA" Font-Bold="True" Font-Size="X-Large" ForeColor="White" OnClick="btnRegedit_Click1" />
            <span id="toRegedit">已有账号？<a href="Login.aspx">登陆</a></span>
        </div>
    </div>
</asp:Content>
