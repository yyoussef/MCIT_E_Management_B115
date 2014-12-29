<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 
CodeFile="Adding_Inbox_Sub_Categories.aspx.cs" Inherits="MainForm_Adding_Inbox_Sub_Categories" Title="اضافة تصنيف فرعي" %>

<%@ Register Src="../UserControls/Add_inbox_Sub_cat.ascx" TagName="Add_inbox_Sub_cat"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:Add_inbox_Sub_cat ID="Add_inbox_Sub_cat" runat="server" />

</asp:Content>

