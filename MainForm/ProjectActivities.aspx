<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectActivities.aspx.cs" Inherits="MainForm_ProjectActivities" Title="Untitled Page" %>

<%@ Register src="~/UserControls/Project_Activities.ascx" tagname="Project_Activities" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:Project_Activities ID="Project_Activities1" runat="server" />

</asp:Content>

