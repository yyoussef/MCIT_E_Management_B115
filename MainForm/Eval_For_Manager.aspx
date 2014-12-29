<%@ Page Title="تقييم الاداء لمدير" Language="C#" MasterPageFile="~/Masters/MainformMaster.master" 

AutoEventWireup="true" CodeFile="Eval_For_Manager.aspx.cs" Inherits="MainForm_Eval_For_Employee" %>

<%@ Register src="~/UserControls/Eval_For_Manager.ascx" tagname="Eval_For_Manager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Eval_For_Manager ID="Eval_For_Employee1" runat="server" />
</asp:Content>

