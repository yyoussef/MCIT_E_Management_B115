<%@ Control Language="C#" AutoEventWireup="true" CodeFile="project_followup.ascx.cs" Inherits="UserControls_project_followup" %>

<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
  <table cellpadding="3" cellspacing="3" style="line-height: 2; width: 80%;">
        <tr>
            <td align="center" colspan="2" height="33px">
                &nbsp;
            </td>
        </tr>
        <tr style="height: 50;">
            <td align="center" colspan="2" height="33px">
                <asp:Label ID="Label1" runat="server" Text="متابعة المستخدمين على المشروعات" CssClass="PageTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right"  dir="rtl" colspan="3">
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="Label7" runat="server" Text="المشروع : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="Label2" runat="server" Text="البيانات : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="ddl_record_type" runat="server" CssClass="drop" Width="276px">
                    <asp:ListItem Value="1">الميزانية</asp:ListItem>
                    <asp:ListItem Value="2">الأنشطة</asp:ListItem>
                    <asp:ListItem Value="3">المعوقات</asp:ListItem>
                    <asp:ListItem Value="4">طلب الاحتياجات</asp:ListItem>
                    <asp:ListItem Value="9">تصديق الاحتياجات</asp:ListItem>
                    <asp:ListItem Value="10">إتاحة الاحتياجات</asp:ListItem>
                    <asp:ListItem Value="11">صرف الاحتياجات</asp:ListItem>
                    <asp:ListItem Value="5">أوامر التوريد</asp:ListItem>
                    <asp:ListItem Value="7">الفواتير</asp:ListItem>
                    <asp:ListItem Value="8">أوامر التوريد للاتفاقيات</asp:ListItem>
                    <asp:ListItem Value="6">الوثائق</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="BtnView" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                    Text="عرض" Width="98px" OnClick="BtnView_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    OnRowDataBound="gvMain_RowDataBound" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="المستخدم" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم العنصر" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("recordName")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العملية" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <asp:Label ID="LBLprocess" runat="server" CssClass="Label" Text="" Width="95px" Height="25px" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="التاريخ" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("action_date")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
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
    </table>