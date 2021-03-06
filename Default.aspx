﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>نظام التراسل الإلكترونى</title>
    <link rel="stylesheet" href="CSS/Orange.css" type="text/css" />
    

    <script type="text/javascript" language="javascript">

        function simplejs() {
            alert("HI");
        }

        function ValidateToken(PINNumber) {


            //{0:Success}{1:PIN Not Matched}{2:Token Not Found}{3:General Error}
            var errorCode;
            //create com object;
            SLSTSVObj = new ActiveXObject("SLSTCOM.SLSTSV");

            //create buffer object;
            SLBufferObj = new ActiveXObject("SLSTCOM.SLBuffer");

            //set buffer value with "Softlock 123 Smart Token";
            SLBufferObj.SLSetString(1, "");
            bufferLength = SLBufferObj.SLSize;

            //intialize library;
            SLSTSVObj.SLSTInitialize("");

            //Enumerate tokens;
            SLIValuesObj = SLSTSVObj.SLSTEnumerateTokens();

            //check last error;
            //{0:Success}{1:PIN Not Matched}{2:Token Not Found}{3:General Error}
            if (SLSTSVObj.GetLastError() != 0) {

                errorCode = 3;
                window.location("TokenErrorPage.aspx?errorCode=" + errorCode);
            }

            //check number of tokens;
            if (SLIValuesObj.SLSize == 0) {
                //alert("2222222");
                errorCode = 2;
                //window.location("TokenErrorPage.aspx?errorCode=" + errorCode );

            }
            //return false;

            //Open Session;
            sessionID = SLSTSVObj.SLSTOpenSession(SLIValuesObj.SLGetItem(0));

            if (SLSTSVObj.GetLastError() != 0) {
                errorCode = 3;
                //alert("333333333333");
                //window.location("TokenErrorPage.aspx?errorCode=" + errorCode );
            }

            //login;
            SLSTSVObj.SLSTLogin(sessionID, SLBufferObj.SLGetString(1), 1);


            //check If PIN Matched
            if (SLSTSVObj.GetLastError() == 0) {
                errorCode = 0;
                // alert("PIN  Matched :)");
                //alert("44444444444");
                //return;
            }
            else {
                //alert("555555555555");
                errorCode = 1;
                //window.location("TokenErrorPage.aspx?errorCode=" + errorCode );
            }

            //Write to public memory;
            //  SLSTSVObj.SLSTWrite (sessionID , 3, 0, SLBufferObj);
            //  if(SLSTSVObj.GetLastError()!=0)
            //   return;

            //Read to public memory;
            //SLBufferObj = SLSTSVObj.SLSTRead(sessionID, 3, 0, bufferLength);
            //    if(SLSTSVObj.GetLastError()!=0)
            //   return;
            //print result buffer;
            //alert(SLSTSVObj.GetLastError());
            //   alert(SLBufferObj.SLGetString(1));







            //Close;
            SLSTSVObj.SLSTLogout(sessionID);

            //logout;
            SLSTSVObj.SLSTCloseSession(sessionID);


            SLSTSVObj.SLSTFinalize();


            window.location = "Default.aspx?errorCode=" + errorCode;

        }


    </script>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div id="div_test" runat="server">
        <input type="hidden" id="hdn_attempts" runat="server" value="0" />
        <table border="0" align="center" cellpadding="0" cellspacing="0" width="99%" style="height: 700px"
            dir="ltr" id="tbl_login" runat="server" visible="false">
            <tr align="center" >
                <td dir="rtl" width="100%" style="background: url(Images/E-man-banner.png) center no-repeat;height: 120px; width: 1000px">
                    <%--<img id="headerImage" runat="server" style="height: 120px; width: 1000px" src="~/Images/E-man-banner.png" />--%>
                    <asp:Label runat="server" Text=" " ID="lbl1" ForeColor="#990000"></asp:Label>
                </td>
            </tr>
           
            <tr align="center">
                <td align="center" class="border" valign="middle" bgcolor="#f9fdff" height="600px"
                    width="50%">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" " " style="height: 184px">
                        <tr>
                            <td colspan="2" align="center" bgcolor="#f9fdff" dir="rtl">
                                &nbsp;
                               <h1 runat="server" ID="enterlab" >دخـــول المسـتخــــدميـن</h1> 
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" bgcolor="#f9fdff" dir="rtl" class="style15">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td dir="rtl" align="right" rowspan="1"  >
                               <asp:TextBox ID="UserName" runat="server"  CausesValidation="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="من فضلك ادخل اسم المستخدم" ValidationGroup="a" SetFocusOnError="True"
                                    Display="Dynamic">*</asp:RequiredFieldValidator>
                            </td>
                            <%--<input type="text" id="UserName" name="Textbox2" value="اسم المستخدم" 
                 onfocus="if(value == 'اسم المستخدم'){value=''}" onblur="if (value == '') {value='اسم المستخدم'}"
                  dir="rtl" size="20" /></td>--%>
                            <td  dir="rtl" align="left">
                              <asp:Label ID="userlbl" runat="server" Text="اسم المستخدم:" ></asp:Label>
                               
                            </td>
                        </tr>
                        <tr align="center">
                            <td dir="rtl" bgcolor="#f9fdff" align="right" valign="baseline" class="style7">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"
                                    CausesValidation="True" ValidationGroup="a" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="من فضلك ادخل كلمة المرور" ValidationGroup="a" 
                                    Display="Dynamic">*</asp:RequiredFieldValidator>
                                <%-- <input type="text" id="Password1" name="Textbox1" value="كلمة المرور" onfocus="if(value == 'كلمة المرور'){value=''}" onblur="if (value== '') {value='كلمة المرور'}"
           dir="rtl"  />--%>
                            </td>
                            <td  dir="rtl" align="left" valign="baseline">
                                <%--/*   onFocus="if (value == 'your@email.com') {value=''}" onBlur="if (value== '') {value='your@email.com'}" */--%>
                            <asp:Label ID="passlbl" runat="server" Text="كلمة المرور:"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#f9fdff" colspan="2" align="center" class="style5" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" valign="middle" >
                                <h2><asp:Button ID="Button1" runat="server" 
                                    Text="دخـــــــول" 
                                    OnClick="Button1_Click" ValidationGroup="a" /></h2>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center"  valign="middle" >
                             <asp:LinkButton ID="LinkButton1" runat="server" Text="نسيت كلمة المرور"  PostBackUrl="Request_Password.aspx"  />
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
        <table border="0" id="tbl_cookie" visible="false" runat="server" align="center" cellpadding="0"
            cellspacing="0" width="99%" style="height: 320px">
            <tr align="center" bgcolor="#C2DDF0">
                <td dir="rtl" width="100%">
                    <img id="Img1" runat="server" style="height: 120px; width: 1000px" src="~/Images/New_Banner.jpg" />
                    <asp:Label runat="server" Text=" " ID="Label2" ForeColor="#990000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblchrome" runat="server" CssClass="Label"></asp:Label>
                </td>
            </tr>
        </table>
       
        <table id="tbl_footer" runat="server" border="0" align="center" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr align="center">
                        <td valign="top" dir="ltr" bgcolor="#f3f3f3">
                            <marquee behavior="scroll" direction="right">
                        <asp:Label  runat="server" ID="Footerlab" Text="حقوق النسخ محفوظة للإدارة المركزية للإستشارات الفنية وتطوير النظم بقطاع البنية المعلوماتية بوزارة الاتصالات وتكنولوجيا المعلومات  ... "
                            Style="text-align: center" ForeColor="#555" Width="100%" Font-Size="12pt"
                            Font-Bold="True" Font-Names="Times New Roman"></asp:Label></marquee>
                        </td>
                    </tr>
                </table>
        
    </div>
    <div id="div_test2" runat="server" visible="false">
        <asp:Label runat="server" Text="    جاري الان عمل تحديث للنظام برجاء الانتظار لحين الانتهاء من إجراءات التحديث وشكرا "
            ID="Label1" ForeColor="#990000" Font-Size="XX-Large" EnableViewState="True"></asp:Label>
    </div>
    </form>
</body>
</html>
