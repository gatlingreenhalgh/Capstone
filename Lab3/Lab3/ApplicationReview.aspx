<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="ApplicationReview.aspx.cs" Inherits="Greenhalgh_Lab_1.ApplicationReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Create the headers, listboxes, labels and textboxes -->
    <h1>Application Review</h1>
    <div ID="mentorlblAlign">
    <h3>Applications</h3>
    <asp:ListBox ID="lstbxScholarships" runat="server" DataSourceID="sqlsrcApplicationTable" DataTextField="Student" DataValueField="StudentID" AutoPostBack="true" OnSelectedIndexChanged="lstbxScholarships_SelectedIndexChanged">
    </asp:ListBox>
        <asp:RequiredFieldValidator 
        ID="rfvScholarships" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="lstbxScholarships"  ForeColor="Red" Text="Must Choose an Application"
        ></asp:RequiredFieldValidator>
   
        </div>
        <h1>Application Information</h1>
    <div>
        
    <asp:Label ID="lblReviewScholarshipTitle" runat="server" Text="Scholarship Title"></asp:Label>
        <asp:TextBox ID="txtReviewScholarshipTitle" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblReviewScholarshipAmount" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="txtReviewScholarshipAmount" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblReviewScholarshipYear" runat="server" Text="Year"></asp:Label>
        <asp:TextBox ID="txtReviewScholarshipYear" runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblScholarshipStudentFN" runat="server" Text="Student First Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipStudentFN" runat="server" CssClass="postedScholTxtAlign"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="lblScholarshipStudentLN" runat="server" Text="Student Last Name"></asp:Label>
        <asp:TextBox ID="txtScholarshipStudentLN" runat="server"></asp:TextBox>
        <br />
        <br />
<h3>Scholarship Award Decison</h3>
    <asp:Label ID="lblAwardDecison" runat="server" Text="Award Scholarship?"></asp:Label>
        <asp:RadioButtonList ID="rbAwardDecison" runat="server">
            <asp:ListItem>Award</asp:ListItem>
            <asp:ListItem Selected="True" >Decline</asp:ListItem>
        </asp:RadioButtonList>
        <br /> 
    <asp:Label ID="lblAwardFN" runat="server" Text="Enter Your First Name"></asp:Label>
        <asp:TextBox ID="txtAwardFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvAwardFirstName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtAwardFirstName"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblAwardLN" runat="server" Text="Enter Your Last Name"></asp:Label>
        <asp:TextBox ID="txtAwardLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvAwardLastName" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtAwardLastName" ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
    <asp:Label ID="lblAwardDate" runat="server" Text="Enter Today's Date (mm/dd/yyyy)"></asp:Label>
        <asp:TextBox ID="txtAwardDate" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvAwardDate" runat="server" ErrorMessage="RequiredFieldValidator" 
        ControlToValidate ="txtAwardDate"  ForeColor="Red" Text="Cannot be blank"
        ></asp:RequiredFieldValidator>
        <br />
        <br />
        <!-- Create the buttons -->
    <asp:Button ID="btnApplyPopulate" runat="server" Text="Populate" CausesValidation="false" OnClick="btnApplyPopulate_Click"/>
    <asp:Button ID="btnApplySave" runat="server" Text="Save Decison" OnClick="btnApplySave_Click"/>
    <asp:Button ID="btnApplyClear" runat="server" Text="Clear" CausesValidation="false" OnClick="btnApplyClear_Click"/>
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="false">Coordinator Doesn't Exist</asp:Label>
    </div>
    <!-- Connect to the sql database -->
     <asp:SqlDataSource 
            ID="sqlsrcApplicationTable" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" 
            SelectCommand="SELECT FirstName + ' ' + LastName AS Student, Students.StudentID FROM Students, Applications WHERE Students.StudentID=Applications.StudentID">
        </asp:SqlDataSource>
</asp:Content>