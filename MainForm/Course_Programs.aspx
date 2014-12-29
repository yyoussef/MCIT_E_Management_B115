<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="Course_Programs.aspx.cs" Inherits="WebForms2_Course_Programs" Title="Untitled Page" %>

<%@ Register src="../UserControls/Course_Programs.ascx" tagname="Course_Programs" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Course_Programs ID="Course_Programs1" runat="server" />
</asp:Content>

