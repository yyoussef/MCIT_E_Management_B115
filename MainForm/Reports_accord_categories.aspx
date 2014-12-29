<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Reports_accord_categories.aspx.cs" Inherits="WebForms2_Reports_accord_categories" Title="Untitled Page" %>




<%@ Register src="../UserControls/Reports_accord_categories.ascx" tagname="Reports_accord_categories" tagprefix="uc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%><uc1:Reports_accord_categories ID="Reports_accord_categories" runat="server" />
&nbsp;
</asp:Content>
