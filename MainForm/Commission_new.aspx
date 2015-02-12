<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
 CodeFile="Commission_new.aspx.cs" Inherits="MainForm_Commission" Title="التكليفات" %>

<%@ Register src="~/UserControls/Commission_New.ascx" tagname="Commission" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Commission ID="Commission" runat="server" />
</asp:Content>

