<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="project_video_service.aspx.cs" Inherits="WebForms2_project_video_service" Title="ملفات فيديو المشروع" %>

<%@ Register src="../UserControls/project_video_service.ascx" tagname="project_video_service" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:project_video_service ID="project_video_service" runat="server" />
</asp:Content>

