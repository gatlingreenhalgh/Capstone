<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogins.aspx.cs" Inherits="Lab3.userlogins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <strong>Login</strong><br />
            Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" onClick="btnLogin_Click" Text="Login" />
            <br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
