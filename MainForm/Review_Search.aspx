<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Review_Search.aspx.cs" Inherits="WebForms_Review_Search" title="بحث في نشرات التعميم"%>


<%@ Register src="../UserControls/Review_Search.ascx" tagname="Review_Search" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Review_Search ID="Review_Search" runat="server" />
  
</asp:Content>
