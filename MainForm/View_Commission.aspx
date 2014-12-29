<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" MaintainScrollPositionOnPostback="true"
 AutoEventWireup="true" CodeFile="View_Commission.aspx.cs" Inherits="MainForm_View_Commission" Title="Untitled Page" %>

<%@ Register src="../UserControls/View_Commission.ascx" tagname="View_Commission" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:View_Commission ID="View_Commission" runat="server" />

</asp:Content>

