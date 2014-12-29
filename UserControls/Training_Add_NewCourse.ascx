<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_Add_NewCourse.ascx.cs"
    Inherits="UserControls_Training_Add_NewCourse" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .mGrid
    {
    }
    .drop
    {
        margin-bottom: 0px;
    }
    .style1
    {
        height: 52px;
    }
    .Button
    {
        height: 26px;
    }
</style>

<script language="javascript" type="text/javascript">

    function Get_Value() {
        var file_Upload = document.getElementById('<%= FileUpload1.ClientID %>').value;

        var slashindex = file_Upload.lastIndexOf("\\");
        var dotindex = file_Upload.lastIndexOf(".");

        //alert(slashindex);
        var name = file_Upload.substring(slashindex + 1, dotindex);

        document.getElementById('<%= tx_filename.ClientID %>').value = name;
        //alert('you selected the file: '+ name);
    }
</script>

<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td>
            <cc1:TabContainer runat="server" ID="TabPanel_All" ActiveTabIndex="0" Height="950px">
                <cc1:TabPanel ID="TabPanel_dtl" runat="server">
                    <HeaderTemplate>
                        <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="بيانات الدوره التدريبيه" />
                        <input type="hidden" runat="server" id="hidden_Id">
                            <input id="hidden_Proj_id" runat="server" type="hidden"></input>
                        </input>
                        </input>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td class="style1">
                                    </input>
                                    <asp:Label ID="lbl_programs" runat="server" CssClass="Label" Text="إسم البرنامج   :  "></asp:Label>
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddl_programs" runat="server" CssClass="drop" Width="200px"
                                        AutoPostBack="True" DataTextField="prog_name" DataValueField="prog_id" OnSelectedIndexChanged="ddl_programs_SelectedIndexChanged"
                                        ValidationGroup="A">
                                        <asp:ListItem Selected="True" Value="0">..... اختر البرنامج ....</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RangeValidator ID="programNameRangeV" runat="server" ControlToValidate="ddl_programs"
                                        ErrorMessage="يجب اختيار اسم البرنامج" MaximumValue="1000" MinimumValue="1" Type="Integer"
                                        ValidationGroup="A"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 198px">
                                    <asp:Label ID="lbl_course" runat="server" CssClass="Label" Text="إسم الدورة التدريبية  :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_course" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                                        DataTextField="course_name" DataValueField="course_id" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">.... اختر الدورة التريبية ....</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_course_name" runat="server" CssClass="Text" Visible="False"></asp:TextBox>
                                    <asp:RangeValidator ID="courseNameRangeV" runat="server" ControlToValidate="ddl_course"
                                        ErrorMessage="يجب اختيار الدورة التدريبية" MaximumValue="1000" MinimumValue="1"
                                        Type="Integer" ValidationGroup="A"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 198px">
                                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="إسم المسار   :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_tracks" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
                                        DataTextField="track_name" DataValueField="id">
                                        <asp:ListItem Selected="True" Value="0">..... اختر المسار ...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="Label" Text="مكان إنعقاد الدورة   :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_place" runat="server" CssClass="drop" Width="200px" DataTextField="place_desc"
                                        DataValueField="place_id">
                                        <asp:ListItem Selected="True" Value="0">..... اختر مكان الانعقاد ....</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RangeValidator ID="placeRangeV" runat="server" ControlToValidate="ddl_place"
                                        ErrorMessage="يجب اختيار مكان انعقاد الدورة" MaximumValue="1000" MinimumValue="1"
                                        Type="Integer" ValidationGroup="A"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label3" runat="server" CssClass="Label" Text="القائم بالتدريس"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tx_organization" runat="server" CssClass="Text" CausesValidation="True"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tx_organization"
                                        ErrorMessage="يجب أن يحتوي علي حروف فقط" 
                                        ValidationExpression="^([\u0600-\u06FF'\s]{3,100})$|^([a-zA-z '\s]{3,100})$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label4" runat="server" CssClass="Label" Text="اخر تاريخ للتسجيل"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tx_lastgenertiondate" runat="server" CssClass="Text" 
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                    <cc1:CalendarExtender ID="tx_lastgenertiondateCalendarExtender1" runat="server" TargetControlID="tx_lastgenertiondate"
                                        PopupButtonID="ImageButton2" Format="dd/MM/yyyy" Enabled="True" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*"
                                        ErrorMessage="مطلوب ادخال اخر معاد للتسجيل" ControlToValidate="tx_lastgenertiondate" ValidationGroup="A"
                                        ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorreg_date" runat="server"
                                        ControlToValidate="tx_lastgenertiondate" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                        ></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="regDateCompVal" runat="server" ControlToValidate="tx_lastgenertiondate"
                                        ErrorMessage="يجب ان يكون اخر تاريخ للتسجيل لا يسبق اليوم و ليس اليوم" Operator="GreaterThan"
                                        ValueToCompare="<%# DateTime.Today.ToShortDateString() %>" Type="Date"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label5" runat="server" CssClass="Label" Text="عدد الموظفين المطلوب"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tx_noofemployee" runat="server" CssClass="Text" 
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="يجب ادخال ارقام فقط "
                                        ControlToValidate="tx_noofemployee" Operator="DataTypeCheck" Type="Integer" ValidationGroup="A"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="ادخل عدد الموظفين المطلوب "
                                        ControlToValidate="tx_noofemployee" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tx_noofemployee"
                                        ValidChars="0987654321" Enabled="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label6" runat="server" CssClass="Label" Text="تاريخ البدء"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_startdate" runat="server" CssClass="Text" 
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_startdate"
                                        PopupButtonID="ImageButton1" Format="dd/MM/yyyy" Enabled="True" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="*"
                                        ErrorMessage="مطلوب ادخال تاريخ بدايه الدوره التدريبيه" ControlToValidate="txt_startdate" ValidationGroup="A"
                                        ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_startdate"
                                        ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)" 

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="tx_lastgenertiondate"
                                        ControlToValidate="txt_startdate" ErrorMessage="CompareValidator" Operator="GreaterThanEqual"
                                        Type="Date" >يجب 
                             ان يكون تاريخ بدايه الدوره التدريبيه لا يسبق اخر معاد للتسجيل</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label7" runat="server" CssClass="Label" Text="تاريخ النهايه"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_enddate" runat="server" CssClass="Text" 
                                        CausesValidation="True"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="اضغط لعرض النتيجة"
                                        Height="22px" ImageUrl="~/images/Calendar_scheduleHS.png" ToolTip="تقويم" Width="22px" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                        PopupButtonID="ImageButton3" TargetControlID="txt_enddate">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_enddate"
                                        ErrorMessage="مطلوب ادخال معاد انتهاء الدوره التدريبيه" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_enddate"
                                        ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)" 
                                        
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txt_startdate"
                                        ControlToValidate="txt_enddate" ErrorMessage="CompareValidator" Operator="GreaterThanEqual"
                                        Type="Date" >يجب ان 
                                 يكون تاريخ نهايه الدوره التدريبيه اكبر من تاريخ البدايه</asp:CompareValidator>
                                </td>
                                <tr>
                                    <td>
                                        <asp:Label ID="label26" runat="server" CssClass="Label" Text="المده بالايام"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_duration" runat="server" CssClass="Text" ValidationGroup="A"
                                            CausesValidation="True"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ValidationGroup="A" ControlToValidate="txt_duration"
                                            ErrorMessage="يجب ادخال ارقام فقط " Operator="DataTypeCheck" Type="Integer" Display="Dynamic"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_duration"
                                            ErrorMessage="ادخل  مده الدوره التدريبيه"  Display="Dynamic"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                            TargetControlID="txt_duration" ValidChars="0987654321">
                                        </cc1:FilteredTextBoxExtender>
                                        <asp:CompareValidator ID="CourseDurationVal" runat="server" ControlToValidate="txt_duration"
                                            Display="Dynamic" ErrorMessage="لا يجب أن تزيد المدة عن الفترة ما بين تاريخ البدء و الانتهاء للدورة"
                                            Type="Double"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_cost" runat="server" CssClass="Label" Text=" القيمة المالية"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_cost" runat="server" CssClass="Text" ValidationGroup="A" CausesValidation="True"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True"
                                            TargetControlID="txt_duration" ValidChars="0987654321">
                                        </cc1:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_cost"
                                            ErrorMessage="ادخل القيمة المالية " ValidationGroup="A" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="costRegExpVal" runat="server" ControlToValidate="txt_cost"
                                            Display="Dynamic" ErrorMessage="القيمة المالية تقبل فقظ أرقام صحيحة أو عشريه"
                                            ValidationExpression="\d*(\.\d+)?" SetFocusOnError="True" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label10" runat="server" CssClass="Label" Text="شروط الترشح"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_candidatescriterea" runat="server" CssClass="Text" Height="137px"
                                            TextMode="MultiLine" Width="385px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="label27" runat="server" CssClass="Label" Text="المرجعيه"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_refrences" runat="server" AutoPostBack="True" CssClass="drop"
                                            OnSelectedIndexChanged="ddl_refrences_SelectedIndexChanged">
                                            <asp:ListItem Value="0">--اختر مرجعيه--</asp:ListItem>
                                            <asp:ListItem Value="1">البريد الالكتروني</asp:ListItem>
                                            <asp:ListItem Value="2">موارد بشريه</asp:ListItem>
                                            <asp:ListItem Value="4">المطالب التدريبيه للقطاع</asp:ListItem>
                                            <asp:ListItem Value="3">اخري</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="email_tr" runat="server" visible="False">
                                    <td runat="server">
                                        <asp:Label ID="label28" runat="server" CssClass="Label" Text="الايميل"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:DropDownList ID="ddl_email" runat="server" AutoPostBack="True" CssClass="drop"
                                            DataSourceID="SqlDataSource1" DataTextField="Subject" DataValueField="ID" OnSelectedIndexChanged="ddl_refrences_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            SelectCommand="SELECT Inbox.Subject, Inbox_Track_Emp.Emp_ID, Inbox.ID FROM Inbox INNER JOIN Inbox_Track_Emp ON Inbox.ID = Inbox_Track_Emp.inbox_id WHERE (Inbox_Track_Emp.Emp_ID = @emp_id)">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="emp_id" SessionField="pmp_id" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr id="refrence_files" runat="server" visible="False">
                                    <td runat="server">
                                        <asp:Label ID="label11" runat="server" CssClass="Label" Text="ملف المرجعيه"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:FileUpload ID="FileUpload_refrencefiles" runat="server" />
                                    </td>
                                </tr>
                                <tr id="gridviewfiles_tr" runat="server" visble="false">
                                    <td runat="server">
                                        <asp:Label ID="الملفات" runat="server" CssClass="Label" Text="الملفات"></asp:Label>
                                    </td>
                                    <td runat="server">
                                        <asp:GridView ID="gv_referancefile" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="mGrid"
                                            Font-Size="17px" ForeColor="Black" GridLines="Vertical" OnRowCommand="gv_referancefile_RowCommand"
                                            utoGenerateColumns="False" Width="100%">
                                            <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="الوثيقة">
                                                    <ItemTemplate>
                                                        <a href='<%# "ALL_Document_Details.aspx?type=training&category=2&id="+ Eval("id") %>'>
                                                            <%# Eval("file_name")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="حذف">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" CommandArgument='<%#Eval("id")%>'
                                                            CommandName="RemoveItem" ImageUrl="../Images/delete.gif" Style="height: 22px" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <PagerStyle BackColor="#999999" CssClass="pgr" ForeColor="Black" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" CssClass="Label" Text="ملاحظات"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_desc" runat="server" CssClass="Text" Height="69px" TextMode="MultiLine"
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="nextbutton" runat="server" CssClass="Button" OnClick="nextbutton_Click"
                                            Text="حفظ" ValidationGroup="A" />
                                        <asp:Button ID="btn_sendmail" runat="server" CssClass="Button" OnClick="btn_sendmail_Click"
                                            Text="ارسال ايميل" Visible="False" />
                                    </td>
                                </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel_files" runat="server">
                    <HeaderTemplate>
                        <asp:Label ID="Label24" runat="server" CssClass="Label" Font-Size="11px" Text="ملفات وصف الدوره التدريبيه" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="label8" runat="server" CssClass="Label" Text="اختر  ملف"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label9" runat="server" CssClass="Label" Text="اسم الملف"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tx_filename" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="Button3" Text="حفظ" runat="server" CssClass="Button" OnClick="Button3_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gv_files" runat="server" AutoGenerateColumns="False" utoGenerateColumns="False"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                        BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                                        OnRowCommand="gv_files_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="الوثيقة">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=training&category=1&id="+ Eval("id") %>'>
                                                        <%# Eval("file_name")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%#Eval("id")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                        <AlternatingRowStyle CssClass="alt" />
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
