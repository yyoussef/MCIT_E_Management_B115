<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/MainformMaster.Master" CodeFile="vocations_permission.aspx.cs" Inherits="WebForms2_vocations_permission" %>

<%@ Register src="../UserControls/vocations_permission.ascx" tagname="vocations_permission" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:vocations_permission ID="vocations_permission" runat="server" />
</asp:Content>
