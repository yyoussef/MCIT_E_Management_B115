<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Emp_Follow_Search.aspx.cs" Inherits="WebForms_Emp_Follow_Search" Title="متابعة الموظف" %>


<%@ Register src="../UserControls/Emp_follow_Search.ascx" tagname="Emp_follow_Search" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <uc1:Emp_follow_Search ID="Emp_follow_Search" runat="server" />
   
</asp:Content>
