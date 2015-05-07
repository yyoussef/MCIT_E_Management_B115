<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_Reports.ascx.cs"
    Inherits="UserControls_Training_Reports" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

<table style="width: 100%; display: block; height: 100px; line-height: 2;" id="tbl_Report"
    runat="server">
    <tr>
        <td style="height: 30px; text-align: center;">
            <asp:Label ID="lbl_report_title" Text="التقارير" runat="server" Font-Names="Arial"
                Font-Size="20px" ForeColor="#1F4569" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image35" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="Training_emp" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Training_emp_Click">الدورات المسجل بها الموظف</asp:LinkButton>
        </td>
        <td>
            <input type="hidden" runat="server" id="hidden_Rpt_Id" />
        </td>
    </tr>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="emptraining" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Emp_Training_Click">الدورات التدريبية للموظفين</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="Emp_Approved_Training" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Emp_Approved_Training_Click">
                                الموظفين الذين تمت الموافقة عليهم  من قبل المدير المختص</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="Emp_Passed_Training" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Emp_Passed_Training_Click">
                                 الموظفين المجتازين للدورات بنجاح</asp:LinkButton>
        </td>
    </tr>
     <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="Emp_total_no_Training" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Emp_total_no_Training_Click">
                                احصاء  للدورات التدريبية</asp:LinkButton>
        </td>
    </tr>
    <%-- <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="Emp_total_no_Training_drow" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Emp_total_no_Training_drow_Click">
                                احصاء بياني  للدورات التدريبية</asp:LinkButton>
        </td>
    </tr>--%>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image36" runat="server" ImageUrl="~/new_images/a1.gif" 
                Style="text-align: right" />
            <asp:LinkButton ID="CompletedCourse" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="CompletedCourse_Click">الدورات التدريبية التي تمت وأسماء 
            المتقدمين للدورات التدريبية من قطاع البنية المعلوماتية</asp:LinkButton>
        </td>
    </tr>
      <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image7" runat="server" ImageUrl="~/new_images/a1.gif" 
                Style="text-align: right" />
            <asp:LinkButton ID="ITInfra_Courses" runat="server" CssClass="Text" 
                Font-Bold="False" onclick="ITInfra_Courses_Click"
                >الدورات التدريبية المعلن عنها للعاملين بقطاع البنية المعلوماتية  
            </asp:LinkButton>
        </td>
    </tr>
     <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="hr_approved_courses" runat="server" CssClass="Text" Font-Bold="False" OnClick="Emp_HR_Approved_Training_Click">
                                الموظفين الذين تمت الموافقة عليهم من قبل إدارة الموارد البشرية</asp:LinkButton>
        </td>
    </tr>
    
     <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image6" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
            <asp:LinkButton ID="lnk_results" runat="server" CssClass="Text" Font-Bold="False" OnClick="Course_Results_Click">
                                           النتائج النهائية للدورات </asp:LinkButton>
        </td>
    </tr>
    
     <tr>
        <td style="height: 30px; text-align: right;">
            &nbsp;</td>
    </tr>
    </table>
<table style="line-height: 2; width: 100%; display: none; height: 100px" id="tbl_Paramater"
    runat="server">
    <tr>
        <td style="height: 41px" align="center">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle"></asp:Label>
        </td>
        <td>
            <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                Width="37px" OnClick="ImgBtnBack_Click" AlternateText="العودة للتقارير الرئيسية" />
        </td>
    </tr>
</table>
<div id="Div_dept" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label1" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" width="400px" dir="rtl">
                <uc1:Smart_Search ID="Smart_dept" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div id="Div_emp" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr visible="true">
        </tr>
        <tr>
            <td align="right" width="110px">
                <asp:Label ID="Label18" runat="server" Text="اسم الموظف : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" valign="middle" style="height: 44px" dir="rtl">
                <uc1:Smart_Search ID="smart_employee" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div id="Div_course" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0" width="100%" >
        <tr visible="true">
        </tr>
        <tr>
           <%-- <td align="right" width="110px">
                <asp:Label ID="Label3" runat="server" Text="اسم الدورة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>--%>
            <td >
              <asp:GridView ID="gv_viewuserrequest" runat="server" 
                AutoGenerateColumns="False" Width="100%" 
                BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                            BorderWidth="1px" AllowPaging="True" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" Font-Size="17px" 
                
                  OnPageIndexChanging="gv_viewuserrequest_PageIndexChanging"  onrowcommand="gv_viewuserrequest_RowCommand">
                <Columns>
                    <asp:BoundField DataField="course_name" HeaderText="اسم الدوره التدريبيه" 
                        SortExpression="course_name" />
                         <asp:BoundField DataField="track_name" HeaderText="اسم المسار" 
                        SortExpression="track_name" />
                    <asp:BoundField DataField="place_desc" HeaderText="المكان" 
                        SortExpression="course_place" />
                    <asp:BoundField DataField="last_register_date" HeaderText="اخر ميعاد للتسجيل" 
                        SortExpression="last_register_date"  />
                    
                    <asp:TemplateField HeaderText="عرض التقرير">
                                                <ItemTemplate>
                                                    <asp:Button ID="Btn_Report"  runat="server" 
                                                        CommandArgument='<%# Eval("id") %>'  Text="عرض التقرير" CssClass="Button"  CommandName="EditItem" Width="100px" />
                                                       
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                         
                </Columns>
                <PagerStyle CssClass="pgr" />
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
              
            </td>
        </tr>
        <tr>
        <td>
          <asp:DropDownList ID="dll_course" runat="server" Width="200px" AutoPostBack="true"
                    CssClass="drop">
                </asp:DropDownList>
        </td>
        </tr>
    </table>
</div>
<table style="line-height: 2; width: 100%; display: none;" id="tbl_Paramater1" runat="server">
    <tr>
        <td align="center" dir="ltr">
            &nbsp;
            <asp:Label ID="Labname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabValue" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabDeptname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                OnClick="Button1_Click" Text="عرض التقرير" Width="98px" />
        </td>
    </tr>
</table>
