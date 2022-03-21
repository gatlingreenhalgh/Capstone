<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Greenhalgh_Lab_1.Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
    <h1>Add a Company</h1>
    <asp:Label ID="lblPostedScholarshipTitle" runat="server" Text="Company Name"></asp:Label>
        <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvCompanyName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtCompanyName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblCompanyAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtCompanyAddress" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvCompanyAddress" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtCompanyAddress"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblCompanyPhone" runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="txtCompanyPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvCompanyPhone" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtCompanyPhone"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>     
        <br />
        <br />
        <br />
    <asp:Label ID="lblContactFirstName" runat="server" Text="Company Contact First Name"></asp:Label>
        <asp:TextBox ID="txtContactFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvContactFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtContactFirstName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblContactLastName" runat="server" Text="Company Contact Last Name"></asp:Label>
        <asp:TextBox ID="txtContactLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvContactLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtContactLastName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblContactPhone" runat="server" Text="Company Contact Phone Number"></asp:Label>
        <asp:TextBox ID="txtContactPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvContactPhone" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtContactPhone"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblContactEmail" runat="server" Text="Company Contact Email"></asp:Label>
        <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvContactEmail" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtContactEmail"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <!-- Create the buttons -->
        <asp:Button ID="btnCompanyPopulate" runat="server" Text="Populate" Height="36px" Width="84px" OnClick="btnCompanyPopulate_Click" CausesValidation="false"/>
        <asp:Button ID="btnCompanySave" runat="server" Text="Save" Height="36px" Width="84px" OnClick="btnCompanySave_Click"/>
        <asp:Button ID="btnCompanyClear" runat="server" Text="Clear" Height="36px" Width="84px" OnClick="btnCompanyClear_Click" CausesValidation="false"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Company or Contact Already Exists</asp:Label>
</asp:Content>
