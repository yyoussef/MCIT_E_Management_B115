<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Update_proj_data.aspx.cs" Inherits="WebForms_Update_proj_data" %>


<%@ Register src="../UserControls/Update_proj_data.ascx" tagname="Update_proj_data" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <uc1:Update_proj_data ID="Update_proj_data" runat="server" />
  
</asp:Content>
