<%@ Control Language="C#" AutoEventWireup="true" CodeFile="change_proj_status.ascx.cs"
    Inherits="UserControls_change_proj_status" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input id="CMT_ID" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td colspan="2" align="center" style="height: 82px">
            <asp:Label ID="lbl1" runat="server" Text="تعديل حالة المشروع" Font-Size="17pt" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbl2" runat="server" Text="المشروع :" CssClass="Label"></asp:Label>
        </td>
        <td>
            <uc1:Smart_Search ID="smart_proj" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbl_status" runat="server" Text="الحالة :" CssClass="Label"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddl_status" runat="server" CssClass="drop" AutoPostBack="true"
                Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ" Font-Size="12pt" Width="61px"
                CssClass="Button" OnClick="btnSave_Click" />
        </td>
    </tr>
</table>
