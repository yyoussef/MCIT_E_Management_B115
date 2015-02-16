<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master"
 AutoEventWireup="true" CodeFile="ChangePassword_new.aspx.cs" Inherits="WebForms_ChangePassword" Title="تعديل كلمة المرور" %>


<%@ Register src="~/SuperAdmin/Change_Password_new.ascx" tagname="Change_Password" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" autocomplete="off">
  
    <uc1:Change_Password ID="Change_Password1" runat="server" autocomplete="off" />
  
</asp:Content>

