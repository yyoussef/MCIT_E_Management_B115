<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Employees_Group_New.aspx.cs" Inherits="WebForms2_Employees_Group" Title="Untitled Page"
    EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="موظفي ومجموعات الأرشيف " />
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="اسم المجموعة" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_Groups_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
      <%--  <tr>
            <td >
                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="القطاع" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Sectors" runat="server" CssClass="ddl" Width="279px" OnSelectedIndexChanged="ddl_Sectors_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="الإدارة" CssClass="Label"></asp:Label>
            </td>
            <td>
                <uc1:Smart_Search ID="Smart_Search_Dept" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBoxList ID="cbl_Employees" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="empname"
                    DataValueField="PMP_ID" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button runat="server" Text="حفــــــظ" ValidationGroup="A" CssClass="Button"
                    Width="99px" ID="BtnSave" OnClick="btnSave_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
