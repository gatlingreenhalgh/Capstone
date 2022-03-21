<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="Greenhalgh_Lab_1.NewJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
    <h1>Add a Job</h1>
    <asp:Label ID="lblHiringCompany" runat="server" Text="Company Name"></asp:Label>
        <asp:TextBox ID="txtHiringCompany" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvHiringCompany" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtHiringCompany"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>    
        <br />
        <br />
        <br />
    <asp:Label ID="lblJobTitle" runat="server" Text="Job Title"></asp:Label>
        <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
         ID="rfvJobTitle" runat="server" ErrorMessage="RequiredFieldValidator" 
         ControlToValidate ="txtJobTitle"  ForeColor="Red" Text="Cannot be blank"
         ></asp:RequiredFieldValidator>       
        <br />
        <br />
        <br />
    <asp:Label ID="lblJobDescription" runat="server" Text="Job Description"></asp:Label>
        <asp:TextBox ID="txtJobDescription" runat="server" style="height:60px" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator 
         ID="rfvJobDescription" runat="server" ErrorMessage="RequiredFieldValidator" 
         ControlToValidate ="txtJobDescription"  ForeColor="Red" Text="Cannot be blank"
         ></asp:RequiredFieldValidator>       
        <br />
        <br />
        <br />
    <asp:Label ID="lblJobStart" runat="server" Text="Start Date"></asp:Label>
        <asp:TextBox ID="txtJobStart" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvJobStart" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtJobStart"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>     
        <br />
        <br />
        <br />
    <!-- Create the buttons -->
        <asp:Button ID="btnJobPopulate" runat="server" Text="Populate" Height="36px" Width="84px" OnClick="btnJobPopulate_Click" CausesValidation="false"/>
        <asp:Button ID="btnJobSave" runat="server" Text="Save" Height="36px" Width="84px" OnClick="btnJobSave_Click"/>
        <asp:Button ID="btnJobClear" runat="server" Text="Clear" Height="36px" Width="84px" OnClick="btnJobClear_Click" CausesValidation="false"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Either the Job Already Exists or the Company Doesn't Exist</asp:Label>
</asp:Content>
