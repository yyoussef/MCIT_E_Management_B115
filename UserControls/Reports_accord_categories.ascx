<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Reports_accord_categories.ascx.cs"
    Inherits="UserControls_Reports_accord_categories" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
   function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid); 
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('collapse') != -1)
       { img.src = "../Images/expand.gif";
        }
    else
        {img.src = "../Images/collapse.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}

</script>

<%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
<table style="width: 100%; display: block; height: 238px; line-height: 2;" id="tbl_Report"
    runat="server">
    <tr>
        <td height="30px" align="center" colspan="3">
            <asp:Label ID="Label1" runat="server" Text="تقارير  " CssClass="PageTitle" Font-Underline="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label29" runat="server" Text="التصنيف : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td colspan="2">
            <asp:DropDownList ID="Drop_cat" runat="server" AutoPostBack="True" Font-Bold="False"
                CssClass="drop" Height="39px" Width="200px" OnSelectedIndexChanged="Drop_cat_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Text="المشروع : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td colspan="2">
            <uc1:Smart_Search ID="Smart_proj" runat="server" />
        </td>
    </tr>
    <tr id="Tr_Reports" runat="server" visible="false">
        <td colspan="3">
            <div id="div6" style="display: block; width: 405px;">
                <table style="line-height: 2; width: 107%">
                    <tr>
                        <td width="28">
                            <input type="hidden" runat="server" id="hidden_Rpt_Id" />
                        </td>
                        <td>
                            <asp:Image ID="Image40" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="PActivitiesPMLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="PActivitiesPMLB_Click">الخطة التنفيذية</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image41" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="PFollowUpPMLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="PFollowUpPMLB_Click">الانجازات و متابعة الأعمال</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image42" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="IndicatortypeLBdeptMang_Click">مؤشرات القياس</asp:LinkButton>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            &nbsp;
                            <asp:LinkButton ID="Indicator_develp_LB" runat="server" Font-Bold="False" OnClick="Indicator_develp_LB_Click"
                                CssClass="Text"> تطور مؤشرات القياس</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            &nbsp;
                            <asp:LinkButton ID="PDemandsLB" runat="server" Font-Bold="False" OnClick="PDemandsLB_Click"
                                CssClass="Text">احتياجات المشروعات مرتبة بالتاريخ المخطط للتوريد</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image25" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            &nbsp;
                            <asp:LinkButton ID="suggest_plan" runat="server" Font-Bold="False" CssClass="Text"
                                OnClick="suggest_plan_Click">مقترح الخطة الاستثمارية لمشروعات البنية المعلوماتية</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            &nbsp;
                            <asp:LinkButton ID="lnk_Tender" runat="server" Font-Bold="False" OnClick="lnk_Tender_Click"
                                CssClass="Text">المناقصات المفتوحة</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            &nbsp;
                            <asp:LinkButton ID="projobjectiveLB" runat="server" Font-Bold="False" OnClick="projobjectiveLB_Click"
                                CssClass="Text">أهداف المشروعات</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table style="line-height: 2; width: 100%; display: none; height: 238px" id="tbl_Paramater"
    runat="server">
    <tr>
        <td height="15px">
        </td>
    </tr>
    <tr>
        <td style="height: 41px" align="center">
            <%--<input type="hidden" visible="false"  runat="server" id="hidden_Rpt_Id" />--%>
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle"></asp:Label>
        </td>
        <td>
            <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                Width="37px" OnClick="ImgBtnBack_Click" AlternateText="العودة للتقارير الرئيسية" />
        </td>
    </tr>
    <tr>
        <td style="height: 41px" align="center">
            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" CssClass="Label"></asp:Label>
        </td>
    </tr>
</table>
<div id="Div_Dept" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" dir="rtl">
                <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" dir="rtl">
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div id="Div_tech" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" dir="rtl">
                <asp:Label ID="Label33" runat="server" Text="التقنيات : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" dir="rtl">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Height="39px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div id="Div_technology_category" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" dir="rtl">
                <asp:Label ID="Label16" runat="server" Text="التصنيف : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" dir="rtl">
                <asp:DropDownList ID="Drop_category" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Height="39px" Width="200px">
                </asp:DropDownList>
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" CssClass="drop"
                                    Font-Bold="false" OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged"
                                    Height="39px" Width="337px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
            </td>
        </tr>
        <tr>
            <td align="right" width="110px" dir="rtl">
                <asp:Label ID="Label17" runat="server" Text="التقنيات : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" dir="rtl">
                <asp:DropDownList ID="Drop_technology" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Height="39px" Width="200px">
                </asp:DropDownList>
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" CssClass="drop"
                                    Font-Bold="false" OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged"
                                    Height="39px" Width="337px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
            </td>
        </tr>
    </table>
</div>
<div id="Div_emp" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label18" runat="server" Text="اسم الموظف : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop"
                                     Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="smart_employee" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
</div>
<div id="Div_monitor" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label25" runat="server" Text="الحالة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="drop_stat" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Width="337px" Height="39px">
                    <asp:ListItem Selected="True" Text="الأكثر استخداما" Value="1"></asp:ListItem>
                    <asp:ListItem Text="الأقل استخداما" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label26" runat="server" Text="عدد الادارات : " Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:TextBox ID="txt_no" runat="server" CssClass="Text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" colspan="1">
                <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="التاريخ من :" Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td align="right" colspan="2">
                <asp:TextBox ID="txt_date_from" runat="server" Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="True" Width="129px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_date_from"
                    PopupButtonID="ImageButton5" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton5" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txt_req_date_from"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="التاريخ الي :" Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                <asp:TextBox ID="txt_date_to" runat="server" Font-Bold="True" Height="29px" Width="128px"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_date_to"
                    PopupButtonID="ImageButton9" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton9" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                    ControlToValidate="txt_req_date_to" ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</div>
<div id="Div_request_date_vacation" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr visible="true">
            <td visible="true" align="center">
                <asp:Label ID="Label19" runat="server" CssClass="PageTitle" color="red" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" colspan="1">
                <asp:Label ID="Label20" runat="server" Font-Bold="False" Text="تاريخ طلب الأجازة - البداية :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td align="right" colspan="2">
                <asp:TextBox ID="txt_req_date_from" runat="server" Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="True" Width="129px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_req_date_from"
                    PopupButtonID="ImageButton3" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton3" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_req_date_from"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="تاريخ طلب الأجازة - النهاية :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                <asp:TextBox ID="txt_req_date_to" runat="server" Font-Bold="True" Height="29px" Width="128px"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_req_date_to"
                    PopupButtonID="ImageButton4" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton4" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_req_date_to"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</div>
<div id="Div_take_date_vacation" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr visible="true">
            <td visible="true" align="center">
                <asp:Label ID="Label22" runat="server" CssClass="PageTitle" color="red" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" colspan="1">
                <asp:Label ID="Label23" runat="server" Font-Bold="False" Text="تاريخ القيام بالأجازة - البداية :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td align="right" colspan="2">
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
            <td align="right" colspan="2">
                <asp:Label ID="Label24" runat="server" Font-Bold="False" Text="تاريخ القيام بالأجازة - النهاية :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
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
</div>
<div id="Div_Proj_Mngr" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label4" runat="server" Text="مدير المشروع : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop"
                                     Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="Smrt_Srch_projmanage" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
</div>
<div id="Div_Status" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label15" runat="server" Text="الحالة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="Dropstatus" runat="server" AutoPostBack="True" Font-Bold="False"
                    CssClass="drop" Width="337px" Height="39px">
                    <asp:ListItem Text="اختر الحالة ...." Value="0"></asp:ListItem>
                    <asp:ListItem Text="تحت الدراسة" Value="1"></asp:ListItem>
                    <asp:ListItem Text="جاري" Value="2"></asp:ListItem>
                    <asp:ListItem Text="لم يبدأ" Value="3"></asp:ListItem>
                    <asp:ListItem Text=" منتهي" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
</div>
<div id="Div_Proj" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="Label7" runat="server" Text="المشروع : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <%--<asp:DropDownList ID="DropProj" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="DropProj_SelectedIndexChanged" CssClass="drop"  Width="337px"
                                    Height="39px">
                                </asp:DropDownList>--%>
                <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div id="Div_Org" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="Label3" runat="server" Text="الجهة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="Droporg" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="Droporg_SelectedIndexChanged" CssClass="drop" Width="337px"
                    Height="39px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Balance" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="LBL_Balance" runat="server" Text="السنة المالية: " Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="Drop_balance" runat="server" Font-Bold="False" OnSelectedIndexChanged="Drop_balance_SelectedIndexChanged"
                    CssClass="drop" Width="300px" Height="39px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Date_balance" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr visible="true">
            <td visible="true" align="center">
                <asp:Label ID="DateLabel" runat="server" CssClass="PageTitle" color="red" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="تاريخ البداية :" Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="TextBox3" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                    Font-Bold="True" Width="129px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox3"
                    PopupButtonID="ImageButton1" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="تاريخ النهاية :" Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Bold="True" Height="29px" Width="128px"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox4"
                    PopupButtonID="ImageButton2" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton2" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox4"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Date_Needs" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td id="td1" runat="server" align="right" width="110px">
                <asp:Label ID="Label10" runat="server" Text="تاريخ الجرد : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td style="height: 44px" align="right" dir="rtl">
                <asp:DropDownList ID="DropDate" runat="server" CssClass="drop" Width="197px" OnSelectedIndexChanged="DropDate_SelectedIndexChanged"
                    Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Dates_Demands" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label11" runat="server" Font-Bold="False" Text="التاريخ المخطط للتوريد من :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="TextBox1" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                    Font-Bold="True" Width="129px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalAvailbleDate" runat="server" TargetControlID="TextBox1"
                    PopupButtonID="ImageButton6" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton6" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="التاريخ المخطط للتوريد إلي :"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Height="29px" Width="128px"
                    Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2"
                    PopupButtonID="ImageButton7" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton7" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Main_Activity" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label13" runat="server" Text="الأنشطةالرئيسية : " Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop"
                                     Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="Smart_Search_main" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
</div>
<div id="Div_sub_Activity" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label14" runat="server" Text="الأنشطةالفرعية : " Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop"
                                     Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="Smart_Search_sub" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
</div>
<div id="Div_btn" runat="server" style="display: none" >
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr align="center">
            <td style="height: 43px;" align="center" dir="ltr">
               
                <asp:Label ID="Labname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="LabValue" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="LabDeptname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
                <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                    OnClick="Button1_Click" Text="عرض التقرير" Width="98px" />
            </td>
        </tr>
    </table>
</div>
