﻿<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_User_Register.aspx.cs" Inherits="WebForms_Training_User_Register" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_User_Register.ascx" tagname="Training_User_Register" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Training_User_Register ID="Training_User_Register1" runat="server" />

</asp:Content>

