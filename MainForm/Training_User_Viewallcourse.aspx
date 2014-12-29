<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Training_User_Viewallcourse.aspx.cs" Inherits="WebForms_Training_User_Viewallcourse" Title="Untitled Page" %>

<%@ Register src="../UserControls/Training_User_Viewallcourse.ascx" tagname="Training_User_Viewallcourse" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
  
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:Training_User_Viewallcourse ID="Training_User_Viewallcourse1" runat="server" />
</asp:Content>

