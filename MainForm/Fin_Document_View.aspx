<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Fin_Document_View.aspx.cs" Inherits="WebForms_Fin_Document_View" Title="Untitled Page" %>
<%@ Register src="../UserControls/Fin_Document_View.ascx" tagname="Fin_Document_View" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:Fin_Document_View ID="Fin_Document_View1" runat="server" />

</asp:Content>