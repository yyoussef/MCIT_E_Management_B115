<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="ProjectSearch.aspx.vb" Inherits="WebForms_ProjectSearch" Title="البحث عن مشـــــــروع" %>


<%@ Register src="../UserControls/ProjectSearch.ascx" tagname="ProjectSearch" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ProjectSearch ID="ProjectSearch1" runat="server" />
    
</asp:Content>
