<%@ Page Title="" Language="C#" MasterPageFile="~/Lab3Master.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Lab2.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    <asp:Label ID="lblUsername" runat="server" Text="Enter Your Email: "></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Enter Your Password: "></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
    <br />
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    

</asp:Content>
