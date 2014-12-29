<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Commitee.aspx.cs" Inherits="Admin_Add_Dept"
    Title="اللجان" %>

<%@ Register Src="~/UserControls/Commitee.ascx" TagName="Add_Dept"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Add_Dept ID="Add_Dept" runat="server" />
    
</asp:Content>
