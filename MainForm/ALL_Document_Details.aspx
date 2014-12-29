<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="ALL_Document_Details.aspx.cs" Inherits="MainForm_ALL_Document_Details"
    Title="Untitled Page" %>

<%@ Register Src="~/UserControls/ALL_Document_Details.ascx" TagName="ALL_Document_Details"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ALL_Document_Details ID="ALL_Document_Details1" runat="server" />
</asp:Content>
