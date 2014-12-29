<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_Complain.aspx.cs" Inherits="WebForms_Project_Complain" Title="المناقضات" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <input id="comp_ID" runat="server" type="hidden" value="0"  />
        <input id="mode" runat="server" type="hidden" value="new"  />
        <input id="id2" runat="server" type="hidden"  />
        <input id="id3" runat="server" type="hidden" />
            <table dir="rtl" style="line-height: 2; width: 99%;">
                <tr>
                    <td align="center" colspan="3" style="height: 33px">
                        <asp:Label ID="Label2" runat="server" CssClass="PageTitle" 
                            Text="المناقضات" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 29px">
                        <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" 
                            ForeColor="Red" CssClass="Label" ></asp:Label>
                    </td>
                </tr>
                <tr>
                <td>
                       <asp:Label ID="Label4" runat="server" CssClass="Label"
                            Text="اسم الجهة:" Width="160px" /> 
                </td>                
                    <td>
                        <asp:DropDownList runat="server" ID ="org_name" CssClass="drop" 
                            AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Org_Desc" 
                            DataValueField="Org_ID" Width="492px" >
                            <asp:ListItem Value="-1">اختر الجهة المناقضة .....</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td align="right" style="width: 173px; height: 42px;">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" 
                            Text="ملف المناقضة:" Width="160px" />
                    </td>
                    
                    <td  dir="rtl" align="right">
                        <asp:FileUpload ID="Upload_File_data" runat="server" CssClass="Button" Width="544px" 
                            Height="26px" />
                           
                    </td>
                </tr>
                            
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ المناقضة:" />
                    </td>
                   
                    <td>
                            <asp:TextBox ID="complain_date" runat="server" CssClass="Text" 
                                onload="complain_date_Load"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="complain_date"
                                        runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="complain_date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="complain_date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="complain_date"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        &nbsp;</td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                            
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="ملاحظات:" />
                    </td>
                     <td style="width:10px;">
                        <asp:TextBox ID="Notes" runat="server" CssClass="Text" Height="150px" 
                            TextMode="MultiLine" Width="550px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
              
                <tr>
                    <td colspan="3" align="center" style="height: 26px">
                        <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                            CssClass="Button"  ValidationGroup="A"/>
                            
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                            
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString%>" 
                            
                                SelectCommand="select * from organization ORDER BY org_id">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            OnRowCommand="GrdView_RowCommand" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="الجهة" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <input id="id2" runat="server" type="hidden" value='<%# Eval("org_id") %>' />
                                        <%# Eval("org_id")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="ملف المناقضة" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <a href='<%# "ALL_Document_Details.aspx?type=complian&id="+ Eval("id") %>'  ><%# Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="تاريخ المناقضة" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                      <%# Eval("complian_date")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                                            
                                
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
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



