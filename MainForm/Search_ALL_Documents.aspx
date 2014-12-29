<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Search_ALL_Documents.aspx.cs" Inherits="WebForms2_Search_ALL_Documents" title="البحث العام"%>

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
                        <asp:ListItem Text="اجتماعات" Value="4"></asp:ListItem>
                        <asp:ListItem Text="عروض تقديمية" Value="5"></asp:ListItem>
                        <asp:ListItem Text="أحداث" Value="6"></asp:ListItem>
                        <asp:ListItem Text="وثائق عامة" Value="7"></asp:ListItem>
                        <asp:ListItem Text="الكل" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3" style="height: 33px" visible="false">
                <table runat="server" id="table_inbox" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div_title_inbox" style="display: block" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الوارد" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_check_inbox" style="display: block" runat="server">
                                <table id="Table25" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:CheckBox ID="Check_inbox" runat="server" Visible="true" Text="وارد من المشرف العام علي القطاع"
                                                CssClass="Label" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_inbox_code" style="display: block" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كلمة في الكود:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Txtcode" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_inbox_subject" style="display: block" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Inbox_name_text" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div_inbox_org" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="جهة الورود : "></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <uc1:Smart_Search ID="Smrt_Srch_org" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div_inbox_date_label" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الورود:" />
                                            <asp:Label ID="Label50" runat="server" CssClass="Label" Text="من:" />
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
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div_outbox_date" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ صادر الجهة:" />
                                            <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
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
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div_out_code" runat="server">
                                <table width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label14" runat="server" CssClass="Label" Text="رقم صادر الجهة:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_out_code" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_outbox" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div1" style="display: block" runat="server">
                                <table id="Table1" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label15" runat="server" CssClass="PageTitle" Text="الصادر" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div2" style="display: block" runat="server">
                                <table id="Table2" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label16" runat="server" CssClass="Label" Text="كلمة في الكود:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_Code_outbox" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div3" style="display: block" runat="server">
                                <table id="Table3" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label18" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_subject_outbox" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div4" runat="server">
                                <table id="Table4" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="تاريخ صادر الجهة:" />
                                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="من:" />
                                            <asp:TextBox ID="outbox_date_from_out" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom"
                                                TargetControlID="outbox_date_from_out" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3"
                                                TargetControlID="outbox_date_from_out">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton3" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="الى:" />
                                            <asp:TextBox ID="Outbox_date_to_out" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                                TargetControlID="Outbox_date_to_out" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton4"
                                                TargetControlID="Outbox_date_to_out">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton4" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div5" runat="server">
                                <table id="Table5" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label22" runat="server" CssClass="Label" Text="رقم صادر الجهة:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_outbox_no" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_Meetings" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div6" style="display: block" runat="server">
                                <table id="Table6" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label23" runat="server" CssClass="PageTitle" Text="الإجتماعات" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div7" style="display: block" runat="server">
                                <table id="Table7" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label24" runat="server" CssClass="Label" Text="كلمة فى الاجتماع:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Meeting_name" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div8" style="display: block" runat="server">
                                <table id="Table8" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label25" runat="server" CssClass="Label" Text="كلمة فى مكان الاجتماع:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Meeting_location" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div9" style="display: block" runat="server">
                                <table id="Table9" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label26" runat="server" CssClass="Label" Text="كلمة فى الجهة:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Meeting_Side" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div10" runat="server">
                                <table id="Table10" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="تاريخ  الإجتماع:" />
                                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="من:" />
                                            <asp:TextBox ID="Meeting_date_from" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom"
                                                TargetControlID="Meeting_date_from" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton5"
                                                TargetControlID="Meeting_date_from">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton5" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label29" runat="server" CssClass="Label" Text="الى:" />
                                            <asp:TextBox ID="Meeting_date_to" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Custom"
                                                TargetControlID="Meeting_date_to" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton6"
                                                TargetControlID="Meeting_date_to">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton6" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_presentations" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div11" style="display: block" runat="server">
                                <table id="Table12" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label30" runat="server" CssClass="PageTitle" Text="العروض التقديمية" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div12" style="display: block" runat="server">
                                <table id="Table13" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="كلمة فى العرض التقديمي:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Presentation_name" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div13" style="display: block" runat="server">
                                <table id="Table14" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text="مكان العرض:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Presentation_location" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div15" runat="server">
                                <table id="Table16" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label34" runat="server" CssClass="Label" Text="تاريخ  العرض:" />
                                            <asp:Label ID="Label35" runat="server" CssClass="Label" Text="من:" />
                                            <asp:TextBox ID="Presentation_date_from" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Custom"
                                                TargetControlID="Presentation_date_from" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton7"
                                                TargetControlID="Presentation_date_from">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton7" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label36" runat="server" CssClass="Label" Text="الى:" />
                                            <asp:TextBox ID="Presentation_date_to" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterType="Custom"
                                                TargetControlID="Presentation_date_to" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton8"
                                                TargetControlID="Presentation_date_to">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton8" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_Events" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div14" style="display: block" runat="server">
                                <table id="Table15" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label33" runat="server" CssClass="PageTitle" Text="الأحداث" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div16" style="display: block" runat="server">
                                <table id="Table17" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label37" runat="server" CssClass="Label" Text="كلمة فى الحدث:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Event_name" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div17" style="display: block" runat="server">
                                <table id="Table18" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label38" runat="server" CssClass="Label" Text="مكان الحدث:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="Event_location" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="display: block" id="div18" runat="server">
                                <table id="Table19" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label39" runat="server" CssClass="Label" Text="تاريخ  الحدث:" />
                                            <asp:Label ID="Label40" runat="server" CssClass="Label" Text="من:" />
                                            <asp:TextBox ID="Event_date_from" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterType="Custom"
                                                TargetControlID="Event_date_from" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="ImageButton9" TargetControlID="Event_date_from">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton9" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label41" runat="server" CssClass="Label" Text="الى:" />
                                            <asp:TextBox ID="Event_date_to" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Custom"
                                                TargetControlID="Event_date_to" ValidChars="0987654321/\" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="ImageButton10" TargetControlID="Event_date_to">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton10" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_General_Documents" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div21" style="display: block" runat="server">
                                <table id="Table22" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label49" runat="server" CssClass="PageTitle" Text="الوثائق العامة" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div22" style="display: block" runat="server">
                                <table id="Table23" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label51" runat="server" CssClass="Label" Text="كلمه فى اسم الوثيقة:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_file_name" Width="338px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div23" style="display: block" runat="server">
                                <table id="Table24" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label52" runat="server" CssClass="Label" Text="كلمه فى وصف الوثيقة:" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_file_discribtion" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div24" style="display: block" runat="server">
                                <table id="Table11" width="100%" runat="server">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label53" runat="server" CssClass="Label" Text="نوع الوثيقة:" />
                                            <asp:DropDownList ID="ddl_File_Type" runat="server" CssClass="drop" Width="300">
                                                <asp:ListItem Text="أختر نوع الملف " Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Word" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Excel" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="PDF" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="IMAGE" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="PowerPoint" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Microsoft Project" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="Video" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="table_All" style="display: none" width="100%">
                    <tr>
                        <td>
                            <div id="div19" style="display: block" runat="server">
                                <table id="Table20" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label42" runat="server" CssClass="PageTitle" Text="الكل " />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div20" style="display: block" runat="server">
                                <table id="Table21" width="100%" runat="server">
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:Label ID="Label43" runat="server" CssClass="Label" Text="كلمة فى - موضوع الوارد - موضوع الصادر - الإجتماعات - العروض التقديمية - الأحداث :" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" dir="rtl">
                                            <asp:TextBox runat="server" CssClass="Text" ID="Part" Width="323px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="div_title_oubbox" style="display: none" runat="server">
                    <asp:Label ID="Label7" runat="server" CssClass="PageTitle" Text="الصادر" />
                </div>
                <div id="div_title_ALL" style="display: none" runat="server">
                    <asp:Label ID="Label3" runat="server" CssClass="PageTitle" Text="الكل" />
                </div>
                <div id="div_title_meetings" style="display: none" runat="server">
                    <asp:Label ID="Label8" runat="server" CssClass="PageTitle" Text="الإجتماعات" />
                </div>
                <div id="div_title_presentations" style="display: none" runat="server">
                    <asp:Label ID="Label9" runat="server" CssClass="PageTitle" Text="العروض التقديمية" />
                </div>
                <div id="div_title_Events" style="display: none" runat="server">
                    <asp:Label ID="Label12" runat="server" CssClass="PageTitle" Text="الأحداث" />
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
                <div id="div_inbox_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label44" runat="server" CssClass="Label" Text="الوارد" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_Main" style="display: block" runat="server">
                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnRowCommand="gvMain_RowCommand" 
                        OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="    رقم القيد    ">
                                <ItemTemplate>
                                    <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                    <%# Eval("incombination")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" تاريخ الورود ">
                                <ItemTemplate>
                                    <%# Eval("Date")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="جهة الورود">
                                <ItemTemplate>
                                    <%# Eval("Org_Desc")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                <ItemTemplate>
                                   
                                    <%# Eval("outcombination")%>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                                <ItemTemplate>
                                    <%# Eval("Org_Out_Box_Code")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                <ItemTemplate>
                                    <%# Eval("Org_Out_Box_DT")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  الموضوع ">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="200px" runat="server"
                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
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
                                        Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عرض" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                        CommandArgument='<%# Eval("ID") %>' />
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
                </div>
                <div id="div_outbox_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label45" runat="server" CssClass="Label" Text="الصادر" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_outbox" style="display: block" runat="server">
                    <asp:GridView ID="GridViewoutbox" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnRowCommand="GridViewoutbox_RowCommand" 
                        OnPageIndexChanging="GridViewoutbox_PageIndexChanging" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText=" الكود ">
                                <ItemTemplate>
                                    <%# Eval("Code")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الصادر" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("Date")%>
                                </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الجهة الصادر لها">
                                <ItemTemplate>
                                    <%# Eval("Org_Desc")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  الموضوع ">
                                <ItemTemplate>
                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="400px" runat="server"
                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
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
                                        Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="عرض" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                        CommandArgument='<%# Eval("ID") %>' />
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
                </div>
                <div id="div_general_documents_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label54" runat="server" CssClass="Label" Text="الوثائق العامة" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_general_doc" style="display: block" runat="server">
                    <asp:GridView ID="GridView_general_doc" runat="server" AutoGenerateColumns="False"
                        CellPadding="3" Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        AllowPaging="True" OnPageIndexChanging="GridView_general_doc_PageIndexChanging"
                        PageSize="5" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>

<HeaderStyle Width="3px"></HeaderStyle>

<ItemStyle Width="3px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="اسم الوثيقة" HeaderStyle-Width="80%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="80%">
                                <ItemTemplate>
                                    <a href='<%# "ALL_Document_Details.aspx?type=deprtfile&id="+ Eval("File_Id") %>'>
                                        <%# Eval("File_name")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                <ItemStyle Width="80%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نوع الوثيقة" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <%# Eval("File_Type_Resolved")%>
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
                <div id="div_meet_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label46" runat="server" CssClass="Label" Text="الإجتماعات" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_meetings" style="display: block" runat="server">
                    <asp:GridView ID="GridView_Meetings" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                        AllowSorting="True" 
                        OnPageIndexChanging="GridView_Meetings_PageIndexChanging" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="الاجتماع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <input id="Meeting_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                    <%# Eval("Meeting_name")%>
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
                            <asp:TemplateField HeaderText="تاريخ الاجتماع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <%# Eval("Meeting_date")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                <div id="div_pres_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label47" runat="server" CssClass="Label" Text="العروض التقديمية" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_Presentations" style="display: block" runat="server">
                    <asp:GridView ID="GridView_presentations" runat="server" AutoGenerateColumns="False"
                        CellPadding="3" Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        AllowPaging="True" AllowSorting="True" 
                        OnPageIndexChanging="GridView_presentations_PageIndexChanging" 
                        GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="العرض" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <input id="Presentation_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                    <%# Eval("Presentation_name")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مكان العرض" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <%# Eval("Presentation_location")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ العرض" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <%# Eval("Presentation_date")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ملف العرض" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <a href='<%# "ALL_Document_Details.aspx?type=Presentation&id="+ Eval("id") %>'>
                                        <%# Eval("File_name")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                <div id="div_event_word" style="display: none" runat="server">
                    <table width="100%">
                        <tr bgcolor="#CCCCCC">
                            <td>
                                <asp:Label ID="Label48" runat="server" CssClass="Label" Text="الاحداث" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_grid_events" style="display: block" runat="server">
                    <asp:GridView ID="GridView_events" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AllowPaging="True"
                        AllowSorting="True" 
                        OnPageIndexChanging="GridView_events_PageIndexChanging" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="الحدث" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <input id="Event_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                    <%# Eval("Event_name")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ملف الحدث" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <a href='<%# "ALL_Document_Details.aspx?type=Event&id="+ Eval("id") %>'>
                                        <%# Eval("File_name")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الحدث" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <%# Eval("Event_date")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مكان الحدث" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <%# Eval("Event_location")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
            </td>
        </tr>
    </table>
</asp:Content>
