<%@ Page Title="" Language="C#" MasterPageFile="~/Lab3Master.Master" AutoEventWireup="true" CodeBehind="PostedJobs.aspx.cs" Inherits="Greenhalgh_Lab_1.PostedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, listboxes, labels and textboxes -->
    <h1 >Posted Jobs</h1>
    <div ID="mentorlblAlign">
    <h3>Select a Job Title</h3>
    <asp:DropDownList ID="ddlJobs" runat="server" DataSourceID="sqlsrcJobTable" DataTextField="Jobs" DataValueField="JobID" AutoPostBack="true" OnSelectedIndexChanged="lstbxJobs_SelectedIndexChanged"></asp:DropDownList>
    
   
        </div>

    
        <h1>Job Information</h1>
    <div>
        
    <asp:Label ID="lblPostedJobTitle" runat="server" Text="Job Title"></asp:Label>
        <asp:TextBox ID="txtPostedJobTitle" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedJobDescription" runat="server" Text="Job Description"></asp:Label>
        <asp:TextBox ID="txtPostedJobDescription" runat="server" TextMode="MultiLine" style="height:60px"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedStartDate" runat="server" Text="Start Date"></asp:Label>
        <asp:TextBox ID="txtPostedStartDate" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedCompany" runat="server" Text="Company"></asp:Label>
        <asp:TextBox ID="txtPostedCompany" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedContactName" runat="server" Text="Contact Name"></asp:Label>
        <asp:TextBox ID="txtPostedContactName" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedContactPhone" runat="server" Text="Contact Phone"></asp:Label>
        <asp:TextBox ID="txtPostedContactPhone" runat="server"></asp:TextBox>
        <br />
        <br />
    </div>
    <!-- Connect to the sql database -->
    <asp:SqlDataSource 
            ID="sqlsrcJobTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT JobTitle As Jobs, JobID FROM Jobs">
        </asp:SqlDataSource>
</asp:Content>
