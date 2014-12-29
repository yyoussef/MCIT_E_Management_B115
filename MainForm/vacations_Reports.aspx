<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="vacations_Reports.aspx.cs" Inherits="WebForms2_vacations_Reports" Title="التقارير" %>


<%@ Register src="../UserControls/Vacation_Reports.ascx" tagname="Vacation_Reports" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <uc1:Vacation_Reports ID="Vacation_Reports" runat="server" />
   
</asp:Content>
