<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="project_followup.aspx.cs" Inherits="project_followup" Title="متابعة المستخدمين" %>


<%@ Register src="../UserControls/project_followup.ascx" tagname="project_followup" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:project_followup ID="project_followup1" runat="server" />
  
</asp:Content>
