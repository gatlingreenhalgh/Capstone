<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AcceptStudents.aspx.cs" Inherits="Lab3.AcceptStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>New Student Accounts</h3>
    <asp:ListBox ID="lstbxStudentAccounts" runat="server" DataSourceID="sqlsrcProposedStudents" DataTextField="Student" DataValueField="ProposedStudentID" AutoPostBack="true">
    </asp:ListBox>
        <asp:RequiredFieldValidator 
        ID="rfvSuentAccounts" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="lstbxStudentAccounts"  ForeColor="Red" Text="Must Choose a Student"
        ></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnAcceptStudent" runat="server" Text="Accept Student Account" onClick="btnAcceptStudent_Click"/>
    <br />
    <br />
    <br />
    <asp:Button ID="btnDenyStudent" runat="server" Text="Deny Student Account" onClick="btnDenyStudent_Click"/>

     <!-- Connect to the sql database -->
     <asp:SqlDataSource 
            ID="sqlsrcProposedStudents" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb2 %>" 
            SelectCommand="SELECT PSFirstName + ' ' + PSLastName AS Student, ProposedStudentID FROM ProposedStudents">
        </asp:SqlDataSource>
</asp:Content>
