<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Training_ViewUserRegisteredCourses.aspx.cs" Inherits="WebForms_Training_ViewUserRegisteredCourses" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_ViewUserRegisteredCourses.ascx" tagname="Training_ViewUserRegisteredCourses" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <p>
        <uc1:Training_ViewUserRegisteredCourses ID="Training_ViewUserRegisteredCourses1" 
            runat="server" />
    </p>
</asp:Content>

