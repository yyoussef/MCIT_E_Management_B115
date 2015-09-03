<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="project_status.aspx.vb" Inherits="WebForms_project_status" Title="حاله المشروع" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="PStat_id" runat="server" type="hidden" />
    <table width="100%" style="line-height: 2;">
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="حالة المشــــــــروع"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <table width="100%" style="line-height: 2;">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="right" style="width: 164px">
                                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="المشــــــــــــــــــروع : " />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DDLProjects" runat="server" CssClass="Button" 
                                            Width="98%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 164px">
                                        <asp:Label ID="label1" runat="server" CssClass="Label" Text="حاله المشـــــــــروع : " />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DDLStatus" runat="server" CssClass="Button" 
                                            Width="22%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 164px">
                                        <asp:Label ID="label2" runat="server" CssClass="Label" Text="تاريخ المشـــــــروع : " />
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtDateStatus" runat="server" CssClass="Text" Width="171px"></asp:TextBox>
                                        <cc1:calendarextender id="txtDateStatus_CalendarExtender" runat="server" targetcontrolid="txtDateStatus"
                                            popupbuttonid="Image1" />
                                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                            AlternateText="اضغط لعرض النتيجة" Height="23px" Width="22px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" 
                                            Width="92px" />
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
                                    <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" 
                                        ItemStyle-Width="50%">
<ItemStyle Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="حاله المشروع" DataField="stat_desc" 
                                        ItemStyle-Width="20%">
<ItemStyle Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="تاريخ المشروع" DataField="PStat_Date" 
                                        DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="20%">
<ItemStyle Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                CommandArgument='<%# Eval("PStat_id") %>' />
                                        </ItemTemplate>

<ItemStyle Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PStat_id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                        </ItemTemplate>

<ItemStyle Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#CCCCCC" />

<PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

<AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
