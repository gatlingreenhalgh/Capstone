<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AcceptMembers.aspx.cs" Inherits="Lab3.AcceptMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>New Member Accounts</h3>
    <asp:ListBox ID="lstbxMemberAccounts" runat="server" DataSourceID="sqlsrcProposedMembers" DataTextField="Member" DataValueField="ProposedMemberID" AutoPostBack="true">
    </asp:ListBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberAccounts" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="lstbxMemberAccounts"  ForeColor="Red" Text="Must Choose a Member"
        ></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnAcceptMember" runat="server" Text="Accept Member Account" onClick="btnAcceptMember_Click"/>
    <br />
    <br />
    <br />
    <asp:Button ID="btnDenyMember" runat="server" Text="Deny Member Account" onClick="btnDenyMember_Click"/>

     <!-- Connect to the sql database -->
     <asp:SqlDataSource 
            ID="sqlsrcProposedMembers" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb2 %>" 
            SelectCommand="SELECT PMMemberFirstName + ' ' + PMMemberLastName AS Member, ProposedMemberID FROM ProposedMembers">
        </asp:SqlDataSource>
</asp:Content>
