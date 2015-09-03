<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Archiving_Report.ascx.cs"
    Inherits="UserControls_Eval_Emp_Report" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    function ChangeMeCase(divid, imgid) {

        var divname = document.getElementById(divid);
        var img = document.getElementById(imgid);

        var imgsrc = img.src;


        if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
            img.src = "../Images/square_arrow_down.gif";
        }
        else {
            img.src = "../Images/square_arrow_flipped.gif";
        }

        divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
    }

</script>

<table style="width: 100%; display: block; height: 310px; line-height: 2;" id="tbl_Report"
    runat="server">
    <tr>
        <td height="30px" align="center">
            <input type="hidden" runat="server" id="hidden_Rpt_Id" />
            <input type="hidden" runat="server" id="hidden_Report" />
            <input type="hidden" runat="server" id="hidden_manager" />
            <asp:Label ID="Label1" runat="server" Text="تقارير  " CssClass="PageTitle" ></asp:Label>
        </td>
    </tr>
    <tr id="Tr1" runat="server">
        <td id="Td2" valign="top" align="right">
            <table id="Table1" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                <tr id="Tr22"  runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img1" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img1');"
                        colspan="2">
                        تقارير الأرشيف الالكتروني الوارد
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Tr2" runat="server">
        <td style="width: 288px">
            <div id="div1" style="display: block; width: 840px;">
                <table style="line-height: 2; width: 121%">
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="eval_empLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="eval_empLB_Click"> تقرير الأرشيف الالكتروني الوارد لموظف</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="General_inbox_LB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="General_inbox_LB_Click"> تقرير  المكلف به خلال فترة - وارد</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="Inbox_doneby_periodLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Inbox_doneby_periodLB_Click"> تقرير  المنجز في فترة و المكلف به في هذه الفترة - وارد </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="inbox_donebefordateLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="inbox_donebefordateLB_Click">  تقرير  المنجز في فترة و المكلف به قبل هذه الفترة - وارد</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LatePeriodLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="LatePeriodLB_Click"> تقرير  المتاخر خلال فترة - وارد</asp:LinkButton>
                        </td>
                    </tr>
                    
                     <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Latedetail_Click"> تقرير  تفصيلي بالوارد المتأخر </asp:LinkButton>
                        </td>
                    </tr>
                    
                    
                </table>
            </div>
        </td>
    </tr>
    <tr id="Tr3" runat="server">
        <td id="Td3" valign="top" align="right">
            <table id="Table2" cellpadding="0" cellspacing="0" style="height: 43px; width: 101%;">
                <tr id="Tr4"  runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img2" src="../Images/square_arrow_flipped.gif" alt="" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');"
                        colspan="2">
                        تقارير الأرشيف الالكتروني الصادر
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Tr5" runat="server">
        <td style="width: 288px">
            <div id="div2" style="display: block; width: 877px;">
                <table style="line-height: 2; width: 123%">
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="LinkButton5_Click" Text="تقرير الأرشيف الالكتروني الصادر لموظف"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="General_Outbox_LB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="General_Outbox_LB_Click"> تقرير  المكلف به خلال فترة - صادر</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="Outbox_doneby_periodLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Outbox_doneby_periodLB_Click"> تقرير  المنجز في فترة و المكلف به في هذه الفترة -صادر</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="Outbox_donebefordateLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="Outbox_donebefordateLB_Click"> تقرير  المنجز في فترة و المكلف به قبل هذه الفترة- صادر</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LatePeriodOutboxLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="LatePeriodOutboxLB_Click"> تقرير  المتاخر خلال فترة-صادر</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr id="Tr6" runat="server">
        <td id="Td4" valign="top" align="right">
            <table id="Table3" cellpadding="0" cellspacing="0" style="height: 43px; width: 100%;">
                <tr id="Tr7"  runat="server">
                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','Img2');">
                        <img border="0" id="Img3" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img3');"
                        colspan="2">
                        تقارير التكليفات
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="Tr8" runat="server">
        <td style="width: 288px">
            <div id="div3" style="display: block; width: 458px;">
                <table style="line-height: 2; width: 218%">
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LinkButton16" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="LinkButton16_Click" Text="تقرير التكليفات لموظف"></asp:LinkButton>
                        </td>
                    </tr>
                     <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="General_com_LB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="General_com_LB_Click"> تقرير  المكلف به خلال فترة - تكليفات</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="com_doneby_periodLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="com_doneby_periodLB_Click"> تقرير  المنجز في فترة و المكلف به في هذه الفترة -تكليفات</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="com_donebefordateLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="com_donebefordateLB_Click"> تقرير  المنجز في فترة و المكلف به قبل هذه الفترة- تكليفات</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="28">
                        </td>
                        <td style="height: 30px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
                            <asp:LinkButton ID="LatePeriodComLB" runat="server" CssClass="Text" Font-Bold="False"
                                OnClick="LatePeriodComLB_Click"> تقرير  المتاخر خلال فترة-تكليفات</asp:LinkButton>
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
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle"></asp:Label>
        </td>
        <td>
            <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                Width="37px" OnClick="ImgBtnBack_Click" AlternateText="العودة للتقارير الرئيسية" />
        </td>
    </tr>
    <tr>
        <td style="height: 41px" align="center">
            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0">
               <%-- <tr>
                    <td>
                        <asp:Label ID="Label30" runat="server" CssClass="Label" Text=" القطاع : " />
                    </td>
                    <td>
                        <asp:DropDownList ID="Ddl_Sectors" CssClass="drop" runat="server" DataSourceID="SqlDataSource2"
                            Enabled="false" DataTextField="Sec_name" DataValueField="Sec_id" Width="200px"
                            OnSelectedIndexChanged="Ddl_Sectors_SelectedIndexChanged" AutoPostBack="true">
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
                        <uc1:Smart_Search ID="Smart_Search_Departments" runat="server" Validation_Group="validgroup" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label32" runat="server" CssClass="Label" Text=" اسم الموظف : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="smart_employee" runat="server" Validation_Group="validgroup" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" colspan="2">
            <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="الفترة من :" Font-Names="Arial"
                Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            <asp:TextBox ID="txt_date_from" runat="server" Font-Names="Arial" Font-Size="20px"
                ForeColor="#1F4569" Font-Bold="True" Width="129px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_date_from"
                PopupButtonID="ImageButton5" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton5" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txt_date_from"
                ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )"
                
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="الفترة الي :" Font-Names="Arial"
                Font-Size="20px" ForeColor="#1F4569"></asp:Label>
            <asp:TextBox ID="txt_date_to" runat="server" Font-Bold="True" Height="29px" Width="128px"
                Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_date_to"
                PopupButtonID="ImageButton9" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton9" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                ControlToValidate="txt_date_to" ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="height: 43px;" align="center" dir="ltr">
            &nbsp;
            <asp:Label ID="Labname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabValue" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabDeptname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" OnClick="Button1_Click"
                ValidationGroup="validgroup" Text="عرض التقرير" Width="98px" />
        </td>
    </tr>
</table>
