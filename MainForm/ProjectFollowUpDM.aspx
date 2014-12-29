<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectFollowUpDM.aspx.cs" Inherits="WebForms_ProjectFollowUpDM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="height: 49px;" align="center" colspan="2" dir="rtl">
                <asp:Label ID="Label5" runat="server" ForeColor="Red" CssClass="Label" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7" style="width: 62px">
                <asp:Label ID="Label3" runat="server" Text="الإدارة :" CssClass="Label" Font-Bold="False"></asp:Label>
            </td>
            <td style="height: 56px">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 47px">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" OnClick="LinkButton1_Click"
                    CssClass="Text" Width="412px" Height="29px">تقرير 
                        الإنجازات و متابعة الأعمال لمشروعات قطاع البنية المعلوماتية</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
