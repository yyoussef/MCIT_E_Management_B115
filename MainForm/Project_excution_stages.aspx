<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_excution_stages.aspx.cs" Inherits="WebForms2_Project_excution_stages" Title="مراحل تنفيذ المشروع" %>

<%@ Register src="../UserControls/Project_excution_stages.ascx" tagname="Project_excution_stages" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_excution_stages ID="Project_excution_stages1" runat="server" />
</asp:Content>

