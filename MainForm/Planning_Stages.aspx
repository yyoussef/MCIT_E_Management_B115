<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Planning_Stages.aspx.cs"
 Inherits="MainForm_Planning_Stages" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>

<%@ Register src="../UserControls/Planning_Stages.ascx" tagname="Planning_Stages" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:Planning_Stages ID="Planning_Stages1" runat="server" />

</asp:Content>

