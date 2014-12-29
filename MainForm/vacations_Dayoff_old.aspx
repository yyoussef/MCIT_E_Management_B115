<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_Dayoff_old.aspx.cs" Inherits="WebForms2_vacations_Dayoff_old" Title="عمل يوم عطلة" %>

<%@ Register src="../UserControls/vacations_errand_old.ascx" tagname="vacations" tagprefix="uc1" %>

<%@ Register src="../UserControls/vacations_Dayoff_old.ascx" tagname="vacations_Dayoff_old" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <uc2:vacations_Dayoff_old ID="vacations_Dayoff_old" runat="server" />
    
    
    
</asp:Content>

