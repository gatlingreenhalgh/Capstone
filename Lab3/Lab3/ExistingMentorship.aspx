<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="ExistingMentorship.aspx.cs" Inherits="Greenhalgh_Lab_1.ExistingMentorship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the headers, listboxes, labels and textboxes -->
    <h1>Mentorships</h1>
    <div ID="mentorlblAlign">
    <h3>Select a Mentor</h3>    
    <asp:ListBox ID="lstbxMentor" runat="server" DataSourceID="sqlsrcMemberTable" DataTextField="Member" DataValueField="MemberID" AutoPostBack="true" OnSelectedIndexChanged="lstbxMentor_SelectedIndexChanged">
    </asp:ListBox>
    <br />
    <br />
    <h3>Select a Student of the Selected Mentor</h3>
    <asp:ListBox ID="lstbxStudentsofMentor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstbxStudentsofMentor_SelectedIndexChanged">
    </asp:ListBox>
        </div>

        <h1>Student Information</h1>
    <div>
    <asp:Label ID="lblMentoredStudentFirstName" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblMentoredStudentLastName" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentLastName" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblMentoredStudentEmail" runat="server" Text="Email Address"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentEmail" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblMentoredStudentMajor" runat="server" Text="Major"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentMajor" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblMentoredStudentGradeLevel" runat="server" Text="Grade Level"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentGradeLevel" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblMentoredStudentEmployment" runat="server" Text="Have Been or Will Be Employed?"></asp:Label>
        <asp:TextBox ID="txtMentoredStudentEmployment" runat="server"></asp:TextBox>
        <br />
        <br />
    </div>
    <!-- Connect to the sql database -->
    <asp:SqlDataSource 
            ID="sqlsrcMemberTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT MemberFirstName + ' ' + MemberLastName AS Member, MemberID FROM Members">
        </asp:SqlDataSource>
</asp:Content>
