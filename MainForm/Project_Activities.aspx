<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_Activities.aspx.cs" MaintainScrollPositionOnPostback="true"  Inherits="WebForms2_Project_Activities"
    Title="أنشطة المشروع" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
 
 <link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css"
        rel="stylesheet" />
    <link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css"
        rel="stylesheet" />

    <script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>

    <script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>

    <script type="text/javascript">

        function dndStartHandler(elem) {

        }
        function dndCompletingHandler(elem, newParent) {

        }
        function dndCompletedHandler2(elem) {
            var curNodeValue = elem.parentNode.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=btnPostBackTrigger2.ClientID %>').click();
        }
        function dndCompletedHandler(elem, newParent) {
            var curNodeValue = elem.getAttribute("treeNodeValue");
            var newParentValue = newParent.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
            document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
        }

        function fireClick() {
            alert('');
            document.getElementById('<%=btnPostBackTrigger3.ClientID %>').click();
            alert('');
        }

 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="أنشطة المشروع" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
                <div style="display: none">
                    <asp:TextBox ID="txtCurrentNode" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtNewParentNode" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPostBackTrigger" runat="server" OnClick="btnPostBackTrigger_Click" />
                    <asp:Button ID="btnPostBackTrigger2" runat="server" OnClick="btnPostBackTrigger2_Click"  />
                    <asp:Button ID="btnPostBackTrigger3" runat="server" OnClick="btnPostBackTrigger3_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" dir="ltr" style="background-color: #F9fdff">
                <ct:ASTreeView ID="astvMyTree" runat="server" BasePath="~/Javascript/astreeview/"
                    DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="true" EnableCheckbox="false"
                    EnableDragDrop="true" EnableTreeLines="true" EnableNodeIcon="true" BackColor="#F9FDFF"
                    EnableCustomizedNodeIcon="true" EnableContextMenu="true" EnableDebugMode="false"
                    EnableContextMenuAdd="false" OnNodeDragAndDropCompletingScript="dndCompletingHandler(elem, newParent)"
                    OnNodeSelectedScript="dndCompletedHandler2(elem)" OnNodeDragAndDropCompletedScript="dndCompletedHandler(elem, newParent)"
                    OnNodeDragAndDropStartScript="dndStartHandler(elem)" EnableMultiLineEdit="false"
                    EnableEscapeInput="false" ForeColor="#F9FDFF" OnOnSelectedNodeChanged="astvMyTree_OnSelectedNodeChanged"  />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <table width="70%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Button ID="btn_New" runat="server" CssClass="Button" Text="جديد" OnClick="btn_New_Click" />
                        </td>
                       <%-- <td>
                            <asp:Button ID="btn_New_Show" runat="server" CssClass="Button" Text="عرض" OnClick="btn_New_Show_Click" />
                        </td>--%>
                        <%--  <td>
                            <asp:Button ID="btn_New_same" runat="server" Width="150px" CssClass="Button" Text="جديد فى نفس المستوى"
                                OnClick="btn_New_same_Click" />
                        </td>--%>
                        <td>
                            <asp:Button ID="btn_New_Under" runat="server" Width="150px" CssClass="Button" Text="جديد أسفل المستوى"
                                OnClick="btn_New_Under_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btn_New_Delete" runat="server" CssClass="Button" Text="حذف" OnClick="btn_New_Delete_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btn_Mpp_Create" runat="server" CssClass="Button" Width="170px" Text="حفظ فى هيئة MPP" OnClick="btn_Mpp_Create_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDesc" runat="server" CssClass="Label" Text="وصـــف النشـاط :" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtDesc" Width="70%" TextMode="MultiLine" Rows="3" Height="70px"
                    runat="server" CssClass="Text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtDesc"
                    runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال وصـــف النشـاط "></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="الملخص :" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSummery" Width="70%" TextMode="MultiLine" Rows="3" Height="70px"
                    runat="server" CssClass="Text" />
            </td>
        </tr>
        <tr>
             <td>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="هذا النشـاط :" />
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlRelation" runat="server"  CssClass="Button" 
                    Width="100" AutoPostBack="true" 
                    onselectedindexchanged="ddlRelation_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True" Text="اختر العلاقة"></asp:ListItem>
                <asp:ListItem Value="1" Text="يبدأ عند بداية"></asp:ListItem>
                <asp:ListItem Value="2" Text="يبدأ عند نهاية"></asp:ListItem>
                <asp:ListItem Value="3" Text="ينتهى عند بداية"></asp:ListItem>
                <asp:ListItem Value="4" Text="ينتهى عند نهاية"></asp:ListItem>
                </asp:DropDownList>
                
                 &nbsp;&nbsp;&nbsp;&nbsp;
                
                 <asp:DropDownList ID="ddlActivities" runat="server"  Width="500" 
                    CssClass="Button" AutoPostBack="true" 
                    onselectedindexchanged="ddlActivities_SelectedIndexChanged"></asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="تاريخ البداية المخطط :" />
            </td>
            <td style="width: 300px">
                <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="Image1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate"


                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
               
            </td>
            <td style="width: 150px" >
                <asp:Label ID="Label9" runat="server" CssClass="Label" 
                    Text="تاريخ النهاية المخطط  :" Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" />
                <asp:ImageButton ID="ImageButton3" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton3" Format="dd/MM/yyyy" />
                <cc1:FilteredTextBoxExtender ID="txtEndDate_BoxExtender1" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="تاريخ البداية الفعلى :" />
            </td>
            <td style="width: 300px">
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtActStartDate"
                    PopupButtonID="Image111" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:TextBox ID="txtActStartDate" runat="server" CssClass="Text" />
                <asp:ImageButton runat="Server" ID="Image111" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:FilteredTextBoxExtender ID="Filtered_txtActStartDate" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtActStartDate" />
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtActStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
            <td style="width: 150px" >
                <asp:Label ID="Label30" runat="server" CssClass="Label" 
                    Text="تاريخ النهاية الفعلى :" Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="txtActEndDate" runat="server" CssClass="Text" />
                <asp:ImageButton ID="ImageButton5" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtActEndDate"
                    PopupButtonID="ImageButton5" Format="dd/MM/yyyy" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtActEndDate" />
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtActEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" align="left" CssClass="Label" Text="مدة التنفيذ :" />
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtPeriod" runat="server" CssClass="Text" Font-Bold="False" />
                <cc1:FilteredTextBoxExtender ID="filteredtxtPeriod" runat="server" FilterType="Numbers"
                    TargetControlID="txtPeriod" />
                <asp:Label ID="Label5" runat="server" CssClass="Label" Height="25px" Text="يوم" />
            </td>
            <td style="width: 150px" >
                <asp:Label ID="Label23" runat="server" CssClass="Label" Text="جهة التنفيذ :" 
                    Width="150px" />
            </td>
            <td>
                <uc1:Smart_Search ID="Smart_Search_org" runat="server" />
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="نسبة الإنجاز :" />
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txt_Progress" runat="server" CssClass="Text" />
                <cc1:FilteredTextBoxExtender ID="txtWight_FilteredTextBoxExtender" runat="server"
                    Enabled="True" FilterType="Numbers" TargetControlID="txt_Progress">
                </cc1:FilteredTextBoxExtender>
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="%" />
                <asp:RangeValidator ControlToValidate="txt_Progress" ErrorMessage="نسبة الإنجاز لا تتعدى 100 %"
                    ID="RangeValidator2" Type="Integer" runat="server" Display="Dynamic" MaximumValue="100"
                    MinimumValue="0" ValidationGroup="A">*</asp:RangeValidator>
            </td>
            <td style="width: 150px" >
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="الوزن النسبى :" 
                    Width="150px" />
            </td>
            <td>
                <asp:TextBox ID="txt_PActv_wieght" runat="server" CssClass="Text" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                    FilterType="Numbers" TargetControlID="txt_PActv_wieght">
                </cc1:FilteredTextBoxExtender>
                <asp:RangeValidator ControlToValidate="txt_PActv_wieght" ErrorMessage="الوزن النسبى لا تتعدى 100 %"
                    ID="RangeValidator1" Type="Integer" runat="server" Display="Dynamic" MaximumValue="100"
                    MinimumValue="1" ValidationGroup="A">*</asp:RangeValidator>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="مسئول التنفيذ :" />
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtExPer" runat="server" CssClass="Text" />
            </td>
            <td style="width: 150px" >
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="موقف التنفيذ :" 
                    Width="150px" />
            </td>
            <td>
                <asp:DropDownList ID="ddlActvSit" Width="200px" runat="server" CssClass="Button" />
            </td>
        </tr>
         <tr>
            <td align="right" colspan="1" dir="rtl" style="width: 99px; height: 41px;">
                <asp:Label ID="Label16" runat="server" CssClass="Label" 
                    Text="المسئول من فريق العمل:" Width="150px"
                    Height="25px" />
            </td>
            <td colspan="3" style="height: 47px; width: 200px;">
                <asp:Panel ID="PanelAssignedTeam" runat="server" BorderColor="Black" BorderWidth="1px"
                    Height="65px" Width="260%" ScrollBars="Vertical">
                    <asp:CheckBoxList ID="chkBoxTeam" runat="server"  Width="100%" SelectionMode="Multiple"
                        ForeColor="Black" Height="21px"  RepeatDirection="Vertical" />
                   
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label34" runat="server" CssClass="Label" Text="النطاق الجغرافى :" />
            </td>
            <td colspan="3" align="right">
                <asp:CheckBox ID="chkAllMain" runat="server" Text="اختر الكل" ForeColor="Black" AutoPostBack="True"
                    OnCheckedChanged="chkAllMain_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Panel ID="chk_list_panel" runat="server" Width="90%" BorderColor="Black" BorderWidth="1px">
                   
                    <asp:CheckBoxList ID="chk_gov_list" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="gov_name" DataValueField="gov_id" Width="100%" SelectionMode="Multiple"
                        ForeColor="Black" Height="80px" RepeatLayout="Flow" RepeatDirection="Horizontal" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT * FROM Governments "></asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
         <tr>
             <td>
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="الأولوية :" />
            </td>
            <td colspan="3">
                 <asp:DropDownList ID="ddlPriorities" runat="server"  CssClass="Button" 
                        Width="150px" 
                        onselectedindexchanged="ddlRelation_SelectedIndexChanged">
                    <asp:ListItem Value="0" Selected="True" Text="اختر الأولوية"></asp:ListItem>
                    <asp:ListItem Value="1" Text="اولى"></asp:ListItem>
                    <asp:ListItem Value="2" Text="ثانية"></asp:ListItem>
                    <asp:ListItem Value="3" Text="ثالثة"></asp:ListItem>
                    <asp:ListItem Value="4" Text="رابعة"></asp:ListItem>
                    <asp:ListItem Value="5" Text="خامسة"></asp:ListItem>
                    <asp:ListItem Value="6" Text="سادسة"></asp:ListItem>
                    <asp:ListItem Value="7" Text="سابعة"></asp:ListItem>
                    <asp:ListItem Value="8" Text="ثامنة"></asp:ListItem>
                    <asp:ListItem Value="9" Text="تاسعة"></asp:ListItem>
                    
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label27" runat="server" CssClass="Label" Text="ملاحظــــــات :" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtActvNote" Width="70%" TextMode="MultiLine" Rows="3" Height="70px"
                    runat="server" CssClass="Text" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" OnClick="BtnSave_Click"
                    ValidationGroup="A" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="A"
                    ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
        <tr >
            <td colspan="3">
            </td>
            <td colspan="1" align="center" style="background:orange">
                <asp:Label ID="lbl1" Text="نسبة انجاز المشروع :" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                 <asp:Label ID="lblProgProgress" runat="server"  ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td colspan="4" align="center">
                 <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" CellPadding="3" 
                        CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="10pt" 
                        Font-Strikeout="False" Font-Underline="False" ForeColor="Black" 
                        OnPreRender="gvSub_PreRender1" PagerStyle-CssClass="pgr" 
                     GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" 
                                HeaderText="م" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                <ItemTemplate>
                                    <%#Eval("Parent_Actv_Num")%>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="parent" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="180px" HeaderText="النشاط الرئيسى" ItemStyle-Width="180px">
                                <HeaderStyle Width="180px" />

<ItemStyle Width="180px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_Desc" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="200px" HeaderText=" النشاط الفرعى" ItemStyle-Width="200px">
                                <HeaderStyle Width="200px" />

<ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_Start_Date" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" 
                                HeaderText="تاريخ البدايه" ItemStyle-Width="75px">
                                <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_End_Date" DataFormatString="{0:dd/MM/yyyy}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" 
                                HeaderText="تاريخ الانتهاء" ItemStyle-Width="75px">
                                <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_Period" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="50px" HeaderText="المـده" ItemStyle-Width="50px">
                                <HeaderStyle Width="50px" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_Actual_Start_Date" 
                                DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="75px" HeaderText="تاريخ البدايه الفعلى" 
                                ItemStyle-Width="75px">
                                <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_Actual_End_Date" 
                                DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="75px" HeaderText="تاريخ الانتهاء الفعلى" 
                                ItemStyle-Width="75px">
                                <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PActv_wieght" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="50px" HeaderText="الوزن النسبى" ItemStyle-Width="50px">
                                <HeaderStyle Width="50px" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                HeaderText="نسبة الانجاز %" ItemStyle-HorizontalAlign="Center" 
                                ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLevel" runat="server" Text='<%#Eval("LVL")%>' 
                                        Visible="false" Width="50px"></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_Parent" runat="server" 
                                        Text='<%#Eval("PActv_Parent")%>' Visible="false" Width="50px"></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_ID" runat="server" Text='<%#Eval("PActv_ID")%>' 
                                        Visible="false" Width="50px"></asp:TextBox>
                                    <uc2:ProgressBar ID="SubPB" runat="server" 
                                        MainValue='<%# Eval("PActv_Progress") %>' />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PActv_Implementing_person" 
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" 
                                HeaderText="مسئول التنفيذ" ItemStyle-Width="100px">
                                <HeaderStyle Width="100px" />

<ItemStyle Width="100px"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                    </asp:GridView>
                    </td>
        </tr>
    </table>
</asp:Content>
