<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" 
CodeFile="Agreement_Work_Order.aspx.cs" Inherits="MainForm_Agreement_Work_Order" Title="Untitled Page" %>
<%@ Register src="~/UserControls/Agreements_work_order.ascx" tagname="Agreement_Work_Order" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <uc1:Agreement_Work_Order ID="Agreement_Work_Order1" runat="server" />
</asp:Content>

