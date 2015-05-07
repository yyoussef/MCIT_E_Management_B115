<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Protocols_Reports.aspx.cs" Inherits="WebForms_Protocols_Reports" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

    
   
   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<input type="hidden" runat="server" id="hidden_Rpt_Id" />
    <script language="javascript" type="text/javascript">
   function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid); 
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('collapse') != -1)
       { img.src = "../Images/expand.gif";
        }
    else
        {img.src = "../Images/collapse.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}

    </script>

    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <table style="width: 100%; display: block; height: 238px; line-height: 2;" id="tbl_Report"
        runat="server">
        <tr>
            <td height="30px" align="center">
                <asp:Label ID="Label1" runat="server" Text="تقارير البروتوكولات " CssClass="PageTitle"
                    Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%">
            <td valign="top" align="right">
                <table id="first_table_reports" cellpadding="0" cellspacing="0" style="height: 43px;
                    width: 100%;">
                    <tr id="firstreports" bgcolor="#E6F3FF">
                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                            <img border="0" id="image0" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');"
                            colspan="2">
                            البروتوكولات المنتهية
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="firts_tr_reports">
            <td style="width: 400px">
                <div id="div0" style="display: block" dir="rtl">
                    <table style="line-height: 2; width: 100%">
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px" width="600px">
                                <asp:Image ID="Image16" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Ended_protocol_cont_proj" runat="server" Font-Bold="False" OnClick="Ended_protocol_cont_proj_Click"
                                    CssClass="Text"> البروتوكولات المنتهية تحتوي مشروعات جارية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="28">
                            </td>
                            <td colspan="2" style="height: 30px"  width="600px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" Style="text-align: right" />
                                <asp:LinkButton ID="Ended_protocol_ended_proj" runat="server" Font-Bold="False" OnClick="Ended_protocol_ended_proj_Click"
                                    CssClass="Text"> البروتوكولات المنتهية لمشروعات منتهية</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style="line-height: 2; width: 100%; display: none; height: 238px" id="tbl_Paramater"
        runat="server">
        <tr>
            <td height="15px">
            </td>
        </tr>
        <tr>
            <td style="height: 41px" align="center">
                <%--<input type="hidden" visible="false"  runat="server" id="hidden_Rpt_Id" />--%>
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                    Width="37px" OnClick="ImgBtnBack_Click" AlternateText="العودة للتقارير الرئيسية" />
            </td>
        </tr>
        <tr>
            <td style="height: 41px" align="center">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100%">
                <div id="Div_Dept" runat="server" style="display: none">
                    <table cellpadding="0" cellspacing="0">
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label5" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" width="400px" dir="rtl">
                <%--  <asp:DropDownList ID="DropDep" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="DropDep_SelectedIndexChanged" CssClass="drop"
                                    Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImgBtnResearch" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />
            </td>
            <!--<td align="right" dir="rtl">
                                
                            </td>-->
        </tr>
    </table>
    </div>
    <div id="Div_Proj_Mngr" runat="server" style="display: none">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" width="110px">
                    <asp:Label ID="Label4" runat="server" Text="مدير المشروع : " Font-Names="Arial" Font-Size="20px"
                        ForeColor="#1F4569" Font-Bold="false"></asp:Label>
                </td>
                <td align="right" valign="middle" style="height: 44px" dir="rtl">
                    <%-- <asp:DropDownList ID="Dropprojmanage" runat="server" AutoPostBack="True" Font-Bold="False"
                                    OnSelectedIndexChanged="Dropprojmanage_SelectedIndexChanged" CssClass="drop"
                                     Width="337px" Height="39px">
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButtonmanage" runat="server" Style="height: 16px" ImageUrl="~/Images/search.jpg"
                                    Width="20px" />--%>
                    <uc1:Smart_Search ID="Smrt_Srch_projmanage" runat="server" />
                </td>
                <!--<td align="right" dir="rtl">
                                
                            </td>-->
            </tr>
        </table>
    </div>
    <div id="Div_Org" runat="server" style="display: none">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" width="110px" style="height: 44px">
                    <asp:Label ID="Label3" runat="server" Text="الجهة : " Font-Names="Arial" Font-Size="20px"
                        ForeColor="#1F4569" Font-Bold="false"></asp:Label>
                </td>
                <td align="right" valign="middle" style="height: 44px" dir="rtl">
                    <uc1:Smart_Search ID="Smart_org" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Div_Date_end" runat="server" style="display: block">
        <table cellpadding="0" cellspacing="0">
            <tr visible="true">
                <td visible="true" align="center">
                    <asp:Label ID="DateLabel" runat="server" CssClass="PageTitle" color="red" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" dir="rtl">
                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="تاريخ نهاية البروتوكول من :" Font-Names="Arial"
                        Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                </td>
                <td align="right">
                    <asp:TextBox ID="Date_end_from" runat="server" Font-Names="Arial" Font-Size="20px"
                        ForeColor="#1F4569" Font-Bold="True" Width="129px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Date_end_from"
                        PopupButtonID="ImageButton1" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                        AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                    <br />
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Date_end_from"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="الي :" Font-Names="Arial"
                        Font-Size="20px" ForeColor="#1F4569"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Date_end_to" runat="server" Font-Bold="True" Height="29px" Width="128px"
                        Font-Names="Arial" Font-Size="20px" ForeColor="#1F4569"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="Date_end_to"
                        PopupButtonID="ImageButton2" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                    </cc1:CalendarExtender>
                    <asp:ImageButton ID="ImageButton2" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                        AlternateText="اضغط لعرض النتيجة" Height="20px" Width="20px" />
                 
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Date_end_to"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </div>
    </td> </tr>
    <tr>
        <td style="height: 43px;" align="center" dir="ltr">
            &nbsp;
            <asp:Label ID="Labname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabValue" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="LabDeptname" runat="server" ForeColor="#003300" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                OnClick="Button1_Click" Text="عرض التقرير" Width="98px"  ValidationGroup="A"/>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
