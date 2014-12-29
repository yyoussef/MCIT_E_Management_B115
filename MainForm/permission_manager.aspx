<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="permission_manager.aspx.cs" Inherits="WebForms2_permission_manager" Title="Untitled Page" %>
<%@ Register src="../UserControls/permission_manager.ascx" tagname="permission_manager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:permission_manager ID="permission_manager" runat="server" />
</asp:Content>

