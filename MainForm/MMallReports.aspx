<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="MMallReports.aspx.cs" Inherits="WebForms2_MMallReports" Title="Untitled Page" %>




<%@ Register src="../UserControls/MMallReports.ascx" tagname="MMallReports" tagprefix="uc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%><uc1:MMallReports ID="MMallReports1" runat="server" />
&nbsp;
</asp:Content>
