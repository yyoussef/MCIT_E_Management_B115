<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Testing_Report.aspx.cs" Inherits="MainForm_Testing_Report" Title="تجربة تقرير" %>


<%@ Register src="../UserControls/Testing_Report.ascx" tagname="Testing_Report" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Testing_Report ID="Testing_Report" runat="server" />
  
</asp:Content>
