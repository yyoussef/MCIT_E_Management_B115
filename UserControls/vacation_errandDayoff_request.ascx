﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacation_errandDayoff_request.ascx.cs" Inherits="UserControls_vacation_errandDayoff_request" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<style type="text/css">
    .style1
    {
        height: 44px;
    }
</style>

<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;" dir=rtl >
    <tr>
        <td  align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                Text="طلب مأمورية"></asp:Label>
                <asp:HiddenField ID="vac_id" Value="0" runat="server" />
        </td>
    </tr>
    <tr>
        <td  align="center" colspan="2" class="style1">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Label24" runat="server" CssClass="Label" Text=" : يوم عطلة" Width="95px"
                Height="25px" style="direction: ltr" />
        </td>
        <td align="right" dir="rtl">
            <asp:CheckBox ID="ChkdayOff"  runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right"  width="20%">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="القائم بالمأمورية :"
                Height="25px" />
        </td>
        <td align="right"  style="height: 51px">
            <uc1:Smart_Search ID="Smrt_Srch_user" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%">
                <tr>
                    <td align="right"  width="50%">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text="من" />&nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                            PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                            ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Enabled="true" />
                        
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                    </td>
                    <td align="right"  width="50%">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="إلى" />&nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                            PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                            ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" Enabled="true" />
                        <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                            
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                    </td>
                 </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%">
                <tr>
                    <td align="right"  width="50%">
                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="من الساعة" />&nbsp;
                        <asp:DropDownList ID="start_hour" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right"  width="50%">
                        <asp:Label ID="Label9" runat="server" CssClass="Label" Text="إلى الساعة" />&nbsp;
                        <asp:DropDownList ID="end_hour" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                 </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right"  width="20%">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الغرض :" Width="95px"
                Height="25px" />
        </td>
        <td align="right"  style="height: 51px">
            <asp:TextBox ID="purpose" runat="server" Width="400px" Height="100px" 
                TextMode="MultiLine"></asp:TextBox>                          
        </td>
    </tr>
     <tr>
        <td align="right"  width="20%">
            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="ملاحظات :" Width="95px"
                Height="25px" />
        </td>
        <td align="right"  style="height: 51px">
            <asp:TextBox ID="notes" runat="server" Width="400px" Height="100px" 
                TextMode="MultiLine"></asp:TextBox>                          
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center" style="direction: ltr">
            <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" 
                Text="حفظ" Width="110px" onclick="BtnVacationRequest_Click" 
                ValidationGroup="Group1" />
        </td>
    </tr>
</table>
