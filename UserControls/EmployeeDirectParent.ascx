<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeDirectParent.ascx.cs"
    Inherits="UserControls_EmployeeDirectParent" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc2" %>
<style type="text/css">
    .style1
    {
        width: 136px;
    }
</style>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td class="style1">
            &nbsp;
        </td>
        <td style="text-align: right">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;
        </td>
        <td style="text-align: center">
            <asp:Label ID="lbl_chooseEmplAndDirMangr" runat="server" CssClass="PageTitle" Text="تحديد الموظف و الادارة العليا"></asp:Label>
        </td>
    </tr>
     <tr>
            <td style="width: 112px">
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="اسم المجموعة" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_Groups_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="lbl_directManager" runat="server" Text="الادارة العليا :" CssClass="Label"
                AssociatedControlID="Smart_Search_Direct_Manager"></asp:Label>
        </td>
        <td>
            <uc2:Smart_Search ID="Smart_Search_Direct_Manager" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="lbl_employeeName" runat="server" Text="  مدخل بيانات الخطاب:" CssClass="Label"
                ForeColor="#808080" font-underline="false" AssociatedControlID="Smart_Search_Employee"></asp:Label>
        </td>
        <td>
            <uc2:Smart_Search ID="Smart_Search_Employee" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="lbl_type" runat="server" Text="نوع الخطاب  :" AssociatedControlID="ddl_Type"
                CssClass="Label"></asp:Label>
        </td>
        <td style="text-align: right">
            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                DataTextField="Commitee_Title" DataValueField="ID">
                <asp:ListItem Selected="True" Value="1">وارد</asp:ListItem>
                <asp:ListItem Value="2">صادر</asp:ListItem>
                <asp:ListItem Value="3">تكليفات</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;
        </td>
        <td style="text-align: right">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Save" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="A"
                OnClick="btn_Save_Click" Width="89px" Height="36px" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;
        </td>
        <td style="text-align: right">
            <input id="currRow_id" type="hidden" runat="server" />
            &nbsp;
        </td>
    </tr>
</table>
<p>
    &nbsp;
    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_RowCommand" GridLines="Vertical">
        <Columns>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                <ItemTemplate>
                    <%#Container.DataItemIndex + 1%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField HeaderText=" اسم الموظف" DataField="EmployeeName" />
            <asp:BoundField HeaderText=" اسم المدير المباشر" DataField="ParentEmployeeName" />
            <asp:BoundField HeaderText=" النوع" DataField="Type" />
        <%--    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>'
                        CommandName="show" />
                </ItemTemplate>
                <HeaderStyle Width="25px" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                        Style="height: 22px" CommandName="dlt" OnClientClick="return confirm(&quot;هل تريد الحذف?&quot;);"
                        CommandArgument='<%# Eval("ID") %>' />
                </ItemTemplate>
                <HeaderStyle Width="25px" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
        </PagerStyle>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
    </asp:GridView>
</p>
