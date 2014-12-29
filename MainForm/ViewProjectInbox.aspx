<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" MaintainScrollPositionOnPostback="true" 
AutoEventWireup="true" CodeFile="ViewProjectInbox.aspx.cs" Inherits="MainForm_ViewProjectInbox" Title="Untitled Page" %>

<%@ Register src="../UserControls/ViewProject_Inbox.ascx" tagname="ViewProject_Inbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ViewProject_Inbox ID="ViewProject_Inbox" runat="server" />

</asp:Content>

