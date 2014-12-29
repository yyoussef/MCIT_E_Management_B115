<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Site_Menu2.ascx.vb" Inherits="UserControls_Site_Menu2" %>
<%--table border="0" dir="rtl" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td height="30px">
        </td>
    </tr>--%>

<script type="text/javascript" src="../Script/JScript.js">
  
</script>

<div id="Div_Main" runat="server">
    <table border="0" id="myMenu" class="nav" onmouseover="showmenu()" onmouseout="hidemenu()">
        <tr align="center" valign="middle">
            <td align="center" valign="middle">
                <div id="MangerDepDiv" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif'); height: 36px;">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Default.aspx">
                                    الرئيسية</a> </li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="ProjectSearch.aspx">
                                    استعلام عام</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Default.aspx?curProj=1">
                                    المشروعات الجارية</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="projects.aspx?mode=new">
                                    مقترح مشروع جديد</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="ProjectSearch.aspx?mode=edit">
                                    تعديل مقترح مشروع</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_priority.aspx">
                                    أولوية مقترح مشروع</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Main_Search.aspx">
                                    البروتوكولات </a></li>
                                <li id="LI_Search_Mngr" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">وثائق الإدارة</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Deprt_Documnts.aspx">
                                            وثائق عامة</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Inbox.aspx">
                                            وارد</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Outbox.aspx">
                                            صادر</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_meetings.aspx">
                                            اجتماعات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_event.aspx">
                                            أحداث </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_presentation.aspx">
                                            عروض تقديمية </a></li>
                                        <li style="background-image: url('../new_images/top2.gif'); display: none;"><a href="Project_protocol.aspx">
                                            بروتوكولات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Complain.aspx">
                                            المناقضات </a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    استعلام عن الوثائق</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="General_Search.aspx">
                                            وثائق عامة</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Connecting_inbox_outbox.aspx">
                                            وارد / صادر</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif');"><a href="Inbox_Search.aspx">
                                            وارد</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif');"><a href="Outbox_Search.aspx">
                                            صادر</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_meetings_search.aspx">
                                            اجتماعات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_presentation_search.aspx">
                                            عروض تقديمية </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_event_search.aspx">
                                            أحداث </a></li>
                                        <li style="background-image: url('../new_images/top2.gif'); display: none;"><a href="Project_protocol_search.aspx">
                                            بروتوكولات </a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="DepartmentmngallReports.aspx">
                                    تقارير</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Add_fav.aspx">إضافة
                                    للمفضلة</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    الأجازات والمأموريات</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations.aspx">
                                            الأجازات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_errand.aspx">
                                            المأموريات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_DayOff.aspx">
                                            عمل يوم عطلة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vocations_permission.aspx">
                                            إذن</a></li>
                                        <li id="Li31" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                            <a href="vacations_Reports.aspx">تقارير</a>
                                            <input type="hidden" runat="server" id="hidden34" value="34" />
                                        </li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li id="Li41" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">التدريب</a>
                                    <ul class="newclass">
                                        <li id="li51" runat="server" style="background-image: url('../new_images/top2.gif')">
                                            <a href="Training_ViewUserRegisteredCourses.aspx">دوراتى</a> </li>
                                        <li id="Li1" runat="server" style="background-image: url('../new_images/top2.gif')">
                                            <a href="Training_view_userrequest.aspx">الدورات السابقة</a> </li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li id="LI_Eval_Emp_mng" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">تقييم الأداء </a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_For_Employee.aspx">
                                            تقييم أداء موظف</a></li>
                                        <li id="LI85" runat="server" style="background-image: url('../new_images/top2.gif')">
                                            <a href="../MainForm/Eval_For_Manager.aspx">تقييم أداء مدير</a>
                                            <input type="hidden" runat="server" id="hidden86" value="111" />
                                        </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_Reports.aspx">
                                            تقارير تقييم أداء موظف</a></li>
                                        <%--<li style="background-image: url('../new_images/top2.gif')"><a href="Evaluation_Dept_Weight.aspx">
                                            أوزان العناصر</a></li>--%>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="change_Password.aspx">
                                    تعديل كلمة السر</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="AssMinister" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif'); height: 36px;">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif');"><a href="Default.aspx">
                                    الرئيسية </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="ProjectSearch.aspx">
                                    استعلام عام</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Commission.aspx">
                                    التكليفات</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Commission_Search.aspx">
                                    بحث في التكليفات</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="ProjectReview.aspx">
                                    نشرات التعميم</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Review_search.aspx">
                                    بحث في نشرات التعميم</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Emp_Follow_Search.aspx">
                                    متابعة موظف</a> </li>
                                <li id="LI_Search_Mnstr" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">استعلام عن الوثائق</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="General_Search.aspx">
                                            وثائق عامة</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Connecting_inbox_outbox.aspx">
                                            وارد / صادر</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif');"><a href="Inbox_Search.aspx">
                                            وارد</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif');"><a href="Outbox_Search.aspx">
                                            صادر</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_meetings_search.aspx">
                                            اجتماعات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_presentation_search.aspx">
                                            عروض تقديمية </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_event_search.aspx">
                                            أحداث </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_protocol_search.aspx">
                                            بروتوكولات </a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Main_Search.aspx">
                                    البروتوكولات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="project_followup.aspx">
                                    متابعة المستخدمين على المشروعات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="MMallReports.aspx?type=1">
                                    تقارير</a>
                                    <%--<ul class="newclass">
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="MMallReports.aspx?type=1">
                                            تقارير - ادارات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="MMallReports.aspx?type=2">
                                            تقارير - تصنيفات</a> </li>
                                    </ul>--%>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Add_fav.aspx">إضافة
                                    للمفضلة</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Inbox_Search.aspx">
                                    بحث في الخطابات الواردة</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Outbox_Search.aspx">
                                    بحث في الخطابات الصادرة</a> </li>
                                <li id="LI_Eval_Emp_mnstr" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">تقييم الأداء </a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_For_Employee.aspx">
                                            تقييم أداء موظف</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_Reports.aspx">
                                            تقارير تقييم أداء موظف</a></li>
                                        <%--<li style="background-image: url('../new_images/top2.gif')"><a href="Evaluation_Dept_Weight.aspx">
                                            أوزان العناصر</a></li>--%>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <%-- <li id="LI_Eval_Emp_mnstr" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Eval_For_Employee.aspx">تقيم أداء موظف</a> </li>--%>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="change_Password.aspx">
                                    تعديل كلمة السر</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="ProjManager" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Default.aspx">الرئيسية</a>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Default.aspx?curProj=1">
                                    المشروعات الجارية</a></li>
                                <li style="background-image: url('../new_images/top2.gif')">
                                    <asp:LinkButton ID="LinkButton1" runat="server">البيانات الاساسية للمشروع</asp:LinkButton>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="../MainForm/File_Archive.aspx">
                                    أرشفة الملفات </a>
                                    <input type="hidden" runat="server" id="hidden63" value="110" /></li>
                                <%--<li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    بيانات عامة</a>
                                    <ul class="newclass">
                                         <li style="background-image: url('../new_images/top2.gif')">
                                            <asp:LinkButton ID="LinkButton1" runat="server">البيانات الأساسية للمشروع</asp:LinkButton>
                                        </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Exchange.aspx">
                                            أبواب الصرف</a> </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Objective.aspx">
                                            أهداف المشروع</a> </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Attitudes.aspx">
                                            الموقف التنفيذي للمشروع</a> </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_excution_stages.aspx">
                                            مراحل تنفيذ المشروع</a> </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_success_elements.aspx">
                                            عناصر نجاح المشروع</a> </li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="geographic_scope.aspx">
                                            النطاق الجغرافي للمشروع</a> </li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="project_team.aspx">
                                            فريق العمل</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="proj_classification.aspx">
                                            تصنيف المشروع</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_organizations.aspx?type=1">
                                            الجهات المستفيــدة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_organizations.aspx?type=2">
                                            الجهات المنفذة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Scope_Assumptions_Dlev.aspx?Type=1">
                                            الإفتراضات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Scope_Assumptions_Dlev.aspx?Type=2">
                                            النطاق</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Scope_Assumptions_Dlev.aspx?Type=3">
                                            المخرجات</a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>--%>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            خطط زمنية</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Activities.aspx">
                                    أنشطة المشــــروع</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="ActivitiesEditing.aspx">
                                    تعديل أنشطة المشــــروع </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href=" ActivitiesEditing_Station.aspx">
                                    تحديث موقف متابعة المشــــروع </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Import_From_MPP.aspx">
                                    إستيراد أنشطة المشــــروع</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Indicators_History.aspx">
                                    قياس المؤشرات</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Constraints.aspx">
                                    معوقات المشــــروع</a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            احتياجات المشروع</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Needs.aspx">
                                    طلب احتياجات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Needs_Approvment.aspx">
                                    تصديق احتياجات</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Need_Available.aspx">
                                    إتاحة احتياجات</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Need_Recieve.aspx">
                                    صرف احتياجات</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif');"><a href="javascript: void(0);">
                            أوامر التوريد</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Fin_Work_Order.aspx">
                                    أوامر التوريد</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Fin_Bills.aspx">
                                    فواتير</a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        كريم
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            وثائق المشروع</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Deprt_Documnts.aspx">
                                    وثائق عامة</a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Inbox.aspx">
                                    وارد</a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_Outbox.aspx">
                                    صادر</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_meetings.aspx">
                                    اجتماعات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_event.aspx">
                                    أحداث </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_presentation.aspx">
                                    عروض تقديمية </a></li>
                                <li style="background-image: url('../new_images/top2.gif'); display: none;"><a href="Project_protocol.aspx">
                                    بروتوكولات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Complain.aspx">
                                    المناقضات </a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            بوابة القطاع</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Service_Info.aspx">
                                    كيفية الحصول على الخدمة</a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="project_img_service.aspx">
                                    مكتبة الصور </a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="project_statistics_service.aspx">
                                    الاحصائيات </a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="project_video_service.aspx">
                                    مكتبة الفيديو</a></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            استعلام عن الوثائق</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Search_ALL_Documents.aspx">
                                    بحث عام</a></li>
                                <%-- <li style="background-image: url('../new_images/toptany.gif')"><a href="General_Search.aspx">
                                            وثائق عامة</a></li>--%>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Connecting_inbox_outbox.aspx">
                                    مرتبط وارد / صادر</a></li>
                                <%-- <li style="background-image: url('../new_images/toptany.gif');"><a href="Inbox_Search.aspx">
                                            وارد</a></li>--%>
                                <%-- <li style="background-image: url('../new_images/toptany.gif');"><a href="Outbox_Search.aspx">
                                            صادر</a></li>--%>
                                <%-- <li style="background-image: url('../new_images/toptany.gif')"><a href="Project_meetings_search.aspx">
                                            اجتماعات </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_presentation_search.aspx">
                                            عروض تقديمية </a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Project_event_search.aspx">
                                            أحداث </a></li>--%>
                                <li style="background-image: url('../new_images/top2.gif'); display: none;"><a href="Project_protocol_search.aspx">
                                    بروتوكولات </a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Main_Search.aspx">
                            البروتوكولات </a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="PMallReports.aspx">
                            تقارير </a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="project_End.aspx">
                            إنهاء المشروع</a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="project_Achievements.aspx">
                            إنجازات المشروع</a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                            الأجازات والمأموريات</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/top2.gif')"><a href="vacations.aspx">
                                    الأجازات</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_errand.aspx">
                                    المأموريات</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_DayOff.aspx">
                                    عمل يوم عطلة</a></li>
                                <%--<li style="background-image: url('../new_images/top2.gif')"><a href="vocations_permission.aspx">
                                            إذن</a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>--%>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="Add_fav.aspx">إضافة
                            للمفضلة</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="change_Password.aspx">
                            تعديل كلمة السر</a> </li>
                        <li style="background-image: url('../new_images/bot.gif')"></li>
                    </ul>
                    </li> </ul>
                </div>
                <div id="DataEntry" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Default.aspx">
                                    فئات الوظائف</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Default.aspx?curProj=1">
                                    أنواع الاحتياج الرئيسي</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Needs_Sub_Type_Entry_Screen.aspx">
                                    أنواع الاحتياج الفرعي</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Employee_Entry_Screen.aspx">
                                    موظفيــــــــن</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Organization_Entry_Screen.aspx">
                                    الجهات المستفيده</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="Div_Protocol" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Default.aspx">
                                    الرئيسية</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Def.aspx">
                                    بروتوكولات / اتفاقيات</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Main_Search.aspx">
                                    البحث عن بروتوكولات / اتفاقيات</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Finishing.aspx">
                                    انهاء بروتوكولات / اتفاقيات</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="Div_GFiles" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Default.aspx">
                                    الرئيسية</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="FDocuments.aspx">
                                    ملفات </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="File_Search.aspx">
                                    بحث في ملفات</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Inbox.aspx">
                                    الخطابات الواردة </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Inbox_Search.aspx">
                                    بحث في الخطابات الواردة</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_outbox.aspx">
                                    الخطابات الصادرة </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Outbox_Search.aspx">
                                    بحث في الخطابات الصادرة</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="Div_Usual_User" runat="server">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Default.aspx">الرئيسية</a>
                                </li>
                                <%--  <li style="background-image: url('../new_images/top2.gif')"><a href="Update_proj_data.aspx">
                                    تعديل بيانات المشروعات</a></li>--%>
                                <li id="Li2" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">التدريب</a>
                                    <ul class="newclass">
                                        <li id="li3" runat="server" style="background-image: url('../new_images/top2.gif')">
                                            <a href="Training_ViewUserRegisteredCourses.aspx">دوراتى</a> </li>
                                        <li id="Li4" runat="server" style="background-image: url('../new_images/top2.gif')">
                                            <a href="Training_view_userrequest.aspx">الدورات السابقة</a> </li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    الأجازات والمأموريات</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations.aspx">
                                            الأجازات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_errand.aspx">
                                            المأموريات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_DayOff.aspx">
                                            عمل يوم عطلة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vocations_permission.aspx">
                                            إذن</a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li id="LI_Eval_Emp" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="javascript: void(0);">تقييم الأداء </a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_For_Employee.aspx">
                                            تقييم أداء موظف</a></li>
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_Reports.aspx">
                                            تقارير تقييم أداء موظف</a></li>
                                        <%--<li style="background-image: url('../new_images/top2.gif')"><a href="Evaluation_Dept_Weight.aspx">
                                            أوزان العناصر</a></li>--%>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <%-- <li id="LI_Eval_Emp" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Eval_For_Employee.aspx">تقيم أداء موظف</a> </li>--%>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="change_Password.aspx">
                                    تعديل كلمة السر</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div id="Taha_Div" runat="server" visible="false">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../Images/Extend_Menu.gif')">
                            <ul>
                                <li style="background-image: url('../new_images/toptany.gif');"><a href="Default.aspx">
                                    الرئيسية </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="MMallReports.aspx">
                                    تقارير</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    الأجازات والمأموريات</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations.aspx">
                                            الأجازات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_errand.aspx">
                                            المأموريات</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vacations_DayOff.aspx">
                                            عمل يوم عطلة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="vocations_permission.aspx">
                                            إذن</a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="change_Password.aspx">
                                    تعديل كلمة السر</a> </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>
