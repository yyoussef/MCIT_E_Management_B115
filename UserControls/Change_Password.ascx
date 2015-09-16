<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Change_Password.ascx.cs"
    Inherits="UserControls_Change_Password" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table dir="rtl" style="line-height: 2; width: 100%;">
    <tr align="center">
        <td dir="rtl" align="left" style="width: 550px; height: 35px;">
            <asp:Label ID="Label1" runat="server"  Text="اسم المستخدم: " />
        </td>
        <td align="right">
          &nbsp;  <asp:Label ID="Label2" runat="server"  />
        </td>
    </tr>
    <tr align="center">
        <td dir="rtl" style="width: 550px; height: 35px;" align="left">
            <asp:Label ID="Label3" runat="server"  Text="كلمة السر الحالية:" />
        </td>
        <td align="right">
            <asp:TextBox runat="server" CssClass="Text" ID="TxtRecentPass" Width="300px" TextMode="Password" autocomplete="off"></asp:TextBox>
        </td>
    </tr>
    <tr align="center">
        <td dir="rtl" style="width: 550px; height: 35px;" align="left">
            <asp:Label ID="Label4" runat="server"  Text="كلمة السر الجديدة:" />
        </td>
        <td align="right">
            <asp:TextBox runat="server" CssClass="Text" ID="TxtNewPassword" Width="300px" 
                TextMode="Password" autocomplete="off" ></asp:TextBox>
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
        <td dir="rtl" align="left" style="width: 550px; height: 35px;" align="left">
            <asp:Label ID="Label5" runat="server"  Text="أعد كتابة كلمة السر الجديدة:" />
        </td>
        <td align="right" >
            <asp:TextBox runat="server" CssClass="Text" ID="TxtRetype_Pass"  Width="300px" TextMode="Password" autocomplete="off"></asp:TextBox>
        </td>
    </tr>
    <tr align="center">
        <td colspan="2" 3>
            <br />
            <asp:Button ID="SaveButton" Text="حفظ" runat="server" CssClass="Button" OnClick="SaveButton_Click"
                ValidationGroup="change" />
            
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
