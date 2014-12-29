<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="PMallReports.aspx.cs" Inherits="WebForms_PMallReports" Title="التقارير" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
   function ChangeMeCase(divid, imgid)
    {
    
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

    <table width="100%" id="headertable" runat="server" style="line-height: 2;">
        <tr>
            <td height="40px" align="center">
                <asp:Label ID="Label6" runat="server" Text="تقارير مدير المشروع" CssClass="PageTitle"
                    Font-Underline="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" id="header2table" runat="server">
                    <tr>
                        <td align="center" dir="rtl" height="45px">
                            <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                                Font-Bold="false" Text="مدير المشروع : " Visible="false" ></asp:Label>
                            <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                                Font-Bold="false" Visible="false" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" id="header3table" runat="server"
        style="height: 36px">
        <tr>
            <td align="center" dir="rtl">
                <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="المشروع : " Font-Names="Arial"
                    Font-Size="20px" ForeColor="#1F4569" Visible="false"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%; display: block; height: 238px" id="tbl_Report" runat="server">
        <tr style="width: 100%">
            <td valign="top" align="right">
                <table id="first_table_reports" cellpadding="0" cellspacing="0" style="height: 34px;
                    width: 100%;">
                    <tr id="firstreports" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                            <img border="0" id="image0" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');"
                            colspan="2">
                            مؤشرات
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="firts_tr_reports">
            <td style="width: 288px">
                <div id="div0" style="display: block" dir="rtl">
                    <table style="line-height: 2; width: 100%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" Font-Bold="False" OnClick="IndicatortypeLBdeptMang_Click"
                                    CssClass="Text"> مؤشرات القياس</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <table id="second_table_reports" cellpadding="0" cellspacing="0" style="height: 36px;
                    width: 100%;">
                    <tr id="secondreports" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img1');">
                            <img border="0" id="Img1" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img1');"
                            colspan="2">
                            الخطط الزمنية
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="second_tr_reports">
            <td style="width: 288px">
                <div id="div1" style="display: none; width: 297px;">
                    <table style="line-height: 2; width: 111%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image116" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="PActivitiesPMLB" runat="server" Font-Bold="False" OnClick="PActivitiesPMLB_Click"
                                    CssClass="Text">الخطة التنفيذية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image10" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="PFollowUpPMLB" runat="server" Font-Bold="False" OnClick="PFollowUpPMLB_Click"
                                    CssClass="Text">الانجازات و متابعة الأعمال</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td id="third_td_reports" valign="top" align="right">
                <table id="third_table_reports" cellpadding="0" cellspacing="0" style="height: 43px;
                    width: 100%;">
                    <tr id="thirdreport" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                            style="height: 43px">
                            <img border="0" id="Img2" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;
                            height: 43px;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                            colspan="2">
                            تقارير عامة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="third_tr_reports">
            <td style="width: 288px">
                <div id="div2" style="display: block">
                    <table style="line-height: 2; width: 107%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image11" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="projobjectiveLB" runat="server" Font-Bold="False" OnClick="projobjectiveLB_Click"
                                    CssClass="Text">أهداف المشروع</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="projAchievmentLB" runat="server" Font-Bold="False" OnClick="projAchievmentLB_Click"
                                    CssClass="Text">إنجازات المشروع</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <%--<tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="project_DetailsLB" runat="server" Font-Bold="False" OnClick="project_DetailsLB_Click"
                                    CssClass="Text">تفاصبل المشروع</asp:LinkButton>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image12" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="EmployeeLB" runat="server" Font-Bold="False" OnClick="EmployeeLB_Click"
                                    CssClass="Text">تقرير العاملين
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="ALL_Act_Actions_No" runat="server" Font-Bold="False" CssClass="Text"
                                    OnClick="ALL_Act_Actions_No_Click">تقرير متابعة إدخال البيانات
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="Link_Fin" runat="server" Font-Bold="False" OnClick="Link_Fin_Click"
                                    CssClass="Text">المناقصات المفتوحة
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="Link_suggest_plan" runat="server" Font-Bold="False" OnClick="Link_suggest_plan_Click"
                                    CssClass="Text">مقترح الخطة الاستثمارية
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td id="Td1" valign="top" align="right">
                <table id="Table1" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                    <tr id="Tr1" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img5');"
                            style="height: 43px">
                            <img border="0" id="Img5" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;
                            height: 43px;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img5');"
                            colspan="2">
                            تقارير مالية
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr2">
            <td style="width: 288px">
                <div id="div5" style="display: block">
                    <table style="line-height: 2; width: 107%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image6" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Work_orderLB" runat="server" Font-Bold="False" OnClick="Work_orderLB_Click"
                                    CssClass="Text">أوامر التوريد</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style="width: 100%; display: none; height: 238px" id="tbl_Paramater" runat="server">
        <tr>
            <td height="15px">
            </td>
        </tr>
        <tr>
            <td style="height: 50px" align="center">
                <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Visible="false"></asp:Label>
            </td>
            <td align="left">
                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                    Width="37px" AlternateText="العودة للتقارير الرئيسية" OnClick="ImgBtnBack_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Laberror" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="Red"
                    Font-Bold="False" Visible="False" Height="100%" Width="93%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <input type="hidden" runat="server" id="hidden_Rpt_Id" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="Div_date" runat="server" style="display: none">
                    <table>
                        <tr>
                            <td align="right" width="110px" dir="rtl">
                                <asp:Label ID="Label5" runat="server" Text="تاريخ الصرف : " Font-Names="Arial" Font-Size="20px"
                                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
                            </td>
                            <td align="right" dir="rtl">
                                <asp:DropDownList ID="DropDate" runat="server" CssClass="drop" Width="222px" Height="23px"
                                    DataTextFormatString="">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="Div_Date_start" runat="server" style="display: block">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                                    Font-Bold="false" Text="تاريخ المنصرف من  :"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TextBox3" runat="server" Font-Size="18px" Height="27px" Font-Bold="True"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox3"
                                    PopupButtonID="ImageButton1" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3"
                                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"
                                    Font-Bold="false" Text="تاريخ الباقي حتي :"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TextBox4" runat="server" Font-Size="18px" Height="27" Font-Bold="True">
                                </asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox4"
                                    PopupButtonID="ImageButton2" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="ImageButton2" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4"
                                    ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="Div_Balance" runat="server" style="display: none">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" width="110px" style="height: 44px">
                                <asp:Label ID="LBL_Balance" runat="server" Text="السنة المالية: " Font-Names="Arial"
                                    Font-Size="20px" ForeColor="#1F4569" Font-Bold="false"></asp:Label>
                            </td>
                            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                                <asp:DropDownList ID="Drop_balance" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Drop_balance_SelectedIndexChanged" CssClass="drop" Width="337px"
                                    Height="39px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 43px;" align="center" dir="ltr">
                <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                    OnClick="Button1_Click" Text="عرض التقرير" Width="98px" />
            </td>
        </tr>
    </table>
</asp:Content>
