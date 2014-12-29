<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="permission_request.aspx.cs" Inherits="WebForms2_permission_request" Title="Untitled Page" %>
<%@ Register src="../UserControls/permission_request.ascx" tagname="permission_request" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:permission_request ID="permission_request" runat="server" />
</asp:Content>

