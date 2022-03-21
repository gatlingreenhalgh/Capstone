<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.Master" AutoEventWireup="true" CodeBehind="UploadPDF.aspx.cs" Inherits="Lab3.UploadPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Upload Your Resume</h3>
    <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
<hr />
<asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="ResumeName" HeaderText="File Name"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <a href="pdfViewer.aspx" target="_BLANK">View</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
