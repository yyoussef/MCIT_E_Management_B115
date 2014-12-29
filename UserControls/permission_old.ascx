<%@ Control Language="C#" AutoEventWireup="true" CodeFile="permission_old.ascx.cs" Inherits="UserControls_permission_old" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 144px;
    }
</style>
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
        <tr>
            <td  align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                    Text="أذونات سابقة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" class="style1">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات الأذونات" Width="95px"
                    Height="25px" />
            </td>
        </tr>
        <tr>
        <td align="center" class="Text" colspan="2" >
            <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..." 
                ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                OnRowCommand="requests_RowCommand" Visible="False" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="طالب الإذن" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("pmp_name")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                   
                   <%-- <asp:TemplateField HeaderText="المدة " HeaderStyle-Wrap="false" ItemStyle-Width="5%"
                        HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("permission_no")%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="اليوم" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_date")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من الساعة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_hour")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="إلي" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("end_hour")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" OnClientClick="return VerifySubmit();"
                                CommandArgument='<%# Eval("id")+ ","+ Eval("user_id") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" OnClientClick="return VerifySubmit();" CommandArgument='<%# Eval("id")+","+ Eval("user_id") %>' />
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
