<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add_inbox_main_cat.ascx.cs"
    Inherits="UserControls_Add_inbox_main_cat" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input id="CMT_ID" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td colspan="2" align="center" style="height: 82px">
            <h2>ادخل التصنيفات الرئيسية</h2>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblPageStatus" runat="server"  ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="lbl2" runat="server" Text="اسم التصنيف :" Width="103px" ></asp:Label>
        </td>
        <td class="style14" style="height: 71px">
            <asp:TextBox ID="txtCatName" runat="server" Width="90%" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ"  Width="61px"
                OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"  
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="اسم التصنيف" DataField="name" />
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                OnClick="ImgBtnDelete_Click" OnClientClick="javascript:return confirm('هل أنت متأكد من الحذف')" Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                </PagerStyle>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
</table>
