<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" 
CodeFile="Hr_Eval_Grid.aspx.cs" Inherits="MainForm_Hr_Eval_Grid" %>

<%@ Register src="../UserControls/Hr_Eval_Grid.ascx" tagname="Hr_Eval_Grid" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Hr_Eval_Grid ID="Hr_Eval_Grid1" runat="server" />
</asp:Content>

