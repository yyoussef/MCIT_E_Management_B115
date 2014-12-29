<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paging.ascx.cs" Inherits="UserControls_Paging" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="main" style="font-size: medium">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:LinkButton ID="FirstLB" runat="server" Text=">>">LinkButton</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="PerviousLB" runat="server" Text="السابق">LinkButton</asp:LinkButton>
            </td>
            <td>
                <asp:TextBox ID="txt_page" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="NextLB" runat="server" Text="التالي">LinkButton</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LastLB" runat="server" Text="<<">LinkButton</asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
