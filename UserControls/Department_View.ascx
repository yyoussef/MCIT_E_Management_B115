<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Department_View.ascx.cs"
    Inherits="UserControls_Department_View" %>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WebForms/Department_Save_Update.aspx"
                CssClass="Text">إضافه قسم</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_dept" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                OnRowCommand="gv_dept_RowCommand" AllowPaging="True" CellPadding="3" 
                GridLines="Vertical">
                <Columns>
                    <asp:BoundField DataField="Dept_name" HeaderText="اسم القسم" SortExpression="Dept_name" />
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("Dept_ID") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandArgument='<%# Eval("Dept_ID") %>' />
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
    SelectCommand="SELECT * FROM Departments"></asp:SqlDataSource>
