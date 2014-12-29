<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacations_DayOff.aspx.cs" Inherits="WebForms2_vacations_DayOff" Title="المأموريات" %>

<%@ Register src="~/UserControls/vacations_DayOff.ascx" tagname="vacations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <uc1:vacations ID="vacations1" runat="server" />
    
    
    
</asp:Content>

