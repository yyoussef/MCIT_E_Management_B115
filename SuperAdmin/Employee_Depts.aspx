<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master" AutoEventWireup="true"
    CodeFile="Employee_Depts.aspx.cs" Inherits="WebForms2_Employee_Depts" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <table style="width: 100%;">
            <tr>
            <td>
            </td>
            <td>
            <asp:Label ID="MainLabel" runat="server" ForeColor="Black" 
                    Text=" تحديد الادارات التابعة للمدير العام" CssClass="Label"></asp:Label>
            </td>
            </tr>
          <%--  <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="القطاع" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_sectors" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                        DataTextField="Sec_name" DataValueField="Sec_id" OnSelectedIndexChanged="ddl_sectors_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="الإدارة" CssClass="label"></asp:Label>
                </td>
                <td>
                    <uc1:Smart_Search ID="Smart_Search_Dept" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Text="الموظف" CssClass="label"></asp:Label>
                </td>
                <td>
                    <uc1:Smart_Search ID="Smart_Search_emp" runat="server" />
                </td>
            </tr>
            <tr>
            <td></td>
                <td>
                    <asp:CheckBoxList ID="cbl_depts" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                        CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="dep_name"
                        DataValueField="dept_id" runat="server" OnSelectedIndexChanged="cbl_depts_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
            <td>&nbsp;</td>
                <td>
                                    <asp:Button runat="server" Text="حفــــــظ" ValidationGroup="A" CssClass="Button" Width="99px" ID="BtnSave" OnClick="btnSave_Click"></asp:Button>

                </td>
            </tr>
        </table>
    </p>
</asp:Content>
