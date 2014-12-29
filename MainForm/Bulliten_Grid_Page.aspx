<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Bulliten_Grid_Page.aspx.cs" Inherits="MainForm_Bulliten_Grid_Page" Title="Untitled Page" %>
<%@ Register src="../UserControls/Bulliten_Grid_Page.ascx" tagname="Bulliten_Grid_Page" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:Bulliten_Grid_Page ID="Bulliten_Grid_Page" runat="server" />
</asp:Content>
