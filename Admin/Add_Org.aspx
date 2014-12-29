<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Add_Org.aspx.cs" Inherits="Admin_Add_Org" %>
<%@ Register src="../UserControls/Add_Org.ascx" tagname="Add_Org" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Add_Org ID="Add_Org" runat="server" />

</asp:Content>

