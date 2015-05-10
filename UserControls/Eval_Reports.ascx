<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Eval_Reports.ascx.cs"
    Inherits="UserControls_Eval_Reports" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    function ChangeMeCase(divid, imgid) {

        var divname = document.getElementById(divid);
        var img = document.getElementById(imgid);

        var imgsrc = img.src;


        if (imgsrc.lastIndexOf('collapse') != -1) {
            img.src = "../Images/expand.gif";
        }
        else {
            img.src = "../Images/collapse.gif";
        }

        divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
    }
    


</script>





<%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
<table style="width: 51%; display: block; height: 238px; line-height: 2;" id="tbl_Report"
    runat="server">
    <tr>
        <td height="30px" align="center">
            <input type="hidden" runat="server" id="hidden_Rpt_Id" />
            <input type="hidden" runat="server" id="hidden_manager" />
            <asp:Label ID="Label1" runat="server" Text="تقارير  " CssClass="PageTitle" Font-Underline="True"></asp:Label>
        </td>
    </tr>
    <tr runat="server" id="tr_empeval">
        <td id="Td2" valign="top" align="right">
            <table id="Table1" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                <tr id="Tr2" bgcolor="#E6F3FF" runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img1" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                        colspan="2">
        تقارير تقييم موظف
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Tr1" runat="server">
        <td style="width: 288px">
            <div id="div1" style="display: block; width: 493px;">
                <table style="line-height: 2; width: 121%">
                    <tr id="tr_empevalfunc" runat="server" >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_empLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_empLB_Click">  تقييم الأداء الوظيفي</asp:LinkButton>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_groupedLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_groupedLB_Click">  تقييم الأداء الوظيفي مجمع بالقيم</asp:LinkButton>
                        </td>
                    </tr>--%>
               
                    <tr id="tr_empevaltot" runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right"   />
                            <asp:LinkButton ID="eval_statusLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_statusLB_Click"  > الموظفين ما تم تقييمهم وما لم يتم تقييمهم</asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_empevalfunc2" runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="direct_mng_finishedLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_empevalfunc3" runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="top_mng_finishedLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المدير الاعلي</asp:LinkButton>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="dept_empLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="dept_empLB_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr id="tr_empevalfunc4" runat="server">
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_statisticsLB_Click">إحصائية بموقف تقييم موظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين الأعلى</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%--  <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Dept_Emp_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%-- <tr >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_strengthLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_strengthLB_Click">التقييم بتحديد نقاط القوة و الضعف</asp:LinkButton>
                        </td>
                    </tr>
                    <tr  >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_needsLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_needsLB_Click">التقييم بتحديد الاحتياجات التدريبية</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                            &nbsp;</td>
                         <td style="height: 30px">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="emplDataLinkButton" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_dept_sector_Click">بيانات جميع الموظفين</asp:LinkButton>
                        </td>
                    </tr>--%>
                    </table>
            </div>
        </td>
    </tr>
    <tr id="Tr3" runat="server">
        <td id="Td3" valign="top" align="right">
            <table id="Table2" cellpadding="0" cellspacing="0" 
                style="height: 43px; width: 101%;">
                <tr id="Tr4" bgcolor="#E6F3FF" runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img2" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                        colspan="2">
        تقارير تقييم مديرين
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Tr5" runat="server">
        <td style="width: 288px">
            <div id="div2" style="display: block; width: 405px;">
                <table style="line-height: 2; width: 123%">
                    <%--<tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_empLB_Click">  تقييم الأداء الوظيفي</asp:LinkButton>
                        </td>
                    </tr>
                     <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_groupedLB_Click">  تقييم الأداء الوظيفي مجمع بالقيم</asp:LinkButton>
                        </td>
                    </tr>--%>
                     <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_mange_groupedLB_Click"> تقييم الأداء الوظيفي للمديرين </asp:LinkButton>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_statusLB_Click"> الموظفين ما تم تقييمهم وما لم يتم تقييمهم</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image17" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton10" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المدير الاعلي</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image18" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton11" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="dept_empLB_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image19" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton12" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_statisticsLB_Click">إحصائية بموقف تقييم موظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
    <%--                <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image20" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton13" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image21" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton14" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين الأعلى</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%--  <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Dept_Emp_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%-- <tr >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_strengthLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_strengthLB_Click">التقييم بتحديد نقاط القوة و الضعف</asp:LinkButton>
                        </td>
                    </tr>
                    <tr  >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_needsLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_needsLB_Click">التقييم بتحديد الاحتياجات التدريبية</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                            &nbsp;</td>
                         <td style="height: 30px">
                            <asp:Image ID="Image22" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton15" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_dept_sector_Click">بيانات جميع الموظفين</asp:LinkButton>
                        </td>
                    </tr>--%>
                    </table>
            </div>
        </td>
    </tr>
    <tr id="Tr6" runat="server">
        <td id="Td4" valign="top" align="right">
            <table id="Table3" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                <tr id="Tr7" bgcolor="#E6F3FF" runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img3" src="../Images/collapse.gif" />
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
    <tr id="Tr8" runat="server">
        <td style="width: 288px">
            <div id="div3" style="display: block; width: 458px;">
                <table style="line-height: 2; width: 108%">
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton16" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_empLB_Click">  تقييم الأداء الوظيفي</asp:LinkButton>
                        </td>
                    </tr>--%>
<%--                     <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image24" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton17" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_groupedLB_Click">  تقييم الأداء الوظيفي مجمع بالقيم</asp:LinkButton>
                        </td>
                    </tr>--%>
          <%--         <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image25" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton18" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_mange_groupedLB_Click"> تقييم الأداء الوظيفي للمديرين </asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image26" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton19" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_statusLB_Click"> الموظفين ما تم تقييمهم وما لم يتم تقييمهم</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image27" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton20" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image28" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton21" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mng_finishedLB_Click"> الموظفين الذين تم تقييمهم من المدير الاعلي</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image29" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton22" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="dept_empLB_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image30" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton23" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_statisticsLB_Click">إحصائية بموقف تقييم موظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                  <%--  <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image31" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton24" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="direct_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين المباشرين</asp:LinkButton>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image32" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton25" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="top_mgr_emp_not_evalLB_Click">تقرير بالموظفين الذين لم يتم الانتهاء من تقييمهم من المديرين الأعلى</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%--  <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Dept_Emp_Click">تقرير بموظفي الإدارات</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <%-- <tr >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_strengthLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_strengthLB_Click">التقييم بتحديد نقاط القوة و الضعف</asp:LinkButton>
                        </td>
                    </tr>
                    <tr  >
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="eval_emp_needsLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_emp_needsLB_Click">التقييم بتحديد الاحتياجات التدريبية</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="28">
                            &nbsp;</td>
                         <td style="height: 30px">
                            <asp:Image ID="Image33" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                            <asp:LinkButton ID="LinkButton26" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="emp_dept_sector_Click">بيانات جميع الموظفين</asp:LinkButton>
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
    <tr>
        <td valign="top" style="width: 100%">
            <div id="Div_Dept" runat="server" style="display: none">
                <table cellpadding="0" cellspacing="0">
    </tr>
     <tr>
          <td>
           <asp:Label ID="sectors" runat="server" Text="القطاع" CssClass="Label"></asp:Label>
          </td>
          <td>
                 <asp:DropDownList ID="ddl_sec" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                  DataTextField="Sec_name" DataValueField="Sec_id" OnSelectedIndexChanged="ddl_sectors_SelectedIndexChanged" >
                </asp:DropDownList>
        </td>
        <!--<td align="right" dir="rtl">
                                
                            </td>-->
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 110px">
            <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="false"></asp:Label>
        </td>
        <td align="right" width="400px" dir="rtl">
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
                    CssClass="drop" Height="39px" Width="200px">
                </asp:DropDownList>
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
            </td>
        </tr>
    </table>
</div>
<div id="Div_emp" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
       <%-- <tr>
            <td>
                <asp:Label ID="Label30" runat="server" CssClass="Label" Text=" القطاع : " />
            </td>
            <td>
                <asp:DropDownList ID="Ddl_Sectors" CssClass="drop" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="Sec_name" DataValueField="Sec_id" Width="200px" OnSelectedIndexChanged="Ddl_Sectors_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand=" select Sec_id,Sec_name from Sectors "></asp:SqlDataSource>
            </td>
      </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label31" runat="server" CssClass="Label" Text=" الإدارة : " />
            </td>
            <td>
                <uc1:Smart_Search ID="Smart_Search_Departments" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label32" runat="server" CssClass="Label" Text=" اسم الموظف : " />
            </td>
            <td>
                <uc1:Smart_Search ID="smart_employee" runat="server" />
            </td>
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
<div id="Div_month" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="Label29" runat="server" Text="شهر: " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="drop_month" runat="server" Font-Bold="False" CssClass="drop"
                    Width="300px" Height="39px">
                    <asp:ListItem Text="اختر الشهر..." Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="يناير" Value="1"></asp:ListItem>
                    <asp:ListItem Text="فبراير" Value="2"></asp:ListItem>
                    <asp:ListItem Text="مارس" Value="3"></asp:ListItem>
                    <asp:ListItem Text="أبريل" Value="4"></asp:ListItem>
                    <asp:ListItem Text="مايو" Value="5"></asp:ListItem>
                    <asp:ListItem Text="يونيو" Value="6"></asp:ListItem>
                    <asp:ListItem Text="يوليو" Value="7"></asp:ListItem>
                    <asp:ListItem Text="أغسطس" Value="8"></asp:ListItem>
                    <asp:ListItem Text="سبتمبر" Value="9"></asp:ListItem>
                    <asp:ListItem Text="أكتوبر" Value="10"></asp:ListItem>
                    <asp:ListItem Text="نوفمبر" Value="11"></asp:ListItem>
                    <asp:ListItem Text="ديسمبر" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div id="Div_Balance" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" width="110px" style="height: 44px">
                <asp:Label ID="LBL_Balance" runat="server" Text="السنة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <asp:DropDownList ID="Drop_balance" runat="server" Font-Bold="False" CssClass="drop"
                    Width="300px" Height="39px">
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
            OnClick="Button1_Click" Text="عرض التقرير" Width="98px" />
            
            <asp:Button ID="Button2" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
            OnClick="Button2_Click" Text="عرض ملخص التقرير" Width="200px"  Visible="false"   />
            
            
    </td>
</tr>
</table> 