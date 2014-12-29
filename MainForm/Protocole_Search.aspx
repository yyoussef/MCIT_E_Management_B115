<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Protocole_Search.aspx.cs" Inherits="WebForms_Protocole_Search"  Title="البحث عن بروتوكولات / اتفاقيات"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table dir="rtl" style="line-height: 2; width: 99%;">
                <tr>
                    <td align="center" colspan="3" style="height: 33px">
                        <asp:Label ID="Label2" runat="server" CssClass="PageTitle" 
                            Text="بروتوكولات / اتفاقية / موافقة السلطة المختصة" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 29px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" 
                            Text="كلمة في البروتوكول:" />
                    </td>
                    <td style="width:10px;">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Protocole_name_text" 
                            Width="323px"></asp:TextBox>
                    </td>
                </tr>
               
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ البداية:" />
                    </td>
                     <td style="width:10px;">
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
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image2" TargetControlID="prot_strt_date_to">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                </tr>
                 <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ النهاية:" />
                    </td>
                     <td style="width:10px;">
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
                    </td>
                    <td>
                            <asp:TextBox ID="prot_end_date_from" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                TargetControlID="prot_end_date_from" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImageButton1" TargetControlID="prot_end_date_from">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الى:" />
                                <asp:TextBox ID="prot_end_date_to" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                TargetControlID="prot_end_date_to" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImageButton2" TargetControlID="prot_end_date_to">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                </tr>
                 <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" 
                            Text="اسم الوثيقة:" />
                    </td>
                    <td style="width:10px;">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Txt_doc_name" 
                            Width="323px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" 
                            Text="نوع الوثيقة:" />
                    </td>
                    <td style="width:10px;">
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="Drop_doc_Type" runat="server" CssClass="drop" Width="300">
                        <asp:ListItem Text="إختر نوع الوثيقة" Value="0"></asp:ListItem>
                        <asp:ListItem Text="اتفاقية/بروتوكول" Value="1"></asp:ListItem>
                        <asp:ListItem Text="مخاطبات" Value="2"></asp:ListItem>
                        <asp:ListItem Text="موافقات" Value="3"></asp:ListItem>
                        <asp:ListItem Text="أمر شغل /نطاق أعمال " Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="تاريخ الوثيقة:" />
                    </td>
                     <td style="width:10px;">
                        <asp:Label ID="Label9" runat="server" CssClass="Label" Text="من:" />
                    </td>
                    <td>
                            <asp:TextBox ID="Txt_doc_date_from" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom"
                                TargetControlID="Txt_doc_date_from" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImageButton3" TargetControlID="Txt_doc_date_from">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton3" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="الى:" />
                                <asp:TextBox ID="Txt_doc_date_to" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                TargetControlID="Txt_doc_date_to" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="ImageButton4" TargetControlID="Txt_doc_date_to">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton4" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                </tr>
                <tr> 
                    <td colspan="3" align="center" style="height: 26px">
                        <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                            CssClass="Button" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            onrowcommand="gvMain_RowCommand" 
                            onpageindexchanging="gvMain_PageIndexChanging" AllowPaging="True" 
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="البروتوكول" HeaderStyle-Width="70px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70px" >
                                 <ItemTemplate  >
                                        <input id="file_ID" runat="server" type="hidden" value='<%# Eval("Protocol_ID") %>' />
                                 <asp:TextBox TextMode="MultiLine" Rows="3"  ReadOnly="true" Width="200px" runat="server" ID="txt2" Text='<%# Eval("Name")%>' ></asp:TextBox>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="النوع" HeaderStyle-Width="70px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70px" >
                                 <ItemTemplate  >
                                      <%# Eval("Type_Name")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText=" تاريخ البداية " HeaderStyle-Width="90px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="90px" >
                                 <ItemTemplate  >
                                      <%# Eval("Signt_Str_DT")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Width="90px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" تاريخ النهاية " HeaderStyle-Width="90px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="90px" >
                                 <ItemTemplate  >
                                      <%# Eval("Signt_End_DT")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Width="90px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="  الجهة المشاركة " HeaderStyle-Width="90px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="90px" >
                                 <ItemTemplate  >
                                      <%# Eval("Org_Desc")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                    <ItemStyle Width="90px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" الميزانية الكلية بالجنية " HeaderStyle-Width="80px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px" >
                                 <ItemTemplate  >
                                      <%# Eval("Total_Balance_LE")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText=" الميزانية الكلية بالدولار " HeaderStyle-Width="80px" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px" >
                                 <ItemTemplate  >
                                      <%# Eval("Total_Balance_US")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                    
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Protocol_ID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("Protocol_ID") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
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

