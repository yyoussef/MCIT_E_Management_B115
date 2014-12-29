<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" 
CodeFile="Evaluation_Dept_Weight.aspx.cs" Inherits="WebForms2_Evaluation_Dept_Weight" Title="Untitled Page" %>


<%@ Register Src="../UserControls/Evaluation_Dept_Weightl.ascx" TagName="Evaluation_Dept_Weightl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Evaluation_Dept_Weightl ID="Evaluation_Dept_Weightl" runat="server" />
    </asp:Content>

