<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacation_request.ascx.cs"
    Inherits="UserControls_vacation_request" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                Text="طلب أجازة"></asp:Label>
            <asp:HiddenField ID="vac_id" Value="0" runat="server" />
            <asp:HiddenField ID="vac_days" Value="0" runat="server" />
            <asp:HiddenField ID="vac_field_name" Value="" runat="server" />
            <asp:HiddenField ID="manager_approve" Value="" runat="server" />
            <asp:HiddenField ID="hidden_StartDate" Value="" runat="server" />
            <asp:HiddenField ID="hidden_EndDate" Value="" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
           
        </td>
    </tr>
    <tr>
        <td align="right" width="20%">
            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="نوع الأجازة :" Width="95px"
                Height="25px" />
        </td>
        <td align="right" style="height: 51px">
            <asp:DropDownList ID="DDLVacationType" runat="server" CssClass="Button" Width="230px"
                Height="25px" DataTextField="vacation_title" DataValueField="id" OnDataBinding="DDLVacationType_DataBinding"
                AutoPostBack="false" />
            &nbsp;
            <asp:Label ID="lblPageStatus0" runat="server" CssClass="Label" ForeColor="Red">الأجازة 
            الإعتيادية يجب أن تقدم قبلها بيومين </asp:Label>
            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT id, vacation_title FROM Vacations"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td align="right" width="20%">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="القائم بالأجازة :" Width="95px"
                Height="25px" />
        </td>
        <td align="right" style="height: 51px">
            <uc1:Smart_Search ID="Smrt_Srch_user" runat="server" Validation_Group="Group1" />
        </td>
    </tr>
    <tr>
        <td align="right" width="20%">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="القائم بالأعمال أثناء الأجازة :"
                Height="25px" />
        </td>
        <td align="right" style="height: 51px">
            <uc1:Smart_Search ID="Smrt_Srch_alter" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="LabFrom" runat="server" CssClass="Label" Text="من" />&nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                            PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                            ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Enabled="true" AutoPostBack="True"
                            OnTextChanged="txtStartDate_TextChanged" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                            
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStartDate"
                                
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                    </td>
                    <td align="right" width="50%" id="td_to" runat="server">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="إلى" />&nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                            PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                            ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" Enabled="true" AutoPostBack="True"
                            OnTextChanged="txtEndDate_TextChanged" />
                            
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right" width="20%">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="تحميل الملف الإجازة" />
        </td>
        <td>
            <asp:FileUpload ID="voc_file" runat="server" CssClass="Text" />
        </td>
    </tr>
    <tr>
        <td align="right" width="20%" valign="top">
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="ملاحظة" />
        </td>
        <td>
            <asp:TextBox ID="txt_note" TextMode="MultiLine" CssClass="Text" runat="server" Height="89px"
                Width="506px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="20%">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="عدد أيام الأجازة :"
                Height="25px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="no_days"
                ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
        </td>
        <td align="right" style="height: 51px">
            <asp:TextBox ID="no_days" runat="server" CssClass="Text" Width="230px" Enabled="False">1</asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="no_days_filtered" runat="server" FilterType="Custom"
                ValidChars="0123456789" TargetControlID="no_days" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center" style="direction: ltr">
            <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="حفظ" Width="110px"
                OnClick="BtnVacationRequest_Click" ValidationGroup="Group1" />
                
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Group1"
                                        ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
</table>
