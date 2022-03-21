<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdfViewer.aspx.cs" Inherits="Lab3.pdfViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lstbxStudents" runat="server" DataSourceID="sqlsrcStudentTable" DataTextField="Student" DataValueField="StudentID" AutoPostBack="true">
    </asp:ListBox>
        </div>
        <asp:SqlDataSource 
            ID="sqlsrcStudentTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb2 %>" 
            SelectCommand="SELECT FirstName + ' ' + LastName AS Student, StudentID FROM Students">
        </asp:SqlDataSource>
    </form>
</body>
</html>
