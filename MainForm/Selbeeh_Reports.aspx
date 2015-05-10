﻿<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Selbeeh_Reports.aspx.cs" Inherits="WebForms_Selbeeh_Reports" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

    
   
   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <td height="30px" align="center">
                <asp:Label ID="Label1" runat="server" Text="تقارير مساعد الوزير " CssClass="PageTitle"
                    Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%">
            <td valign="top" align="right">
                <table id="first_table_reports" cellpadding="0" cellspacing="0" style="height: 43px;
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
                                <asp:Image ID="Image16" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" Font-Bold="False" OnClick="IndicatortypeLBdeptMang_Click"
                                    CssClass="Text"> مؤشرات القياس</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image10" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Indicator_develp_LB" runat="server" Font-Bold="False" OnClick="Indicator_develp_LB_Click"
                                    CssClass="Text">  تطور مؤشرات القياس</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr id="activities_tr" runat="server">
            <td valign="top" align="right">
                <table id="second_table_reports" cellpadding="0" cellspacing="0" style="height: 43px;
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
                                <asp:Image ID="Image17" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="PActivitiesPMLB" runat="server" Font-Bold="False" OnClick="PActivitiesPMLB_Click"
                                    CssClass="Text">الخطة التنفيذية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image21" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="PFollowUpPMLB" runat="server" Font-Bold="False" OnClick="PFollowUpPMLB_Click"
                                    CssClass="Text">الانجازات و متابعة الأعمال</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr runat="server" id="NeedsTR">
            <td id="Td2" valign="top" align="right">
                <table id="Table1" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                    <tr id="Tr1" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img3');">
                            <img border="0" id="Img3" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img3');"
                            colspan="2">
                            احتياجات المشروعات
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr3">
            <td style="width: 288px">
                <div id="div3" style="display: none; width: 342px;" dir="rtl">
                    <table style="line-height: 2; width: 108%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px" align="right">
                                <asp:Image ID="Image20" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="PDemandsLB" runat="server" Font-Bold="False" OnClick="PDemandsLB_Click"
                                    CssClass="Text">احتياجات المشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image27" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="projectsneedapproveLB" runat="server" Font-Bold="False" OnClick="projectsneedapproveLB_Click"
                                    CssClass="Text">احتياجات 
                                        المشروعات التي تحتاج تصديق </asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="summation_needs_deptLB" runat="server" Font-Bold="False" OnClick="summation_needs_deptLB_Click"
                                    CssClass="Text">إجمالي احتياجات القطاع مرتبة ادارات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="summation_needs_projLB" runat="server" Font-Bold="False" OnClick="summation_needs_projLB_Click"
                                    CssClass="Text">إجمالي احتياجات الإدارات مرتبة مشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image6" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="needs_in_detailsLB" runat="server" Font-Bold="False" OnClick="needs_in_detailsLB_Click"
                                    CssClass="Text">تفصيل بالاحتياجات مرتبة مشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr runat="server" id="FinanceTr">
            <td id="Td3" valign="top" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                    <tr id="Tr2" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','Img4');">
                            <img border="0" id="Img4" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','Img4');"
                            colspan="2">
                            تقارير مالية
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr4">
            <td style="width: 288px">
                <div id="div4" style="display: none; width: 400px;" dir="rtl">
                    <table style="line-height: 2; width: 100%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image23" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="commitedandRefusedProjectsLB" runat="server" Font-Bold="False"
                                    OnClick="commitedandRefusedProjectsLB_Click" CssClass="Text">ميزانية 
                                المشروعات بقطاع البنية المعلوماتية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image8" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Budget_SourceLB" runat="server" Font-Bold="False" OnClick="Budget_SourceLB_Click"
                                    CssClass="Text">مقترح موازنة مشروعات البنية المعلوماتية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image26" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="dismissal_ReportLB" runat="server" Font-Bold="False" OnClick="dismissal_ReportLB_Click"
                                    CssClass="Text">إجمالي المنصرف في سنة مالية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2">
                                <asp:Image ID="Image9" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="suggest_plan" runat="server" Font-Bold="False" OnClick="suggest_plan_Click"
                                    CssClass="Text"> مقترح الخطة الاستثمارية لمشروعات البنية المعلوماتية</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image7" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="linkAllBalance" runat="server" Font-Bold="False" CssClass="Text"
                                    OnClick="linkAllBalance_Click">إجمالي ميزانية المشروعات بالإدارات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="link_M_Balance" runat="server" Font-Bold="False" CssClass="Text"
                                    OnClick="link_M_Balance_Click"> 
                                     إجمالي ميزانية الإدارات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="hidden" runat="server" id="hidden_Rpt_Id" />
                            </td>
                            <td colspan="2" style="height: 30px">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="lnk_Tender" runat="server" Font-Bold="False" OnClick="lnk_Tender_Click"
                                    CssClass="Text">المناقصات المفتوحة</asp:LinkButton>
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
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                            <img border="0" id="Img2" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                            colspan="2">
                            تقارير عامة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="third_tr_reports">
            <td style="width: 288px">
                <div id="div2" style="display: block; width: 405px;">
                    <table style="line-height: 2; width: 107%">
                        <%--<tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image18" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="ProjectsEmloyeesLB" runat="server" Font-Bold="False" OnClick="ProjectsEmloyeesLB_Click"
                                    CssClass="Text">الموظفين بالإدارة</asp:LinkButton>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image19" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="EmployeeLB" runat="server" CssClass="Text" Font-Bold="False"
                                    OnClick="EmployeeLB_Click">العاملين في المشروعات</asp:LinkButton>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image24" runat="server" ImageUrl="~/new_images/a1.gif" />
                                <asp:LinkButton ID="CurrentProjectsLB" runat="server" Font-Bold="False" OnClick="CurrentProjectsLB_Click"
                                    CssClass="Text"> المشروعات الجارية بقطاع 
                                البنية المعلوماتية</asp:LinkButton>
                            </td>
                        </tr>--%>
                       <%-- <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image26" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;<asp:LinkButton ID="OrganizationsProjectsLB" runat="server" Font-Bold="False"
                                    OnClick="OrganizationsProjectsLB_Click" CssClass="Text">المشروعات 
                                     الخاصة بجهات معينة</asp:LinkButton>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image28" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;<asp:LinkButton ID="projobjectiveLB" runat="server" Font-Bold="False" OnClick="projobjectiveLB_Click"
                                    CssClass="Text">أهداف المشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="needhighinetrLB" runat="server" Font-Bold="False" OnClick="needhighinetrLB_Click"
                                    CssClass="Text">مشروعات تحتاج تدخل ادارة عليا</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                       
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image13" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="protocole_Report" runat="server" Font-Bold="False" OnClick="protocole_Report_Click"
                                    CssClass="Text">البروتوكولات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image15" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="year_Vs_Project" runat="server" Font-Bold="False" OnClick="year_Vs_Project_Click"
                                    CssClass="Text">مقترح انتهاء المشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                                &nbsp;
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image29" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Projects_Status" runat="server" Font-Bold="False" OnClick="Projects_Status_Click"
                                    CssClass="Text">البيانات الأساسية لمشروعات قطاع البنية المعلوماتية</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                                &nbsp;</td>
                            <td style="height: 30px">
                                <asp:Image ID="Image30" runat="server" ImageUrl="~/new_images/a1.gif" 
                                    Style="text-align: right" />
                                <asp:LinkButton ID="projects_Org" runat="server" Font-Bold="False"
                                    OnClick="projects_Org_Click" CssClass="Text">بيانات المشروعات الأساسية 
                                الخاصة بجهة معينة</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                                &nbsp;
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image22" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="project_select_status" runat="server" Font-Bold="False" OnClick="project_select_status_Click"
                                    CssClass="Text">موقف المشروعات</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                                &nbsp;
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image24" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Delay_Projects" runat="server" Font-Bold="False" OnClick="Delay_Projects_Click"
                                    CssClass="Text">المشروعات المتأخرة</asp:LinkButton>
                            </td>
                        </tr>
                         <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image14" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="Files_No" runat="server" Font-Bold="False" OnClick="Files_No_Click"
                                    CssClass="Text">عدد الوثائق العامة</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image12" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="ALL_Actions_No" runat="server" Font-Bold="False" OnClick="ALL_Actions_No_Click"
                                    CssClass="Text">عدد كل الوثائق</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image25" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="Files_No_Size" runat="server" Font-Bold="False"
                                    CssClass="Text" onclick="Files_No_Size_Click">عدد وحجم كل الوثائق</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image11" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                &nbsp;
                                <asp:LinkButton ID="ALL_Act_Actions_No" runat="server" Font-Bold="False" OnClick="ALL_Act_Actions_No_Click"
                                    CssClass="Text">متابعة إدخال بيانات المشروعات</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                          <tr>
                            <td width="28">
                                &nbsp;
                            </td>
                            <td style="height: 30px">
                                <asp:Image ID="Image18" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Similar_ProjectLB" runat="server" Font-Bold="False"  OnClick="Similar_ProjectLB_Click"
                                    CssClass="Text">المشروعات المتشابهة</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style="line-height: 2; width: 100%; display: none; height: 238px" id="tbl_Paramater" runat="server">
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
        <tr>
            <td valign="top" style="width: 100%">
                <div id="Div_Dept" runat="server" style="display: none">
                    <table cellpadding="0" cellspacing="0">
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" width="400px" dir="rtl">
                <%--  <asp:DropDownList ID="DropDep" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="DropDep_SelectedIndexChanged" CssClass="drop"
                                    Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnResearch" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
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
                                     CssClass="drop" Height="39px"
                                    Width="200px">
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
                                     CssClass="drop" Height="39px"
                                    Width="200px">
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
                <!--<td align="right" dir="rtl">
                                <asp:ImageButton ID="ImageButton5" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />
                            </td>-->
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
    <div id="Div_Date_balance" runat="server" style="display: block">
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
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                 
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

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
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
    <div id="Div_Dates_Demands" runat="server" style="display: block">
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

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
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

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
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
    </td> </tr>
    <tr>
        <td style="height: 43px;" align="center" dir="ltr">
            &nbsp;
            <asp:Label ID="Labname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabValue" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabDeptname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                OnClick="Button1_Click" Text="عرض التقرير" Width="98px"  ValidationGroup="A"/>
                
                
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
