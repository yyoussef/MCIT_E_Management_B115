<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Departments_Entry_Screen.aspx.vb" Inherits="WebForms_Departments_Entry_Screen" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="Dept_ID" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;">
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                            Text="اكــــــــــــواد الادارات"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <table width="100%" style="line-height: 2;">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="width: 126px">
                                                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="القطــــــــــــــــــاع : " />
                                            </td>
                                            <td align="right">
                                                <asp:DropDownList ID="DdlSectors" runat="server" CssClass="drop" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 126px">
                                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="نــــــــــوع الادارة : " />
                                            </td>
                                            <td align="right">
                                                <asp:DropDownList ID="DdlDeptType" runat="server" CssClass="drop" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 126px; height: 76px;">
                                                <asp:Label ID="Label3" runat="server" CssClass="Label" 
                                                    Text="الادارة التابعة لها : " />
                                            </td>
                                            <td align="right" style="height: 76px">
                                                <asp:DropDownList ID="DdlRelatedDepts" runat="server" CssClass="drop" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 126px">
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اســــــــــم الادارة : " />
                                            </td>
                                            <td align="right">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="Text" Height="53px" 
                                                    Width="516px" />
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
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField HeaderText="القطاع" DataField="Sec_name" />
                                            <asp:BoundField HeaderText="نوع الادارة" DataField="Deptt_Desc" />
                                            <asp:BoundField HeaderText="الادارة التابعه لها" DataField="Related_Dept_name" />
                                            <asp:BoundField HeaderText="اسم الادارة" DataField="Dept_name" />
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                        CommandArgument='<%# Eval("Dept_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                        OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Dept_ID") %>' />
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

