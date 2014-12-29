<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_userresult.aspx.cs" Inherits="WebForms_Training_userresult" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_userresult.ascx" tagname="Training_userresult" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_userresult ID="Training_userresult1" runat="server" />
</asp:Content>

