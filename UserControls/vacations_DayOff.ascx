<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/UserControls/vacations_DayOff.ascx.cs" Inherits="UserControls_vacations_errand" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
                <tr>
                    <td dir="rtl" align="center" colspan="2">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                            Text="عمل يوم عطلة"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td align="left" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" 
                            Text="طلب عمل يوم عطلة" Width="200px" onclick="BtnVacationRequest_Click" />
                    </td>
                    <td align="right" style="direction: ltr" width="50%">
                       &nbsp; 
                        <asp:Button ID="BtnRequests" runat="server" CssClass="Button" 
                            Text="طلبات أيام عطلة" Width="200px" onclick="BtnRequests_Click" 
                            Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" dir="rtl" colspan="2">
                        <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                            ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                            onrowdatabound="requests_RowDataBound" OnRowCommand="requests_RowCommand" 
                            GridLines="Vertical">
                            <Columns>
                               <%-- <asp:TemplateField HeaderText="الجهة" ItemStyle-Width="35%" HeaderStyle-Width="35%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("location")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="المطلوب مقابلته" ItemStyle-Width="35%" HeaderStyle-Width="35%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("person_to_meet")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText= "القائم بالطلب" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("pmp_name")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                                    <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ الطلب" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("request_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                                    <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("start_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                                    <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("end_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                                    <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="الحالة" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:Label ID="VocStatus" runat="server" CssClass="Label" Text="" Height="25px" />
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="5%" />
                                    <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" Visible="false" runat="server" ImageUrl="../Images/Edit.jpg"
                                            CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" Visible="false" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
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
                <tr>
                    <td align="left" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="Button1" runat="server" CssClass="Button" 
                            Text="طلب عمل يوم عطلة" Width="200px" onclick="BtnVacationRequest_Click" />
                    </td>
                    <td align="right" style="direction: ltr" width="50%">
                       &nbsp; 
                        <asp:Button ID="Button2" runat="server" CssClass="Button" 
                            Text="طلبات أيام عطلة" Width="200px" onclick="BtnRequests_Click" 
                            Visible="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
