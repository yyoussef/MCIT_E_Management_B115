<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectActivitiesDM.aspx.cs" Inherits="WebForms_ProjectActivitiesDM" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="2" style="height: 37px">
                <asp:Label ID="Label9" runat="server" CssClass="PageTitle" Font-Bold="False" 
                    Text="تقرير الخطة التنفيذية لمشروع"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 32px">
                <asp:Label ID="Label5" runat="server" Font-Bold="false" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 29px">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="الإدارة :" CssClass="Label"></asp:Label>
            </td>
            <td style="height: 29px">
                <asp:Label ID="Label8" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="المشروع :" CssClass="Label"></asp:Label>
            </td>
            <td style="height: 40px">
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" Font-Size="Large"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnTextChanged="DropDownList2_TextChanged"
                    CssClass="drop" Width="550px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 37px">
                <asp:LinkButton ID="PActivitiesReportLink" runat="server" Font-Bold="False" OnClick="PActivitiesReportLink_Click"
                    CssClass="Label">تقرير 
                    الخطة التنفيذية لمشروع</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
