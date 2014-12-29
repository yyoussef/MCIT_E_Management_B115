<%@ Page Title="تقييم الاداء لموظف" Language="C#" MasterPageFile="~/Masters/MainformMaster.master" 

AutoEventWireup="true" CodeFile="Eval_For_Employee.aspx.cs" Inherits="MainForm_Eval_For_Employee" %>

<%@ Register src="../UserControls/Eval_For_Employee.ascx" tagname="Eval_For_Employee" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Eval_For_Employee ID="Eval_For_Employee1" runat="server" />
</asp:Content>

