<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Outbox_Search.aspx.cs" Inherits="MainForm_Outbox_Search"title="بحث في الخطابات الصادرة" %>


<%@ Register src="../UserControls/Outbox_Search.ascx" tagname="Outbox_Search" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Outbox_Search ID="Outbox_Search1" runat="server" />
  
</asp:Content>
