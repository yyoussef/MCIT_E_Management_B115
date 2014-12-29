<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_gmanager.aspx.cs" Inherits="WebForms2_vacations_gmanager" Title="الأجازات" %>

<%@ Register src="../UserControls/vacations_gmanager.ascx" tagname="vacations_gmanager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:vacations_gmanager ID="vacations_gmanager1" runat="server" />
    
</asp:Content>

