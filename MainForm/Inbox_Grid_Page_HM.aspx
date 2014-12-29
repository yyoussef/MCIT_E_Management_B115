<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Inbox_Grid_Page_HM.aspx.cs" Inherits="MainForm_Inbox_Grid_Page_HM" Title="Untitled Page" %>
<%@ Register src="../UserControls/Inbox_Grid_Page_HM.ascx" tagname="Inbox_Grid_Page_HM" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:Inbox_Grid_Page_HM ID="Inbox_Grid_Page_HM" runat="server" />
</asp:Content>
