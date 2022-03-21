 <%@ Page Title="" Language="C#" MasterPageFile="~/Lab3Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Greenhalgh_Lab_1.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<!-- Create the header and insert the image -->
    <h1 id="headerHome" style="text-align:center; padding-top:5%">Welcome to the Ole School Alumni Group</h1>
    <asp:Image ID="imgJMU" runat="server" width = "400px" height = "300px"  style="display: block;
			 margin-left: auto;
			 margin-right: auto;
			 text-align: center;" ImageUrl="/images/ole.jpg"/>
</asp:Content>
