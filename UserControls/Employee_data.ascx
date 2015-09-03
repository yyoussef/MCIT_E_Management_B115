<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Employee_data.ascx.cs"
    Inherits="UserControls_Employee_data" %>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<asp:UpdatePanel ID="panl" runat="server">
    <ContentTemplate>
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr>
                <td>
                    <input type="hidden" runat="server" id="update_id" />
                    <input type="hidden" runat="server" id="update_id2" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    <cc1:TabContainer runat="server" ID="TabPanel_All" ActiveTabIndex="0" Height="1000px"
                        OnActiveTabChanged="TabPanel_All_ActiveTabChanged">
                        <cc1:TabPanel ID="TabPanel_dtl" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="البيانات الاساسيه للموظفين" />
                                <input type="hidden" runat="server" id="hidden_Id" />
                                <input type="hidden" runat="server" id="hidden_Proj_id" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_success" runat="server" Text="تم الحفظ بنجاح" Visible="false"
                                                ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                                
                                                  <asp:Label ID="lbl_user" runat="server" Text="برجاء إدخال إسم مستخدم أخر" Visible="false"
                                                ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                                
                                            <asp:Label ID="Label42" runat="server" Text=" عفوا لا يمكنك التعديل في بيانات هذا القطاع"
                                                Visible="false" ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label41" runat="server" CssClass="Label" Visible="false" Text=" إجمالي عدد الموظفين :"></asp:Label>
                                            <asp:Label ID="lbl_total_emp" runat="server" CssClass="Label" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="sectors" runat="server" Text="القطاع" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_sectors" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                                                DataTextField="Sec_name" DataValueField="Sec_id" OnSelectedIndexChanged="ddl_sectors_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label40" runat="server" CssClass="Label" Visible="false" Text=" إجمالي عدد الموظفين بالقطاع:"></asp:Label>
                                            <asp:Label ID="lbl_sec_count" runat="server" CssClass="Label" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="الإدارة :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_Search_mang" runat="server"   ValidationGroup="A" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label39" runat="server" CssClass="Label" Visible="false" Text="  إجمالي عدد الموظفين بالإدارة :"></asp:Label>
                                            <asp:Label ID="Lbl_count" runat="server" CssClass="Label" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text=" إسم الموظف :" CssClass="Label" ForeColor="#808080" font-underline="false"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_Search_emp" runat="server" ValidationGroup="A"/>
                                        </td>
                                    </tr>
                                    <tr id="tr_allow_chk_dept" runat="server" visible="False">
                                        <td id="Td1" runat="server">
                                        </td>
                                        <td id="Td2" runat="server">
                                            <asp:CheckBox ID="chk_allow_Chn_dept" runat="server" Text="تغيير الإدارة" CssClass="Label" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="الرقم الوظيفي :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="job_no_txt" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="المسمي الوظيفي :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="title_txt" runat="server" CssClass="Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label43" runat="server" Text="الوظيفة فى النظام :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Job_Category" runat="server" CssClass="drop">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label5" runat="server" Text="تاريخ التعيين :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:TextBox runat="server" CssClass="Text" Width="270px" ID="txt_rec_DT"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender runat="server" ValidChars="0987654321/\" Enabled="True"
                                                TargetControlID="txt_rec_DT" ID="FilteredTextBoxExtender2">
                                            </cc1:FilteredTextBoxExtender>
                                            <cc1:CalendarExtender runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                                                Enabled="True" TargetControlID="txt_rec_DT" ID="CalendarExtender2">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton runat="server" AlternateText="اضغط لعرض النتيجة" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                Height="23px" ToolTip="تقويم" Width="23px" ID="ImageButton2"></asp:ImageButton>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_rec_DT"
                                                ErrorMessage="أدخل التاريخ بطريقة صحيحة" 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label10" runat="server" Text="البريد الإلكتروني :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmail" runat="server" CssClass="Text"  AutoPostBack="true"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmail"
                                                ErrorMessage="أدخل البريد الالكتروني بطريقة صحيحة" 
                                                
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                       <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label46" runat="server" Text=" إسم الدخول :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_username" runat="server" CssClass="Text">   
                                            
                                            </asp:TextBox>
                                            
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txt_username"
                                              runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال إسم الدخول ">
                                              
                                              
                                              </asp:RequiredFieldValidator>
                                       
                                        </td>
                                    </tr>
                                    
                                      <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="مسئول إتصال :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_resp" runat="server"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Style="text-align: right" Text="الرئيس المباشر للأجازات :"
                                                CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_Search_Vaction_mng" runat="server" />
                                        </td>
                                    </tr>
                                    <tr visible="False" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="Label8" runat="server" Style="text-align: right" Text="الرئيس المباشر :"
                                                CssClass="Label"></asp:Label>
                                        </td>
                                        <td runat="server">
                                            <uc1:Smart_Search ID="Smart_Search2" runat="server" />
                                        </td>
                                    </tr>
                                    <tr visible="False" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="Label9" runat="server" Text="الرئيس الاعلي :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td runat="server">
                                            <uc1:Smart_Search ID="Smart_Search3" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="موقف الموظف من العمل" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_status" runat="server" CssClass="drop">
                                                <asp:ListItem Value="0" >-- اختر--</asp:ListItem>
                                                <asp:ListItem Value="1" Selected="True" >يعمل</asp:ListItem>
                                                <asp:ListItem Value="2">اجازه بدون مرتب</asp:ListItem>
                                                <asp:ListItem Value="3">منقطع عن العمل</asp:ListItem>
                                                <asp:ListItem Value="4">لا يعمل</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_status"
                                                ErrorMessage="يجب ادخال حاله الموظف">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label29" runat="server" CssClass="Label" Text="الفئه"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_search_category" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text="المؤهل الدراسي"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_universitydegree" runat="server" CssClass="drop">
                                                <asp:ListItem Value="0" Selected="True">-- اختر--</asp:ListItem>
                                                <asp:ListItem Value="1">دكتواره</asp:ListItem>
                                                <asp:ListItem Value="2">ماجيستير</asp:ListItem>
                                                <asp:ListItem Value="3">بكالريوس</asp:ListItem>
                                                <asp:ListItem Value="4">ليسانس</asp:ListItem>
                                                <asp:ListItem Value="5">دبلوم</asp:ListItem>
                                                <asp:ListItem Value="8">ثانوية عامة</asp:ListItem>
                                                <asp:ListItem Value="6">اعدادية</asp:ListItem>
                                                <asp:ListItem Value="7">ابتدائية</asp:ListItem>
                                                <asp:ListItem Value="9">معهد</asp:ListItem>
                                                <asp:ListItem Value="10">شهادة محو امية</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text="جهة الحصول علي المؤهل"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_universityname" runat="server" CssClass="Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="التخصص"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_major" runat="server" CssClass="Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Button ID="btn_Save" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="A"
                                                OnClick="btn_Save_Click" />
                                            <asp:Button ID="btn_clear" runat="server" CssClass="Button" Text="جديد" OnClick="btn_clear_Click" />
                                            <asp:Button ID="Btn_Reset" runat="server" CssClass="Button" Text="إعادة تعيين كلمة المرور" OnClick="Btn_Reset_Click"  Width="150px"/>
                                            
                                          <asp:Button ID="btn_active" runat="server" CssClass="Button" Text="إعادة تفعيل الحساب" OnClick="btn_active_Click"  Width="150px"/>

                                            
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label33" runat="server" CssClass="Label" Font-Size="11px" Text="مديرين تقييم الاداء" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_res" runat="server" Text="تم حفظ بيانات مديرين تقييم الاداء بنجاح للموظف  :  "
                                                Visible="false" ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label35" runat="server" Text="الرئيس الاعلي لتقييم الاداء :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="smrtHigherManager" runat="server" Validation_Group="M1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Text="الرئيس المباشر لتقييم الاداء :" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:Smart_Search ID="smrtDirectManager" runat="server" Validation_Group="M1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center" colspan="2">
                                            <asp:Button ID="Button1" runat="server" CssClass="Button" Text="حفظ" Validation_Group="M1"
                                                OnClick="imgbtnAddMngr_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" width="10%">
                                            <asp:GridView ID="gvManagers" runat="server" AutoGenerateColumns="False" DataKeyNames="Emp_Mngr_ID"
                                                dir="rtl" OnRowDeleting="gvManagers_RowDeleting" OnRowEditing="gvManagers_RowEditing"
                                                PageSize="20" Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC"
                                                BorderStyle="None" BorderWidth="1px" CssClass="mGrid" Font-Size="17px">
                                                <Columns>
                                                    <asp:BoundField DataField="Emp_Mngr_ID" HeaderText="Emp_Mngr_ID" Visible="False">
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Serial" HeaderText="م">
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MngrName" HeaderText="إسم المدير">
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="managerlevel" HeaderText="الدرجة">
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%#             Eval("Mngr_Emp_ID")%>'
                                                                CommandName="Edit" Style="height: 22px" Text="تعديل" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../Images/delete.gif" CommandArgument='<%#         Eval("Mngr_Emp_ID") %>'
                                                                CommandName="Delete" OnClientClick="return confirm(&quot;هل تريد الحذف?&quot;);"
                                                                Style="height: 22px" Text="حذف" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel3" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label19" runat="server" CssClass="Label" Font-Size="11px" Text="بيانات عامه" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label36" runat="server" Text="تم حفظ البيانات العامة بنجاح للموظف  :  "
                                                Visible="false" ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Text="التليفون" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_otherphone" runat="server" CssClass="Text" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_otherphone"
                                                ValidChars="0987654321" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Text="الموبايل" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_mobile" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_mobile"
                                                ValidChars="0987654321" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="الايميل" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_othermail" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_othermail"
                                                ErrorMessage="أدخل البريد الالكتروني بطريقة صحيحة" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" Text="المهام المكلف بها" CssClass="Label">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_currenttasks" runat="server" CssClass="Text" TextMode="MultiLine"
                                                Height="69px" Width="350px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Text="هل تشرف علي موظفين" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rb_ismanager" runat="server" CssClass="Label" RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="changing" AutoPostBack="true">
                                                <asp:ListItem Value="1">نعم</asp:ListItem>
                                                <asp:ListItem Value="0" Selected="True">لا</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="noofemployee_tr" visible="false">
                                        <td>
                                            <asp:Label ID="Label25" runat="server" Text="عدد الموظفين" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_noofemployee" runat="server" CssClass="Text" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_noofemployee"
                                                ValidChars="0987654321" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label26" runat="server" Text="مستوي اللغه الانجليزيه" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rb_englishlevel" runat="server" CssClass="Label" RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="changing">
                                                <asp:ListItem Value="4" Selected="True">ممتاز</asp:ListItem>
                                                <asp:ListItem Value="3">جيد جدا</asp:ListItem>
                                                <asp:ListItem Value="2">جيد </asp:ListItem>
                                                <asp:ListItem Value="1">مقبول</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="2">
                                            <asp:Button ID="btn_publicdatasave" runat="server" Text="حفظ" OnClick="btn_publicdatasave_Click"
                                                CssClass="Button"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel4" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label13" runat="server" CssClass="Label" Font-Size="11px" Text="الدورات التدريبية" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label38" runat="server" Text="تم حفظ بيانات الدورات التريبية بنجاح للموظف  :  "
                                                Visible="false" ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" Text="اسم البرنامج" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_coursename" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="train"
                                                ErrorMessage="يجب ادخال اسم الدوره التدريبيه" ControlToValidate="txt_coursename"
                                                Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" Text=" الفترة من" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tx_startdate" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                            <cc1:CalendarExtender ID="tx_lastgenertiondateCalendarExtender1" runat="server" TargetControlID="tx_startdate"
                                                PopupButtonID="ImageButton1" Format="dd/MM/yyyy" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="train"
                                                runat="server" Text="*" ErrorMessage="مطلوب ادخال تاريخ البديء" ControlToValidate="tx_startdate"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorreg_date" runat="server"
                                                ValidationGroup="train" ControlToValidate="tx_startdate" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">
                                                
                                                </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text=" الفترة إلي" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_endate" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_endate"
                                                PopupButtonID="ImageButton3" Format="dd/MM/yyyy" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="train"
                                                runat="server" Text="*" ErrorMessage="مطلوب ادخال تاريخ الانتهاء" ControlToValidate="txt_endate"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="train"
                                                ControlToValidate="txt_endate" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"  ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">

                                                </asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator5" runat="server" ValidationGroup="train"
                                                ControlToCompare="tx_startdate" ControlToValidate="txt_endate" ErrorMessage="CompareValidator"
                                                Operator="GreaterThan" Type="Date">يجب ان 
                                 يكون تاريخ نهايه الدوره التدريبيه اكبر من تاريخ البدايه</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btn_save_EX_Training" runat="server" Text="حفظ" CssClass="Button"
                                                ValidationGroup="train" OnClick="btn_save_EX_Training_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="gv_Employee_EX_TRaing" runat="server" OnRowCommand="gv_Employee_EX_TRaing_RowCommand"
                                                AutoGenerateColumns="False" Width="100%" BackColor="White" ForeColor="Black"
                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CssClass="mGrid" Font-Size="17px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="م">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Width="3px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="3px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="course_name" HeaderText="اسم البرنامج" />
                                                    <asp:BoundField DataField="start_date" HeaderText="فتره انعقاد البرنامج" />
                                                    <asp:BoundField DataField="end_date" HeaderText="إلي" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="editItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="alt" />
                                                <PagerStyle CssClass="pgr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel1" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label12" runat="server" CssClass="Label" Font-Size="11px" Text="الخبرات السابقه" />
                                <input type="hidden" runat="server" id="hidden1" />
                                <input type="hidden" runat="server" id="hidden2" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label37" runat="server" Text="تم حفظ بيانات الخبرات السابقة بنجاح للموظف  :  "
                                                Visible="false" ForeColor="#EC981F" font-underline="false" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Text="الفترة من" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExperienceStartDate" runat="server" CssClass="Text"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtExperienceStartDate"
                                                PopupButtonID="ImageButton4" Format="dd/MM/yyyy" Enabled="True" />
                                            <asp:ImageButton runat="server" ID="ImageButton4" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="E" runat="server"
                                                Text="*" ErrorMessage="مطلوب ادخال تاريخ البدء" ControlToValidate="txtExperienceStartDate"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="E"
                                                ControlToValidate="txtExperienceStartDate" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">

                                                </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label45" runat="server" Text="الفترة إلي" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExperienceEndDate" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:ImageButton runat="server" ID="ImageButton5" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExperienceEndDate"
                                                PopupButtonID="ImageButton5" Format="dd/MM/yyyy" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="E" runat="server"
                                                Text="*" ErrorMessage="مطلوب ادخال تاريخ الانتهاء" ControlToValidate="txtExperienceEndDate"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="E"
                                                ControlToValidate="txtExperienceEndDate" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"
                                                
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">
                                                
                                                </asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="E" ControlToCompare="txtExperienceStartDate"
                                                ControlToValidate="txtExperienceEndDate" ErrorMessage="CompareValidator" Operator="GreaterThan"
                                                Type="Date">يجب ان 
                                 يكون تاريخ نهايه فترة الخبرة اكبر من تاريخ البدايه</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Text="الجهه" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_organization" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txt_organization"
                                                ValidationGroup="E" ErrorMessage="*">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="المسمي الوظيفي" CssClass="Label" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_jobtitle" runat="server" CssClass="Text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_jobtitle"
                                                ValidationGroup="E" ErrorMessage="*">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Text="ملخص المهام" CssClass="Label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_tasks" runat="server" CssClass="Text" TextMode="MultiLine" Height="69px"
                                                Width="350px" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_tasks"
                                                ValidationGroup="E" ErrorMessage="*">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="2">
                                            <asp:Button ID="btn_addexperience" runat="server" Text="حفظ" ValidationGroup="E"
                                                OnClick="btn_addexperience_Click" CssClass="Button"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:GridView ID="gv_experience" runat="server" AutoGenerateColumns="False" utoGenerateColumns="False"
                                            Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                            BorderWidth="1px" CssClass="mGrid" Font-Size="17px" OnRowCommand="gv_experience_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="FromDate" HeaderText="الفترة من" />
                                                <asp:BoundField DataField="ToDate" HeaderText="الفترة إلي" />
                                                <asp:BoundField DataField="organization" HeaderText="الجهه" />
                                                <asp:BoundField DataField="job_title" HeaderText="المسمي الوظيفي" />
                                                <asp:BoundField DataField="desc" HeaderText="ملخص المهام" />
                                                <asp:TemplateField HeaderText="تعديل">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="editItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                            Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="حذف">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                            Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                            <PagerStyle CssClass="pgr" />
                                        </asp:GridView>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <%--<Triggers>
            <asp:PostBackTrigger ControlID="BtnDocUpload" />
        </Triggers>--%>
</asp:UpdatePanel>
