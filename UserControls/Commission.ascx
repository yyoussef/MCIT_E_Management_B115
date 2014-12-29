<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commission.ascx.cs" Inherits="UserControls_Commission" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function showalert() {
        alert('1');
        var choose_val = false;
        if (confirm('هل تود الحذف نهائياً') == true) {
            document.getElementById('<%= send_id.ClientID %>').value = "1";
            choose_val = true;
        }
        else {
            document.getElementById('<%= send_id.ClientID %>').value = "1";
            choose_val = false;
        }
        alert(choose_val);
        return choose_val;
    }
    function Get_Value() {
        var file_Upload = document.getElementById('<%= FileUpload1.ClientID %>').value;

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
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr>
                <td align="center" colspan="4" style="height: 33px">
                    <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="التكليفات" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" style="height: 5px">
                    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <input type="hidden" runat="server" id="hidden_Id" />
                    <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px" ActiveTabIndex="1">
                        <cc1:TabPanel ID="TabPanel_Visa" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label24" runat="server" CssClass="Label" Font-Size="11px" Text="تفاصيل التكليف" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الموضوع :" />
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Subject" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_Subject"
                                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال الموضوع "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="تاريخ التكليف :" Width="135px" />
                                            <input type="hidden" runat="server" id="hidden_Visa_Id"></input>
                                        </td>
                                        <td dir="rtl">
                                            <asp:TextBox ID="txt_Visa_date" runat="server" CssClass="Text" Width="270px" OnTextChanged="txt_Visa_date_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_Visa_date"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3"
                                                TargetControlID="txt_Visa_date" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_Visa_date"
                                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال تاريخ التاشيرة "></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Visa_date"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="B" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label29" runat="server" CssClass="Label" Text="درجة الأهمية: " Width="100px" />
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
                                            <asp:TextBox ID="txt_Dead_Line_DT" runat="server" AutoPostBack="True" OnTextChanged="txt_Dead_Line_DT_TextChanged"
                                                CssClass="Text" Width="270px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_Dead_Line_DT"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton33"
                                                TargetControlID="txt_Dead_Line_DT" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton33" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Dead_Line_DT"
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
                                                <asp:ListItem Text="للتحدث" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="للحفظ" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="المدة  :" Width="135px" />
                                        </td>
                                        <td dir="rtl" colspan="3">
                                            <asp:Label ID="lbl_period" runat="server" CssClass="Label" ForeColor="Red" />
                                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="يوم" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--
                                            <td>
                                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="القطاع :" />
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="drop_sectors" AutoPostBack="True" OnSelectedIndexChanged="drop_sectors_SelectedIndexChanged"
                                                    runat="server" CssClass="drop" Width="314px"    DataTextField="Sec_name" DataValueField="Sec_id">
                                                </asp:DropDownList>
                                            </td>
                                              <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الإدارة التابع لها :" />
                                </td>
                                <td>
                                    <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
                                </td>
                               
                           
                            --%>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="  الإدارة  :" CssClass="Label" Font-Underline="False"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
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
                                                AutoPostBack="True" CssClass="Label" Font-Bold="True" CellPadding="2" CellSpacing="1"
                                                RepeatColumns="6" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="المفضلة" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="الكل" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="مديري الادارات" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="مسئولي الاتصال" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="  رؤساء اللجان" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="رؤساء الاقسام " Value="6"></asp:ListItem>
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
                                                </asp:CheckBox>
                                                <asp:CheckBoxList ID="chklst_Visa_Emp_All" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                                                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                    DataValueField="PMP_ID" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                        <td id="Td3" runat="server">
                                            <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server" CssClass="Button" />
                                            <asp:Button ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server"
                                                CssClass="Button" />
                                        </td>
                                        <td id="Td4" runat="server">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                dir="rtl" class="borderControl">
                                                <asp:ListBox ID="lst_emp" runat="server" Height="270px" Width="300px" Font-Size="Small">
                                                </asp:ListBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الموظف المسئول عن اغلاق التكليف  :" />
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="drop_Resp_close_emp" runat="server" CssClass="drop" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr_old_emp" runat="server">
                                        <td id="Td5" runat="server">
                                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="المسئول عن التنفيذ :" />
                                        </td>
                                        <td id="Td6" align="right" colspan="3" runat="server">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                dir="rtl">
                                                <asp:CheckBoxList ID="chklst_Visa_Emp" CellPadding="5" CellSpacing="5" RepeatColumns="6"
                                                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                    DataValueField="PMP_ID" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="txt_Emp_ID_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text="نص التكليف :" />
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Visa_Desc" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_Visa_Desc"
                                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال وصف التكليف "></asp:RequiredFieldValidator>
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
                                            <asp:Button ID="Button1" OnClick="btn_Visa_Click" ValidationGroup="B" Text="حفظ"
                                                runat="server" CssClass="Button" />
                                            <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btnClear" OnClick="btnClear_Click"
                                                Width="50px" />
                                            <asp:Button runat="server" CssClass="Button" Text="إرســال" ID="btn_send" OnClick="btn_send_Click"
                                                Width="70px" />
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
                                                                <asp:CheckBox ID="chkSent" runat="server" AutoPostBack="true" OnCheckedChanged="chkSent_CheckedChanged" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" ارسال إيميل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit123" CommandName="SendItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Visa_Id") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="تعديل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Visa_Id") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="حذف">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                    Style="height: 22px" CommandArgument='<%# Eval("Visa_Id") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%-- <cc1:TabPanel ID="TabPanel_dtl" runat="server">
                    <HeaderTemplate>
                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text=" التكليف" />
                        
                        <input type="hidden" runat="server" id="hidden_Proj_id" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="Label" Text="الكود :" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="Text" ID="txt_Code" Width="319px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="Label" Text="تاريخ التكليف :" />
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
                                </td>
                            </tr>
                            <tr visible="false">
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlMainCat" runat="server" CssClass="Button" AutoPostBack="True"
                                        Width="300px" OnSelectedIndexChanged="ddlMainCat_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                          <tr>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlSubCat" runat="server" CssClass="Button" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="4" align="center">
                                    <br />
                                    <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                                        ValidationGroup="A" Width="99px" />
                                   
                                      <asp:Button runat="server" CssClass="Button" OnClientClick="if (confirm('هل تود ارسال ايميل الى المدير المختص') == false) return false;"
                                        Text="ارسال إلي المدير المختص" ID="Button2" OnClick="btnSend_Click" ValidationGroup="A"
                                        Width="170px" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>--%>
                        <cc1:TabPanel ID="TabPanel_Files" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label18" runat="server" CssClass="Label" Font-Size="11px" Text="ملفات التكليف" />
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
                                            <input type="hidden" runat="server" id="send_id"></input>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" onchange="Get_Value()"
                                                Width="700px"></asp:FileUpload>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <br />
                                            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
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
                                                            <a href='<%# "ALL_Document_Details.aspx?type=Commission&id="+ Eval("Commission_File_ID") %>'>
                                                                <%# Eval("File_name")%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نوع الوثيقة">
                                                        <ItemTemplate>
                                                            <%# Get_Type(Eval("Original_Or_Attached"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="عرض الوثيقة">
                                                        <ItemTemplate>
                                                            <a href='<%# "ALL_Document_Details.aspx?type=Commission&id="+ Eval("Commission_File_ID") %>'>
                                                                <img src="../Images/Edit.jpg" id="img1" alt="عرض الوثيقة" style="border: 0" />
                                                            </a>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Commission_File_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Commission_File_ID") %>' />
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
                        <cc1:TabPanel ID="TabPanel_Visa_Folow" runat="server">
                            <HeaderTemplate>
                                <asp:Label ID="Label6" runat="server" CssClass="Label" Font-Size="11px" Text="المسير" />
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label36" runat="server" CssClass="Label" Text="المسئول عن التنفيذ:"
                                                Width="135px" />
                                            <input type="hidden" runat="server" id="hidden_Follow_ID"></input>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                            <asp:Label ID="Label37" runat="server" CssClass="Label" Text="وصف المتابعة: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Descrption" runat="server" CssClass="Text" Height="70px" Width="90%"
                                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Descrption"
                                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال وصف المتابعة "></asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label38" runat="server" CssClass="Label" Width="293px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label39" runat="server" CssClass="Label" Text="تاريخ المتابعة :" Width="135px" />
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
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Follow_Date"
                                                Text="*" ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                                ValidationGroup="VF" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة "></asp:RegularExpressionValidator>
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="150px">
                                            <asp:Label ID="Label40" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                                        </td>
                                        <td dir="rtl" colspan="3">
                                            <asp:FileUpload ID="FileUpload_Visa_Follow" runat="server" onchange="Get_Value()"
                                                ForeColor="Maroon" Width="700px" />
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
                                            <asp:GridView ID="GridView_Visa_Follow" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView_Visa_Follow_RowCommand"
                                                Width="100%">
                                                <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
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
                                                            <a href='<%# "ALL_Document_Details.aspx?type=inbox_follow&id="+ Eval("Follow_ID") %>'>
                                                                <%# Eval("File_name")%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" ارسال إيميل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit123" runat="server" CommandArgument='<%# Eval("Follow_ID") %>'
                                                                CommandName="SendItem" ImageUrl="../Images/Edit.jpg" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle BackColor="#999999" CssClass="pgr" ForeColor="Black" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            <br />
                                            <asp:Button runat="server" CssClass="Button" Text="طباعة تقرير المسير" ID="btn_print_report"
                                                OnClick="btn_print_report_Click" Width="150px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 450px">
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
