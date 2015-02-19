<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Site_Menu_Admin.ascx.cs"
    Inherits="UserControls_Site_Menu_Admin" %>

<script type="text/javascript" src="../Script/JScript.js">
  
</script>

<div id="Div_Main" runat="server">
    <table border="0" id="myMenu" class="nav">
        <tr align="center" valign="middle">
            <td align="center" valign="middle">
                <br />
                <br />
                <div id="MangerDepDiv" runat="server">
                    <ul id="verticalmenu" class="glossymenu">
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/Home.aspx">
                            الرئيسية</a> </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/Foundations_new.aspx">
                            بيانات الجهات </a></li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/AdminUsers_Add.aspx">
                            مديري الأنظمة </a></li>
                        <%--<li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/Content.aspx">
                            إدارة اللأنظمة</a></li>--%>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/Admin_Module.aspx">
                            تفعيل اللأنظمة</a></li>
                       <%-- <li style="background-image: url('../new_images/top2.gif')"><a href="../SuperAdmin/pages.aspx">
                            صفحات النظام </a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="../SuperAdmin/Activiates.aspx">
                            ربط الأنظمه بالصفحات</a> </li>--%>
                            
                             <li id="Li5" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">المشروعات</a>
                            <ul class="newclass">
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="change_proj_status.aspx">
                                    تعديل حالة المشروع</a> </li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Update_proj_data.aspx">
                                    ادارة بيانات المشروع</a> </li>
                                <li id="Li4" style="background-image: url('../new_images/toptany.gif')" runat="server">
                                    <a href="Employee_Depts.aspx">تحديد الادارات التابعة للمدير العام</a> </li>
                            </ul>
                        </li>
                     <li style="background-image: url('../new_images/toptany.gif')"><a href="../SuperAdmin/Foundations_Followup.aspx">
                            متابعة الجهات</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="../SuperAdmin/ChangePassword.aspx">
                            تعديل كلمة المرور</a> </li>
                        <li style="background-image: url('../new_images/bot.gif')"></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>
