<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectFollowUpMM.aspx.cs" Inherits="WebForms_ProjectFollowUpMM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="height: 45px" align="center" colspan="2" dir="rtl">
                <asp:Label ID="Label6" runat="server" CssClass="PageTitle" Font-Bold="False" 
                    Text="تقرير الإنجازات ومتابعة الأعمال لمشروعات قطاع البنية المعلوماتية"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 46px" align="center" colspan="2" dir="rtl">
                <asp:Label ID="Label5" runat="server" Font-Bold="false" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="الإدارة :" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    CssClass="drop" Width="550px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 48px">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" OnClick="LinkButton1_Click"
                    CssClass="Text">تقرير 
            الإنجازات و متابعة الأعمال لمشروعات قطاع البنية المعلوماتية</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
