<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="EditStudents.aspx.cs" Inherits="Lab2.EditStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Select a Student</h1>    
    <asp:ListBox ID="lstbxStudents" runat="server" DataSourceID="sqlsrcStudentTable" DataTextField="Student" DataValueField="StudentID" AutoPostBack="true" OnSelectedIndexChanged="lstbxStudents_SelectedIndexChanged">
    </asp:ListBox>

    <h2>Edit the Selected Students Information</h2> 
    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtFirstName" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtLastName" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvPhone" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtPhone" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvEmail" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtEmail" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblMajor" runat="server" Text="Major"></asp:Label>
        <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvMajor" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtMajor" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblGradeLevel" runat="server" Text="Grade Level"></asp:Label>
        <asp:TextBox ID="txtGradeLevel" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvGradeLevel" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtGradeLevel" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblGradYear" runat="server" Text="Graduation Year"></asp:Label>
        <asp:TextBox ID="txtGradYear" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvGradYear" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtGradYear" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblIntern" runat="server" Text="Have Been or Will Be an Intern?"></asp:Label>
        <asp:TextBox ID="txtIntern" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvIntern" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtIntern" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblEmployment" runat="server" Text="Have Been or Will Be Employed?"></asp:Label>
        <asp:TextBox ID="txtEmployment" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvEmployment" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate = "txtEmployment" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Button ID="btnEditStudent" runat="server" Text="Update Student Record" OnClick="btnEditStudent_Click"/>
    <asp:SqlDataSource 
            ID="sqlsrcStudentTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb2 %>" 
            SelectCommand="SELECT FirstName + ' ' + LastName AS Student, StudentID FROM Students">
        </asp:SqlDataSource>
</asp:Content>
