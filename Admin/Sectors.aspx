<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" 
CodeFile="Sectors.aspx.cs" Inherits="Admin_Sectors" %>
<%@ Register src="../UserControls/Add_Sectors.ascx" tagname="Add_Sectors" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Add_Sectors ID="Add_Sectors" runat="server" />
</asp:Content>

