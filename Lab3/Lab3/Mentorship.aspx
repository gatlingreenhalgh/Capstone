<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="Mentorship.aspx.cs" Inherits="Greenhalgh_Lab_1.Mentorship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
     <h1>Create a Mentorship</h1>
    <div>
    <asp:Label ID="lblMenteeFirstName" runat="server" Text="Student First Name"></asp:Label>
        <asp:TextBox ID="txtMenteeFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
         ID="rfvMenteeFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
         ControlToValidate ="txtMenteeFirstName"  ForeColor="Red"
         Text="Cannot be blank"
         ></asp:RequiredFieldValidator> 
        <br />
        <br />
        <br />
    <asp:Label ID="lblMenteeLastName" runat="server" Text="Student Last Name"></asp:Label>
        <asp:TextBox ID="txtMenteeLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMenteeLastName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="txtMenteeLastName" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMentorFirstName" runat="server" Text="Mentor First Name"></asp:Label>
        <asp:TextBox ID="txtMentorFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
         ID="rfvMentorFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
         ControlToValidate ="txtMentorFirstName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblMentorLastName" runat="server" Text="Mentor Last Name"></asp:Label>
        <asp:TextBox ID="txtMentorLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvMentorLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtMentorLastName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <!-- Create the buttons -->
        <asp:Button ID="btnMentorshipPopulate" runat="server" Text="Populate" Height="36px" Width="84px" OnClick="btnMentorshipPopulate_Click" CausesValidation="false"/>
        <asp:Button ID="btnMentorshipSave" runat="server" Text="Save" Height="36px" Width="84px" Onclick="btnMentorshipSave_Click"/>
        <asp:Button ID="btnMentorshipClear" runat="server" Text="Clear" Height="36px" Width="84px" OnClick="btnMentorshipClear_Click" CausesValidation="false"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Either Mentorship Already Exists or Student/Member Doesn't Exist</asp:Label>
    </div>
</asp:Content>
