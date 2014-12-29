<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
 CodeFile="Training_Results.aspx.cs" Inherits="MainForm_Training_Results" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_Results.ascx" tagname="Training_Results" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_Results ID="Training_Results1" runat="server" />
</asp:Content>

