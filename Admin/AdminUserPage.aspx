<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="AdminUserPage.aspx.cs" Inherits="WebForms_AdminUserPage"
    Title="" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .style3
        {
            height: 39px;
        }
        .hidden
        {
            display: none;
        }
    </style>
    <table dir="rtl" style="line-height: 2; width: 85%;">
        <tr align="center">
            <td dir="rtl" style="width: 369px; height: 35px;" align="left">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="اسم المستخدم:" />
            </td>
            <td align="right">
                <uc1:Smart_Search ID="SmartEmployee" runat="server" />
            </td>
        </tr>
        <tr align="center">
            <td dir="rtl" style="width: 369px; height: 35px;" align="left">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="نوع الصلاحية:" />
            </td>
            <td align="right">
                <asp:DropDownList ID="DropModule" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Height="39px" Width="200px" OnSelectedIndexChanged="DropModule_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="center">
            <td>
            </td>
            <td>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageIndex="10">
                    <Columns>
                        <%--<asp:BoundField DataField="pk_ID" ItemStyle-CssClass="hidden"
                        HeaderStyle-CssClass="hidden" />
                    --%>
                        <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                            <ItemTemplate>
                                <asp:Label ID="lblPageID" runat="server" Text='<%# Eval("pk_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="25px" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                            <ItemTemplate>
                                <asp:Label ID="lblInsertedBefore" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="اسم الشاشة" DataField="Name" ControlStyle-Font-Size="X-Large" />
                        <asp:TemplateField HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("Dept_id") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" 
                                CommandArgument='<%# Eval("Dept_id") %>' />--%>
                                <asp:CheckBox ID="chkSelected" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2" class="style3">
                <asp:Label runat="server" ID="lblMessage" Font-Bold="true" ForeColor="Red" Font-Size="Large" />
            </td>
        </tr>
        <tr align="center">
            <td colspan="2" class="style3">
                <asp:Button ID="SaveButton" Text="حفظ" runat="server" CssClass="Button" OnClick="SaveButton_Click"
                    ValidationGroup="change" />
                &nbsb
            </td>

         
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:GridView ID="gvUserPages" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageIndex="10">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px"
                            HeaderText="م" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <%-- <asp:BoundField HeaderText="نوع الصلاحية" DataField="module" ControlStyle-Font-Size="X-Large" />--%>
                        <asp:BoundField HeaderText="اسم الشاشة" DataField="page" ControlStyle-Font-Size="X-Large" />
                        <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("pk_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
