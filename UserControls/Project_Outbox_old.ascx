<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_Outbox_old.ascx.cs"
    Inherits="UserControls_Project_Outbox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">

function Get_Value()
{
var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex+1,dotindex);

document.getElementById('<%= txtFileName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
</script>


<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="30" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
        <div style="position: fixed; background-color: #FAFAFA; z-index: 2147483647 !important;
            opacity: 0.8; overflow: hidden; text-align: center; top: 0; left: 0; height: 100%;
            width: 100%; padding-top: 20%;">
            <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" ImageUrl="~/Images/icon-loading.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div  ng-app="SmartSearch" ng-controller="SmartSearchCtrl" ng-init="type=2;loadOrganization()">
<input type="hidden" runat="server" id="OrgDesc" name="OrgDesc" value="--اختر الجهة--" />
<input type="hidden" runat="server" id="OrgID" name="OrgID" value="0" />
    <input type="hidden" runat="server" id="type" name="type" value="3" />
<input id="Outbox_ID" runat="server" type="hidden"  />
<input id="mode" runat="server" type="hidden" value="new" />
<input id="id2" runat="server" type="hidden" />
<input id="id3" runat="server" type="hidden" />
<input id="empId" runat="server" type="hidden" />
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr>
                <td align="center" colspan="4" style="height: 33px">
                    <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الخطابات الصادرة" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" style="height: 5px">
                    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px">
                        <cc1:TabPanel ID="TabPanel_dtl" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="تفاصيل الخطاب" />
                                <input type="hidden" runat="server" id="hidden_Id"> 
                                    <input id="hidden_Proj_id" runat="server" type="hidden"></input>
                                    
                                </input>
                                </input>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="نوع الخطاب" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop" Width="319px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                                <asp:ListItem Text="صادر داخلى" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="صادر خارجى" Value="2" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="مرسل بواسطة :" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Source_Type" runat="server" CssClass="drop" Width="319px">
                                                <asp:ListItem Text="البريد" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="الإيميل" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="الفاكس" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" CssClass="Label" Text="الكود :" />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_Code" Width="319px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Code"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال الكود "></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="التاريخ :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Date" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_Date"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                                TargetControlID="txt_Date" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Date"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Date"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="نوع الارتباط" />
                                            <asp:TextBox runat="server" CssClass="Text" ID="txt_Name" Visible="False" Width="319px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Related_Type" runat="server" CssClass="drop" Width="319px"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddl_Related_Type_SelectedIndexChanged">
                                                <asp:ListItem Text="صادر جديد" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="رد على وارد" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="رد على تأشيرة وزير" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="استعجال صادر" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="أخري.." Value="5"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trSmart"  style="display:none" >
                                        <td colspan="4" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Inbox_type" runat="server" CssClass="Label" Text="رد او استعجال للخطاب:" />
                                                    </td>
                                                    <td>
                                                        <uc1:Smart_Search ID="Smart_Related_Id" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr_Inbox_out">
                                        <td colspan="4" align="right" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الجهة الصادر لها :" />
                                                    </td>
                                                    <td>
                                
                                                        <div id="myDiv">
                                                        <ui-select ng-model="organization.selected" theme="select2"  ng-disabled="disabled" style="min-width: 300px;" on-select="setHiddenWithOrg($item)">
                                                              <ui-select-match placeholder="{{initialSelectedOrganization}}">{{$select.selected.name}}</ui-select-match>
                                                                <ui-select-choices repeat="organization in organizations | propsFilter: {name: $select.search}">
                                                                  <div ng-bind-html="organization.name | highlight: $select.search"></div>                                                                    
                                                                </ui-select-choices>
                                                              </ui-select>  
                                                      </div>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="رقم صادر الجهة :" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Org_Out_Box_Code" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="تاريخ صادر الجهة :" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Org_Out_Box_DT" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_Org_Out_Box_DT"
                                                            ValidChars="0987654321/\" Enabled="True" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                                                            TargetControlID="txt_Org_Out_Box_DT" Enabled="True">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                            Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Org_Out_Box_DT"
                                                            Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                            ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="الإدارة داخل الجهة :" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Org_Dept_Name" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text="المرسل اليه داخل الجهة ( صفته / شخصه ) :" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Org_Out_Box_Person" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr_Inbox_In" style="display: none;width:10px">
                                        <td colspan="4" align="right" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="  الادارة :" CssClass="Label" ForeColor="#808080" font-underline="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <uc1:Smart_Search ID="Smrt_Srch_structure2" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server" CssClass="Label" Text="وصف:" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Dept_Desc" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text="الموظف :" />
                                                    </td>
                                                    <td>
                                                        <uc1:Smart_Search ID="Smart_Emp_ID" runat="server" />
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" CssClass="Label" Text="التصنيف الرئيسي  :"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 100px"
                                                dir="rtl" class="borderControl">
                                                <asp:CheckBoxList ID="Chk_main_cat" runat="server" CellPadding="5" CellSpacing="5"
                                                    CssClass="Label" Font-Size="Small" RepeatColumns="6" RepeatDirection="Horizontal"
                                                    AutoPostBack="True" DataTextField="Name" DataValueField="id" OnSelectedIndexChanged="Chk_main_cat_SelectedIndexChanged">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label37" runat="server" CssClass="Label" Text="التصنيف الفرعى :"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:CheckBoxList ID="Chk_sub_cat" runat="server" CellPadding="5" CellSpacing="5"
                                                CssClass="Label" Font-Size="Small" RepeatColumns="6" RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الموضوع :"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Subject" runat="server" CssClass="Text" Height="70px" Rows="6"
                                                TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Subject"
                                                ErrorMessage="يجب ادخال الموضوع " Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="عدد الاوراق :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Paper_No" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" CssClass="Label" Text="عدد المرفقات :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Paper_Attached" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" CssClass="Label" Text="ملاحظات :" />
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Notes" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <br />
                                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                                                ValidationGroup="A" Width="99px" />
                                            <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btnClear" OnClick="btnClear_Click"
                                                 Width="50px" />
                                            <asp:Button runat="server" CssClass="Button" Text="ارسال إلي المدير المختص" ID="Button2"
                                                OnClick="btnSend_Click" ValidationGroup="A" Width="170px" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                                ShowMessageBox="True" ShowSummary="False" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel_Files" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label18" runat="server" CssClass="Label" Font-Size="11px" Text="ملفات الخطاب" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                                            <input type="hidden" runat="server" id="hidden_Inbox_OutBox_File_ID"></input>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td dir="rtl">
                                            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" Width="700px" onchange="Get_Value()" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="700px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="نوع الوثيقــــــــة: " />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Original_Or_Attached" runat="server" CssClass="drop" Width="319px">
                                                <asp:ListItem Text="وثيقة أصلية" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="مرفقات" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="حفظ الوثيقة" runat="server"
                                                CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                OnRowCommand="GrdView_Documents_RowCommand" Font-Size="17px" GridLines="Vertical">
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="الوثيقة">
                                                        <ItemTemplate>
                                                            <a href='<%# "ALL_Document_Details.aspx?type=Inbox&id="+ Eval("Inbox_OutBox_File_ID") %>'>
                                                                <%# Eval("File_name")%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نوع الوثيقة">
                                                        <ItemTemplate>
                                                            <%# Get_Type(Eval("Original_Or_Attached"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Inbox_OutBox_File_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Inbox_OutBox_File_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel_Visa" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label24" runat="server" CssClass="Label" Font-Size="11px" Text="التأشيرات" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr id="tr_dr_hesham_Visa" runat="server" visible="False">
                                        <td id="Td1" runat="server">
                                            <asp:Label ID="Label41" runat="server" CssClass="Label" Text="  نص تأشيرة المدير المختص" />
                                        </td>
                                        <td id="Td2" colspan="3" runat="server">
                                            <asp:TextBox runat="server" CssClass="Text" Height="70px" Width="50%" Rows="5" ID="txt_dr_hesham_visa"
                                                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="تاريخ التاشيرة :" Width="135px" />
                                            <input type="hidden" runat="server" id="hidden_Visa_Id"></input>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td dir="rtl">
                                            <asp:TextBox ID="txt_Visa_date" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_Visa_date"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3"
                                                TargetControlID="txt_Visa_date" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_Visa_date"
                                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال تاريخ التاشيرة "></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Visa_date"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="B" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="درجة الأهمية: " Width="100px" />
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl_Important_Degree" runat="server" CssClass="drop" Width="150px">
                                                <asp:ListItem Text="هام" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="عاجل" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="عادى" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="txt_Important_Degree_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label42" runat="server" CssClass="Label" Text="اخر تاريخ مسموح به  :"
                                                Width="135px" />
                                        </td>
                                        <td dir="rtl">
                                            <asp:TextBox ID="txt_Dead_Line_DT" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_Dead_Line_DT"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton33"
                                                TargetControlID="txt_Dead_Line_DT" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton33" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_Dead_Line_DT"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="B" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label43" runat="server" CssClass="Label" Text="غرض التاشيرة: " Width="100px" />
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl_Visa_Goal_ID" runat="server" CssClass="drop" Width="150px">
                                                <asp:ListItem Text="للدراسة" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="للعرض" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td>
                                    <asp:Label ID="Label50" runat="server" CssClass="Label" Text="القطاع :" />
                               </td>
                               <td colspan="3">
                                    <asp:DropDownList ID="ddl_sectors2" AutoPostBack="True" OnSelectedIndexChanged="ddl_sectors2_SelectedIndexChanged"
                                        runat="server" CssClass="drop" Width="314px"   DataTextField="Sec_name" DataValueField="Sec_id" >
                                     </asp:DropDownList>
                               </td>
                             </tr>
                            
                            <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الإدارة التابع لها :" />
                                </td>
                                <td>
                                    <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="txt_Dept_ID_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                </td>--%>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="  الادارة :" CssClass="Label" ForeColor="#808080" font-underline="false"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <uc1:Smart_Search ID="Smrt_Srch_structure" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" CssClass="Label" Text="النوع :" />
                                        </td>
                                        <td align="right" colspan="3">
                                            <asp:RadioButtonList ID="radlst_Type" runat="server" OnSelectedIndexChanged="radlst_Type_SelectedIndexChanged"
                                                AutoPostBack="True" CssClass="Label" Font-Bold="True" CellPadding="2" CellSpacing="1"
                                                RepeatColumns="6" RepeatDirection="Horizontal">
                                                 <asp:ListItem Text="اختر" Value="7" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="المفضلة" Value="1" ></asp:ListItem>
                                                <asp:ListItem Text="الكل" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="مديري الادارات" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="مسئولي الاتصال" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="  رؤساء اللجان" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="رؤساء الاقسام " Value="6"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tr_emp_list" runat="server">
                                        <td id="Td3" runat="server">
                                            <asp:Label ID="Label47" runat="server" CssClass="Label" Text="الموظف المسئول  :" />
                                        </td>
                                        <td id="Td4" align="right" runat="server">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                dir="rtl" class="borderControl">
                                                <asp:CheckBox ID="chk_ALL" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
                                                    Text="اختر الكل" AutoPostBack="True" runat="server" OnCheckedChanged="chk_ALL_CheckedChanged">
                                                </asp:CheckBox>
                                                <asp:CheckBoxList ID="chklst_Visa_Emp_All" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                                                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                    DataValueField="PMP_ID" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                        <td id="Td5" runat="server">
                                            <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server" CssClass="Button" />
                                            <asp:Button ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server"
                                                CssClass="Button" />
                                        </td>
                                        <td id="Td6" runat="server">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                dir="rtl" class="borderControl">
                                                <asp:ListBox ID="lst_emp" runat="server" Height="270px" Width="300px" Font-Size="Small">
                                                </asp:ListBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <%--<tr id="tr_old_emp" runat="server">
                                        <td id="Td7" runat="server">
                                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="المسئول عن التنفيذ :" />
                                        </td>
                                        <td id="Td8" align="right" colspan="3" runat="server">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                dir="rtl">
                                                <asp:CheckBoxList ID="chklst_Visa_Emp" CellPadding="5" CellSpacing="5" RepeatColumns="6"
                                                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                    DataValueField="PMP_ID" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="Label29" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="txt_Emp_ID_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text="نص التاشيرة :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Visa_Desc" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_Visa_Desc"
                                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال وصف التاشيرة "></asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label323" runat="server" CssClass="Label" Text="ملف الحفظ :" />
                                            <asp:TextBox ID="txt_saving_file" runat="server" CssClass="Text" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" CssClass="Label" Text="مدة التاشيرة :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Visa_Period" runat="server" CssClass="Text" Width="293px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" CssClass="Label" Text="حالة التاشيرة :" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Visa_Satus" runat="server" CssClass="drop" Width="319px">
                                                <asp:ListItem Text="جارية" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="منتهية" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="غير منتهية" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="المتابعة" Visible="false" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="موقف المتابعة :" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Follow_Up_Notes" runat="server" CssClass="Text" Width="293px"
                                                            Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                                        </td>
                                        <td dir="rtl" colspan="3">
                                            <asp:FileUpload ID="FileUpload_Visa" runat="server" ForeColor="Maroon" Width="700px" />
                                            <br />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="Button1" OnClick="btn_Visa_Click" ValidationGroup="B" Text="حفظ"
                                                runat="server" CssClass="Button" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="B"
                                                ShowMessageBox="True" ShowSummary="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 450px">
                                                <asp:GridView ID="GridView_Visa" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                    OnRowCommand="GridView_Visa_RowCommand" Font-Size="17px" AllowPaging="True" AllowSorting="True"
                                                    OnRowDataBound="GridView_Visa_rw_data_bound" GridLines="Vertical">
                                                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="تاريخ التأشيرة">
                                                            <ItemTemplate>
                                                                <%# Eval("Visa_date")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="درجة الأهمية">
                                                            <ItemTemplate>
                                                                <%# Get_Type_Visa(Eval("Important_Degree"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="اسم المحور">
                                                            <ItemTemplate>
                                                                <%# Eval("Dept_ID_Txt")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="وصف التأشيرة">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("Visa_Desc")%>'></asp:Label>
                                                                <asp:Label ID="lbl_emp" runat="server" Text='<%# Eval("Emp_ID")%>' Visible ="false" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="الوثيقة">
                                                         <ItemTemplate>
                                                               <a href='<%# "ALL_Document_Details.aspx?type=outbox_visa&id="+ Eval("Visa_Id") %>'>
                                                                 <%# Eval("File_name")%></a>
                                                         </ItemTemplate>
                                                      </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="المسئول عن التنفيذ">
                                                            <ItemTemplate>
                                                                <%# Get_Visa_Emp(Eval("Visa_Id"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="موقف المتابعة">
                                                            <ItemTemplate>
                                                                <%# Eval("Follow_Up_Notes")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="تم ارسال إيميل">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSent" runat="server" AutoPostBack="true" OnCheckedChanged="chkSent_CheckedChanged" Enabled="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" ارسال إيميل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit123" CommandName="SendItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Visa_Id") %>' Visible="true"  />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="تعديل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Visa_Id") %>' Visible="true" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="حذف">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                    Style="height: 22px" CommandArgument='<%# Eval("Visa_Id") %>'  Visible="true"/>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel_Visa_Folow" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label38" runat="server" CssClass="Label" Font-Size="11px" Text="المسير" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label39" runat="server" CssClass="Label" Text="المسئول عن التنفيذ:"
                                                Width="135px" />
                                            <input type="hidden" runat="server" id="hidden_Follow_ID"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </input>
                                        </td>
                                        <td dir="rtl">
                                            <asp:DropDownList ID="ddl_Visa_Emp_id" runat="server" CssClass="drop" Width="319px">
                                            </asp:DropDownList>
                                            <asp:RangeValidator ControlToValidate="ddl_Visa_Emp_id" ErrorMessage="يجب اختيار المسئول عن التنفيذ"
                                                ID="RangeValidator2" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                                MinimumValue="1" ValidationGroup="VF">*</asp:RangeValidator>
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label40" runat="server" CssClass="Label" Text="وصف المتابعة: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Descrption" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Descrption"
                                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال وصف المتابعة "></asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label44" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label45" runat="server" CssClass="Label" Text="تاريخ المتابعة :" Width="135px" />
                                        </td>
                                        <td dir="rtl">
                                            <asp:TextBox ID="txt_Follow_Date" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_Follow_Date"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton4"
                                                TargetControlID="txt_Follow_Date" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton4" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Follow_Date"
                                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال تاريخ المتابعة "></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_Follow_Date"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="VF" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label48" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                                        </td>
                                        <td dir="rtl" colspan="3">
                                            <asp:FileUpload ID="FileUpload_Visa_Follow" runat="server" ForeColor="Maroon" Width="700px" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="btn_Visa_Follow" OnClick="btn_Visa_Follow_Click" ValidationGroup="VF"
                                                Text="حفظ" runat="server" CssClass="Button" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="VF"
                                                ShowMessageBox="True" ShowSummary="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="left">
                                            <br />
                                            <asp:Button runat="server" CssClass="Button" Text="طباعة تقرير المسير" ID="btn_print_report"
                                                OnClick="btn_print_report_Click" Width="150px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 450px">
                                                <asp:GridView ID="GridView_Visa_Follow" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="3" Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                                                    BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                    OnRowCommand="GridView_Visa_Follow_RowCommand" Font-Size="17px" AllowSorting="True"
                                                    GridLines="Vertical">
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="المسئول عن التنفيذ">
                                                            <ItemTemplate>
                                                                <%# Eval("pmp_name")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="تاريخ المتابعة">
                                                            <ItemTemplate>
                                                                <%# Eval("Date")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="الوقت">
                                                            <ItemTemplate>
                                                                <%# Eval("time_follow")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="وصف المتابعة">
                                                            <ItemTemplate>
                                                                <%# Eval("Descrption")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="الوثيقة">
                                                            <ItemTemplate>
                                                                <a href='<%# "ALL_Document_Details.aspx?type=outbox_follow&id="+ Eval("Follow_ID") %>'>
                                                                    <%# Eval("File_name")%></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      <%--  <asp:TemplateField HeaderText=" ارسال إيميل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit123" CommandName="SendItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Follow_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="TabPanel_All$TabPanel_Files$btn_Doc" />
    </Triggers>
    <Triggers>
        <asp:PostBackTrigger ControlID="TabPanel_All$TabPanel_Visa$Button1" />
    </Triggers>
    <Triggers>
        <asp:PostBackTrigger ControlID="TabPanel_All$TabPanel_Visa_Folow$btn_Visa_Follow" />
    </Triggers>
</asp:UpdatePanel>
