<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_Outbox.aspx.cs" Inherits="MainForm_Project_Outbox" Title="الخطابات الصادرة" %>

<%@ Register src="../UserControls/Project_Outbox.ascx" tagname="Project_Outbox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  

  
    <uc2:Project_Outbox ID="Project_Outbox1" runat="server" />

  

  
</asp:Content>
