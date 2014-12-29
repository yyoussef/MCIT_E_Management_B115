<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_Inbox_search.aspx.cs" Inherits="WebForms_Project_Inbox_search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الخطابات" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 29px">
                <asp:RadioButtonList ID="Letter_type" runat="server" RepeatDirection="Horizontal"
                    Font-Size="14pt" ForeColor="Black" Width="301px">
                    <asp:ListItem Value="outbox">صادر</asp:ListItem>
                    <asp:ListItem Value="inbox">وارد</asp:ListItem>
                    <asp:ListItem Value="all" Selected="True">الكل</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 126px; height: 35px;">
                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="كلمة فى الخطاب:" />
            </td>
            <td style="width: 297px;">
                <asp:TextBox runat="server" CssClass="Text" ID="Inbox_no" Width="324px"></asp:TextBox>
            </td>
            <td style="width: 85px">
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="السنة:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="Inbox_year" Width="324px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 126px; height: 35px;">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="مكان الخطاب:" />
            </td>
            <td style="width: 297px;">
                <asp:TextBox runat="server" CssClass="Text" ID="Inbox_location" Width="324px"></asp:TextBox>
            </td>
            <td style="width: 85px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 126px; height: 35px;">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الخطاب:" />
            </td>
            <td style="width: 297px;" nowrap="nowrap">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
                <asp:TextBox ID="Inbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                    TargetControlID="Inbox_date_from" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="Image1" TargetControlID="Inbox_date_from">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            </td>
            <td style="width: 85px">
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الى:" />
                <asp:TextBox ID="Inbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    TargetControlID="Inbox_date_to" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                    TargetControlID="Inbox_date_to">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 126px; height: 35px;">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة فى العنوان:" />
            </td>
            <td style="width: 297px;">
                <asp:TextBox runat="server" CssClass="Text" ID="Inbox_name" Width="323px"></asp:TextBox>
            </td>
            <td style="width: 85px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 126px; height: 35px;">
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="الجهة:" />
            </td>
            <td style="width: 297px;">
                <uc1:Smart_Search ID="Inbox_organization" runat="server" />
                <%-- <asp:DropDownList ID="Inbox_organization" runat="server" CssClass="drop" 
                            Width="314px" DataSourceID="SqlDataSource1" DataTextField="Org_Desc" 
                                DataValueField="Org_ID">
                            </asp:DropDownList>--%>
            </td>
            <td colspan="2">
            </td>
            <%--    <td style="width: 85px">
                        <asp:Label ID="Label17" runat="server" CssClass="Label" 
                            Text="النوع:" />
                    </td>
                    <td>
                            <asp:DropDownList ID="Inbox_type" runat="server" CssClass="drop" 
                            Width="314px">
                                <asp:ListItem>جديد</asp:ListItem>
                                <asp:ListItem>رد</asp:ListItem>
                                <asp:ListItem>استعجال</asp:ListItem>
                            </asp:DropDownList>
                    </td>--%>
        </tr>
        <tr>
            <td colspan="4" align="center" style="height: 26px">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT [Org_ID], [Org_Desc] FROM [Organization]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowDataBound="gvMain_RowDataBound"
                    OnRowCommand="gvMain_RowCommand" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="تاريخ الخطاب" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("Inbox_date")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رقم الخطاب" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("Inbox_no")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="لسنة" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("Inbox_year")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموضوع" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("Inbox_name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع الخطاب" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Get_Type(Eval("Inbox_type"))%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملف الخطاب" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href='<%# "ALL_Document_Details.aspx?type=Inbox&id="+ Eval("id") %>'>
                                    <%# Eval("File_name")%></a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="وثائق مرتبطة">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="RelatedItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("id") %>' />
                                <asp:Label ID="lbl_Type" Visible="false" runat="server" Text='<%# Eval("Inbox_type") %>' />
                                <asp:Label ID="lbl_Reply_ID" Visible="false" runat="server" Text='<%# Eval("Reply_ID") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                <asp:Label ID="Label6" runat="server" CssClass="PageTitle" Text="وثائق مرتبطة" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                <asp:GridView ID="GridView1" Visible="False" runat="server" AutoGenerateColumns="False"
                    CellPadding="3" Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                    BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    CssClass="mGrid" PagerStyle-CssClass="pgr" 
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="تاريخ الخطاب" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <%# Eval("Date")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رقم الخطاب" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <%# Eval("No")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="لسنة" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <%# Eval("Year")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموضوع" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <%# Eval("Name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع الخطاب" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <%# Get_Type(Eval("type"))%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملف الخطاب" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="15%">
                            <ItemTemplate>
                                <a href='<%# "ALL_Document_Details.aspx?type=Inbox&id="+ Eval("id") %>'>
                                    <%# Eval("File_name")%></a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
