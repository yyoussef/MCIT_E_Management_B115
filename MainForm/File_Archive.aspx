<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="File_Archive.aspx.cs" Inherits="Admin_Add_Dept"
    Title="أرشفة الملفات" %>

<%@ Register Src="~/UserControls/File_Archive.ascx" TagName="Add_Dept"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <uc1:Add_Dept ID="Add_Dept" runat="server" />
    
</asp:Content>
