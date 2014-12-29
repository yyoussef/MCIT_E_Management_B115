<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="change_Password.aspx.cs" Inherits="MainForm_change_Password" Title="تعديل كلمة المرور" %>

<%@ Register src="../UserControls/Change_Password.ascx" tagname="Change_Password" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Change_Password ID="Change_Password1" runat="server" />
</asp:Content>

