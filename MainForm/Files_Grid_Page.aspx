<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Files_Grid_Page.aspx.cs" Inherits="MainForm_Files_Grid_Page" Title="Untitled Page" %>

<%@ Register src="../UserControls/Files_Grid_Page.ascx" tagname="Files_Grid_Page" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:Files_Grid_Page ID="Files_Grid_Page1" runat="server" />
    
</asp:Content>

