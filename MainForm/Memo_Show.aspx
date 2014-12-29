<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Memo_Show.aspx.cs" Inherits="MainForm_Memo_Show" Title="Untitled Page" %>

<%@ Register src="../UserControls/Memo_Show.ascx" tagname="Memo_Show" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Memo_Show ID="Memo_Show1" runat="server" />
</asp:Content>

