<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Request_Password.aspx.cs"
    Inherits="Request_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ارسال ايميل بكلمة المرور</title>
    <link rel="stylesheet" href="CSS/style (2).css" type="text/css" />
    <style type="text/css">
        .style11
        {
            width: 299px;
            height: 39px;
        }
        .style15
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0" width="99%" style="height: 320px"
        dir="ltr">
        <tr align="center" bgcolor="#C2DDF0">
            <td dir="rtl" width="100%">
                <img src="Images/New_Banner.jpg" />
            </td>
        </tr>
        <tr align="center">
            <td width="99%" style="height: -15px" align="char" dir="rtl">
            </td>
        </tr>
        <tr align="center">
            <td align="center" class="border" valign="middle" bgcolor="#f9fdff" height="400px"
                width="50%">
                <table border="0" align="center" cellpadding="0" cellspacing="0" " " style="height: 184px">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#f9fdff" dir="rtl">
                            &nbsp;
                            <asp:Label runat="server" Text="ارسال ايميل بكلمة المرور" ID="enterlab" ForeColor="#990000"
                                Font-Bold="False" Font-Names="Arial"  font-underline="false" Font-Size="24px"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr align="center">
                        <td dir="rtl" bgcolor="#f9fdff" align="right" rowspan="1" valign="baseline" class="style11">
                            <asp:TextBox ID="Txt_Email" runat="server" Width="200px" Font-Bold="True" Font-Size="17px"
                                Style="margin-bottom: 0px" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="Txt_Email"
                                ErrorMessage="من فضلك ادخل البريد الالكترونى" ValidationGroup="a" SetFocusOnError="True"
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="من فضلك ادخل بريد الالكترونى صحيح"
                                ValidationGroup="a" ControlToValidate="Txt_Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td bgcolor="#f9fdff" dir="rtl" align="center">
                            <asp:Label ID="userlbl" runat="server" Text="البريد الالكترونى:" Font-Size="13pt"
                                ForeColor="#244A6F" Height="25px" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" bgcolor="#f9fdff" valign="middle" height="35px">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="إلغاء" Font-Bold="True" ForeColor="#436485"
                                align="right" PostBackUrl="Default.aspx" Width="90px" valign="bottom"
                                Font-Names="arial" Font-Size="16px" />
                            <asp:Button ID="Button1" runat="server" BackColor="#C2DDF0" Font-Bold="True" Font-Size="Medium"
                                ForeColor="#244A6F" Height="26px" Text="ارســال كلمة المرور" Width="130px" BorderStyle="None"
                                OnClick="Button1_Click" ValidationGroup="a" />
                        </td>
                       
                    </tr>
                     <tr>
                        <td colspan="2" align="center" bgcolor="#f9fdff" dir="rtl" class="style15">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20px">
            </td>
        </tr>
    </table>
    <table width="99%" border="0" align="center" bgcolor="#C2DDF0" style="height: 25px">
        <tr>
            <td valign="top" align="center" bgcolor="#C2DDF0" valign="top">
                <asp:Label runat="server" ID="Footerlab" Text="حقوق النسخ محفوظة لوزارة الاتصالات وتكنولوجيا المعلومات ... 2010"
                    ForeColor="#244A6F" Width="100%" Font-Size="12pt" Height="16px" Font-Bold="True"
                    Font-Names="Times New Roman"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
    
</body>
</html>
