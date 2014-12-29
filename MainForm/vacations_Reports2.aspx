<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="vacations_Reports2.aspx.cs" Inherits="WebForms_vacations_Reports2" %>


<%@ Register src="../UserControls/vacations_report.ascx" tagname="vacations_report" tagprefix="uc1" %>


<script runat="server">

    
   
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   



    <uc1:vacations_report ID="vacations_report1" runat="server" />

   



</asp:Content>
