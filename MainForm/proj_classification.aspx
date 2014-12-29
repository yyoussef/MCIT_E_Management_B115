<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="proj_classification.aspx.cs" Inherits="WebForms_proj_classification" Title="تصنيف المشروع" %>


<%@ Register src="../UserControls/proj_classification.ascx" tagname="proj_classification" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:proj_classification ID="proj_classification" runat="server" />
  
</asp:Content>
