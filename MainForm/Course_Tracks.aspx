<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Course_Tracks.aspx.cs" Inherits="WebForms2_Course_Tracks" Title="Untitled Page" %>

<%@ Register src="../UserControls/Course_Tracks.ascx" tagname="Course_Tracks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Course_Tracks ID="Course_Tracks1" runat="server" />
</asp:Content>

