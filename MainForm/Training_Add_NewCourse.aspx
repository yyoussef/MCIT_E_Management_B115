<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_Add_NewCourse.aspx.cs" Inherits="WebForms_Training_Add_NewCourse" Title="Untitled Page" %>







<%@ Register src="../UserControls/Training_Add_NewCourse.ascx" tagname="Training_Add_NewCourse" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <uc2:Training_Add_NewCourse ID="Training_Add_NewCourse1" runat="server" />
    
    
    
</asp:Content>

