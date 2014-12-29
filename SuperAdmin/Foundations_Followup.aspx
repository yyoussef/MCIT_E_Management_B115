<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="Foundations_Followup.aspx.cs" Inherits="SuperAdmin_Foundations_Followup" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/Foundations_Followup.ascx" TagName="Found_follow" TagPrefix="ucf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<ucf:Found_follow  ID="found_follow1" runat="server" />

</asp:Content>

