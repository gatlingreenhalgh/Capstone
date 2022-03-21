<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="EditIndividualStudent.aspx.cs" Inherits="Lab2.EditIndividualStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Create header, labels and buttons-->
    <h1>Add a Student</h1>
    
    <asp:Button ID="btnViewInfo" runat="server" Text="View Info" OnClick="btnViewInfo_Click" CausesValidation="false"/>
    <br />
    <br />
    <asp:Label ID="lblStudentFirstName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtStudentFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
                ID="rfvStudentFirstName" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentFirstName" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentLastName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtStudentLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
                ID="rfvStudentLastName" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentLastName" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentEmail" runat="server" Text="Email Address"></asp:Label>
        <asp:TextBox ID="txtStudentEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
                ID="rfvStudentEmail" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentEmail" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentPhone" runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="txtStudentPhone" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator 
                ID="rfvStudentPhone" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentPhone" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentMajor" runat="server" Text="Major"></asp:Label>
        <asp:TextBox ID="txtStudentMajor" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator 
                ID="rfvStudentMajor" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentMajor" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentGradeLevel" runat="server" Text="Grade Level"></asp:Label>
        <asp:TextBox ID="txtStudentGradeLevel" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator 
                ID="rfvStudentGradeLevel" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentGradeLevel" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentGradYear" runat="server" Text="Graduation Year"></asp:Label>
        <asp:TextBox ID="txtStudentGradYear" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator 
                ID="rfvStudentGradYear" 
                runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStudentGradYear" ForeColor="Red" Text="Cannot be Blank" style="float:right;"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentInternship" runat="server" Text="Did The Student/Will The Student Have an Internship?"></asp:Label>
        <asp:DropDownList ID="ddlStudentInternship" runat="server" style="margin-left:16px">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem Selected="True">No</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
    <asp:Label ID="lblStudentJob" runat="server" Text="Did The Student/Will The Student Have a Job?"></asp:Label>
            <asp:DropDownList ID="ddlStudentJob" runat="server" style="margin-left:16px">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem Selected="True">No</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <!-- Create the buttons -->
        <asp:Button ID="btnStudentEdit" runat="server" Text="Update Student Record" Height="36px" OnClick="btnStudentEdit_Click"/>
</asp:Content>
