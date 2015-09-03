<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Project_Team.ascx.vb"
    Inherits="UserControls_Project_Team" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<div>
    <input id="PTem_ID" runat="server" type="hidden" />
</div>
<div>
    <table dir="rtl" width="100%" style="line-height: 2;">
        <tr>
            <td dir="rtl" align="center" colspan="2" style="height: 44px">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="فــــــريق العــــمــــــل"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" colspan="2" style="height: 44px">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label2" runat="server" CssClass="Label" Text="فئة الوظيفــه : " />
            </td>
            <td>
                <uc1:Smart_Search ID="Smart_Search1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server" Text="الاســـــم:" CssClass="Label" />
            </td>
            <td>
                <uc1:Smart_Search ID="Smart_Search2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label3" runat="server" CssClass="Label" Text="الوظيفة بالمشروع:" Font-Bold="True"
                    Font-Size="18px" />
            </td>
            <td>
                <asp:DropDownList ID="ddlrol" runat="server" CssClass="drop" Width="90%" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label4" runat="server" CssClass="Label" Text="الــــــدور : " class="Label" />
            </td>
            <td>
                <asp:TextBox ID="txtrole" runat="server" CssClass="Text" Width="90%" Height="56px"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label5" runat="server" CssClass="Label" Text="إدخال بيانات المشروع : "
                    class="Label" />
            </td>
            <td>
                <asp:CheckBox ID="chk_Edit_Project" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" class="Text" dir="rtl">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    HorizontalAlign="Center" GridLines="Vertical">
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle Width="3px"></HeaderStyle>
                            <ItemStyle Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="فئة الوظيفــه" DataField="rol_Desc" ControlStyle-Font-Bold="true"
                            ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150"
                            ItemStyle-Wrap="true">
                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Wrap="True" Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الاســـــم" DataField="pmp_name" ControlStyle-Font-Bold="true"
                            ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100">
                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الوظيفة بالمشروع" DataField="JTIT_Desc" ControlStyle-Font-Size="Large"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
<ControlStyle Font-Size="Large"></ControlStyle>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الدور" DataField="PTem_Task" ControlStyle-Font-Bold="true"
                            ItemStyle-Width="350" ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center">
                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle Width="350px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="تعديل" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20">
                            <ItemTemplate>
                                <input id="PTem_ID" runat="server" type="hidden" value='<%# Eval("PTem_ID") %>' />
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("PTem_ID") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PTem_ID") %>'
                                    OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center"></PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
