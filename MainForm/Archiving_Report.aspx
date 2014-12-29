<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Archiving_Report.aspx.cs"
 Inherits="MainForm_Eval_Emp_Report" Title="Untitled Page" %>


<%@ Register src="~/UserControls/Archiving_Report.ascx" tagname="Archiving_Emp_Report" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Archiving_Emp_Report ID="Archiving_Emp_Report" runat="server" />
</asp:Content>

