<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditMembersAdmin.aspx.cs" Inherits="Lab3.EditMembersAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Create header, labels and buttons-->
    <h1>Select a Student</h1>    
    <asp:ListBox ID="lstbxMembers" runat="server" DataSourceID="sqlsrcMemberTable" DataTextField="Member" DataValueField="MemberID" AutoPostBack="true" OnSelectedIndexChanged="lstbxMembers_SelectedIndexChanged">
    </asp:ListBox>
     <h3>Edit Profile</h3>
    <br />
    <br />
    <asp:Label ID="lblMemberFirstName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtMemberFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtMemberFirstName" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberLastName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtMemberLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate="txtMemberLastName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberEmail" runat="server" Text="Email Address"></asp:Label>
        <asp:TextBox ID="txtMemberEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberEmail" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberEmail"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberPhone" runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="txtMemberPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberPhone" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberPhone"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberGradYear" runat="server" Text="Graduation Year"></asp:Label>
        <asp:TextBox ID="txtMemberGradYear" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberGradYear" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberGradYear"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberTitle" runat="server" Text="Member Title"></asp:Label>
        <asp:TextBox ID="txtMemberTitle" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberTitle" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberTitle"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <!-- Create the buttons -->
        <asp:Button ID="btnMemberUpdate" runat="server" Text="Update Member Record" Height="36px" AutoPostBack="true" OnClick="btnMemberUpdate_Click"/>

    <asp:SqlDataSource 
            ID="sqlsrcMemberTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT MemberFirstName + ' ' + MemberLastName AS Member, MemberID FROM Members">
        </asp:SqlDataSource>
</asp:Content>