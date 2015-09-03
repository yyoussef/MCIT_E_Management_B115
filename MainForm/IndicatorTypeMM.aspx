<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="IndicatorTypeMM.aspx.cs" Inherits="WebForms_IndicatorTypeMM" Title="Untitled Page" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="height: 163px">
        <tr>
            <td style="height: 45px" align="center" colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="تقرير مؤشرات القياس"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 45px" align="center" colspan="2">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="#EC981F" font-underline="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" style="width: 90px; height: 36px">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="الإدارة : " CssClass="Label"></asp:Label>
            </td>
            <td style="height: 36px">
                <asp:DropDownList ID="DropDep" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropDep_SelectedIndexChanged" CssClass="drop" 
                    Width="500px" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td dir="rtl" style="width: 90px; height: 36px">
                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="المشروع : " CssClass="Label"></asp:Label>
            </td>
            <td style="height: 36px">
                <asp:DropDownList ID="DropProj" runat="server" Font-Bold="False" 
                    OnSelectedIndexChanged="DropProj_SelectedIndexChanged" CssClass="drop" Width="500px"
                    >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 39px">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" OnClick="LinkButton1_Click"
                    CssClass="Text" Font-Size="16pt">تقرير 
                مؤشرات القياس</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
