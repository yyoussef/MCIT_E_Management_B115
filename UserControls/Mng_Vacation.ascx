<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Mng_Vacation.ascx.cs"
    Inherits="UserControls_Mng_Vacation" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="line-height: 2; width: 100%; height: 238px" id="tbl_Paramater" runat="server">
    <tr>
        <td height="30px" align="center" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="إدارة الأجازات والمأموريات" CssClass="PageTitle"
                Font-Underline="True"></asp:Label>
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 110px">
            <asp:Label ID="Label2" runat="server" Text="النوع : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td align="right" width="400px" dir="rtl">
            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop" Width="319px">
                <asp:ListItem Text="الأجازات" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="المأموريات" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 110px">
            <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td align="right" width="400px" dir="rtl">
            <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right" width="110px">
            <asp:Label ID="Label18" runat="server" Text="اسم الموظف : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td align="right" valign="middle" style="height: 44px" dir="rtl">
            <uc1:Smart_Search ID="smart_employee" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="top">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        <asp:Label ID="Label23" runat="server" Font-Bold="False" Text="من :" Font-Names="Arial"
                            Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txt_take_date_from" runat="server" Font-Names="Arial" Font-Size="20px"
                            ForeColor="#1F4569" Font-Bold="True" Width="129px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_take_date_from"
                            PopupButtonID="ImageButton51" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImageButton51" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_take_date_from"
                            ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                            Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 50px">
                    </td>
                    <td align="right">
                        <asp:Label ID="Label24" runat="server" Font-Bold="False" Text="إلى :" Font-Names="Arial"
                            Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txt_take_date_to" runat="server" Font-Bold="True" Height="29px"
                            Width="128px" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_take_date_to"
                            PopupButtonID="ImageButton8" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImageButton8" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt_take_date_to"
                            ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                            
                            Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_Search" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                OnClick="btn_Search_Click" Text="بحـث" Width="98px" />
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="2">         
            <asp:GridView ID="gvMain" runat="server" Visible="False" 
                AutoGenerateColumns="False" CellPadding="3"
                AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                OnRowCommand="gvMain_RowCommand" 
                OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="طالب الأجازة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("pmp_name")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="نوع الأجازة" HeaderStyle-Wrap="false" ItemStyle-Width="10%"
                        HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("vacation_title")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="المدة باليوم" HeaderStyle-Wrap="false" ItemStyle-Width="5%"
                        HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("no_days")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_date")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("end_date")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الحالة" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                        HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Get_Staus(Eval("general_manager_approve"),Eval("manager_approve"))%>
                        </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="15%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="15%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("id")+","+ Eval("pmp_id") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" CommandArgument='<%# Eval("id")+","+ Eval("pmp_id") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="عرض تقرير الاجازة " HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                        
                            <asp:Button ID="btn_show" runat="server" CssClass="Button"  Text="عرض تقرير الاجازة"
                            
                            CommandName="dlt" CommandArgument='<%# Eval("id")+ "," + Eval("vacation_id") %>'  Width="150"  />
                  
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                
                
                
              </asp:GridView>
              
              
            <asp:GridView ID="gvMain_errand" runat="server" Visible="False" 
                AutoGenerateColumns="False" CellPadding="3"
                AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnRowCommand="gvMain_errand_RowCommand" 
                OnPageIndexChanging="gvMain_errand_PageIndexChanging" GridLines="Vertical">
               <Columns>
                        <asp:TemplateField HeaderText="القائم بالمأمورية" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="15%" HeaderStyle-Width="15%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="Large" Width="15%" Wrap="False" />
                            <ItemStyle Font-Size="Large" Width="15%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الجهة" HeaderStyle-Wrap="false" ItemStyle-Width="40%" HeaderStyle-Width="40%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("location")%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="Large" Width="40%" Wrap="False" />
                            <ItemStyle Font-Size="Large" Width="40%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="المطلوب مقابلته" HeaderStyle-Wrap="false" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("person_to_meet")%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="Large" Width="25%" Wrap="False" />
                            <ItemStyle Font-Size="Large" Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("start_date")%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                            <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("end_date")%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="Large" Width="5%" Wrap="False" />
                            <ItemStyle Font-Size="Large" Width="5%" Wrap="False" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="الحالة" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                        HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Get_Staus(Eval("general_manager_approve"),Eval("manager_approve"))%>
                        </ItemTemplate>
                              <HeaderStyle Font-Size="Large" Width="15%" />
                              <ItemStyle Font-Size="Large" Width="15%" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
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
</table>
