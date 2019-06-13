<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AncientSites.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/LogAndReg.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div id="loginBox">
        <div id="center">
            <br /><br /><br /><br /><br /><br />
            <span class="info">用户名：</span><asp:TextBox ID="txtUserName" runat="server" Height="29px" Width="250px" Font-Size="Medium"></asp:TextBox><br /><br />
            <span class="info">密&nbsp;&nbsp;&nbsp;码：</span><asp:TextBox ID="txtPassWord" runat="server" Height="29px" Width="250px" Font-Size="Large" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="登  陆" BorderStyle="None" Height="40px" Width="240px" BackColor="#8B2AFA" Font-Bold="True" Font-Size="X-Large" ForeColor="White" OnClick="btnLogin_Click" />
            <span id="toRegedit">还没有账号？<a href="Regedit.aspx">注册</a></span>
        </div>
    </div>
</asp:Content>


