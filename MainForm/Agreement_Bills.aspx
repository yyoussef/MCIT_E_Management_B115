<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" 
CodeFile="Agreement_Bills.aspx.cs" Inherits="MainForm_Agreement_Bills" Title="Untitled Page" %>


<%@ Register src="../UserControls/Agreement_Bills.ascx" tagname="agreement_Bills" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:agreement_Bills ID="agreement_Bills1" runat="server" />

</asp:Content>

