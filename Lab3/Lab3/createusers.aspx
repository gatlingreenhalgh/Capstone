<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createusers.aspx.cs" Inherits="Lab3.createusers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <strong>Create User</strong><br />
            Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" onClick="btnSubmit_Click" Text="Submit" />
            <br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <br />
            <asp:LinkButton ID="lnkAnother" runat="server" onClick="lnkAnother_Click" Visible="False">Create Another</asp:LinkButton>
        </div>
    </form>
</body>
</html>
