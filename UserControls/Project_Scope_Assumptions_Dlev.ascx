<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_Scope_Assumptions_Dlev.ascx.cs"
    Inherits="UserControls_Project_Scope_Assumptions_Dlev" %>
<div>
    <input id="Presentation_ID" runat="server" type="hidden" value="0" />
    <input id="mode" runat="server" type="hidden" value="new" />
    <input type="hidden" runat="server" id="hidden_Id" />
    <input type="hidden" runat="server" id="hidden_Proj_id" />
    <input type="hidden" runat="server" id="hidden_type" />
    <input type="hidden" runat="server" id="hidden_flag" value="0" />
</div>
<div>
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <asp:Label ID="Lblassump" runat="server" CssClass="PageTitle" Text="الافتراضات" Visible="false" />
                <asp:Label ID="Lblscope" runat="server" CssClass="PageTitle" Text="النطاق" Visible="false" />
                <asp:Label ID="Lbldeliv" runat="server" CssClass="PageTitle" Text="المخرجات" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="الوصف:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="name" Width="700px" TextMode="MultiLine"
                    Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="height: 26px">
                <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    OnRowCommand="GrdView_RowCommand" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>

<HeaderStyle Width="1%"></HeaderStyle>

<ItemStyle Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الوصف" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("Psc_dl_asump_Desc")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("Psc_dl_asump_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("Psc_dl_asump_id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
