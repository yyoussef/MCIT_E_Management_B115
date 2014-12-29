<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Protocol_Main_Search_Control.ascx.cs"
    Inherits="UserControls_Protocol_Main_Search_Control" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
<asp:HiddenField ID="HiddenField1" runat="server" Value="ASC" />
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="بروتوكولات " />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الاسم:" />
        </td>
        <td style="width: 10px;">
            &nbsp;
        </td>
        <td>
            <asp:TextBox runat="server" CssClass="Text" ID="Protocole_name_text" Width="323px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ البداية:" />
        </td>
        <td style="width: 10px;">
            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
        </td>
        <td>
            <asp:TextBox ID="prot_strt_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="prot_strt_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="prot_strt_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الى:" />
            <asp:TextBox ID="prot_strt_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                TargetControlID="prot_strt_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                TargetControlID="prot_strt_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ النهاية:" />
        </td>
        <td style="width: 10px;">
            <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
        </td>
        <td>
            <asp:TextBox ID="prot_end_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                TargetControlID="prot_end_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                TargetControlID="prot_end_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الى:" />
            <asp:TextBox ID="prot_end_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                TargetControlID="prot_end_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                TargetControlID="prot_end_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة"
                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
    </tr>
    
     <tr>
                                        <td >
                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" الجهة المشاركة : " />
                                            
                                        </td>
                                        <td>
                                        </td>
                                    <td>
                                            <uc1:Smart_Search ID="Smart_Org1" runat="server" />
                                      </td>
     </tr>
 <%--   <tr>
        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="المشروع:" />
        </td>
        <td style="width: 10px;">
            &nbsp;
        </td>
        <td>
            <uc1:Smart_Search ID="Smart_Project" runat="server" />
        </td>
    </tr>--%>
    <tr>
        <td colspan="3" align="center" style="height: 26px">
        
            <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                CssClass="Button" />
        </td>
    </tr>
    <tr id="tr_page_count" visible="false" runat="server">
        <td colspan="3" align="left" style="height: 26px">
            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="عدد الصفحات : " />
            <asp:Label ID="lbl_page_count" runat="server" CssClass="Label" />
        </td>
    </tr>
    <tr>
        
        <td align="center" class="Text" colspan="3">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_RowCommand"
                OnPageIndexChanging="gvMain_PageIndexChanging" AllowPaging="True" 
                PagerSettings-NextPageText="التالى" PagerSettings-PreviousPageText="السابق" OnSorting="gvMain_Sorting"
                AllowSorting="True" PagerSettings-Mode="Numeric" GridLines="Vertical">
<PagerSettings NextPageText="التالى" PreviousPageText="السابق"></PagerSettings>
                <Columns>
                    <asp:TemplateField HeaderText="الاسم" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="70px">
                        <ItemTemplate>
                            <input id="file_ID" runat="server" type="hidden" value='<%# Eval("Protocol_ID") %>' />
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="200px" runat="server"
                                ID="txt2" Text='<%# Eval("Name")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="النوع" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="70px">
                        <ItemTemplate>
                            <%# Get_Type(Eval("Type"))%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" تاريخ البداية " HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="90px" SortExpression="CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.Strt_DT), 103)">
                        <ItemTemplate>
                            <%# Eval("Strt_DT")%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" تاريخ النهاية " HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="90px" SortExpression="CONVERT(datetime, dbo.datevalid(Protocol_Main_Def.End_DT), 103)">
                        <ItemTemplate>
                            <%# Eval("End_DT")%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                        <ItemStyle Width="90px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الميزانية الكلية بالجنية " HeaderStyle-Width="80px"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <%# Eval("Total_Balance_LE")%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الميزانية الكلية بالدولار " HeaderStyle-Width="80px"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <%# Eval("Total_Balance_US")%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تجديد البروتوكول">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit123" CommandName="Related_Item" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("Protocol_ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("Protocol_ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"
                                CommandArgument='<%# Eval("Protocol_ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
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
    <tr align="center" id="tr_paging" runat="server" visible="false">
        <td colspan="3">
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text=" رقم الصفحة:" />
            <asp:TextBox ID="txt_page_no" runat="server" Width="25" AutoPostBack="true" OnTextChanged="Btn_page_Click"  Font-Size="Medium" Font-Bold="true"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom"
                TargetControlID="txt_page_no" ValidChars="0987654321" />
            <asp:Button ID="Btn_page" Text="إذهب" runat="server" CssClass="Button" 
                onclick="Btn_page_Click" />
        </td>
    </tr>
</table>
