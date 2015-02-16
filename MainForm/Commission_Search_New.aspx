<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Commission_Search_New.aspx.cs" Inherits="MainForm_Commission_Search_New" %>

<%@ Register Src="~/UserControls/Commission_Search_New.ascx" TagPrefix="uc1" TagName="Commission_Search_New" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Commission_Search_New runat="server" ID="Commission_Search_New" />

</asp:Content>

