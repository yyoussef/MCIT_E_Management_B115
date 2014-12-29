<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectReview.aspx.cs" Inherits="WebForms2_ProjectReview" Title="نشرات التعميم" %>


<%@ Register src="../UserControls/ProjectReview.ascx" tagname="ProjectReview" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ProjectReview ID="ProjectReview1" runat="server" />
</asp:Content>

