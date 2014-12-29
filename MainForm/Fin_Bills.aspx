<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Fin_Bills.aspx.cs" Inherits="WebForms_Fin_Bills" Title="الفواتير" %>

<%@ Register src="../UserControls/Fin_Bills.ascx" tagname="Fin_Bills" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 
    <uc1:Fin_Bills ID="Fin_Bills1" runat="server" />

 
</asp:Content>
