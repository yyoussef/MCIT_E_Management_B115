<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="EmployeesAndCorrParents.aspx.cs" Inherits="WebForms_EmployeesAndCorrParents" Title="Untitled Page" %>

<%@ Register src="../UserControls/EmployeeDirectParent.ascx" tagname="EmployeeDirectParent" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:EmployeeDirectParent ID="EmployeeDirectParent1" runat="server" />
</asp:Content>

