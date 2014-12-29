<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProjectSearch.ascx.vb" Inherits="UserControls_ProjectSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<table id="tblSearch" runat="server" width="100%" visible="true" dir="rtl" style="line-height: 2;">
        <%--border-color: Black; border-width: thin; border-style: solid;"--%>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="Label10" runat="server" CssClass="PageTitle" Font-Bold="true" Text="البحث عن مشـــــــروع" />
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" colspan="4">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr id="deptrow" runat="server">
            <td align="right">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الإدارة : " />
            </td>
            <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                <uc1:Smart_Search ID="Smart_Search_dep" runat="server" />  
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 60px">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="اسم المشروع : " />
            </td>
            <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                <uc1:Smart_Search ID="Smart_Search_pr" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="مدير المشــــروع : " />
            </td>
            <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                <uc1:Smart_Search ID="Smart_Search_man" runat="server" />
            </td>
        </tr>
        <tr id="orgrow" runat="server">
            <td align="right">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الجهة المستفيدة : " />
            </td>
            <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                <uc1:Smart_Search ID="Smart_Search_org" runat="server" />
            </td>
        </tr>
        <tr id="exorgrow" runat="server">
            <td align="right">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="الجهة المنفذة : " />
            </td>
            <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                <uc1:Smart_Search ID="Smart_Search_exc" runat="server" />
            </td>
        </tr>
        <tr id="statusrow" runat="server">
            <td dir="rtl" style="width: 169px">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="حالة المشروع : " />
            </td>
            <td colspan="3">
                <asp:DropDownList ID="DdlProjStatus" runat="server" Width="196px" CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 169px">
                <asp:Label ID="label8" runat="server" CssClass="Label" Text="تاريخ اقتراح المشروع :" />
            </td>
            <td>
                <asp:TextBox ID="txtProjDateSearch" runat="server" CssClass="Text" Width="117px"
                    AutoPostBack="True" />
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtProjDateSearch"
                    PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="txtProjDateSearch_filtered" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtProjDateSearch" />
            </td>
            <td align="right">
                <asp:Label ID="label9" runat="server" CssClass="Label" Text="الميزانية من: " />
                <asp:TextBox ID="txtProjStartCoastSearch" runat="server" CssClass="Text" Width="100px" />
            </td>
            <td align="right">
                <asp:Label ID="label7" runat="server" CssClass="Label" Text="الميزانية الي: " />
                <asp:TextBox ID="txtProjEndCoastSearch" runat="server" CssClass="Text" Width="105px" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="بحــــث" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    CssClass="mGrid" PagerStyle-CssClass="pgr" 
                    AlternatingRowStyle-CssClass="alt" BackColor="White" BorderColor="#999999" 
                    ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="الادارة المختصة">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_Dept_name" runat="server" Text='<%# Eval("Dept_name") %>'
                                    CommandArgument='<%# Eval("Dept_name") %>' OnClick="LinkButton3_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم المشروع">
                            <ItemTemplate>
                                <input id="Proj_id" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                <asp:LinkButton ID="Project_name" runat="server" Text='<%# Eval("Proj_Title") %>'
                                    OnClick="LinkButton1_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مدير المشروع">
                            <ItemTemplate>
                                <asp:LinkButton ID="Project_man" runat="server" Text='<%# Eval("pmp_name") %>' CommandArgument='<%# Eval("pmp_name") %>'
                                    OnClick="LinkButton2_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="عرض التفاصيل" ItemStyle-Width="20px" Visible="true">
                            <ItemTemplate>
                                <input id="Proj_id1" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Proj_id") %>'
                                    OnClick="LinkButton1_Click" />
                            </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px" Visible="true">
                            <ItemTemplate>
                                <input id="Proj_id2" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    CommandArgument='<%# Eval("Proj_id") %>' OnClick="LinkButton1_Click" OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center"></PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>