<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AwardedScholarships.aspx.cs" Inherits="Lab2.AwardedScholarships" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Reviewed Scholarships</h1>
    <div>
            <asp:GridView 
                ID="gvScholarships" 
                runat="server" 
                DataSourceID="sqlsrcScholarshipQuery" 
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="First Name" DataField="FirstName"/>
                    <asp:BoundField HeaderText="Last Name" DataField="LastName"/>
                    <asp:BoundField HeaderText="Title" DataField="ScholarshipName"/>
                    <asp:BoundField HeaderText="Status" DataField="ReviewStatus"/>
                    
                </Columns>
                
            </asp:GridView>
        </div>
        <asp:SqlDataSource 
            ID="sqlsrcScholarshipQuery" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnStringOb1 %>" SelectCommand="SELECT FirstName, LastName, ScholarshipName, ReviewStatus FROM Students INNER JOIN Applications ON Students.StudentID=Applications.StudentID INNER JOIN Scholarships ON Scholarships.ScholarshipID=Applications.ScholarshipID WHERE ReviewStatus='Award' OR ReviewStatus='Decline' ORDER BY LastName">
             </asp:SqlDataSource>

</asp:Content>
