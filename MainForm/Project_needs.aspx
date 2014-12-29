<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Project_needs.aspx.vb" Inherits="WebForms_Project_needs" Title="احتياجات المشروع" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table dir="rtl" width="100%" cellpadding="5px">
                <input id="PNed_ID" runat="server" type="hidden" />
                <tr>
                    <td dir="rtl" align="center" colspan="3" style="height: 34px">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                            Text="احتياجات المشـــــــــــــروع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" dir="rtl" colspan="3" style="height: 31px">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 51px;">
                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="نوع الاحتياج الرئيسى:   " />
                    </td>
                    <td align="right" dir="rtl" style="height: 51px" colspan="2">
                        <uc1:Smart_Search ID="Smart_Search_mn" runat="server" />
                    </td>
                    <%--<td align="right" style="height: 40px;" width="85%">
                        <asp:DropDownList ID="ddlMainCat" runat="server" AutoPostBack="True" 
                            CssClass="drop" Width="95%">
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImgBtnResearch1" runat="server" Height="20px" 
                            ImageUrl="~/Images/search.jpg" Style="height: 16px" Width="20px" />
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 53px;">
                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text="نوع الاحتياج الفرعى : " />
                    </td>
                    <%--<td align="right" style="height: 39px;" width="85%">
                        <asp:DropDownList ID="ddlSubCat" runat="server" AutoPostBack="True" 
                            CssClass="drop" Width="95%">
                                </asp:DropDownList>
                            </td>--%>
                    <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="2">
                        <uc1:Smart_Search ID="Smart_Search_sp" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 38px;">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text="اسم البنــــد : " />
                    </td>
                    <td align="right" style="width: 534px; height: 38px;" width="85%" colspan="2">
                        <asp:TextBox ID="txtItem" runat="server" CssClass="Text" Width="135%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 38px;">
                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="وصف البنــــد : " />
                    </td>
                    <td align="right" style="width: 534px; height: 38px;" width="85%" colspan="2">
                        <asp:TextBox ID="txtItemDesc" runat="server" CssClass="Text" Height="46px" Width="135%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="القيمه التقديريه للوحده : " />
                    </td>
                    <td align="right" style="width: 534px; height: 44px;" width="85%" colspan="2">
                        <asp:TextBox ID="txtInitialValue" runat="server" AutoPostBack="True" CssClass="Text"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="filtered_txtInitialValue" runat="server" FilterType="Custom"
                            TargetControlID="txtInitialValue" ValidChars="1234567890." />
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black">ج م</asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 35px;">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الكميـــــــــــــــــــــــــه : " />
                    </td>
                    <td align="right" style="width: 534px; height: 35px;" width="85%" colspan="2">
                        <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="True" CssClass="Text"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredtxtAmount" runat="server" FilterType="Numbers"
                            TargetControlID="txtAmount" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 39px;">
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="تاريخ الطلب : " />
                    </td>
                    <td align="right" style="width: 534px; height: 39px;" width="85%" colspan="2">
                        <asp:TextBox ID="txt_request_DT" runat="server"  CssClass="Text"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                            TargetControlID="txt_request_DT" ValidChars="0987654321/\" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                            TargetControlID="txt_request_DT">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                            Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_request_DT"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 39px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="مطلوب توفيره قبل  : " />
                    </td>
                    <td align="right" style="width: 534px; height: 39px;" width="85%" colspan="2">
                        <asp:TextBox ID="txtdate" runat="server" AutoPostBack="True" CssClass="Text"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                            TargetControlID="txtdate" ValidChars="0987654321/\" />
                        <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="Image1" TargetControlID="txtdate">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                            ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 39px;">
                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="مصدر التمويل :" />
                    </td>
                    <td align="right" style="width: 0%; height: 39px;">
                        <asp:DropDownList ID="ddl_Source" Width="250" runat="server" CssClass="Button" Font-Bold="True"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 42%; height: 39px;" width="85%">
                        <asp:DropDownList ID="ddl_Provider" runat="server" CssClass="Button" DataTextField="Provider_Name"
                            DataValueField="Provider_ID" Font-Bold="True" Width="368px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 19%; height: 39px" valign="top">
                        <asp:Label ID="Label9" runat="server" CssClass="Label" 
                            Text="الانشطة المرتبطة :" />
                    </td>
                    <td colspan="2" dir="rtl" style="background-color: #F9fdff">
                        <asp:CheckBox ID="chkBoxAll" runat="server" AutoPostBack="true" 
                            ForeColor="Black" OnCheckedChanged="chekAllChange" Text="اختر الكل" />
                        <div ID="divGrid" style="overflow: auto; width: 650px; height: 300px">
                            <asp:GridView ID="gvActivities" runat="server" 
                                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                CaptionAlign="Top" CellPadding="3" CssClass="mGrid" 
                                EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="10pt" 
                                Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                                GridLines="Vertical" OnPreRender="gvSub_PreRender1" PagerStyle-CssClass="pgr" 
                                Width="607px">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                                        <ItemTemplate>
                                            <input id="RowIndex" runat="server" type="hidden" />
                                            <asp:TextBox ID="txtLevel" runat="server" Text='<%#Eval("LVL")%>' 
                                                Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPActv_Parent" runat="server" 
                                                Text='<%#Eval("PActv_Parent")%>' Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtPActv_ID" runat="server" Text='<%#Eval("PActv_ID")%>' 
                                                Visible="false"></asp:TextBox>
                                            <asp:CheckBox ID="chkboxRow" runat="server" 
                                                CommandArgument='<%#Eval("PActv_ID")%>' 
                                                CommandName="<%#Container.DataItemIndex%>" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" 
                                        HeaderText="م" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                        <ItemTemplate>
                                            <%#Eval("Parent_Actv_Num")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="3px" />
                                        <ItemStyle HorizontalAlign="Center" Width="3px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="parent" HeaderStyle-HorizontalAlign="Center" 
                                        HeaderStyle-Width="200px" HeaderText="النشاط الرئيسى" ItemStyle-Width="200px">
                                        <HeaderStyle Width="300px" />
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PActv_Desc" HeaderStyle-HorizontalAlign="Center" 
                                        HeaderStyle-Width="200px" HeaderText=" النشاط الفرعى" ItemStyle-Width="200px">
                                        <HeaderStyle Width="300px" />
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle BackColor="#999999" CssClass="pgr" ForeColor="Black" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 37px">
                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ"  ValidationGroup="A"/>
                        
                        
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
                <tr id="totalNeeds" runat="server" visible="false">
                    <td align="left" colspan="3" dir="ltr" style="width: 739px; height: 40px;">
                        <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black"
                            Text="اجمالـــى الاحتياجــــات :" />
                        <asp:Label ID="lblTotalNeedsCalc" runat="server" CssClass="Button" />
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black">ج م</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3" dir="rtl">
                        <asp:GridView ID="gvMain" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                            ForeColor="Black" PagerStyle-CssClass="pgr" Width="100%" 
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3px" />
                                    <ItemStyle Width="3px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NMT_Desc" HeaderText="نوع الاحتياج الرئيسى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NST_Desc" HeaderText="نوع الاحتياج الفرعى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PNed_Name" HeaderText="اسم البنــــد" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="moneyv" HeaderText="القيمه التقديريه للوحده" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PNed_Number" HeaderText="الكميــه" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="multiply_money_integer" HeaderText="اجمالى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PNed_Date" HeaderText="مطلوب توفيره قبل" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="تعديل" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <input id="pned_id" runat="server" type="hidden" value='<%# Eval("pned_id") %>' />
                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" CommandArgument='<%# Eval("pned_id") %>'
                                            ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" CommandArgument='<%# Eval("pned_id") %>'
                                            ImageUrl="../Images/delete.gif" OnClick="ImgBtnDelete_Click" Style="height: 22px"
                                            OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
