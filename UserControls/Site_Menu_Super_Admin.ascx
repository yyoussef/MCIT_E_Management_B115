<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Site_Menu_Admin.ascx.cs" Inherits="UserControls_Site_Menu_Admin" %>

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
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="home.aspx">الرئيسية</a>
                        </li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Content.aspx">
                            إدارة اللأنظمة</a></li>
                        <li style="background-image: url('../new_images/toptany.gif')"><a href="Admin_Module.aspx">
                            تفعيل اللأنظمة</a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="pages.aspx">صفحات
                            النظام </a></li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="Activiates.aspx">
                            ربط الأنظمه بالصفحات</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="Evaluation.aspx">
                            عناصر التقييم الرئيسية للموظفين</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="SubEval.aspx">عناصر
                            التقييم الفرعى للموظفين</a> </li>
                        <li style="background-image: url('../new_images/top2.gif')"><a href="ChangePassword.aspx">
                            تعديل كلمة المرور</a> </li>
                        <li style="background-image: url('../new_images/bot.gif')"></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</div>
