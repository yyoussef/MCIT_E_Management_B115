<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Review.aspx.cs" Inherits="WebForms_Project_Inbox"  Title="الخطابات الواردة"%>


<%@ Register src="../UserControls/Project_Inbox.ascx" tagname="Project_Inbox" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
    <uc1:Project_Inbox ID="Project_Inbox1" runat="server" />

    
</asp:Content>
