<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacation_errand_request.aspx.cs" Inherits="WebForms2_vacation_errand_request" Title="طلب مأمورية" %>

<%@ Register src="../UserControls/vacation_errand_request.ascx" tagname="vacation_request" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            
    
            
    <uc1:vacation_request ID="vacation_request1" runat="server" />
            
    
            
</asp:Content>

