<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Protocol_Main_Details.aspx.cs" Inherits="WebForms_Protocol_Main_Details" Title="Untitled Page" %>

<%@ Register src="../UserControls/Protocol_Main_Details.ascx" tagname="Protocol_Main_Details" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Protocol_Main_Details ID="Protocol_Main_Details" runat="server" />

</asp:Content>
