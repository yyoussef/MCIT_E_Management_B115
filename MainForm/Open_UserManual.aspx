<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Open_UserManual.aspx.cs" Inherits="MainForm_Open_UserManual" Title="دليل مستخدم" %>


<%@ Register src="../UserControls/Open_UserManual.ascx" tagname="Open_UserManual" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Open_UserManual ID="Open_UserManual" runat="server" />
  
</asp:Content>
