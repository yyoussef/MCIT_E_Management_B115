<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_errand_old.aspx.cs" Inherits="WebForms2_vacations_errand_old" Title="المأموريات" %>

<%@ Register src="../UserControls/vacations_errand_old.ascx" tagname="vacations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:vacations ID="vacations1" runat="server" />
    
</asp:Content>

