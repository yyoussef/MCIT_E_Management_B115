<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Inbox_Search.aspx.cs" Inherits="MainForm_Inbox_Search" title="بحث في الخطابات الواردة"%>


<%@ Register src="../UserControls/Inbox_Search.ascx" tagname="Inbox_Search" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Inbox_Search ID="Inbox_Search1" runat="server" />
  
</asp:Content>
