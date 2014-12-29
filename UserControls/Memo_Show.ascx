<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Memo_Show.ascx.cs"
    Inherits="UserControls_MemorandumShow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="مذكرات عرض" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
            <asp:DropDownList ID="Drop_arabic_doc" Width="700px" runat="server" CssClass="drop" AutoPostBack="true" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
            <asp:Button runat="server" CssClass="Button" Text="عرض" ID="btn_arabic_doc" OnClick="btn_arabic_doc_Click" />
        </td>
    </tr>
</table>
