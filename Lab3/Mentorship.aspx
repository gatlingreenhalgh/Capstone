<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="Mentorship.aspx.cs" Inherits="Greenhalgh_Lab_1.Mentorship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, labels and textboxes -->
     <h1>Create a Mentorship</h1>
    <div>
     <h1>Mentorships</h1>
    <div ID="mentorlblAlign">
    <h3>Select a Mentor</h3>    
    <asp:ListBox ID="lstbxMentor" runat="server" DataSourceID="sqlsrcMemberTable" DataTextField="Member" DataValueField="MemberID" AutoPostBack="true">
    </asp:ListBox>
    <br />
    <br />
    <h3>Select a Student</h3>
    <asp:ListBox ID="lstbxStudent" runat="server" DataSourceID="sqlsrcStudentTable" DataTextField="Student" DataValueField="StudentID" AutoPostBack="true">
    </asp:ListBox>
        </div>
        <!-- Create the buttons -->
        <asp:Button ID="btnMentorshipSave" runat="server" Text="Save" Height="36px" Width="84px" Onclick="btnMentorshipSave_Click"/>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Mentorship Already Exists</asp:Label>
    </div>
    <asp:SqlDataSource 
            ID="sqlsrcMemberTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT MemberFirstName + ' ' + MemberLastName AS Member, MemberID FROM Members">
        </asp:SqlDataSource>
    <asp:SqlDataSource 
            ID="sqlsrcStudentTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT FirstName + ' ' + LastName AS Student, StudentID FROM Students">
        </asp:SqlDataSource>
</asp:Content>
