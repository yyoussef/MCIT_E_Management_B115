﻿<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Course_Programs_Link.aspx.cs" Inherits="WebForms2_Course_Programs_Link" Title="Untitled Page" %>

<%@ Register src="../UserControls/Course_Programs_Link.ascx" tagname="Course_Programs_Link" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Course_Programs_Link ID="Course_Programs_Link1" runat="server" />
</asp:Content>

