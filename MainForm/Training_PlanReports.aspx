<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_PlanReports.aspx.cs" Inherits="MainForm_Training_PlanReports" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_PlanReports.ascx" tagname="Training_PlanReports" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <uc1:Training_PlanReports ID="Training_PlanReports1" runat="server" />


</asp:Content>

