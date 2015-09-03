<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Project_Distributions.aspx.vb" Inherits="WebForms_Project_Distributions" 
 Title="النطاق الجغرافى للمشروع" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="PDist_id" runat="server" type="hidden" />
    <table width="100%" style="line-height: 2;">
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="النطاق الجغرافى المشــــــــروع"></asp:Label>
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
                                    <td align="right" style="width: 175px">
                                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="المشــــــــــــــــــروع : " />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DDLProjects" runat="server" CssClass="Button" 
                                            Width="450px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 175px">
                                        <asp:Label ID="label1" runat="server" CssClass="Label" Text="النطـــــــاق الجغرافى : " />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DDLDist" runat="server" Width="450px" CssClass="Button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" 
                                            Width="84px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="Text">
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                Width="660px" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                GridLines="Vertical">
                                 
                                <Columns>
                                    <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                    <asp:BoundField HeaderText="النطاق الجغرافى" DataField="DIST_Name" />
                                    <asp:TemplateField HeaderText="تعديل">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                CommandArgument='<%# Eval("PDist_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PDist_id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                        </ItemTemplate>
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
