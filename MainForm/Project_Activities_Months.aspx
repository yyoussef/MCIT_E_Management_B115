<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true" CodeFile="Project_Activities_Months.aspx.cs" Inherits="WebForms_Project_Activities_Months" %>

<%@ Register src="../UserControls/Project_Activities_Months.ascx" tagname="Project_Activities_Months" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Project_Activities_Months ID="Project_Activities_Months1" runat="server" />
</asp:Content>

