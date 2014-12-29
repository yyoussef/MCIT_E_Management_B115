<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Protocol_Main.aspx.cs" Inherits="WebForms_Protocol_Main" Title="Untitled Page" %>

<%@ Register src="../UserControls/Protocol_Main_Control.ascx" tagname="Protocol_Main_Control" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Protocol_Main_Control ID="Protocol_Main_Control1" runat="server" />

</asp:Content>
