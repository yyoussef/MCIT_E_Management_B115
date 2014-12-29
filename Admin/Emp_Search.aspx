<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Emp_Search.aspx.cs" Inherits="Admin_Emp_Search" Title="Untitled Page" %>

<%@ Register src="../UserControls/Emp_Search.ascx" tagname="Emp_Search" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Emp_Search ID="Emp_Search1" runat="server" />
</asp:Content>

