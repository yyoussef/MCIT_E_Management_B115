<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacations_errand_old.ascx.cs" Inherits="UserControls_vacations_errand_old" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
        <tr>
            <td  align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                    Text="مأموريات سابقة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2"  style="width: 144px; height: 36px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات المأموريات" Width="95px"
                    Height="25px" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text"  colspan="2">
                <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                    onrowcommand="requests_RowCommand" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="القائم بالمأمورية" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="15%" HeaderStyle-Width="15%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="15%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الجهة" HeaderStyle-Wrap="false" ItemStyle-Width="40%" HeaderStyle-Width="40%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("location")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="40%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="40%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المطلوب مقابلته" HeaderStyle-Wrap="false" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("person_to_meet")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="25%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="25%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("start_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("end_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="5%"></ItemStyle>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="2" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="direction: ltr">
                <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" 
                    Text="عودة" Width="110px" onclick="BtnVacationRequest_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="2" >
                &nbsp;</td>
        </tr>
    </table>
