<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Evaluation_subItems_Manager.aspx.cs" Inherits="MainForm_Evaluation_Main_Items" %>


<%@ Register Src="~/UserControls/Evaluation_SubItems_Manager.ascx" TagName="Evaluation_Dept_Weightl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Evaluation_Dept_Weightl ID="Evaluation_Dept_Weightl" runat="server" />
    </asp:Content>

