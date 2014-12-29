<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Needs_Sub_Type_Entry_Screen.aspx.vb" Inherits="WebForms_Needs_Sub_Type_Entry_Screen" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="NST_ID" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;">
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                            Text="الاحتياجات الفرعية للمشروع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center" style="height: 44px">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <table width="" style="line-height: 2;">
                            <tr>
                                <td>
                                    <table width="">
                                        <tr>
                                            <td align="right" style="width: 141px; height: 81px;" >
                                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الاحتياج الرئيسي : " />
                                            </td>
                                            
                                            <td style="height: 81px"> 
                                            <asp:DropDownList ID="DdlMainTypes" runat="server" 
                                                    CssClass="Button" Width="450px" 
                                                    /></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 141px" >
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم الاحتيـــــــاج : " />
                                            </td>
                                            <td align="right" style="width: 176px">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="Text" 
                                                    Height="35px" Width="450px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="Text">
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField HeaderText="الاحتياج الرئيسي" DataField="NMT_Desc" />
                                            <asp:BoundField HeaderText="الاحتياج الفرعي" DataField="NST_Desc" />
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                        CommandArgument='<%# Eval("NST_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                        OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("NST_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                            HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
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
