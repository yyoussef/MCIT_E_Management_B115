<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="change_proj_status.aspx.cs" Inherits="WebForms2_change_proj_status"
    Title="تعديل حالة المشروع" %>

<%@ Register Src="../UserControls/change_proj_status.ascx" TagName="change_proj_status"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:change_proj_status ID="change_proj_status" runat="server" />
    
</asp:Content>
