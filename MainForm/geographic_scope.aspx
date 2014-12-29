<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="geographic_scope.aspx.cs" Inherits="WebForms2_geographic_scope" Title="النطاق الجغرافي" %>


<%@ Register src="../UserControls/geographic_scope.ascx" tagname="geographic_scope" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:geographic_scope ID="geographic_scope1" runat="server" />
</asp:Content>

