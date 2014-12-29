<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Admin_Module.aspx.cs" Inherits="Admin_Admin_Module" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:CheckBoxList ID="cbl_Module" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="Name"
                    DataValueField="pk_ID" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" Text="حفــــــظ" ValidationGroup="A" CssClass="Button"
                    Width="99px" ID="BtnSave" OnClick="btnSave_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
