<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Change_Password.ascx.cs"
    Inherits="UserControls_Change_Password" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 369px;
        height: 35px;
    }
    .style2
    {
        height: 35px;
    }
    .style3
    {
        height: 39px;
    }
</style>
<table dir="rtl" style="line-height: 2; width: 85%;">
    <tr align="center">
        <td dir="rtl" align="left" style="width: 369px; height: 35px;">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم المستخدم:" />
        </td>
        <td align="right">
            <asp:Label ID="Label2" runat="server" CssClass="Label" />
        </td>
    </tr>
    <tr align="center">
        <td dir="rtl" style="width: 369px; height: 35px;" align="left">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="كلمة السر الحالية:" />
        </td>
        <td align="right">
            <asp:TextBox runat="server" CssClass="Text" ID="TxtRecentPass" MaxLength="20" Width="200px" TextMode="Password" autocomplete="off"></asp:TextBox>
        </td>
    </tr>
    <tr align="center">
        <td dir="rtl" style="width: 369px; height: 35px;" align="left">
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة السر الجديدة:" />
        </td>
        <td align="right">
            <asp:TextBox runat="server" CssClass="Text" ID="TxtNewPassword" Width="200px"  
                TextMode="Password"  autocomplete="off"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtNewPassword"
                Display="None" ValidationExpression="^.*(?=.{8,})(?=.*[a-z])(?=.*[\d\W]).*$"
                ValidationGroup="change" ErrorMessage=" برجاء عدم استخدام الأسماء او الكلمات.استخدم خليط من الحروف و الأرقام و العلامات "></asp:RegularExpressionValidator>
            <cc1:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" TargetControlID="TxtNewPassword"
                DisplayPosition="BelowRight" PrefixText="Your password is " StrengthIndicatorType="Text"
                MinimumNumericCharacters="1" MinimumSymbolCharacters="1" PreferredPasswordLength="8"
                RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Weak; Not Good; Good"
                TextStrengthDescriptionStyles="TextStrengthWeak; TextStrengthNotGood; TextStrengthGood" >
            </cc1:PasswordStrength>
        </td>
    </tr>
    <tr align="center">
        <td dir="rtl" align="left" class="style1">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="أعد كتابة كلمة السر الجديدة:" />
        </td>
        <td align="right" class="style2">
            <asp:TextBox runat="server" CssClass="Text" ID="TxtRetype_Pass"  Width="200px" TextMode="Password" autocomplete="off"></asp:TextBox>
        </td>
    </tr>
    <tr align="center">
        <td colspan="2" class="style3">
            <br />
            <asp:Button ID="SaveButton" Text="حفظ" runat="server" CssClass="Button" OnClick="SaveButton_Click"
                ValidationGroup="change" autocomplete="off"/>
            &nbsb
        </td>
    </tr>
    <tr align="center">
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="change" 
                DisplayMode="SingleParagraph" />
        </td>
    </tr>
</table>
