<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" MaintainScrollPositionOnPostback="true" 
AutoEventWireup="true" CodeFile="ViewProjectReview.aspx.cs" Inherits="MainForm_ViewProjectReview" Title="Untitled Page" %>

<%@ Register src="../UserControls/ViewProjectReview.ascx" tagname="ViewProjectReview" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:ViewProjectReview ID="ViewProjectReview" runat="server" />

</asp:Content>

