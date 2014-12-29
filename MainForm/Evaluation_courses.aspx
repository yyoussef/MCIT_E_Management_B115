<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Evaluation_courses.aspx.cs" Inherits="WebForms2_Evaluation_courses" Title="Untitled Page" %>

<%@ Register src="../UserControls/Evaluation_courses.ascx" tagname="Evaluation_courses" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Evaluation_courses ID="Evaluation_courses1" runat="server" />
</asp:Content>

