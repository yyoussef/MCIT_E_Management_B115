<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="project_img_service.aspx.cs" Inherits="WebForms2_project_img_service" Title="ملفات صور خدمات المشروع" %>

<%@ Register src="../UserControls/project_img_service.ascx" tagname="project_img_service" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:project_img_service ID="project_img_service" runat="server" />
</asp:Content>

