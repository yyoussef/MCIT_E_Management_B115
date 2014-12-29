<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_Exchange.aspx.cs" Inherits="WebForms2_Project_Exchange" %>

<%@ Register src="../UserControls/Project_Exchange.ascx" tagname="Project_Exchange" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_Exchange ID="Project_Exchange1" runat="server" />
</asp:Content>

