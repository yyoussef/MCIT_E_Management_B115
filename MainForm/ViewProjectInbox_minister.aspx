<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ViewProjectInbox_minister.aspx.cs" Inherits="WebForms_ViewProjectInbox_minister" Title="Untitled Page" %>

<%@ Register src="../UserControls/ViewProject_Inbox_Minister.ascx" tagname="ViewProject_Inbox_Minister" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ViewProject_Inbox_Minister ID="ViewProject_Inbox_Minister1" runat="server" />

</asp:Content>

