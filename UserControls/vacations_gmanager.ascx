<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacations_gmanager.ascx.cs" Inherits="UserControls_vacations_gmanager" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                    Text="الأجازات"></asp:Label>
            </td>
        </tr>
         <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" dir="rtl" style="width: 144px; height: 36px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات الأجازات" Width="95px"
                    Height="25px" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" dir="rtl" colspan="2">
                <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                    onrowcommand="requests_RowCommand" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="الإدارة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("Dept_name")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="طالب الأجازة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع الأجازة" HeaderStyle-Wrap="false" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("vacation_title")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المدة باليوم" HeaderStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("no_days")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("start_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("end_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="قبول/رفض">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="AcceptRefuseRBList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" >قبول</asp:ListItem>
                                <asp:ListItem Value="2">رفض</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:TextBox ID="txt_Data" runat="server" Text='<%#Eval("id")%>' Visible="false" >
                            </asp:TextBox>
          
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                        <%--
                        
                        <asp:TemplateField HeaderText="موافقة">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رفض">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        --%>
                        
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
            <td align="center" class="Text" colspan="2" dir="rtl">
                <asp:Button ID="Btn_AcceptReject" runat="server" CssClass="Button" 
                    onclick="Btn_AcceptReject_Click" Text="موافق" Width="103px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="direction: ltr">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="2" dir="rtl">
                &nbsp;</td>
        </tr>
    </table>