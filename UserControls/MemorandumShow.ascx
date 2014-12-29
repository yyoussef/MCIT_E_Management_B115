<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemorandumShow.ascx.cs"
    Inherits="UserControls_MemorandumShow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="مذكرات عرض" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
            <asp:DropDownList ID="Drop_arabic_doc" Width="700px" runat="server" CssClass="drop">
                <asp:ListItem Text="اختر مذكرة ...." Value="0"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير لتقييم كراسة" Value="1"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير بالقيمة التقديرية لكراسة " Value="2"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير بالتامين الابتدائي" Value="3"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير بالاعلان" Value="4"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على وكيل الوزارة بتشكيل لجنة البت" Value="5"></asp:ListItem>
                <asp:ListItem Text="استمارة صرف مخازن " Value="6"></asp:ListItem>
                <asp:ListItem Text="فاكس من مدير ادارة الى السيد المشرف على قطاع البنية الأساسية للاتصالات "
                    Value="7"></asp:ListItem>
                <asp:ListItem Text="فاكس من مدير ادارة الى رئيس الادارة المركزية للشئون الهندسية"
                    Value="8"></asp:ListItem>
                <asp:ListItem Text="فاكس من مدير ادارة لمسئول بجهة خارجية " Value="9"></asp:ListItem>
                <asp:ListItem Text="فاكس من مكتب رئاسة القطاع لمساعد وزير" Value="10"></asp:ListItem>
                <asp:ListItem Text="فاكس من مكتب رئيس القطاع الى السيد المشرف على قطاع البنية الأساسية للاتصالات"
                    Value="11"></asp:ListItem>
                <asp:ListItem Text="فاكس من مكتب رئيس القطاع الى رئيس الادارة المركزية للشئون الهندسية"
                    Value="12"></asp:ListItem>
                <asp:ListItem Text="مذكرة الوزير لطرح كراسة" Value="13"></asp:ListItem>
                <asp:ListItem Text="مذكرة داخلية من مدير ادارة الى رئيس القطاع" Value="14"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير -   من مكتب رئاسة القطاع لشرح موقف تنفيذي لمشروع "
                    Value="15"></asp:ListItem>
                <asp:ListItem Text="مذكرة عرض على الوزير لتوقيع بروتوكولات" Value="16"></asp:ListItem>
                 <asp:ListItem Text="نموذج التقرير الفني للجنة البت لمشروع" Value="17"></asp:ListItem>
                 
                  <asp:ListItem Text="نموذج الكميات المطلوب توفيرها من الاجهزة والشبكات ويرفق بخطاب للمهندس رأفت هندي" Value="18"></asp:ListItem>
                   <asp:ListItem Text="TOR نموذج" Value="19"></asp:ListItem>
                    <asp:ListItem Text="نموذج مذكرة بدلات سفر" Value="20"></asp:ListItem>
                    
                     <asp:ListItem Text="محضر بإنهاء وغلق مشروع" Value="21"></asp:ListItem>
                     
                       <asp:ListItem Text="تقرير مالي فني- لمناقصة " Value="22"></asp:ListItem>
                         <asp:ListItem Text="مذكرة عرض على المهندس ايمن صادق بشان لجنة البت والترسية" Value="23"></asp:ListItem>
                       <asp:ListItem Text="خطوات اعمال طرح كراسة الشروط والمواصفات" Value="24"></asp:ListItem>
                      <asp:ListItem Text="مذكرة عرض علي مساعد أول الوزير" Value="25"></asp:ListItem>
                     <asp:ListItem Text="مذكرة لمدير الشئون المالية بالوزارة" Value="26"></asp:ListItem>
                       <asp:ListItem Text="مذكرة عرض علي رئيس القطاع للسفر إلي المحافظات " Value="27"></asp:ListItem>
                       
                            <asp:ListItem Text="  نموذج التقديم لدورة تدريبية " Value="28"></asp:ListItem>
                <%--<asp:ListItem Text="مذكرة عرض على د. هشام الديب - المشرف على القطاع " Value="17"></asp:ListItem>--%>
                <%--<asp:ListItem Text="نموذج مذكرة وزير " Value="10"></asp:ListItem>--%>
                <%--<asp:ListItem Text="نموذج خطاب" Value="3"></asp:ListItem>--%>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
            <asp:Button runat="server" CssClass="Button" Text="عرض" ID="btn_arabic_doc" OnClick="btn_arabic_doc_Click" />
        </td>
    </tr>
</table>
