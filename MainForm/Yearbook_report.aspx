<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Yearbook_report.aspx.cs" Inherits="MainForm_Yearbook_report" Title="Untitled Page" %>

<%@ Register src="../UserControls/Yearbook_report.ascx" tagname="Yearbook_report" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <uc1:Yearbook_report ID="Yearbook_report1" runat="server" />
  
</asp:Content>

