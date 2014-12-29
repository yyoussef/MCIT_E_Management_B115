<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Department_View.aspx.cs" Inherits="WebForms_Department_View" Title="Untitled Page" %>

<%@ Register src="../UserControls/Department_View.ascx" tagname="Department_View" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Department_View ID="Department_View1" runat="server" />
</asp:Content>

