<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="MemorandumShow.aspx.cs" Inherits="MainForm_MemorandumShow" Title="مذكرات عرض" %>


<%@ Register src="../UserControls/MemorandumShow.ascx" tagname="MemorandumShow" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:MemorandumShow ID="MemorandumShow" runat="server" />
  
</asp:Content>
