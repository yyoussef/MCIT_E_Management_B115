<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_Descion.aspx.cs" Inherits="WebForms_Training_Descion" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_Descion.ascx" tagname="Training_Descion" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_Descion ID="Training_Descion1" runat="server" />
</asp:Content>

