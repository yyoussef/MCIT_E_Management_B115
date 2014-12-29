<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Connecting_inbox_outbox.aspx.cs" Inherits="MainForm_Connecting_inbox_outbox" title="البحث المرتبط وارد/صادر"%>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <input type="hidden" runat="server" id="hidden_in_out" />
                <input type="hidden" runat="server" id="hidden1" />
                <div id="div_choose" style="display: block" runat="server">
                    <asp:DropDownList ID="Drop_choose" runat="server" AutoPostBack="true" CssClass="drop"
                        OnSelectedIndexChanged="Drop_choose_SelectedIndexChanged">
                        <asp:ListItem Text="اختر نوع البحث ...." Value="0"></asp:ListItem>
                        <asp:ListItem Text="وارد" Value="1"></asp:ListItem>
                        <asp:ListItem Text="صادر" Value="2"></asp:ListItem>
                        <asp:ListItem Text="الكل" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <div id="div_title_inbox" style="display: none" runat="server">
                    <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الوارد" />
                </div>
                <div id="div_title_oubbox" style="display: none" runat="server">
                    <asp:Label ID="Label7" runat="server" CssClass="PageTitle" Text="الصادر" />
                </div>
                <div id="div_title_ALL" style="display: none" runat="server">
                    <asp:Label ID="Label3" runat="server" CssClass="PageTitle" Text="الكل" />
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 29px">
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <div id="div_inbox_code_label" style="display: none" runat="server">
                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كلمة في الكود:" />
                </div>
            </td>
            <td colspan="2">
                <div id="div_inbox_code_text" style="display: none" runat="server">
                    <asp:TextBox runat="server" CssClass="Text" ID="Txtcode" Width="323px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <div id="div_inbox_subject_label" style="display: none" runat="server">
                    <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
                </div>
            </td>
            <td colspan="2">
                <div style="display: none" id="div_inbox_subject_text" runat="server">
                    <asp:TextBox runat="server" CssClass="Text" ID="Inbox_name_text" Width="323px"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px">
                <div style="display: none" id="div_inbox_org_label" runat="server">
                    <asp:Label ID="Label13" runat="server" CssClass="Label" Text="جهة الورود : "></asp:Label>
                </div>
            </td>
            <td align="right" dir="rtl" colspan="2">
                <div style="display: none" id="div_inbox_org_smart" runat="server">
                    <uc1:Smart_Search ID="Smrt_Srch_org" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <div style="display: none" id="div_inbox_date_label" runat="server">
                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الورود:" />
                </div>
            </td>
            <td style="width: 10px;">
                <div style="display: none" id="div_inbox_date_label_from" runat="server">
                    <asp:Label ID="Label50" runat="server" CssClass="Label" Text="من:" />
                </div>
            </td>
            <td>
                <div style="display: none" id="div_inbox_date_text" runat="server">
                    <asp:TextBox ID="Inbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                        TargetControlID="Inbox_date_from" ValidChars="0987654321/\" />
                    <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                        PopupButtonID="Image1" TargetControlID="Inbox_date_from">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                        ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label111" runat="server" CssClass="Label" Text="الى:" />
                    <asp:TextBox ID="Inbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                        TargetControlID="Inbox_date_to" ValidChars="0987654321/\" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                        TargetControlID="Inbox_date_to">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                        ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <div style="display: none" id="div_outbox_date_label" runat="server">
                    <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ صادر الجهة:" />
                </div>
            </td>
            <td style="width: 10px;">
                <div style="display: none" id="div_outbox_date_label_from" runat="server">
                    <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
                </div>
            </td>
            <td>
                <div style="display: none" id="div_outbox_date_text" runat="server">
                    <asp:TextBox ID="Outbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                        TargetControlID="Outbox_date_from" ValidChars="0987654321/\" />
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                        TargetControlID="Outbox_date_from">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                        Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="الى:" />
                    <asp:TextBox ID="Outbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                        TargetControlID="Outbox_date_to" ValidChars="0987654321/\" />
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                        TargetControlID="Outbox_date_to">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة"
                        Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <div id="div_save" align="center" style="display: none" runat="server">
                    <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                        CssClass="Button" />
                    &nbsb
                    <%-- <asp:Button ID="Button1" runat="server" Text="تصدير الي إكسل" Width="130px" CssClass="Button"
                        OnClick="Button1_Click" />--%>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <div id="div_grid_Main" style="display: block" runat="server">
                    <asp:GridView ID="gvMain" OnRowDataBound="gvMain_RowDataBound" runat="server" 
                        AutoGenerateColumns="False" CellPadding="3"
                        AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnRowCommand="gvMain_RowCommand" 
                        OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText=" الكود ">
                                <ItemTemplate>
                                    <%# Eval("Code")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الورود" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("Date")%>
                                </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="جهة الورود">
                                <ItemTemplate>
                                    <%# Eval("Org_Desc")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" تاريخ صادر الجهة " ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("Org_Out_Box_DT")%>
                                </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  الموضوع ">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المرتبط">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>'
                                        CommandName="Link">المرتبط</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <div id="div_connecting_label" style="display: none" runat="server">
                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="المرتبط:" />
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <div id="div_connecting_grid" style="display: none" runat="server">
                    <asp:GridView ID="gvsub" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        AllowPaging="false" AllowSorting="true" Width="99%" BackColor="White" ForeColor="Black"
                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnRowCommand="gvsub_RowCommand" OnPageIndexChanging="gvsub_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText=" الكود ">
                                <ItemTemplate>
                                    <%# Eval("Code")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الورود" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("Date")%>
                                </ItemTemplate>
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="جهة الورود">
                            <ItemTemplate>
                                <%# Eval("Org_Desc")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText=" تاريخ صادر الجهة " ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("Org_Out_Box_DT")%>
                                </ItemTemplate>
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  الموضوع ">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  النوع ">
                                <ItemTemplate>
                                    <%# Eval("Rtype")%>
                                    <%# Eval("R2type")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="  ID " Visible="false">
                            <ItemTemplate>
                                 <%# Eval("Related_ID")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <%-- <asp:TemplateField HeaderText="المرتبط">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument='<%# Eval("ID") %>'>LinkButton</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <%-- <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                        <PagerStyle CssClass="pgr" />
                        <AlternatingRowStyle CssClass="alt" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
