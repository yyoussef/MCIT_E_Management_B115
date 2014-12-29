<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Admin_Default2" Title="Untitled Page" %>
<%@ Register src="~/UserControls/Employee_data_new.ascx" tagname="Outbox_Search" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Outbox_Search ID="Outbox_Search1" runat="server" />

</asp:Content>

