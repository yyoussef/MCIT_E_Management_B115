<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Project_Attitudes.aspx.cs" Inherits="WebForms_Project_Attitude2" Title="الموقف التنفيذي للمشروع" %>



<%@ Register src="../UserControls/Project_Attitudes.ascx" tagname="Project_Attitude" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_Attitude ID="Project_Attitude1" runat="server" />
</asp:Content>

