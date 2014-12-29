<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="AboutSystem.aspx.cs" Inherits="MainForm_AboutSystem" Title="عن النظام  " %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="نظام إدارة الارشيف الالكترونى نسخة 4.0" />
            </td>
        </tr>
        <%--<tr>
            <td align="center" style="height: 5px">
                &nbsp;
            </td>
        </tr>--%>
        <tr>
            <td style="text-align: right">
                <%--<asp:Label ID="Label27" runat="server" CssClass="Label" Text="تعتمد آلية العمل في هذا النظام على وجود شخص مسئول مكلف من داخل كل ادارة مسئول بإدخال البيانات المطلوبة وتوثيق كافة الاوراق بعد ان يتم عمل مسح ضوئي لها، وتعيين اسم مستخدم لكل موظف داخل الادارة للتعرف على المهام الموكلة اليه من رئيسه ومتابعة تلك المهام ومتابعة تقديم اجازاته ومأمورياته بشكل يتيح له رصد كل ما يخصه من شئون داخل ادارته.
كانت للإدارة المركزية للاستشارات الفنية وتطوير النظم والتابعة لقطاع البنية المعلوماتية الشرف في بناء وتطوير هذا النظام على مدار سنوات من العمل الجاد والشاق، حيث ساهمت الادارة من خلال كوادر من المهندسين المؤهلين على مستوى عال من الكفاءة في توفير كافة الأدوات اللازمة للعمل بهذا النظام.
">
                              
                </asp:Label>--%>
                <span style="font-family: Arial; font-weight: bold; font-size: 18px; color: #1F4569;
                    margin-left: 3px;">
                    <br />
                    هذا النظام نتاج مجهود تم من خلال الإدارة المركزية للاستشارات الفنية وتطوير النظم
                    التابعة لقطاع البنية المعلوماتية بوزارة الاتصالات وتكنولوجيا المعلومات على مدار
                    سنوات من العمل الجاد والشاق، حيث ساهمت الادارة من خلال كوادر من المهندسين المؤهلين
                    على مستوى عال من الكفاءة في توفير كافة الأدوات اللازمة للعمل بهذا النظام.<br />
                    <br />
                    <span style="font-size: 25px;">ويهدف نظام متابعة الاعمال الى:<br />
                    </span>- متابعة أعمال المشروعات<br />
                    - استخراج التقارير والإحصائيات لدعم اتخاذ القرار
                    <br />
                    - ميكنة دورات الأعمال<br />
                    - أرشفة المكاتبات ووثائق المشروعات<br />
                    - إحكام الرقابة المالية على المشروعات ومتابعة المنصرف وأوامر التوريد
                    <br />
                    <br />
                    ويتكون نظام متابعة الأعمال مما يلي:<br />
                    1- نظام إدارة المشروعات<br />
                    - متابعة البروتوكولات وربطها بالمشروعات<br />
                    - متابعة المشروعات (الخطط الزمنية ونسبة الانجاز والمعوقات)<br />
                    - أرشفة وثائقية<br />
                    - استعلام عن موقف المشروع وبياناته الأساسية<br />
                    - استخراج التقارير والإحصائيات<br />
                    2- الأرشيف الالكتروني والتكليفات<br />
                    - متابعة المراسلات<br />
                    - متابعة التأشيرات والتكليفات<br />
                    - التكامل مع البريد الالكتروني<br />
                    - أرشفة وثائقية<br />
                    - مسير المراسلات<br />
                    3- الاتفاقيات<br />
                    - متابعة الاتفاقيات<br />
                    - أرشفة وثائقية<br />
                    - الاستعلام عن الاتفاقيات<br />
                    - استخراج التقارير والإحصائيات<br />
                    4- الإجازات والمأموريات<br />
                    - تسجيل طلب الإجازات أو مأموريات<br />
                    - متابعة موقف الإجازة (قبول – رفض – لم تنظر)<br />
                    - الاستعلام عن رصيد الإجازات<br />
                    - استخراج التقارير والإحصائيات<br />
                    5- نظام متابعة احتياجات المشروعات<br />
                    - تسجيل دورة الاحتياجات (طلب – تصديق – إتاحة – صرف)<br />
                    - استعلام عن موقف الطلبات<br />
                    - استخراج التقارير والإحصائيات<br />
                    6- النظام المالي ومتابعة المنصرف<br />
                    - متابعة الموقف المالي للمشروعات (موازنة – اتفاقيات – بروتوكولات – مناقصات)<br />
                    - استخراج التقارير المالية<br />
                    <br />
                    ونتقدم بخالص الشكر والتقدير لكل القائمين على هذا النظام، ونخص بالشكر والتقدير السيد
                    الاستاذ الدكتور/ هشام الديب المشرف العام علي قطاع البنية المعلوماتية على توجيهاته
                    وإرشاداته ليخرج هذا النظام على شاكلته كما هو الآن.<br />
                    <br />
                    ونتقدم بالشكر لفريق عمل الإدارة المركزية للاستشارات الفنية وتطوير النظم وعلى رأسها
                    :
                    <br />
                </span>
            </td>
        </tr>
    </table>
    <table style="width: 100%" border="1px">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="د/ أحمد فرج ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="مدير الادارة المركزية للاستشارات الفنية وتطوير النظم ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="م/ مني درويش  ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="مدير إدارة  ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="م/ هالة إمام  ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="مدير إدارة  ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="م/ يوسف أحمد   ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" CssClass="Label" Text="مدير مشروع   ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="م/ أحمد رزق ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="مدير 
                                مشروع   ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="م/ مصطفي عبد المالك ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="مدير مشروع   ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="م/ معتز عبد اللطيف ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="مهندس برمجيات ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="م/ حفص درويش  ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="مهندس برمجيات  ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="م/ محمد الشاهد  ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="مهندس برمجيات ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" CssClass="Label" Text="م/ نورا محمد احمد   ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="مهندس برمجيات ">
                              
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label25" runat="server" CssClass="Label" Text="م/  أسامة أحمد علي  ">
                              
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="Label26" runat="server" CssClass="Label" Text="مهندس برمجيات ">
                              
                </asp:Label>
            </td>
        </tr>
    </table>
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td style="text-align: right">
                <span style="font-family: Arial; font-weight: bold; font-size: 18px; color: #1F4569;
                    margin-left: 3px;">
                    <br />
                    كما نخص بالشكر كل من قدم وشارك باقتراحات فى النظام وعلى سبيل الذكر وليس الحصر ا/نيفين
                    نصرت الرفاعي عبد الله مكتب مساعد أول وزير وا/محمد عيد مكتب د/هشام الديب و م/عصام زغلول مدير ادارة التخطيط
                    والمتابعة
                    <br />
                    <br />
                </span>
            </td>
        </tr>
    </table>
</asp:Content>
