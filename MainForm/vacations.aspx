<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations.aspx.cs" Inherits="WebForms2_vacations" Title="أجازاتى" %>

<%@ Register src="../UserControls/vacations.ascx" tagname="vacations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:vacations ID="vacations1" runat="server" />
    
</asp:Content>

