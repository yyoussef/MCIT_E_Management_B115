<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_old.aspx.cs" Inherits="WebForms2_vacations_old" Title="الأجازات" %>

<%@ Register src="../UserControls/vacations_old.ascx" tagname="vacations_old" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:vacations_old ID="vacations_old1" runat="server" />
    
</asp:Content>

