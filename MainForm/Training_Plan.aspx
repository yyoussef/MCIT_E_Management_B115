<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Training_Plan.aspx.cs" Inherits="MainForm_Training_Plan" Title="Untitled Page" %>


<%@ Register src="../UserControls/Training_Plan.ascx" tagname="Training_Plan" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <uc1:Training_Plan ID="Training_Plan1" runat="server" />

    
</asp:Content>

