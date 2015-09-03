<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Project_Organizations.ascx.vb"
    Inherits="UserControls_Project_Organizations" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div>
    <input id="POrg_id" runat="server" type="hidden" />
</div>
<div>
    <table style="line-height: 2; width: 98%;" align="right">
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text=" الجهــــــــات المستفيـــــدة"
                    Visible="false"></asp:Label>
                <asp:Label ID="lblexec" runat="server" CssClass="PageTitle" Text=" الجهــــــــات المنفذة"
                    Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" style="height: 44px">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="right">
                <table dir="rtl" width="100%">
                    <tr>
                        <td>
                            <table width="100%" align="right">
                                <tr>
                                    <td align="right" style="width: 136px" dir="rtl">
                                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="الجهـــــة : " />
                                    </td>
                                    <td align="right" dir="rtl" style="height: 51px" colspan="3">
                                        <uc1:Smart_Search ID="Smart_Search_org" runat="server" />
                                    </td>
                                    <%--<td>
                                       <asp:ImageButton ID="ImgBtnResearch" runat="server" Style="height: 16px" Height="18px"
                                            ImageUrl="~/Images/search.jpg" Width="27px"  />
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" style="width: 136px">
                                        <asp:Label ID="label8" runat="server" CssClass="Label" Text="مسئول الاتصال:" />
                                    </td>
                                    <td align="right" style="width: 387px">
                                        <asp:TextBox ID="txtcontactPerson" runat="server" BackColor="White" CssClass="Text" />
                                    </td>
                                    <td align="right" dir="rtl" style="width: 89px">
                                        <asp:Label ID="label7" runat="server" CssClass="Label" Text="الدور:" />
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtrole" runat="server" Height="25px" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" style="width: 136px">
                                        <asp:Label ID="label2" runat="server" CssClass="Label" Text="هاتــــف : " />
                                    </td>
                                    <td align="right" style="width: 387px">
                                        <asp:TextBox ID="txtphone" runat="server" CausesValidation="True" CssClass="Text"
                                            MaxLength="15" />
                                        <cc1:FilteredTextBoxExtender ID="txtphone_filtered" runat="server" FilterType="Custom"
                                            ValidChars="0987654321-()+" TargetControlID="txtphone" />
                                    </td>
                                    <td align="right" dir="rtl" style="width: 89px">
                                        <asp:Label ID="label4" runat="server" CssClass="Label" Text="محمــــول : " />
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtmobile" runat="server" CssClass="Text" MaxLength="15" />
                                        <cc1:FilteredTextBoxExtender ID="txtmobile_filtered" runat="server" FilterType="Custom"
                                            ValidChars="0987654321-()+" TargetControlID="txtmobile" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 136px;" dir="rtl">
                                        <asp:Label ID="label3" runat="server" CssClass="Label" Text="بريد إلكترونى : " />
                                    </td>
                                    <td align="right" style="width: 387px">
                                        <asp:TextBox ID="txtEmail" runat="server" BackColor="White" CssClass="Text" />
                                    </td>
                                    <td align="right" dir="rtl" style="width: 89px">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 136px;" dir="rtl">
                                        <asp:Label ID="label6" runat="server" CssClass="Label" Text="ملاحظـــات : " />
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:TextBox ID="txtNotes" runat="server" Width="98%" BackColor="White" Height="54px"
                                            TextMode="MultiLine" Style="margin-right: 0px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 136px;" dir="rtl">
                                        <asp:Label ID="lblchk" runat="server" CssClass="Label" Text="جهة التنفيذ الرئيسية: " />
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:CheckBox ID="chkmain" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" dir="rtl">
                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" />
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
                                    <asp:BoundField HeaderText="الجهة" DataField="Org_Desc" />
                                    <asp:BoundField HeaderText="مسئول الاتصـــال" DataField="Contact_person" />
                                    <asp:BoundField HeaderText="هاتــــف" DataField="phone" />
                                    <asp:BoundField HeaderText="بريد إلكترونى" DataField="Email" />
                                    <asp:BoundField HeaderText="محمــــول" DataField="mobile" />
                                    <asp:BoundField HeaderText="ملاحظات" DataField="Notes" />
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <input id="POrg_id" runat="server" type="hidden" value='<%# Eval("POrg_id") %>' />
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                CommandArgument='<%# Eval("POrg_id") %>' />
                                        </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("POrg_id") %>'
                                                OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                        </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
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
            </td>
        </tr>
    </table>
</div>
