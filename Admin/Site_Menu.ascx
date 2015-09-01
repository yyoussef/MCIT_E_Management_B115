<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Site_Menu.ascx.cs" Inherits="UserControls_Site_Menu" %>

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
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="home.aspx">الرئيسية</a>
                        </li>
                        <li id="Li1" style="background-image: url('../new_images/toptany.gif')" runat="server">
                            <a href="SiteUpload.aspx">اضافة صورة الجهة</a> </li>
                        <%-- <li id="Li5" style="background-image: url('../new_images/toptany.gif')" runat="server">
                            <a href="Admin_Module.aspx">تفعيل الانظمة</a> </li>--%>
                       <%-- <li style="background-image: url('../new_images/toptany.gif')"><a href="Sectors.aspx">
                            بيانات القطاعات</a> </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Add_Dept.aspx">
                            بيانات الإدارات</a> </li>--%>
                            
                            <li style="background-image: url('../new_images/toptany.gif')"><a href="Department_manage.aspx">
                             الهيكل التنظيمي</a> </li>
                               <li style="background-image: url('../new_images/toptany.gif')"><a href="Employee_data.aspx">
                            بيانات الموظفين</a> </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Emp_Search.aspx">
                            بحث عن الموظفين</a> </li>
                            
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Commitee.aspx">
                            بيانات اللجان</a> </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="committee_Presidents.aspx">
                            رؤساء الأقسام و اللجان</a> </li>
                      
                     
                        <li id="Li6" style="background-image: url('../new_images/toptany.gif')" runat="server">
                            <a href="  Add_Org.aspx">مؤسسات متصلة بالجهة</a> </li>
                        <li id="Li133" runat="server" style="background-image: url('../new_images/top2.gif')">
                            <a href="javascript: void(0);">الأرشيف</a>
                            <ul class="newclass">
                                <li id="Li2" style="background-image: url('../new_images/top2.gif')" runat="server">
                                    <a href="Groups.aspx">مجموعات الارشيف</a></li>
                                <li id="Li3" style="background-image: url('../new_images/top2.gif')" runat="server">
                                    <a href="Employees_Group_New.aspx">موظفي مجموعات الارشيف</a> </li>
                                <li style="background-image: url('../new_images/top2.gif')"><a href="EmployeesAndCorrParents.aspx">
                                    الادارة العليا و السكرتارية </a></li>
                                <li style="background-image: url('../new_images/top2.gif')"></li>
                            </ul>
                        </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="AdminUserPage.aspx">
                            صلاحيات المستخدمين</a> </li>
                             <li style="background-image: url('../new_images/toptany.gif')"><a href="Foundations_Followup.aspx">
                            متابعة الجهات</a> </li>
                                <li style="background-image: url('../new_images/toptany.gif')"><a href="Foundation_localconnection.aspx">
                             مسار قاعدة البيانات الداخلية</a> </li>
                            <li style="background-image: url('../new_images/toptany.gif')"><a href="Database_Backup.aspx">
                             نسخة من قاعدة البيانات</a> </li>
                          <li style="background-image: url('../new_images/top2.gif')"><a href="Open_UserManual.aspx">
                            دليل المستخدم</a> </li>

                        <li style="background-image: url('../new_images/top2.gif')"><a href="ChangePassword.aspx">
                            تعديل كلمة المرور</a> </li>
                        <%--<li style="background-image: url('../new_images/menu.png')"></li>--%>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>
