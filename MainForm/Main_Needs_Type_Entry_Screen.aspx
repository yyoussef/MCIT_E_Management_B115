<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Main_Needs_Type_Entry_Screen.aspx.vb" Inherits="WebForms_Main_Needs_Type_Entry_Screen" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="NMT_ID" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;">
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                            Text="الاحتياج الرئيسي للمشروع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <table width="600px" style="line-height: 2;">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="width: 94px">
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم الاحتياج : " />
                                            </td>
                                            <td align="right">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="Text" 
                                                    Height="35px" Width="377px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــظ" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="Text">
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField HeaderText="اسم الاحتياج" DataField="NMT_Desc" />
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                        CommandArgument='<%# Eval("NMT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                        OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("NMT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle BackColor="#999999" CssClass="pgr" ForeColor="Black" 
                                            HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
