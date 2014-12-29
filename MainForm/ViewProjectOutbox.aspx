<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" MaintainScrollPositionOnPostback="true" 
AutoEventWireup="true" CodeFile="ViewProjectOutbox.aspx.cs" Inherits="MainForm_ViewProjectOutbox" Title="Untitled Page" %>

<%@ Register src="../UserControls/ViewProject_Outbox.ascx" tagname="ViewProject_Outbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ViewProject_Outbox ID="ViewProject_Outbox" runat="server" />

</asp:Content>

