<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Course_Places.aspx.cs" Inherits="WebForms2_Course_Places" Title="Untitled Page" %>

<%@ Register src="../UserControls/Course_Places.ascx" tagname="Course_Places" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Course_Places ID="Course_Places1" runat="server" />
</asp:Content>

