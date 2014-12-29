<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="permission_old.aspx.cs" Inherits="WebForms2_permission_old" Title="Untitled Page" %>
<%@ Register src="../UserControls/permission_old.ascx" tagname="permission_old" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:permission_old ID="permission_old" runat="server" />
</asp:Content>

