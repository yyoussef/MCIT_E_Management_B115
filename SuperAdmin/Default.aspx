<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>نظام متابعة أعمال البنية المعلوماتية</title>
    <link rel="stylesheet" href="CSS/style (2).css" type="text/css" />
    <style type="text/css">
        .style5
        {
            height: 20px;
        }
        .style7
        {
            width: 299px;
            height: 30px;
        }
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
     <script type="text/javascript" language="javascript">
        
        function simplejs()
        {
        alert("HI");
        }
   
function ValidateToken (PINNumber)
{


//{0:Success}{1:PIN Not Matched}{2:Token Not Found}{3:General Error}
   var errorCode;
    //create com object;
   SLSTSVObj = new ActiveXObject("SLSTCOM.SLSTSV");

 //create buffer object;
   SLBufferObj = new ActiveXObject("SLSTCOM.SLBuffer");

 //set buffer value with "Softlock 123 Smart Token";
    SLBufferObj.SLSetString (1 ,"");
    bufferLength = SLBufferObj.SLSize;

 //intialize library;
    SLSTSVObj.SLSTInitialize("");

    //Enumerate tokens;
   SLIValuesObj = SLSTSVObj.SLSTEnumerateTokens();
   
 //check last error;
 //{0:Success}{1:PIN Not Matched}{2:Token Not Found}{3:General Error}
    if(SLSTSVObj.GetLastError()!=0)
    {
    
      errorCode=3;
    window.location("TokenErrorPage.aspx?errorCode=" + errorCode );
    }
    
 //check number of tokens;
    if(SLIValuesObj.SLSize == 0)
    {
   //alert("2222222");
        errorCode=2;
        //window.location("TokenErrorPage.aspx?errorCode=" + errorCode );
    
    }
    //return false;

    //Open Session;
    sessionID = SLSTSVObj.SLSTOpenSession(SLIValuesObj.SLGetItem(0));
    
    if(SLSTSVObj.GetLastError()!=0){
       errorCode=3;
       //alert("333333333333");
       //window.location("TokenErrorPage.aspx?errorCode=" + errorCode );
       }

    //login;
    SLSTSVObj.SLSTLogin (sessionID, SLBufferObj.SLGetString(1), 1);
    
 
      //check If PIN Matched
    if(SLSTSVObj.GetLastError() == 0)
    {
    errorCode=0;
    // alert("PIN  Matched :)");
    //alert("44444444444");
    //return;
    }
    else
    {
    //alert("555555555555");
    errorCode=1;
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
    SLSTSVObj.SLSTLogout( sessionID);
    
 //logout;
    SLSTSVObj.SLSTCloseSession( sessionID);
    

    SLSTSVObj.SLSTFinalize();


window.location = "Default.aspx?errorCode=" + errorCode ;

}


    </script>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
     <table border="0" align="center" cellpadding="0" cellspacing="0" width="99%" style="height: 320px"
        dir="ltr">
        <tr align="center" bgcolor="#C2DDF0">
           <input type="hidden" id="hdn_attempts" runat="server" value="0" />
           <td dir="rtl" width="100%">
               <img  id="headerImage" runat="server" style="height:120px;width:1000px" src="~/Images/banner2.jpg"  />
             
             <asp:Label runat="server" Text=" " ID="lbl1" ForeColor="#990000"></asp:Label>

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
                            <asp:Label runat="server" Text="دخـــول المسـتخــــدميـن    " ID="enterlab" ForeColor="#990000"
                                Font-Bold="False" Font-Names="Arial" Font-Underline="False" Font-Size="24px"></asp:Label>
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
                        <td dir="rtl" bgcolor="#f9fdff" align="right" rowspan="1" valign="baseline" class="style11">
                            <asp:TextBox ID="UserName" runat="server" Width="200px" Font-Bold="True" Font-Size="17px"
                                Style="margin-bottom: 0px" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="من فضلك ادخل اسم المستخدم" ValidationGroup="a" SetFocusOnError="True"
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                        <%--<input type="text" id="UserName" name="Textbox2" value="اسم المستخدم" 
                 onfocus="if(value == 'اسم المستخدم'){value=''}" onblur="if (value == '') {value='اسم المستخدم'}"
                  dir="rtl" size="20" /></td>--%>
                        <td bgcolor="#f9fdff" dir="rtl" align="center">
                            <asp:Label ID="userlbl" runat="server" Text="اسم المستخدم:" Font-Size="13pt" AssociatedControlID="Password"
                                ForeColor="#244A6F" Height="25px" Width="95px" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center">
                        <td dir="rtl" bgcolor="#f9fdff" align="right" valign="baseline" class="style7">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="200px" Font-Size="16px"
                                CausesValidation="True" ValidationGroup="a" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="من فضلك ادخل كلمة المرور" ValidationGroup="a" 
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                            <%-- <input type="text" id="Password1" name="Textbox1" value="كلمة المرور" onfocus="if(value == 'كلمة المرور'){value=''}" onblur="if (value== '') {value='كلمة المرور'}"
           dir="rtl"  />--%>
                        </td>
                        <td bgcolor="#f9fdff" dir="rtl" align="center" valign="baseline">
                            <%--/*   onFocus="if (value == 'your@email.com') {value=''}" onBlur="if (value== '') {value='your@email.com'}" */--%>&nbsp;
                            <asp:Label ID="passlbl" runat="server" Text="كلمة المرور:" Font-Bold="True" Font-Size="12pt"
                                ForeColor="#244A6F"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f9fdff" colspan="2" align="center" class="style5" style="color: Red;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" bgcolor="#f9fdff" valign="middle" height="35px">
                            <asp:Button ID="Button1" runat="server" BackColor="#C2DDF0" Font-Bold="True" Font-Size="Medium"
                                ForeColor="#244A6F" Height="26px" Text="دخـــــــول" Width="71px" BorderStyle="None"
                                OnClick="Button1_Click" ValidationGroup="a" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" bgcolor="#f9fdff" valign="middle" height="35px">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="نسيت كلمة المرور" Font-Bold="True"
                                ForeColor="#436485" align="right" PostBackUrl="Request_Password.aspx" Width="130px"
                                valign="bottom" Font-Names="arial" Font-Size="16px" />
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
                <asp:Label runat="server" ID="Footerlab" Text="حقوق النسخ محفوظة لوزارة الاتصالات وتكنولوجيا المعلومات ... "
                    ForeColor="#244A6F" Width="100%" Font-Size="12pt" Height="16px" Font-Bold="True"
                    Font-Names="Times New Roman"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
