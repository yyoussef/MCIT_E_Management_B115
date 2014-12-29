<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" 
CodeFile="Training_adminapprove.aspx.cs" Inherits="MainForm_Training_adminapprove" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_adminapprove.ascx" tagname="Training_adminapprove" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_adminapprove ID="Training_adminapprove1" runat="server" />
</asp:Content>

