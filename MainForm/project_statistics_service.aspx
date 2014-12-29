<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="project_statistics_service.aspx.cs" Inherits="WebForms2_project_statistics_service" Title="ملفات احصائيات خدمات المشروع" %>

<%@ Register src="../UserControls/project_statistics_service.ascx" tagname="project_statistics_service" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:project_statistics_service ID="project_statistics_service" runat="server" />
</asp:Content>

