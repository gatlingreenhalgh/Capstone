<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Greenhalgh_Lab_1.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
    <h1>Add a Member</h1>
    <div>
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
    <asp:Label ID="lblMemberUser" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtMemberUser" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberUser" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberUser"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMemberPass" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtMemberPass" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMemberPass" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMemberPass"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <!-- Create the buttons -->
        <asp:Button ID="btnMemberPopulate" runat="server" Text="Populate" Height="36px" Width="84px" OnClick="btnMemberPopulate_Click" CausesValidation="false"/>
        <asp:Button ID="btnMemberSave" runat="server" Text="Save" Height="36px" Width="84px" OnClick="btnMemberSave_Click"/>
        <asp:Button ID="btnMemberClear" runat="server" Text="Clear" Height="36px" Width="84px" OnClick="btnMemberClear_Click" CausesValidation="false"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Member Already Exists</asp:Label>
    </div>
</asp:Content>
