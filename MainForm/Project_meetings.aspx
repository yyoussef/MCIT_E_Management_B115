<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_meetings.aspx.cs" Inherits="WebForms_Project_meetings" Title="الاجتماعات" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input id="meeting_ID" runat="server" type="hidden" value="0" />
    <input id="side_ID" runat="server" type="hidden" value="0" />
    <input id="mode" runat="server" type="hidden" value="new" />
    <input id="mode2" runat="server" type="hidden" value="new" />
    <input id="id2" runat="server" type="hidden" />
    <input id="id3" runat="server" type="hidden" />
    <cc1:TabContainer runat="server" ID="TabPanel_All" Height="500px" ActiveTabIndex="0">
        <cc1:TabPanel ID="TabPanel_dtl" runat="server" TabIndex="0">
            <HeaderTemplate>
                <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="بيانات الاجتماع" />
                <input type="hidden" runat="server" id="hidden1" />
            
            
        </HeaderTemplate>
            
<ContentTemplate>
                <table dir="rtl" style="line-height: 2; width: 99%;">
                    <tr>
                        <td align="center" colspan="3" style="height: 29px">
                            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="اسم الاجتماع:" />
                        </td>
                        <td style="width: 10px;">
                            <asp:Label ID="Label7" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label">*</asp:Label>
                        </td> 
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="Meeting_name" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="مكان الاجتماع:" />
                        </td>
                        <td style="width: 10px;">
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="Meeting_location" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" style="width: 173px; height: 44px;">
                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الاجتماع:" />
                        </td>
                        <td style="width: 10px; height: 44px;">
                            <asp:Label ID="Label10" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label">*</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Meeting_date" runat="server" Width="138px" Height="35px" Font-Bold="True"
                                Font-Size="20px" Font-Names="Arial" ForeColor="#1F4569"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server"
                                TargetControlID="Meeting_date" ValidChars="0987654321/\" Enabled="True" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="Meeting_date" Enabled="True">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Meeting_date"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="ملاحظات:" />
                        </td>
                        <td style="width: 10px;">
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Notes" runat="server" CssClass="Text" Height="150px" TextMode="MultiLine"
                                Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center" style="height: 26px">
                            <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                                CssClass="Button"  ValidationGroup="A" />
                            &nbsp;
                            <asp:Button ID="ResetButton" runat="server" CssClass="Button" 
                                OnClick="ResetButton_Click" Text="جديد"  ValidationGroup="A"/>
                                
                                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        
</cc1:TabPanel>
        
        <cc1:TabPanel ID="TabPanel1" runat="server" TabIndex="0">
            <HeaderTemplate>
                <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Size="11px" Text="جهة الاجتماع" />
                <input type="hidden" runat="server" id="hidden2" />
            
            
        </HeaderTemplate>
            
<ContentTemplate>
                <table dir="rtl" style="line-height: 2; width: 99%;">
                    <tr>
                        <td align="center" colspan="3" style="height: 29px">
                            <asp:Label ID="lblErrorMsg2" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  dir="rtl" >
                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="جهة الاجتماع:" />
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label">*</asp:Label>
                            <asp:TextBox ID="txt_side_Name" runat="server" CssClass="Text" Height="30px" TextMode="SingleLine"
                                Width="700px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                            <asp:Button ID="btn_save_Doc" Text="حفظ" OnClick="btn_save_Doc_Click" runat="server"
                                CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                             <asp:GridView ID="SidesGV" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="SidesGV_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم الجهة" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <input id="Side_ID" runat="server" type="hidden" value='<%# Eval("Side_ID") %>' />
                                        <%# Eval("Side_Name")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                            CommandArgument='<%# Eval("Side_ID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("Side_ID") %>'   OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        
</cc1:TabPanel>
        
        <cc1:TabPanel ID="TabPanel2" runat="server" TabIndex="0">
            <HeaderTemplate>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Font-Size="11px" Text="ملفات الاجتماع" />
                <input type="hidden" runat="server" id="hidden3" />
            
            
        </HeaderTemplate>
            
<ContentTemplate>
                <table dir="rtl" style="line-height: 2; width: 99%;" border="0">
                    <tr>
                        <td align="center" colspan="2" style="height: 29px">
                            <asp:Label ID="lblErrorMsg3" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 173px; height: 42px;">
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="ملف محضر الاجتماع:"
                                Width="160px" />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:FileUpload ID="File_data" runat="server" CssClass="Button" Width="300px" Height="26px" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                            <asp:Button ID="btn_save_File" Text="حفظ" OnClick="btn_save_File_Click" runat="server"
                                CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                             <asp:GridView ID="FilesGV" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="FilesGV_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم الملف" HeaderStyle-Width="80%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="80%">
                                    <ItemTemplate>
                                        <a href='<%# "ALL_Document_Details.aspx?type=meeting&id="+ Eval("id") %>'>
                                         <%# Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                    <ItemStyle Width="80%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 </Columns>
                            <PagerStyle CssClass="pgr" />
                            <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        
</cc1:TabPanel>
        
        
        
        
    </cc1:TabContainer>
    <div align="center" style="line-height: 2; width: 99%; font-size: medium">
        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
            OnRowCommand="GrdView_RowCommand" GridLines="Vertical">
            <Columns>
                <asp:TemplateField HeaderText="اسم الاجتماع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="20%">
                    <ItemTemplate>
                        <input id="meeting_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                        <%# Eval("Meeting_name")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="تاريخ الاجتماع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# Eval("Meeting_date")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="مكان الاجتماع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# Eval("Meeting_location")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                    <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
        </asp:GridView>
    </div>
</asp:Content>
