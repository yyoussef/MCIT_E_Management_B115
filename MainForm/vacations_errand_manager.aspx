<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_errand_manager.aspx.cs" Inherits="WebForms2_vacations_errand_manager" Title="الأجازات" %>

<%@ Register src="../UserControls/vacations_errand_manager.ascx" tagname="vacations_manager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:vacations_manager ID="vacations_manager1" runat="server" />
    
</asp:Content>

