<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Mng_Vacation.aspx.cs" Inherits="WebForms_Mng_Vacation" %>

<%@ Register src="../UserControls/Mng_Vacation.ascx" tagname="Mng_Vacation" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Mng_Vacation ID="Mng_Vacation1" runat="server" />
</asp:Content>

