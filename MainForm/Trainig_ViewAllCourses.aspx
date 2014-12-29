<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Trainig_ViewAllCourses.aspx.cs" Inherits="WebForms_Trainig_ViewAllCourses" Title="Untitled Page" %>

<%@ Register src="../UserControls/Trainig_ViewAllCourses.ascx" tagname="Trainig_ViewAllCourses" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Trainig_ViewAllCourses ID="Trainig_ViewAllCourses1" runat="server" />
</asp:Content>

