<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="NewScholarship.aspx.cs" Inherits="Greenhalgh_Lab_1.NewScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
    <h1>Add a Scholarship</h1>
    <asp:Label ID="lblScholarshipTitle" runat="server" Text="Scholarship Title"></asp:Label>
        <asp:TextBox ID="txtScholarshipTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvScholarshipTitle" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtScholarshipTitle"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblScholarshipAmount" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="txtScholarshipAmount" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvScholarshipAmount" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtScholarshipAmount"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblScholarshipYear" runat="server" Text="Year"></asp:Label>
        <asp:TextBox ID="txtScholarshipYear" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator 
        ID="rfvScholarshipYear" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtScholarshipYear"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblScholarshipMemberFN" runat="server" Text="Coordinator First Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipMemberFN" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvScholarshipMemberFN" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtScholarshipMemberFN"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblScholarshipMemberLN" runat="server" Text="Coordinator Last Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipMemberLN" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvScholarshipMemberLN" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtScholarshipMemberLN"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <!-- Create the buttons -->
        <asp:Button ID="btnScholarshipPopulate" runat="server" Text="Populate" Height="36px" Width="84px" OnClick="btnScholarshipPopulate_Click" CausesValidation="false"/>
        <asp:Button ID="btnScholarshipSave" runat="server" Text="Save" Height="36px" Width="84px" OnClick="btnScholarshipSave_Click"/>
        <asp:Button ID="btnScholarshipClear" runat="server" Text="Clear" Height="36px" Width="84px" OnClick="btnScholarshipClear_Click" CausesValidation="false"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Either Scholarship Already Exists or Coordinator Doesn't Exist</asp:Label>
</asp:Content>
