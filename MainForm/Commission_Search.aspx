<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Commission_Search.aspx.cs" Inherits="MainForm_Commission_Search" Title="بحث في التكليفات" %>


<%@ Register src="../UserControls/Commission_Search.ascx" tagname="Commission_Search" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Commission_Search ID="Commission_Search" runat="server" />
  
</asp:Content>
