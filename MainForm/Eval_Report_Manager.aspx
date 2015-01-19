<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Eval_Report_Manager.aspx.vb" Inherits="MainForm_Eval_Report_Manager" title="Untitled Page" %>

<%@ Register src="~/UserControls/Eval_Report_Manager.ascx" tagname="Eval_Reports" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<uc1:Eval_Reports ID="Eval_Reports" runat="server" />
</asp:Content>

