<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="Project_Inbox_old.aspx.cs" Inherits="MainForm_Project_Inbox" Title="الخطابات الواردة" %>

<%@ Register src="../UserControls/Project_Inbox_old.ascx" tagname="Project_Inbox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_Inbox ID="Project_Inbox1" runat="server" />
</asp:Content>

