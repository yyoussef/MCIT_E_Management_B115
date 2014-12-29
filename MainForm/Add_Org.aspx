<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Add_Org.aspx.cs" Inherits="Admin_Add_Org" %>
<%@ Register src="../UserControls/Add_Org.ascx" tagname="Outbox_Search" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Outbox_Search ID="Outbox_Search1" runat="server" />

</asp:Content>

