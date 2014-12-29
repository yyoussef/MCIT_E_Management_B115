<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Protocol_Finishing.aspx.cs" Inherits="WebForms_Protocol_Finishing"
    Title="Untitled Page" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" width="100%" style="line-height: 2;color: Black">
        <tr>
            <td align="center">
            <br />
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="إنهاء بروتوكولات / اتفاقيات"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                <input type="hidden" runat="server" id="hidden_ID" />
                <input type="hidden" runat="server" id="hidden_Status" value="1" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" اسم البروتوكول : " />
                        </td>
                        <td>
                            <uc1:Smart_Search ID="Smart_Search_Protocol" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="التاريخ : " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Finish_Date" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="txt_Finish_Date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="txt_Finish_Date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Finish_Date"
                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                                
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Finish_Date"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الوثيقة:" />
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" />
                             <a id="A2" runat="server" visible="false" style="font-weight:bold;font-size:medium"   >عرض</a>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" نوع الإنتهاء : " />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Finish_Type" runat="server" Width="250px" CssClass="drop">
                                <asp:ListItem Text="بنجاح" Selected="True" Value="2"></asp:ListItem>
                                <asp:ListItem Text="إلغاء" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                    ValidationGroup="A" Width="99px" />
                     <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_View_Mng" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    OnRowCommand="GrdView_RowCommand" Font-Size="17px" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="الاسم" DataField="Name" />
                        <asp:TemplateField HeaderText="النوع">
                            <ItemTemplate>
                                <%# Get_Type(Eval("Type"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="تاريخ البداية" DataField="Signt_Str_DT" />
                        <asp:BoundField HeaderText=" تاريخ النهاية" DataField="Signt_End_DT" />
                        <asp:BoundField HeaderText=" الميزانية الكلية" DataField="Total_Balance" />
                        <asp:BoundField HeaderText="تاريخ الإنتهاء" DataField="Finish_Date" />
                        <asp:TemplateField HeaderText="الحالة">
                            <ItemTemplate>
                                <%# Get_Status(Eval("Finish_Type"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px" CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
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
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>
