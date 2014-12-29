<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Training_ViewEXUserRequests.aspx.cs" Inherits="WebForms_Training_ViewEXUserRequests" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_ViewEXUserRequests.ascx" tagname="Training_ViewEXUserRequests" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Training_ViewEXUserRequests ID="Training_ViewEXUserRequests1" 
        runat="server" />
</asp:Content>

