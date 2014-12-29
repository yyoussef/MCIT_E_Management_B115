<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Fin_Work_Order.aspx.cs" Inherits="WebForms_Fin_Work_Order" Title="أوامر التوريد" %>

<%@ Register src="../UserControls/Fin_Work_Order.ascx" tagname="Fin_Work_Order" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Fin_Work_Order ID="Fin_Work_Order1" runat="server" />

   </asp:Content>
