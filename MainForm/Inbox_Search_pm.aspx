<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Inbox_Search_pm.aspx.cs" Inherits="MainForm_Inbox_Search_pm" title="بحث في الخطابات الواردة"%>


<%@ Register src="../UserControls/Inbox_Search_pm.ascx" tagname="Inbox_Search_pm" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Inbox_Search_pm ID="Inbox_Search_pm1" runat="server" />
  
</asp:Content>
