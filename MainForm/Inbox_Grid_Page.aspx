<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Inbox_Grid_Page.aspx.cs" Inherits="MainForm_Inbox_Grid_Page" Title="Untitled Page" %>
<%@ Register src="../UserControls/Inbox_Grid_Page.ascx" tagname="Inbox_Grid_Page" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:Inbox_Grid_Page ID="Inbox_Grid_Page" runat="server" />
</asp:Content>
