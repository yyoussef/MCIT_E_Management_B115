<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="ViewProjectInboxminister.aspx.cs" Inherits="WebForms2_ViewProjectInboxminister" Title="Untitled Page" %>

<%@ Register src="../UserControls/ViewProject_Inbox_Minister.ascx" tagname="ViewProject_Inbox_Minister" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ViewProject_Inbox_Minister ID="ViewProject_Inbox_Minister" runat="server" />

</asp:Content>

