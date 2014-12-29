<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="vacation_Dayoff_request.aspx.cs" Inherits="WebForms2_vacation_Dayoff_request" Title="طلب مأمورية" %>

<%@ Register src="../UserControls/vacation_request.ascx" tagname="vacation_request" tagprefix="uc1" %>

<%@ Register src="../UserControls/vacation_Dayoff_request.ascx" tagname="vacation_Dayoff_request" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            
    
    
            
    <uc2:vacation_Dayoff_request ID="vacation_Dayoff_request1" 
        runat="server" />
            
    
            
    
            
    
            
</asp:Content>

