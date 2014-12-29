<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="emp_search.aspx.cs" Inherits="MainForm_Add_fav" Title="بحث عن بيانات موظف" %>


<%@ Register src="../UserControls/Emp_Search.ascx" tagname="Add_Fav" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Add_Fav ID="Add_Fav" runat="server" />
  
</asp:Content>
