<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Memo_Upload.aspx.cs" Inherits="MainForm_Memo_Upload" Title="Untitled Page" %>

<%@ Register src="../UserControls/Memo_Upload.ascx" tagname="Memo_Upload" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Memo_Upload ID="Memo_Upload1" runat="server" />
</asp:Content>

