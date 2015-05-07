<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    EnableEventValidation="true" CodeFile="Admin_Report.aspx.cs" Inherits="Admin_Admin_Report"
    Title="تقارير" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="h1" runat="server" />
    <table width="80%" style="line-height: 2; color: Black">
        <%-- <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم المستخدم:" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="Label" />
                    </td>
                </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="اسم الادارة التابع لها الموظف:" />
            </td>
            <td>
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="اسم الموظف:" />
            </td>
            <td>
                <uc1:Smart_Search ID="smart_employee" runat="server" />
            </td>
        </tr>
        <tr>
        </tr>
        <tr align="center">
            <td colspan="2">
                <br />
                <asp:Button ID="btnSave" Text="عرض التقرير" runat="server" CssClass="Button" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
