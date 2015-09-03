<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Service_Info.ascx.cs"
    Inherits="UserControls_Add_inbox_Sub_cat" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input id="CMT_ID" runat="server" type="hidden" />
<input id="CST_ID" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td colspan="2" align="center" style="height: 82px">
            <asp:Label ID="lbl1" runat="server" Text="كيفية الحصول على الخدمة" 
                Font-Size="17pt" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="نوع الخدمة" Width="163px" Font-Size="15pt"
                ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="Button" AutoPostBack="true"
                Width="700px" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged">
                <asp:ListItem>خدمات مواطنين</asp:ListItem>
                <asp:ListItem>خدمات</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="lbl2" runat="server" Text="الخط الساخن" Width="160px" Font-Size="15pt"
                ForeColor="Black"></asp:Label>
        </td>
        <td class="style14" style="height: 71px">
            <asp:TextBox ID="txtHotLine" runat="server" Width="700px" Height="35px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label2" runat="server" Text="خطوات الحصول على الخدمة" Width="199px"
                Font-Size="15pt" ForeColor="Black"></asp:Label>
        </td>
        <td class="style14" style="height: 71px">
            <asp:TextBox ID="txtServiceSteps" runat="server" Width="700px" Height="35px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label3" runat="server" Text="تواصل معنا" Width="160px" Font-Size="15pt"
                ForeColor="Black"></asp:Label>
        </td>
        <td class="style14" style="height: 71px">
            <asp:TextBox ID="txtContactUs" runat="server" Width="700px" Height="35px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label4" runat="server" Text="موقع خاص بالمشروع" Width="160px" Font-Size="15pt"
                ForeColor="Black"></asp:Label>
        </td>
        <td class="style14" style="height: 71px">
            <asp:TextBox ID="txtProjectLocation" runat="server" Width="700px" Height="35px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ" Font-Size="12pt" Width="61px"
                OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            &nbsp;</td>
    </tr>
</table>
