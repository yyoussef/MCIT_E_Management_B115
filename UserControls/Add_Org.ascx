<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add_Org.ascx.cs" Inherits="UserControls_Add_Org" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input id="CMT_ID" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td colspan="2" align="center" style="height: 82px">
            <asp:Label ID="lbl1" runat="server" Text="ادخل الجهات" Font-Size="17pt" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="lbl2" runat="server" Text="اسم الجهة" CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txtCatName" runat="server" CssClass="Text" Width="314px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="Button" OnClick="btnSave_Click" />
               <asp:Button ID="BtnNew" runat="server" Text="جديد" CssClass="Button" OnClick="BtnNew_Click" />
            <asp:Button ID="btnSearch" runat="server" Text="بحث في الجهات " Width="120px" CssClass="Button" OnClick="btnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageIndex="10">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" ControlStyle-Font-Size="X-Large"/>
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("Org_ID") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                CommandArgument='<%# Eval("Org_ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif" 
                                OnClick="ImgBtnDelete_Click" OnClientClick="javascript:return confirm('هل أنت متأكد من الحذف')" Style="height: 22px" CommandArgument='<%# Eval("Org_ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                <PagerStyle CssClass="pgr"></PagerStyle>
                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
</table>
