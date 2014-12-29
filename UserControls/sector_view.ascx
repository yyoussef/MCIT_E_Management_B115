<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sector_view.ascx.cs" Inherits="UserControls_sector_view" %>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForms/Sector_save_update.aspx"
                CssClass="Text">إضافه قطاع</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_sector" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                OnRowCommand="gv_sector_RowCommand" CellPadding="3" GridLines="Vertical">
                <Columns>
                    <asp:BoundField DataField="Sec_name" HeaderText="اسم القطاع" SortExpression="Sec_name" />
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("Sec_id") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandArgument='<%# Eval("Sec_id") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    SelectCommand="SELECT Sectors.* FROM Sectors "></asp:SqlDataSource>
