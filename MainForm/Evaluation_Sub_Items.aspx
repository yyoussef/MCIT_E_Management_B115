<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Evaluation_Sub_Items.aspx.cs" Inherits="MainForm_Evaluation_Sub_Items" %>



<%@ Register Src="../UserControls/Evaluation_Sub_Items.ascx" TagName="Evaluation_Dept_Weightl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:Evaluation_Dept_Weightl ID="Evaluation_Dept_Weightl" runat="server" />
    </asp:Content>

