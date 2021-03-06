﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewProject_Inbox_Minister.ascx.cs"
    Inherits="UserControls_ViewProject_Inbox_Minister" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<style type="text/css">
    .style17
    {
        height: 35px;
    }
</style>

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
   
</script>

<input id="Inbox_ID" runat="server" type="hidden" value="0" />
<input id="mode" runat="server" type="hidden" value="new" />
<input id="id2" runat="server" type="hidden" />
<input id="id3" runat="server" type="hidden" />
<input type="hidden" runat="server" id="hidden_Id" />
<input type="hidden" runat="server" id="hidden_Proj_id" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="تأشيرة وزير" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4" style="height: 5px">
            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
        </td>
    </tr>
</table>
<table width="99%" dir="rtl" style="line-height: 2">
    <tr >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                        <tr >
                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                                <img border="0" id="image0" src="../Images/square_arrow_down.gif" />
                            </td>
                            <td style="font-size: large;  text-decoration: underline; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                                التفاصيل
                            </td>
                        </tr>
                    </table>
                </td>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div0" style="display: block">
                <table style="line-height: 2; width: 100%" align="center">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="1" dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="الموضوع :" Font-Size="22px" />
                                    </td>
                                    <td colspan="1" dir="rtl" valign="top" align="right" width="95%">
                                        <asp:Label ID="txt_subject" runat="server" CssClass="Label" Font-Size="20px" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style17">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label19" runat="server" CssClass="Label" Text="النوع :" Font-Bold="true" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblLetterType" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label21" runat="server" CssClass="Label" Text="مرسل بواسطة :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblSourceType" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label28" runat="server" CssClass="Label" Text="الكود :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblCode" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label33" runat="server" CssClass="Label" Text="التاريخ :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblLetterDate" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label35" runat="server" CssClass="Label" Text="نوع الارتباط :" />
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblRelatedType" runat="server" CssClass="Label" Font-Bold="False"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label44" runat="server" CssClass="Label" Text="جهة الورود :" Font-Bold="true" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblOrgName" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label46" runat="server" CssClass="Label" Text="الإدارة داخل الجهة :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblDept_in" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label48" runat="server" CssClass="Label" Text="رقم صادر الجهة :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblOrg_Out_Box_Code" runat="server" CssClass="Label" Font-Bold="False"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label50" runat="server" CssClass="Label" Text=" المرسل داخل الجهة ( صفته / شخصه ) :" />
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblOrg_Out_Box_Person" runat="server" CssClass="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label52" runat="server" CssClass="Label" Text="تاريخ صادر الجهة :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblOrg_Out_Box_DT" runat="server" CssClass="Label" Font-Bold="False"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label54" runat="server" CssClass="Label" Text="عدد الصفحات:" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lbl_paper_no" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label56" runat="server" CssClass="Label" Text="عدد المرفقات :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lbl_att_no" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="35">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label58" runat="server" CssClass="Label" Text="ملاحظات :" />
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="txt_notes" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table width="99%" cellpadding="0" cellspacing="0" style="height: 50px" dir="rtl">
    <tr>
        <td valign="top" align="right" width="99%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                <tr  align="right">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');"
                        align="right">
                        <img border="0" id="image1" src="../Images/square_arrow_down.gif" />
                    </td>
                    <td style="font-size: large;  text-align: right; text-decoration: underline;
                        font-weight: bold;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                        الوثائق
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div1" style="display: block">
                <table style="line-height: 2; width: 100%" align="right">
                    <tr>
                        <td align="center" dir="rtl" colspan="4">
                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                                Font-Size="17px" GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText="الوثيقة">
                                        <ItemTemplate>
                                            <a href='<%# "ALL_Document_Details.aspx?type=Inbox&id="+ Eval("Inbox_OutBox_File_ID") %>'>
                                                <%# Eval("File_name")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="نوع الوثيقة">
                                        <ItemTemplate>
                                            <%# Get_Type(Eval("Original_Or_Attached"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="عرض الوثيقة" ItemStyle-Width="40px">
                        <ItemTemplate>
                            <a href='<%# "ALL_Document_Details.aspx?type=Inbox&id="+ Eval("Inbox_OutBox_File_ID") %>'>
                                <img src="../Images/Edit.jpg" id="img1" alt="عرض الوثيقة" style="border: 0" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                    HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table width="99%" cellpadding="0" cellspacing="0" style="height: 50px" dir="rtl">
    <tr>
        <td valign="top" align="right" width="100%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;" dir="rtl ">
                <tr  align="right">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image2');"
                        align="right">
                        <img border="0" id="image2" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td style="font-size: large;  text-align: right; text-decoration: underline;
                        font-weight: bold;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image2');">
                        التأشيرة
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div2" style="display: none">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr id="tr_mngr1" runat="server">
                        <td colspan="1">
                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الإدارة التابع لها :" />
                        </td>
                        <td colspan="3">
                            <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" colspan="1">
                            <asp:Label ID="Label29" runat="server" CssClass="Label" Text="درجة الأهمية: " Width="100px" />
                        </td>
                        <td colspan="3">
                            <br />
                            <asp:DropDownList ID="ddl_Important_Degree" runat="server" CssClass="drop" Width="150px">
                                <asp:ListItem Text="هام" Value="1" Selected="True"> </asp:ListItem>
                                <asp:ListItem Text="عاجل" Value="2"> </asp:ListItem>
                                <asp:ListItem Text="عادى" Value="3"> </asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="txt_Important_Degree_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="المسئول عن التنفيذ :" />
                        </td>
                        <td align="right" colspan="3">
                            <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                dir="rtl">
                                <asp:CheckBoxList ID="chklst_Visa_Emp" CellPadding="5" CellSpacing="5" RepeatColumns="4"
                                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" RepeatLayout="Table"
                                    TextAlign="Right" DataTextField="pmp_name" DataValueField="PMP_ID" runat="server"
                                    Width="97%">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px" colspan="1">
                            <asp:Label ID="Label15" runat="server" CssClass="Label" Text="تاريخ التاشيرة :" Width="135px" />
                        </td>
                        <td dir="rtl" colspan="3">
                            <asp:TextBox ID="txt_Visa_date" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                TargetControlID="txt_Visa_date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                TargetControlID="txt_Visa_date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_Visa_date"
                                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال تاريخ التاشيرة "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px" colspan="1">
                            <asp:Label ID="Label42" runat="server" CssClass="Label" Text="اخر تاريخ مسموح به  :"
                                Width="135px" />
                        </td>
                        <td dir="rtl" colspan="3">
                            <asp:TextBox ID="txt_Dead_Line_DT" runat="server" CssClass="Text" Width="270px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                TargetControlID="txt_Dead_Line_DT" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton33"
                                TargetControlID="txt_Dead_Line_DT">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton33" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" colspan="1">
                            <asp:Label ID="Label43" runat="server" CssClass="Label" Text="غرض التاشيرة: " Width="100px" />
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_Visa_Goal_ID" runat="server" CssClass="drop" Width="250px">
                                <asp:ListItem Text="للدراسة" Value="1" Selected="True"> </asp:ListItem>
                                <asp:ListItem Text="للعرض" Value="2"> </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="نص التأشيرة :" />
                        </td>
                        <td align="right" colspan="3">
                            <asp:TextBox ID="txt_Visa_Desc" runat="server" CssClass="Text" Height="105px" TextMode="MultiLine"
                                Width="45%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr_mngr2" runat="server">
                        <td align="center" dir="rtl" colspan="4">
                            <asp:Button ID="Button1" OnClick="btn_Visa_Click" ValidationGroup="B" Text="حفظ"
                                runat="server" CssClass="Button" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="B"
                                ShowMessageBox="true" ShowSummary="false" />
                            <input type="hidden" runat="server" id="hidden_Visa_Id" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView_Visa" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Visa_RowCommand"
                                Font-Size="17px" AllowPaging="true" AllowSorting="true" >
                                <Columns>
                                    <asp:TemplateField HeaderText="تاريخ التأشيرة">
                                        <ItemTemplate>
                                            <%# Eval("Visa_date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="درجة الأهمية">
                                        <ItemTemplate>
                                            <%# Get_Type_Visa(Eval("Important_Degree"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="اسم المحور">
                                        <ItemTemplate>
                                            <%# Eval("Dept_ID_Txt")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="وصف التأشيرة">
                                        <ItemTemplate>
                                            <%# Eval("Visa_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="اخر تاريخ مسموح به">
                                        <ItemTemplate>
                                            <%# Eval("Dead_Line_DT")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="المسئول عن التنفيذ">
                                        <ItemTemplate>
                                            <%# Get_Visa_Emp(Eval("Visa_Id"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="موقف المتابعة">
                                        <ItemTemplate>
                                            <%# Eval("Follow_Up_Notes")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تم ارسال ">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSent" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ارسال " ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit123" CommandName="SendItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("Visa_Id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("Visa_Id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                               CommandArgument='<%# Eval("Visa_Id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table width="99%" cellpadding="0" cellspacing="0" style="height: 50px" dir="rtl" runat="server" id="Trfollow" >
    <tr >
        <td valign="top" align="right" width="100%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;" dir="rtl ">
                <tr  align="right">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3');"
                        align="right">
                        <img border="0" id="image3" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td style="font-size: large;  text-align: right; text-decoration: underline;
                        font-weight: bold;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3');">
                        المتابعة
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div3" style="display: none">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr id="tr_follow_person" runat="server">
                        <td align="right" width="150px" colspan="1">
                            <asp:Label ID="Label36" runat="server" CssClass="Label" Text="المسئول عن التنفيذ:"
                                Width="135px" />
                            <input type="hidden" runat="server" id="hidden_Follow_ID" />
                        </td>
                        <td dir="rtl" colspan="1">
                            <asp:DropDownList ID="ddl_Visa_Emp_id" runat="server" CssClass="drop" Width="319px">
                            </asp:DropDownList>
                            <asp:RangeValidator ControlToValidate="ddl_Visa_Emp_id" ErrorMessage="يجب اختيار المسئول عن التنفيذ"
                                ID="RangeValidator2" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                MinimumValue="1" ValidationGroup="VF">*</asp:RangeValidator>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr id="tr_follow_desc" runat="server">
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label37" runat="server" CssClass="Label" Text="وصف المتابعة: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Descrption" runat="server" CssClass="Text" Height="70px" Width="90%"
                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Descrption"
                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال وصف المتابعة "></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label38" runat="server" CssClass="Label" Width="293px"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr_follow_date" runat="server">
                        <td align="right" width="150px">
                            <asp:Label ID="Label39" runat="server" CssClass="Label" Text="تاريخ المتابعة :" Width="135px" />
                        </td>
                        <td dir="rtl">
                            <asp:TextBox ID="txt_Follow_Date" runat="server" CssClass="Text" Width="213px" 
                                Height="19px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom"
                                TargetControlID="txt_Follow_Date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton4"
                                TargetControlID="txt_Follow_Date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton4" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Follow_Date"
                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال تاريخ المتابعة "></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr id="tr_follow_doc" runat="server">
                        <td align="right" width="150px">
                            <asp:Label ID="Label40" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                        </td>
                        <td dir="rtl" colspan="3">
                            <asp:FileUpload ID="FileUpload_Visa_Follow" runat="server" onchange="Get_Value()"
                                ForeColor="Maroon" Width="700px" />
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_follow_save" runat="server">
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Visa_Follow" OnClick="btn_Visa_Follow_Click" ValidationGroup="VF"
                                Text="حفظ" runat="server" CssClass="Button" />
                            <%-- <asp:Button ID="Button2" OnClick="btn_Send_Main_Click" Width="200px" Text="ارسال بريد للمشرف على القطاع "
                                        runat="server" CssClass="Button" />--%>
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="VF"
                                ShowMessageBox="true" ShowSummary="false" />
                        </td>
                    </tr>
                </table>
            </div>
           
        </td>
    </tr>
</table>

<table width="100%" cellpadding="0" cellspacing="0" style="height: 50px" dir="rtl">
    <tr>
        <td valign="top" align="right" width="100%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;" dir="rtl ">
                <tr  align="right">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','image4');"
                        align="right">
                        <img border="0" id="image4" src="../Images/square_arrow_down.gif" />
                    </td>
                    <td style="font-size: large;  text-align: right; text-decoration: underline;
                        font-weight: bold;" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','image4');">
                       المسير
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
        <div id="div4" style="display: block">
        <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;" dir="rtl " >
<tr>
    <td align="center" colspan="4">
        <asp:GridView ID="GridView_Visa_Follow" runat="server" AutoGenerateColumns="False"
            CellPadding="3" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Visa_Follow_RowCommand"
            Font-Size="17px" AllowPaging="True" AllowSorting="True" Width="100%" 
            GridLines="Vertical">
            <Columns>
                <asp:TemplateField HeaderText="المسئول عن التنفيذ">
                    <ItemTemplate>
                        <%# Eval("pmp_name")%>
                    </ItemTemplate>
                    <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="تاريخ المتابعة">
                    <ItemTemplate>
                        <%# Eval("Date")%>
                    </ItemTemplate>
                    <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="الوقت">
                    <ItemTemplate>
                        <%# Eval("time_follow")%>
                    </ItemTemplate>
                    <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="وصف المتابعة">
                    <ItemTemplate>
                        <%# Eval("Descrption")%>
                    </ItemTemplate>
                    <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="الوثيقة">
                    <ItemTemplate>
                        <a href='<%# "ALL_Document_Details.aspx?type=inbox_follow&id="+ Eval("Follow_ID") %>'>
                            <%# Eval("File_name")%></a>
                    </ItemTemplate>
                    <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
        </asp:GridView>
    </td>
</tr>
<tr>
    <td align="center">
        <asp:LinkButton ID="lnkBtnUnderStudy" runat="server" Text="تحت الدراسة" Font-Bold="true"
            OnClick="lnkBtnUnderStudy_Click" Visible="false">
        </asp:LinkButton>
    </td>
</tr>
<tr>
    <td align="center">
        <asp:Button runat="server" CssClass="Button" Text="إغلاق الموضوع" ID="btn_close_inbox"
            OnClick="btn_close_inbox_Click" Width="150px" />
    </td>
</tr>
</table> 
</div> 
</td> 
</tr> 

</table> 