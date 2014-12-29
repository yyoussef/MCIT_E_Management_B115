<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Training_view_userrequest.aspx.cs" Inherits="WebForms_Training_view_userrequest" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_view_userrequest.ascx" tagname="Training_view_userrequest" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_view_userrequest ID="Training_view_userrequest1" runat="server" />
</asp:Content>

