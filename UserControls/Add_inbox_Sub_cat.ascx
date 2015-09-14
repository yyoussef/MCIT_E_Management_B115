<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add_inbox_Sub_cat.ascx.cs"
    Inherits="UserControls_Add_inbox_Sub_cat" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input id="CMT_ID" runat="server" type="hidden" />
<input id="CST_ID" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td colspan="2" align="center" style="height: 82px">
            <h2>ادخل التصنيفات الفرعيه</h2>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text=" اسم التصنيف الرئيسى : " Width="140px"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlMainCat" runat="server" CssClass="Button" AutoPostBack="true"
                Width="700px" OnSelectedIndexChanged="ddlMainCat_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="lbl2" runat="server" Text="اسم التصنيف الفرعى :"  ></asp:Label>
        </td>
        <td >
            <asp:TextBox ID="txtCatName" runat="server" Width="700px" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ" Width="61px"
                OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:GridView ID="gvSub" runat="server" AutoGenerateColumns="False" 
               
                EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                GridLines="Vertical">
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

<PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />

<AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
</table>
