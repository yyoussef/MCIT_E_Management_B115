<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Inbox_Search_pm.ascx.cs"
    Inherits="UserControls_Inbox_Search_pm" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="بحث في الارشيف" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 142px">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="الجهة  : "></asp:Label>
        </td>
        <td align="right" dir="rtl" colspan="2">
            <uc1:Smart_Search ID="Smrt_Srch_org" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
                &nbsb
                <%--<asp:Button ID="Button1" runat="server" Text="تصدير الي إكسل" Width="130px" CssClass="Button"
                        OnClick="Button1_Click" />--%>
            </div>
        </td>
    </tr>
     <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="btnReport" Text="طباعة" OnClick="btnReport_Click" runat="server"
                    CssClass="Button"   />
                &nbsb
                <%--<asp:Button ID="Button1" runat="server" Text="تصدير الي إكسل" Width="130px" CssClass="Button"
                        OnClick="Button1_Click" />--%>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="3">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                CssClass="mGrid"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnRowCommand="gvMain_RowCommand" OnPageIndexChanging="gvMain_PageIndexChanging"
                GridLines="Vertical" OnDataBound="gvMain_DataBound">
                <Columns>
                    <asp:TemplateField HeaderText=" نوع الأرشيف ">
                        <ItemTemplate>
                            <%# Get_Type(Eval("type"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الحالة">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Get_Type_status(Eval("status"))%>'></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الكود ">
                        <ItemTemplate>
                            <%# Eval("Code")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" التاريخ ">
                        <ItemTemplate>
                            <%# Eval("Date")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="  الموضوع ">
                        <ItemTemplate>
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Font-Size="Small" Font-Bold="true"
                                Width="350px" runat="server" ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="عرض" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <%--<FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />--%>
                <%--<SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />--%>
            </asp:GridView>
        </td>
    </tr>
    
</table>
