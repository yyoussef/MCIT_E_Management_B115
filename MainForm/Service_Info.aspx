<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master"  AutoEventWireup="true" CodeFile="Service_Info.aspx.cs" Inherits="WebForms2_Service_Info" Title="بيان الخدمة" %>

<%@ Register Src="~/UserControls/Service_Info.ascx" TagName="Service_Info"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <uc1:Service_Info ID="Service_Info" runat="server" />

</asp:Content>

