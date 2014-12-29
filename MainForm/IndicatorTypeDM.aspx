<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="IndicatorTypeDM.aspx.cs" Inherits="WebForms_IndicatorTypeDM" Title="Untitled Page" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="height: 44px"  align="center" colspan="2">
                <asp:Label ID="Label6" runat="server" CssClass="PageTitle" 
                    Text="تقرير مؤشرات القياس" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 37px"  align="center" colspan="2">
                <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 38px; width: 109px;">
                <asp:Label ID="LabDep" runat="server" Font-Bold="False" Text="الإدارة : " CssClass="Label"></asp:Label>
            </td>
            <td style="height: 38px">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 41px; width: 109px;">
                <asp:Label ID="LabProj_Mang" runat="server" Font-Bold="False" Text="مدير المشروع : "
                    CssClass="Label"></asp:Label>
            </td>
            <td style="height: 41px" valign="middle">
                <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop" 
                    Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 109px; height: 30px;">
                <asp:Label ID="LabProj" runat="server" Font-Bold="False" Text="المشروع : " CssClass="Label"></asp:Label>
            </td>
            <td style="height: 30px" dir="rtl">
                <asp:DropDownList ID="DropProj" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropProj_SelectedIndexChanged" CssClass="drop" Width="500px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 43px; width: 133px" align="center" colspan="2">
                <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" Font-Bold="False" OnClick="IndicatortypeLBdeptMang_Click"
                    CssClass="Text" Font-Size="14pt">تقرير 
                مؤشرات القياس</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
