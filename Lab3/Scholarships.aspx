<%@ Page Title="" Language="C#" MasterPageFile="~/Lab3Master.Master" AutoEventWireup="true" CodeBehind="Scholarships.aspx.cs" Inherits="Greenhalgh_Lab_1.Scholarships" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the header, listboxe, labels and textboxes -->
    <h1>Available Scholarships</h1>
    <div ID="mentorlblAlign">
    <h3>Select a Scholarship</h3>
    <asp:ListBox ID="lstbxScholarships" runat="server" DataSourceID="sqlsrcScholarshipTable" DataTextField="Scholarships" DataValueField="ScholarshipID" OnSelectedIndexChanged="lstbxScholarships_SelectedIndexChanged" AutoPostBack="True">
    </asp:ListBox>
        <asp:RequiredFieldValidator 
        ID="rfvScholarships" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="lstbxScholarships"  ForeColor="Red" Text="Must Choose a Scholarship"
        ></asp:RequiredFieldValidator>
   
        </div>
        <h1>Scholarship Information</h1>
    <div>
        
    <asp:Label ID="lblPostedScholarshipTitle" runat="server" Text="Scholarship Title"></asp:Label>
        <asp:TextBox ID="txtPostedScholarshipTitle" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="PostedScholarshipAmount" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="txtPostedScholarshipAmount" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblPostedScholarshipYear" runat="server" Text="Year"></asp:Label>
        <asp:TextBox ID="txtPostedScholarshipYear" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblScholarshipMemberFN" runat="server" Text="Coordinator First Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipMemberFN" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblScholarshipMemberLN" runat="server" Text="Coordinator Last Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipMemberLN" runat="server"></asp:TextBox>
        <br />
        <br />


<h3>Apply Here For The Selected Scholarship</h3>
    <asp:Label ID="lblApplyFirstName" runat="server" Text="Enter Your First Name"></asp:Label>
        <asp:TextBox ID="txtApplyFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvApplyFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtApplyFirstName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblApplyLastName" runat="server" Text="Enter Your Last Name"></asp:Label>
        <asp:TextBox ID="txtApplyLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvApplyLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtApplyLastName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
     <asp:Label ID="lblApplyText" runat="server" Text="Why Do You Deserve This Scholarship?"></asp:Label>
        <asp:TextBox ID="txtApplyText" runat="server" style="height:60px" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtApplyText"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblApplyDate" runat="server" Text="Enter Today's Date"></asp:Label>
        <asp:TextBox ID="txtApplyDate" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvApplyDate" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtApplyDate"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <!-- Create the buttons -->
    <asp:Button ID="btnApplySave" runat="server" Text="Save Apply" OnClick="btnApplySave_Click"/>
    <asp:Button ID="btnApplyClear" runat="server" Text="Clear" OnClick="btnApplyClear_Click" CausesValidation="false"/>
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Application Already Exists</asp:Label>
    </div>
    <!-- Connect to the sql database -->
    <asp:SqlDataSource 
            ID="sqlsrcScholarshipTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT ScholarshipName AS Scholarships, ScholarshipID FROM Scholarships">
        </asp:SqlDataSource>
</asp:Content>
