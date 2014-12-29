<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_success_elements.aspx.cs" Inherits="WebForms2_Project_success_elements" Title="عناصر نجاح المشروع" %>

<%@ Register src="../UserControls/Project_success_elements.ascx" tagname="Project_success_elements" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_success_elements ID="Project_success_elements1" runat="server" />
</asp:Content>

