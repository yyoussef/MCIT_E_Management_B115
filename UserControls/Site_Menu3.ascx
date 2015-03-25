<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Site_Menu3.ascx.cs" Inherits="UserControls_Site_Menu" %>

<script type="text/javascript" src="../Script/JScript.js">
  
</script>

<div id="Div_Main" runat="server">
    <%--<table border="0" id="myMenu" class="nav" onmouseover="showmenu()" onmouseout="hidemenu()">--%>
    <table border="0" id="myMenu" class="nav">
        <tr align="center" valign="middle">
            <td align="center" valign="middle">
                <br />
                <br />
                <div id="MangerDepDiv" runat="server">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Default.aspx">
                            الرئيسية</a> </li>
                        <li id="Li2" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="ProjectSearch.aspx">استعلام عام </a>
                            <input type="hidden" runat="server" id="hidden1" value="78" />
                        </li>
                        <li id="Li61" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Default.aspx?curProj=1">المشروعات الجارية</a>
                            <input type="hidden" runat="server" id="hidden64" value="79" />
                        </li>
                        <li id="Li83" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href='<%="ProjectGeneralData.aspx?mode=edit&Proj_id=" + Session_CS.Project_id.ToString()%>' id="ahref" runat="server">
                                البيانات الاساسيه للمشروع</a>
                            <input type="hidden" runat="server" id="hidden71" value="101" />
                        </li>
                        <li id="Li20" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_Info.aspx?mode=fin">ميزانية المشروعات</a>
                            <input type="hidden" runat="server" id="hidden12" value="12" />
                        </li>
                        <li id="Li90" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/Yearbook_report.aspx">الكتاب السنوي للقطاع </a>
                            <input type="hidden" runat="server" id="hidden4" value="502" />
                        </li>
                        <li id="Li62" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="projects.aspx?mode=new">مقترح مشروع جديد</a>
                            <input type="hidden" runat="server" id="hidden65" value="80" />
                        </li>
                        <li id="Li63" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="ProjectSearch.aspx?mode=edit">تعديل مقترح مشروع</a>
                            <input type="hidden" runat="server" id="hidden66" value="81" />
                        </li>
                        <li id="Li64" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_priority.aspx">أولوية مقترح مشروع</a>
                            <input type="hidden" runat="server" id="hidden67" value="82" />
                        </li>
                        <li id="Li65" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Deprt_Documnts.aspx">وثائق عامة</a>
                            <input type="hidden" runat="server" id="hidden68" value="83" />
                        </li>
                        <li id="Li69" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">خطط زمنية</a>
                            <input type="hidden" runat="server" id="hidden72" value="87" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Project_Activities.aspx">
                                    أنشطة المشــــروع</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="../MainForm/ProjectActivities.aspx">
                                    تعديل أنشطة المشــــروع </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Planning_Stages.aspx">
                                    أنشطة مراحل المشـــروع</a></li>
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
                        <li id="Li70" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">احتياجات المشروع</a>
                            <input type="hidden" runat="server" id="hidden73" value="88" />
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
                        <li id="Li133" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">أوامر التوريد</a>
                            <input type="hidden" runat="server" id="hidden10" value="10" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Fin_Work_Order.aspx">
                                    أوامر التوريد</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Fin_Bills.aspx">
                                    فواتير</a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="Li66" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">وثائق</a>
                            <input type="hidden" runat="server" id="hidden69" value="84" />
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
                        <li id="Li67" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">استعلام عن الوثائق</a>
                            <input type="hidden" runat="server" id="hidden70" value="86" />
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
                        <li id="Li71" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">بوابة القطاع</a>
                            <input type="hidden" runat="server" id="hidden74" value="89" />
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
                        <li id="Li72" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">استعلام عن الوثائق</a>
                            <input type="hidden" runat="server" id="hidden75" value="90" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Search_ALL_Documents.aspx">
                                    بحث عام</a></li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Connecting_inbox_outbox.aspx">
                                    مرتبط وارد / صادر</a></li>
                                <li style="background-image: url('../new_images/top2.gif'); display: none;"><a href="Project_protocol_search.aspx">
                                    بروتوكولات </a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="Li73" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="PMallReports.aspx">تقارير </a>
                            <input type="hidden" runat="server" id="hidden76" value="91" />
                        </li>
                        <li id="Li74" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="project_End.aspx">إنهاء المشروع </a>
                            <input type="hidden" runat="server" id="hidden77" value="92" />
                        </li>
                        <li id="Li75" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="project_Achievements.aspx">إنجازات المشروع </a>
                            <input type="hidden" runat="server" id="hidden78" value="93" />
                        </li>
                        .
                        <li id="Li76" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Default.aspx">فئات الوظائف </a>
                            <input type="hidden" runat="server" id="hidden79" value="94" />
                        </li>
                        <li id="Li77" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/Main_Needs_Type_Entry_Screen.aspx">أنواع الاحتياج الرئيسي </a>
                            <input type="hidden" runat="server" id="hidden80" value="95" />
                        </li>
                        <li id="Li78" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Needs_Sub_Type_Entry_Screen.aspx">أنواع الاحتياج الفرعي </a>
                            <input type="hidden" runat="server" id="hidden81" value="96" />
                        </li>
                        <%--  <li id="Li79" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Employee_Entry_Screen.aspx">موظفيــــــــن </a>
                            <input type="hidden" runat="server" id="hidden82" value="97" />
                        </li>--%>
                        <li id="Li80" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Organization_Entry_Screen.aspx">الجهات المستفيده </a>
                            <input type="hidden" runat="server" id="hidden83" value="98" />
                        </li>
                        <li id="Li81" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="DepartmentmngallReports.aspx">تقارير </a>
                            <input type="hidden" runat="server" id="hidden84" value="99" />
                        </li>
                        <li id="Li60" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="FDocuments.aspx">ملفات </a>
                            <input type="hidden" runat="server" id="hidden63" value="1" />
                        </li>
                        <%-- <li id="Li84" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/File_Archive.aspx">أرشفة الملفات </a>
                            <input type="hidden" runat="server" id="hidden85" value="110" />
                        </li>--%>
                        <li id="Li18" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="File_Search.aspx">بحث في ملفات</a>
                            <input type="hidden" runat="server" id="hidden2" value="2" />
                        </li>
                        <li id="Li17" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_Inbox.aspx">الخطابات الواردة </a>
                            <input type="hidden" runat="server" id="hidden3" value="3" />
                        </li>
                        <li id="Li16" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="Inbox_Search.aspx">بحث في الخطابات الواردة</a>
                            <%--<input type="hidden" runat="server" id="hidden4" value="4" />--%>
                        </li>
                        <li id="Li88" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Inbox_Search_pm.aspx">بحث في الخطابات -إدارة عليا</a>
                            <input type="hidden" runat="server" id="hidden433" value="500" />
                        </li>
                        <li id="Li89" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Default_HM.aspx">اشعارات -إدارة عليا</a>
                            <input type="hidden" runat="server" id="hidden4336" value="400" />
                        </li>
                        <li id="Li15" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/Project_Outbox.aspx">الخطابات الصادرة </a>
                            <input type="hidden" runat="server" id="hidden5" value="5" />
                        </li>
                        <li id="Li14" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="Outbox_Search.aspx">بحث في الخطابات الصادرة</a>
                            <%--<input type="hidden" runat="server" id="hidden6" value="6" />--%>
                        </li>
                        <li id="Li36" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Commission.aspx">التكليفات </a>
                            <input type="hidden" runat="server" id="hidden40" value="50" />
                        </li>
                        <li id="Li37" runat="server"  style="background-image: url('../new_images/top2.gif')">
                            <a href="Commission_Search.aspx">بحث في التكليفات </a>
                            <%--<input type="hidden" runat="server" id="hidden41" value="51" />--%>
                        </li>
                        <li id="Li45" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="ProjectReview.aspx">نشرات التعميم </a>
                            <input type="hidden" runat="server" id="hidden48" value="62" />
                        </li>
                        <li id="Li53" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Review_Search.aspx">بحث في نشرات التعميم </a>
                            <input type="hidden" runat="server" id="hidden57" value="63" />
                        </li>
                        <li id="Li54" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="change_proj_status.aspx">تعديل حالة المشروع </a>
                            <input type="hidden" runat="server" id="hidden43" value="64" />
                        </li>
                        <li id="Li13" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocol_Def.aspx">بروتوكولات / اتفاقيات</a>
                            <input type="hidden" runat="server" id="hidden7" value="7" />
                        </li>
                        <li id="Li11" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocole_Search.aspx">البحث عن بروتوكولات / اتفاقيات</a>
                            <input type="hidden" runat="server" id="hidden8" value="8" />
                        </li>
                        <li id="Li25" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocol_Project_Search.aspx">البحث عن مشروعات الاتفاقية </a>
                            <input type="hidden" runat="server" id="hidden28" value="28" />
                        </li>
                        <li id="Li12" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocol_Finishing.aspx">انهاء بروتوكولات / اتفاقيات</a>
                            <input type="hidden" runat="server" id="hidden9" value="9" />
                        </li>
                        <li id="Li32" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Update_proj_data.aspx">ادارة بيانات المشروعات</a>
                            <input type="hidden" runat="server" id="hidden37" value="38" />
                        </li>
                        <li id="Lir122" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_Activities.aspx">أنشطة المشــــروع</a>
                            <input type="hidden" runat="server" id="hidden11" value="11" />
                        </li>
                        <%--  <li id="Li122" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Emp_ADD.aspx">إضافة موظف</a>
                            <input type="hidden" runat="server" id="hidden13" value="13" />
                        </li>--%>
                        <li id="Li3" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_Inbox_Minister.aspx">تأشيرة الوزير </a>
                            <input type="hidden" runat="server" id="hidden14" value="14" />
                        </li>
                        <li id="Li1" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Inbox_Minister_Search.aspx">بحث في تأشيرة الوزير</a>
                            <input type="hidden" runat="server" id="hidden15" value="15" />
                        </li>
                        <li id="Li27" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Emp_Follow_Search.aspx">متابعة موظف</a>
                            <input type="hidden" runat="server" id="hidden30" value="32" />
                        </li>
                        <li id="Li38" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="project_followup.aspx">متابعة المستخدمين على المشروعات</a>
                            <input type="hidden" runat="server" id="hidden45" value="44" />
                        </li>
                        <li id="Li5" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Clear_Organization.aspx">تصحيح الجهات</a>
                            <input type="hidden" runat="server" id="hidden17" value="17" />
                        </li>
                        <li id="Li19" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Connecting_inbox_outbox.aspx">المرتبط</a>
                            <input type="hidden" runat="server" id="hidden25" value="25" />
                        </li>
                        <li id="Li26" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Connecting_InIR_OutIR.aspx">المرتبط</a>
                            <input type="hidden" runat="server" id="hidden29" value="30" />
                        </li>
                        <li id="Li8" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Inbox_Minister_Search_without_edit.aspx">بحث في تأشيرة الوزير</a>
                            <input type="hidden" runat="server" id="hidden20" value="20" />
                        </li>
                        <li id="Li9" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Business_Card_System.aspx">بطاقات العمل</a>
                            <input type="hidden" runat="server" id="hidden21" value="21" />
                        </li>
                        <li id="Li28" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">أوامر التوريد</a>
                            <input type="hidden" runat="server" id="hidden31" value="31" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Agreement_Work_Order.aspx">
                                    أوامر التوريد</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Agreement_Bills.aspx">
                                    فواتير </a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="Li4" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">البروتوكولات</a>
                            <input type="hidden" runat="server" id="hidden16" value="16" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Protocol_Main.aspx">
                                    إضافة بروتوكول</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Protocol_Main_Search.aspx">
                                    بحث عن بروتوكول</a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="Li21" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocols_Reports.aspx">تقارير البروتوكولات </a>
                            <input type="hidden" runat="server" id="hidden23" value="23" />
                        </li>
                        <li id="Li34" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Protocol_Main_Search.aspx">بحث عن بروتوكول </a>
                            <input type="hidden" runat="server" id="hidden38" value="42" />
                        </li>
                        <li id="Li29" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">التصنيفات</a>
                            <input type="hidden" runat="server" id="hidden32" value="29" />
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Adding_Inbox_Main_Categories.aspx">
                                    اضافة تصنيف رئيسى</a></li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="Adding_Inbox_Sub_Categories.aspx">
                                    اضافة تصنيف فرعى</a></li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="Li10" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project.aspx">وثيقة مشروع</a>
                            <input type="hidden" runat="server" id="hidden22" value="22" />
                        </li>
                        <%--<li id="Li23" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="MMallReports.aspx">تقارير</a>
                                    <input type="hidden" runat="server" id="hidden26" value="26" />
                                </li>--%>
                        <li id="Li30" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="IR_Reports.aspx">تقارير-متابعة موظفين</a>
                            <input type="hidden" runat="server" id="hidden33" value="33" />
                        </li>
                        <li id="Li6" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/Archiving_Report.aspx">تقارير-الأرشيف الالكتروني </a>
                            <input type="hidden" runat="server" id="hidden18" value="123" />
                        </li>
                        <%-- <li id="Li32" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="IR_Reports.aspx">تقارير</a>
                                    <input type="hidden" runat="server" id="hidden35" value="33" />
                                </li>--%>
                        <li id="Li33" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="MMallReports.aspx">تقارير</a>
                            <input type="hidden" runat="server" id="hidden36" value="35" />
                        </li>
                        <li id="Li23" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="Add_fav.aspx">إضافة للمفضلة</a>
                            <%--<input type="hidden" runat="server" id="hidden26" value="36" />--%>
                        </li>
                        <%-- <li style="background-image: url('../new_images/top2.gif')"><a href="javascript: void(0);">
                                    وثائق عامة</a>
                                    <ul class="newclass">
                                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Deprt_Documnts.aspx">
                                            إضافة وثيقة</a></li>
                                        <li style="background-image: url('../new_images/top2.gif')"><a href="Deprt_Documnts_Search.aspx">
                                            بحث عن وثيقة</a></li>
                                        <li style="background-image: url('../new_images/bot.gif')"></li>
                                    </ul>
                                </li>--%>
                        <%--<li id="Li22" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Vacation_Mng_ALL_User.aspx">إدخال أرصدة الأجازات</a>
                                    <input type="hidden" runat="server" id="hidden24" value="24" />
                                </li> --%>
                        <li id="Li35" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Clear_Organization.aspx">إضافة جهة جديدة</a>
                            <input type="hidden" runat="server" id="hidden39" value="41" />
                        </li>
                        <li id="Li52" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Evaluation_Dept_Weight.aspx">أوزان عناصر تقييم أداء</a>
                            <input type="hidden" runat="server" id="hidden44" value="52" />
                        </li>
                        <li id="Li7" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Evaluation_Main_Items.aspx">عناصر التقييم الرئيسية</a>
                            <input type="hidden" runat="server" id="hidden13" value="125" />
                        </li>
                        <li id="Li44" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Evaluation_Sub_Items.aspx">عناصر التقييم الفرعية</a>
                            <input type="hidden" runat="server" id="hidden19" value="126" />
                        </li>
                        <li id="Li68" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Evaluation_MainItems_Manager.aspx">عناصر التقييم الرئيسية للمديرين</a>
                            <input type="hidden" runat="server" id="hidden56" value="127" />
                        </li>
                        <li id="Li79" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Evaluation_SubItems_Manager.aspx">عناصر التقييم الفرعية للمديرين</a>
                            <input type="hidden" runat="server" id="hidden82" value="128" />
                        </li>
                        <li id="Li47" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="sector_view.aspx">عرض القطاعات</a>
                            <input type="hidden" runat="server" id="hidden49" value="55" />
                        </li>
                        <li id="Li49" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Sector_save_update.aspx">إضافه قطاع</a>
                            <input type="hidden" runat="server" id="hidden51" value="57" />
                        </li>
                        <li id="Li48" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Department_View.aspx">عرض الاقسام</a>
                            <input type="hidden" runat="server" id="hidden50" value="56" />
                        </li>
                        <li id="Li50" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Department_Save_Update.aspx">إضافه قسم</a>
                            <input type="hidden" runat="server" id="hidden52" value="58" />
                        </li>
                        <li id="LI39" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href=" Employee_data.aspx">بيانات الموظفين</a>
                            <input type="hidden" runat="server" id="hidden46" value="45" />
                        </li>
                        <li id="LI51" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="emp_search.aspx">بحث عن بيانات موظف </a>
                            <input type="hidden" runat="server" id="hidden86" value="120" />
                        </li>
                        <%-- <li id="LI_Eval_Emp" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Eval_For_Employee.aspx">تقييم أداء موظف</a>
                                    <input type="hidden" runat="server" id="hidden42" value="43" />
                                </li>
                                <li id="LI85" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="../MainForm/Eval_For_Manager.aspx">تقييم أداء مدير</a>
                                    <input type="hidden" runat="server" id="hidden86" value="111" />
                                    </li>--%>
                        <li id="LI_Eval_Emp_Report" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Eval_Reports.aspx">تقارير تقييم الأداء</a>
                            <input type="hidden" runat="server" id="hidden_rep" value="46" />
                        </li>
                        <li id="LI40" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Project_Activities_Months.aspx">شهور تنفيذ خطة المشروع</a>
                            <input type="hidden" runat="server" id="hidden47" value="53" />
                        </li>
                        <li id="Li41" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">ادارة التدريب </a>
                            <input type="hidden" runat="server" id="hidden42" value="121" />
                            <ul class="newclass">
                                <li id="li56" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Course_Programs.aspx">تسجيل بيانات البرامج</a>
                                    <input type="hidden" runat="server" id="hidden59" value="73" />
                                </li>
                                <li id="li59" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Course_Programs_Link.aspx">تسجيل أسماء الدورات</a>
                                    <input type="hidden" runat="server" id="hidden62" value="76" />
                                </li>
                                <li id="li91" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="../MainForm/Training_PlanReports.aspx">تقارير الخطة التدريبية </a>
                                    <input type="hidden" runat="server" id="hidden6" value="503" />
                                </li>
                                <li id="li57" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Course_Tracks.aspx">مسارات الدورات التدريبية</a>
                                    <input type="hidden" runat="server" id="hidden60" value="74" />
                                </li>
                                <li id="li43" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_Add_NewCourse.aspx?type=1">إضافة الدورات التدريبية </a>
                                    <input type="hidden" runat="server" id="hidden54" value="60" />
                                </li>
                                <li id="li42" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Trainig_ViewAllCourses.aspx">إدارة الدورات التدريبية</a>
                                    <input type="hidden" runat="server" id="hidden53" value="59" />
                                </li>
                                <li id="li58" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Course_Places.aspx">اماكن إنعقاد الدورات التدريبية</a>
                                    <input type="hidden" runat="server" id="hidden61" value="75" />
                                </li>
                                <li id="li46" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_adminapprove.aspx?type=1">الموافقة النهائية على المتدريبين </a>
                                    <input type="hidden" runat="server" id="hidden55" value="61" />
                                </li>
                                <li id="li55" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_Results.aspx">تسجيل نتائج الدورات</a>
                                    <input type="hidden" runat="server" id="hidden58" value="70" />
                                </li>
                                <li id="li82" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_Reports.aspx">التقارير</a>
                                    <input type="hidden" runat="server" id="hidden87" value="70" />
                                </li>
                            </ul>
                        </li>
                        <%--<li id="li44" visible="false" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="Training_Reports.aspx">التقارير </a>
                            <input type="hidden" runat="server" id="hidden56" value="54" />
                        </li>--%>
                        <li id="Li22" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="vacations_Reports.aspx">تقارير-أجازات</a>
                            <input type="hidden" runat="server" id="hidden24" value="27" />
                        </li>
                        <li id="Li24" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Vacation_Mng_ALL_User_Summery.aspx">إدخال إجمالى أرصدة الأجازات</a>
                            <input type="hidden" runat="server" id="hidden27" value="24" />
                        </li>
                        <li id="Li31" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Mng_Vacation.aspx">إدارة الأجازات والمأموريات</a>
                            <input type="hidden" runat="server" id="hidden35" value="37" />
                        </li>
                        <li id="Mod_Training_10" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">التدريب</a>
                            <ul class="newclass">
                                <li id="li87" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_ViewUserRegisteredCourses.aspx">دوراتى</a> </li>
                                <li id="Li96" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="Training_view_userrequest.aspx">الدورات السابقة </a></li>
                            </ul>
                        </li>
                       
                        
                        <li id="Mod_Evaluation_11" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">تقييم الأداء</a>
                            <%--  <input type="hidden" runat="server" id="hidden71" value="85" />--%>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_For_Employee.aspx">
                                    تقييم أداء موظف</a></li>

                                <%-- <li style="background-image: url('../new_images/toptany.gif')"><a href="Eval_Reports.aspx">
                                    تقارير تقييم أداء موظف</a></li>--%>
                                <li id="LI85" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="../MainForm/Eval_For_Manager.aspx">تقييم أداء مدير</a> </li>
                                 <%--     <li style="background-image: url('../new_images/top2.gif')"><a href="../MainForm/Eval_Report_Manager.aspx">
                             تقرير تقييم الأداء الوظيفي</a> </li> --%>
                            </ul>
                        </li>
                        <li id="Mod_Vacation_9" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">الأجازات والمأموريات</a>
                            <input type="hidden" runat="server" id="hidden34" value="40" />
                            <ul class="newclass">
                                <li id="lip" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="vacations.aspx">الأجازات</a> </li>
                                <li id="lip2" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="vacations_errand.aspx">المأموريات</a> </li>
                                <li id="lip3" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="vacations_DayOff.aspx">عمل يوم عطلة</a> </li>
                                <li id="li_perm" runat="server" style="background-image: url('../new_images/top2.gif')">
                                    <a href="vocations_permission.aspx">إذن </a></li>
                                <li id="Li313" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                                    <a href="vacations_Reports2.aspx">تقارير</a>
                                    <input type="hidden" runat="server" id="hidden344" value="34" />
                                </li>
                                <li style="background-image: url('../new_images/bot.gif')"></li>
                            </ul>
                        </li>
                        <li id="li86" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <input type="hidden" runat="server" id="hidden88" value="136" />
                            <a href="../MainForm/Memo_Upload.aspx">إدارة مذكرات العرض</a> </li>
                        <li id="Li84" runat="server" visible="false" style="background-image: url('../new_images/top2.gif')">
                            <a href="Add_Org.aspx">مؤسسات متصلة بالجهة</a>
                            <input type="hidden" runat="server" id="hidden85" value="132" />
                        </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="../MainForm/Training_Plan.aspx">
                            الإحتياجات التدريبية</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="Open_UserManual.aspx">
                            دليل المستخدم</a> </li>
                        <li id="li_doc_Show" runat="server" visible="true" style="background-image: url('../new_images/top2.gif')">
                            <a href="../MainForm/Memo_Show.aspx">مذكرات عرض</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="AboutSystem.aspx">
                            عن النظام</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="ChangePassword.aspx">
                            تعديل كلمة المرور</a> </li>
                        <li style="background-image: url('../new_images/bot.gif')"></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>
