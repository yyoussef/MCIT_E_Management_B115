<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Protocol_Def.aspx.cs" Inherits="WebForms_Protocol_Def" Title="بروتوكولات / اتفاقيات" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
   function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('square_arrow_flipped') != -1)
       { img.src = "../Images/square_arrow_down.gif";
        }
    else
        {img.src = "../Images/square_arrow_flipped.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}

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

    </script>
    <input id="hidden_Balance_ID" type="hidden" runat="server" />
    <table width="100%" style="line-height: 2; color: Black">
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="بروتوكولات / اتفاقيات"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                <input type="hidden" runat="server" id="hidden_Protocol_ID" />
                <input type="hidden" runat="server" id="hidden_Status" value="1" />
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" style="height: 61px">
                <table width="100%">
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" الاسم : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Name" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Name"
                                runat="server" Text="*"  ValidationGroup="A" ErrorMessage="يجب ادخال الاسم "></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label14" runat="server" CssClass="Label" Text=" النوع : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" تاريخ البداية : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Signt_Str_DT" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="txt_Signt_Str_DT" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="txt_Signt_Str_DT">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Signt_Str_DT"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" تاريخ النهاية : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Signt_End_DT" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                TargetControlID="txt_Signt_End_DT" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                TargetControlID="txt_Signt_End_DT">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Signt_End_DT"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="الميزانية الكلية بالجنيه : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Total_Balance_LE" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="Filteredtxt_Total_Balance_LE" runat="server" FilterType="Numbers"
                                TargetControlID="txt_Total_Balance_LE" />
                            <asp:Label ID="labelle" runat="server" Text="ج.م" Font-Size="14pt" />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="الميزانية الكلية بالدولار : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Total_Balance_US" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="filteredTxt_Total_Balance_US" runat="server" FilterType="Numbers"
                                TargetControlID="txt_Total_Balance_US" />
                            <asp:Label ID="label9" runat="server" Text="دولار" Font-Size="14pt" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" الجهة المشاركة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:DropDownList ID="ddl_Org_ID" runat="server" CssClass="drop">
                            </asp:DropDownList>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" المسئول : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:DropDownList ID="ddl_PMP_ID" runat="server" CssClass="drop">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text=" تاريخ التوقيع : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txtsigndate" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="Filteredtxtsigndate" runat="server" FilterType="Custom"
                                TargetControlID="txtsigndate" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                                TargetControlID="txtsigndate">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtsigndate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text=" تاريخ موافقة السلطة المختصة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txtAuthortyApprovDate" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTxtAuthortyApprovDate" runat="server" FilterType="Custom"
                                TargetControlID="txtAuthortyApprovDate" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3"
                                TargetControlID="txtAuthortyApprovDate">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton3" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAuthortyApprovDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label11" runat="server" CssClass="Label" Text="رقم موافقة السلطة المختصة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txtApprovalNum" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text=" السلطة المختصة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txtApprovalAuthority" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label25" runat="server" CssClass="Label" Text="إمضاء السلطة المختصة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:CheckBox ID="chk_Sign_Authority" runat="server" />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label26" runat="server" CssClass="Label" Text=" وظيفة السلطة المختصة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Job_Authority" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="إمضاء الجهة المشاركة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:CheckBox ID="chk_Sign_Org" runat="server" />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text=" وظيفة الجهة المشاركة : " />
                        </td>
                        <td align="right" dir="rtl">
                            <asp:TextBox ID="txt_Job_Org" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                    ValidationGroup="A" Width="99px" />
                    
                    
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btn_New" OnClick="btn_New_Click"
                    Width="99px" />
            </td>
        </tr>
        <tr style="width: 100%">
            <td valign="top" align="right">
                <table id="first_table_reports" cellpadding="0" cellspacing="0" style="height: 27px;
                    width: 100%;">
                    <tr id="firstreports" >
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','img0');">
                            <img border="0" id="img0" src="../Images/square_arrow_down.gif" />
                        </td>
                        <td 
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','img0');"
                            colspan="2">
                            الميزانية
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="firts_tr_reports">
            <td>
                <div id="div0" style="display: block" dir="rtl">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" CssClass="Label" Text=" من : " />
                                <input type="hidden" runat="server" id="hidden_balance_period_ID" />
                            </td>
                            <td align="right" dir="rtl">
                                <asp:TextBox ID="txtFrom" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredtxtFrom" runat="server" FilterType="Custom"
                                    TargetControlID="txtFrom" ValidChars="0987654321/\" />
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton4"
                                    TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="ImageButton4" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                    Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                    
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFrom"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="B" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" CssClass="Label" Text=" إلى : " />
                            </td>
                            <td align="right" dir="rtl">
                                <asp:TextBox ID="txtTo" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredtxtTo" runat="server" FilterType="Custom"
                                    TargetControlID="txtTo" ValidChars="0987654321/\" />
                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton5"
                                    TargetControlID="txtTo">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="ImageButton5" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                    Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTo"


                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="B" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" dir="rtl">
                                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="المبلغ بالجنيه : " />
                            </td>
                            <td align="right" dir="rtl">
                                <asp:TextBox ID="txtAmountLE" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                <asp:Label ID="label19" runat="server" Text="جنيه" Font-Size="14pt" />
                                <cc1:FilteredTextBoxExtender ID="FilteredtxtAmountLE" runat="server" FilterType="Numbers"
                                    TargetControlID="txtAmountLE" />
                            </td>
                            <td align="right" dir="rtl">
                                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="المبلغ بالدولار : " />
                            </td>
                            <td align="right" dir="rtl">
                                <asp:TextBox ID="txtAmountUS" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                <asp:Label ID="label21" runat="server" Text="دولار" Font-Size="14pt" />
                                <cc1:FilteredTextBoxExtender ID="FilteredtxtAmountUS" runat="server" FilterType="Numbers"
                                    TargetControlID="txtAmountUS" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" style="height: 26px">
                                <asp:Button ID="btn_period_balance" OnClick="btn_balance_period_Click" Enabled="false"
                                    Text="حفظ فترة" Width="100px" runat="server" CssClass="Button"   ValidationGroup="B" />
                                    
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="B"
                                        ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="grdView_periods" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="grdView_Periods_RowCommand"
                                    Font-Size="17px" GridLines="Vertical">
                                    <Columns>
                                        <asp:BoundField HeaderText="الفترة من" DataField="From_DT" />
                                        <asp:BoundField HeaderText="الفترة إلى" DataField="To_DT" />
                                        <asp:BoundField HeaderText="المبلغ بالجنيه" DataField="Amount_LE" />
                                        <asp:BoundField HeaderText="المبلغ بالدولار" DataField="Amount_US" />
                                        <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <input id="hidden_Balance_ID" runat="server" type="hidden" value='<%# Eval("Protocol_Balance_ID") %>' />
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                    CommandArgument='<%# Eval("Protocol_Balance_ID") %>' />
                                            </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                    Style="height: 22px" CommandArgument='<%# Eval("Protocol_Balance_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                            </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                                        </asp:TemplateField>
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
                </div>
            </td>
        </tr>
        <tr style="width: 100%">
            <td valign="top" align="right">
                <table id="Table1" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                    <tr id="Tr1" >
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','img1');">
                            <img border="0" id="img1" src="../Images/square_arrow_down.gif" />
                        </td>
                        <td 
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','img1');"
                            colspan="2">
                            الملفات
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="Tr2">
            <td>
                <div id="div1" style="display: block" dir="rtl">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="الوثيقة الرئيسية :"
                                    Width="135px" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Parent_ID" runat="server" CssClass="drop">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="6" valign="top">
                             <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px" 
                                            dir="rtl" align="right">
                                            <asp:TreeView ID="Tree_Files" ExpandDepth="1" runat="server" ImageSet="Simple" 
                                                Font-Bold="True" ForeColor="Black" 
                                                ShowCheckBoxes="None" Height="187px">
                                                <NodeStyle ForeColor="#808080" font-underline="false" Font-Bold="true" Font-Size="Medium" />
                                                <SelectedNodeStyle BackColor="WhiteSmoke" ForeColor="Black" />
                                                <ParentNodeStyle CssClass="Label" />
                                            </asp:TreeView>
                                        </div>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" CssClass="Label" Text="الوثيقة:" />
                                <input type="hidden" runat="server" id="hidden_Doc_ID" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                                    Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="Text" ID="txtFileName"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="نوع الوثيقة:" Width="135px" />
                                <input type="hidden" runat="server" id="hidden1" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_File_Kind" runat="server" CssClass="drop">
                                    <asp:ListItem Text="اتفاقية/بروتوكول" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="مخاطبات" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="موافقات" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="أمر شغل /نطاق أعمال" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" CssClass="Label" Text="تاريخ الوثيقة: " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_File_Date" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                    TargetControlID="txt_File_Date" ValidChars="0987654321/\" />
                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton6"
                                    TargetControlID="txt_File_Date">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="ImageButton6" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                    Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                    
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_File_Date"


                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="C" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="وصف الوثيقة:" Width="135px" />
                                <input type="hidden" runat="server" id="hidden2" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="Text" ID="txt_File_desc" TextMode="MultiLine"
                                    Rows="4" Height="50px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <br />
                                <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Enabled="false" Text="حفظ الوثيقة"
                                    runat="server" CssClass="Button" ValidationGroup="C" />
                                       <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="C"
                                        ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                                    Font-Size="17px" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="الوثيقة">
                                            <ItemTemplate>
                                                <a href='<%# "ALL_Document_Details.aspx?type=protocoldef&id="+ Eval("id") %>'>
                                                    <%# Eval("File_name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="نوع الوثيقة">
                                            <ItemTemplate>
                                                <%# Get_Type(Eval("File_Kind"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الوثيقة">
                                            <ItemTemplate>
                                                <%# Eval("File_Date")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="وصف الوثيقة">
                                            <ItemTemplate>
                                                <%# Eval("File_desc")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                    CommandArgument='<%# Eval("ID") %>' />
                                            </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                    Style="height: 22px" CommandArgument='<%# Eval("ID") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                            </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                                        </asp:TemplateField>
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="grd_View_Mng" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    OnRowCommand="GrdView_RowCommand" Font-Size="17px" Visible="False" 
                    GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="الاسم" DataField="Name" />
                        <asp:BoundField HeaderText="النوع" DataField="Type_Name" />
                        <asp:BoundField HeaderText="تاريخ البداية" DataField="Signt_Str_DT" />
                        <asp:BoundField HeaderText=" تاريخ النهاية" DataField="Signt_End_DT" />
                        <asp:BoundField HeaderText=" الميزانية الكلية بالجنيه" DataField="Total_Balance_LE" />
                        <asp:BoundField HeaderText=" الميزانية الكلية بالدولار" DataField="Total_Balance_US" />
                        <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("Protocol_ID") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="20px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px" CommandArgument='<%# Eval("Protocol_ID") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                            </ItemTemplate>
                            <ItemStyle Width="20px"></ItemStyle>
                        </asp:TemplateField>
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
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>
