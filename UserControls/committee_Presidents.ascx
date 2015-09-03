<%@ Control Language="C#" AutoEventWireup="true" CodeFile="committee_Presidents.ascx.cs"
    Inherits="UserControls_committee_Presidents"%>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td>
            <input type="hidden" runat="server" id="hid_id" />
        </td>
        <td style="text-align: right">
            <asp:Label ID="Label14" runat="server" CssClass="Label" Text="  رؤساء الاقسام واللجان" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text=" إسم الموظف :" CssClass="Label" ForeColor="#808080" font-underline="false"></asp:Label>
        </td>
        <td>
            <uc1:Smart_Search ID="Smart_Search_emp" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="sectors" runat="server" Text="إسم اللجنة :" CssClass="Label"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddl_committee" runat="server" CssClass="drop" Width="200px"
                AutoPostBack="True" DataTextField="Commitee_Title" DataValueField="ID">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="رئيس القسم /الإدارة  :" CssClass="Label"></asp:Label>
        </td>
        <td>
            <uc1:Smart_Search ID="Smart_Search_mang" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td style="text-align: right">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Save" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="A"
                OnClick="btn_Save_Click" />
        </td>
    </tr>
</table>
<p>
    &nbsp;
</p>
