<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Adding_Inbox_Main_Categories.aspx.cs" Inherits="MainForm_Adding_Inbox_Main_Categories"
    Title="اضافة تصنيف رئيسي" %>

<%@ Register Src="../UserControls/Add_inbox_main_cat.ascx" TagName="Add_inbox_main_cat"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Add_inbox_main_cat ID="Add_inbox_main_cat" runat="server" />
    
</asp:Content>
