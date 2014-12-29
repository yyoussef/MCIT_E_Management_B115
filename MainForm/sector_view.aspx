<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="sector_view.aspx.cs" Inherits="WebForms_sector_view" Title="Untitled Page" %>

<%@ Register src="../UserControls/sector_view.ascx" tagname="sector_view" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:sector_view ID="sector_view1" runat="server" />
</asp:Content>

