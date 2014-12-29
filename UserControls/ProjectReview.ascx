<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectReview.ascx.cs"
    Inherits="UserControls_ProjectReview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">

function Get_Value()
{ 
var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex + 1, dotindex);

    document.getElementById('<%= txtFileName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
</script>

<input id="Inbox_ID" runat="server" type="hidden" value="0" />
<input id="mode" runat="server" type="hidden" value="new" />
<input id="id2" runat="server" type="hidden" />
<input id="id3" runat="server" type="hidden" />
<input id="empId" runat="server" type="hidden" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="نشرات التعميم" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4" style="height: 5px">
            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px" ActiveTabIndex="1">
                <cc1:TabPanel ID="TabPanel_dtl" runat="server">
                    <HeaderTemplate>
                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="تفاصيل نشرات التعميم" /><input
                            type="hidden" runat="server" id="hidden_Id" /><input type="hidden" runat="server"
                                id="hidden_Proj_id" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table class="style2">
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="Label" Text="الكود :" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="Text" ID="txt_Code" Width="319px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="Label" Text="التاريخ :" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Date" runat="server" CssClass="Text" Width="293px"></asp:TextBox><cc1:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_Date" ValidChars="0987654321/\"
                                        Enabled="True" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                        TargetControlID="txt_Date" Enabled="True">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="اضغط لعرض النتيجة"
                                        Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" ControlToValidate="txt_Date" runat="server" Text="*"
                                            ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الموضوع :" />
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
                                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="ملاحظات :"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txt_Notes" runat="server" CssClass="Text" Height="70px" Rows="6"
                                        TextMode="MultiLine" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الإدارة التابع لها :" />
                                </td>
                                <td>
                                    <uc1:Smart_Search ID="Smart_Search_dept" runat="server"></uc1:Smart_Search>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="txt_Dept_ID_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label46" runat="server" CssClass="Label" Text="النوع :" />
                                </td>
                                <td align="right" colspan="3">
                                    <asp:RadioButtonList ID="radlst_Type" runat="server" OnSelectedIndexChanged="radlst_Type_SelectedIndexChanged"
                                        AutoPostBack="True" CssClass="Label" Font-Bold="True" CellPadding="30" CellSpacing="15"
                                        RepeatColumns="4" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="المفضلة" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="الكل" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="مديري الادارات" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="مسئولي الاتصال" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr id="tr_emp_list" runat="server">
                                <td id="Td1" runat="server">
                                    <asp:Label ID="Label47" runat="server" CssClass="Label" Text="الموظف المسئول  :" />
                                </td>
                                <td id="Td2" align="right" runat="server">
                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                        dir="rtl" class="borderControl">
                                        <asp:CheckBox ID="chk_ALL" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
                                            Text="اختر الكل" AutoPostBack="True" runat="server" OnCheckedChanged="chk_ALL_CheckedChanged">
                                        </asp:CheckBox><asp:CheckBoxList ID="chklst_Visa_Emp_All" CellPadding="5" CellSpacing="5"
                                            RepeatColumns="2" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
                                            DataTextField="pmp_name" DataValueField="PMP_ID" runat="server">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                                <td id="Td3" runat="server">
                                    <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server" CssClass="Button" /><asp:Button
                                        ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server" CssClass="Button" />
                                </td>
                                <td id="Td4" runat="server">
                                    <asp:ListBox ID="lst_emp" runat="server" Height="270px" Width="300px" Font-Size="Small">
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <br />
                                    <asp:Button ID="BtnSave" runat="server" CssClass="Button" OnClick="btnSave_Click"
                                        Text="حفــــــظ" ValidationGroup="A" Width="99px" /><asp:Button ID="btnClear" runat="server"
                                            CssClass="Button" OnClick="btnClear_Click" Text="جديد" Width="50px" />
                                    <asp:Button runat="server" CssClass="Button" Text="إرسال " ID="Button2" OnClick="btnSend_Click"
                                        ValidationGroup="A" Width="170px" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel_Files" runat="server">
                    <HeaderTemplate>
                        <asp:Label ID="Label18" runat="server" CssClass="Label" Font-Size="11px" Text="ملفات نشرات التعميم" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td align="right" width="150px">
                                    <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" /><input
                                        type="hidden" runat="server" id="hidden_Review_File_ID"></input>
                                </td>
                                <td dir="rtl">
                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                                        Width="700px" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
                                        ErrorMessage="يجب ادخال الملف " Text="*" ValidationGroup="B"></asp:RequiredFieldValidator>
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
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="B"
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="mGrid"
                                        EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="17px" ForeColor="Black"
                                        OnRowCommand="GrdView_Documents_RowCommand" Width="100%">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="الوثيقة">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=review&id="+ Eval("Review_File_ID") %>'>
                                                        <%# Eval("File_name")%></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="نوع الوثيقة">
                                                <ItemTemplate>
                                                    <%# Get_Type(Eval("Original_Or_Attached"))%></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="عرض الوثيقة">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=review&id="+ Eval("Review_File_ID") %>'>
                                                        <img id="img1" alt="عرض الوثيقة" src="../Images/Edit.jpg" style="border: 0" />
                                                    </a>
                                                </ItemTemplate>
                                                <ItemStyle Width="40px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit124" runat="server" CommandArgument='<%# Eval("Review_File_ID") %>'
                                                        CommandName="EditItem" ImageUrl="../Images/Edit.jpg" />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete0" runat="server" CommandArgument='<%# Eval("Review_File_ID") %>'
                                                        CommandName="RemoveItem" ImageUrl="../Images/delete.gif" Style="height: 22px" />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </td>
    </tr>
</table>
