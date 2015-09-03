<%@ Control Language="C#" AutoEventWireup="true" CodeFile="permission_request.ascx.cs" Inherits="UserControls_permission_request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<style type="text/css">
    .style1
    {
        height: 16px;
    }
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                        Text="طلب إذن"></asp:Label>
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
                    <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td align="right" width="20%">
                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="القائم بالإذن :" Width="95px"
                        Height="25px" />
                </td>
                <td align="right" style="height: 51px">
                    <uc1:smart_search id="Smrt_Srch_user" runat="server" validation_group="Group1" />
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="القائم بالأعمال أثناء الإذن :"
                        Height="25px" />
                </td>
                <td align="right" style="height: 51px">
                    <uc1:smart_search id="Smrt_Srch_alter" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    <table width="100%">
                    
                         <tr>
                            <td align="right" width="50%">
                                <asp:Label ID="LabFrom" runat="server" CssClass="Label" Text="تاريخ الإذن :" />&nbsp;
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                    ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Enabled="true" AutoPostBack="True"
                                    OnTextChanged="txtStartDate_TextChanged" />
                                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                    
                                                    
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                            </td>
                           
                        </tr>
                         <tr>
                             <td colspan="2">
                                 <table width="100%">
                                     <tr>
                                         <td align="right" class="style1" width="50%">
                                             <asp:Label ID="Label8" runat="server" CssClass="Label" Text="من الساعة" />
                                             <asp:DropDownList ID="start_hour" runat="server" AutoPostBack="True" 
                                                 onselectedindexchanged="start_hour_SelectedIndexChanged">
                                                 <asp:ListItem Value="9">9</asp:ListItem>
                                                 <asp:ListItem Value="1">1</asp:ListItem>
                                             </asp:DropDownList>
                                             &nbsp;
                                         </td>
                                         <td align="right" class="style1" width="50%">
                                             <asp:Label ID="Label9" runat="server" CssClass="Label" Text="إلى الساعة" />
                                             <asp:TextBox ID="end_hour" runat="server" Enabled="False">11</asp:TextBox>
                                             &nbsp;
                                         </td>
                                     </tr>
                                 </table>
                             </td>
                         </tr>
                    </table>
                </td>
            </tr>
            <%--<tr>
                <td align="right" width="20%">
                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="عدد مرات الأذن :"
                        Height="25px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="no_days"
                        ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
                </td>
                <td align="right" style="height: 51px">
                    <asp:TextBox ID="no_days" runat="server" CssClass="Text" Width="230px" Enabled="False">1</asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="no_days_filtered" runat="server" FilterType="Custom"
                        ValidChars="0123456789" TargetControlID="no_days" />
                </td>
            </tr>--%>
            <tr>
                <td colspan="2" align="center" style="direction: ltr">
                    <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="حفظ" Width="110px"
                        OnClick="BtnVacationRequest_Click" ValidationGroup="Group1" />
                        
                             
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Group1"
                                        ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
