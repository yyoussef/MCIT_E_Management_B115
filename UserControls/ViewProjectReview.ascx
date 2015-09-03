<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewProjectReview.ascx.cs"
    Inherits="UserControls_ViewProjectReview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<style type="text/css">
    .style22
    {
        width: 543px;
    }
</style>

<script language="javascript" type="text/javascript">
   

    function ChangeMeCase(divid, imgid, Number) {

        var divname = document.getElementById(divid);
        var img = document.getElementById(imgid);

        document.getElementById('<%=hidden_Number.ClientID%>').value = Number;

        var imgsrc = img.src;


        if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
            img.src = "../Images/square_arrow_down.gif";
        }
        else {
            img.src = "../Images/square_arrow_flipped.gif";
        }

        divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
    }

    function Change_Case() {
        alert(document.getElementById('<%=hidden_Number.ClientID%>').value);
    }
</script>

<input id="Inbox_ID" runat="server" type="hidden" value="0" />
<input id="mode" runat="server" type="hidden" value="new" />
<input id="id2" runat="server" type="hidden" />
<input id="id3" runat="server" type="hidden" />
<input type="hidden" runat="server" id="hidden_Number" />
<input type="hidden" runat="server" id="hidden_Id" />
<input type="hidden" runat="server" id="hidden_Proj_id" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="نشرات التعميم" />
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
                <tr>
                    <td valign="top" align="right" width="95%">
                        <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                            <tr >
                                <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0','0');">
                                    <img border="0" id="image0" src="../Images/square_arrow_down.gif" />
                                </td>
                                <td style="font-size: large;  text-decoration: underline; font-weight: bold;"
                                    onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0','0');">
                                    التفاصيل
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div0" style="display: block">
                <table style="line-height: 2; width: 95%" align="center">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="1" dir="rtl" valign="top" align="right" width="10%">
                                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الموضوع :" Font-Size="22px" />
                                    </td>
                                    <td colspan="1" dir="rtl" valign="top" align="right" width="95%">
                                        <asp:Label ID="txt_subject" runat="server" CssClass="Label" Font-Size="20px" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="10%">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                <%--    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="النوع :" Font-Bold="true" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblLetterType" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="20">
                                    </td>--%>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Text="الكود :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblCode" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label18" runat="server" CssClass="Label" Text="التاريخ :" />
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblLetterDate" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        &nbsp;
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        &nbsp;
                                    </td>
                                    <td valign="top" width="20">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right" width="10%">
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="ملاحظات :" />
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="txt_notes" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1','1');">
                        <img border="0" id="image1" src="../Images/square_arrow_down.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1','1');">
                        الوثائق
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <div id="div1" style="display: block">
                <table style="line-height: 2; width: 96%" align="right">
                    <tr>
                        <td align="center" dir="rtl" colspan="4">
                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                                Font-Size="17px">
                                <Columns>
                                    <asp:TemplateField HeaderText="الوثيقة">
                                        <ItemTemplate>
                                            <a href='<%# "ALL_Document_Details.aspx?type=review&id="+ Eval("Review_File_ID") %>'>
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

<input type="hidden" runat="server" id="hidden_Follow_ID" />
<%--  <table width="99%" dir="rtl" runat="server" id="Trfollow">
    <tr >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35px" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3','3');">
                        <img border="0" id="image3" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3','3');">
                        المتابعة
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr id="tr_follow_person" runat="server">
        <td align="right" colspan="2">
            <div id="div3" style="display: none">
                <table style="line-height: 2; width: 100%" align="right">
                    <tr>
                        <td align="right" width="150px" colspan="1">
                            <asp:Label ID="Label36" runat="server" CssClass="Label" Text="المسئول عن التنفيذ:"
                                Width="135px" />
                            <input type="hidden" runat="server" id="hidden_Follow_ID" />
                        </td>
                        <td dir="rtl" colspan="4">
                            <asp:DropDownList ID="ddl_Visa_Emp_id" runat="server" CssClass="drop" Width="319px">
                            </asp:DropDownList>
                            <asp:RangeValidator ControlToValidate="ddl_Visa_Emp_id" ErrorMessage="يجب اختيار المسئول عن التنفيذ"
                                ID="RangeValidator2" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                MinimumValue="1" ValidationGroup="VF">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="tr_follow_proj" runat="server">
                        <td colspan="1" class="style32">
                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="المشروع :" />
                        </td>
                        <td colspan="4" class="style32">
                            <uc1:Smart_Search ID="Smart_Search_proj" runat="server" />
                        </td>
                    </tr>
                    <tr id="tr_follow_desc" runat="server">
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label37" runat="server" CssClass="Label" Text="وصف المتابعة: " />
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Descrption" runat="server" CssClass="Text" Height="78px" Width="100%"
                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Descrption"
                                runat="server" Text="*" ValidationGroup="VF" ErrorMessage="يجب ادخال وصف المتابعة "></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label38" runat="server" CssClass="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr_follow_date" runat="server">
                        <td align="right" width="150px">
                            <asp:Label ID="Label39" runat="server" CssClass="Label" Text="تاريخ المتابعة :" Width="135px" />
                        </td>
                        <td dir="rtl" colspan="4">
                            <asp:TextBox ID="txt_Follow_Date" runat="server" CssClass="Text" Width="110px" Height="25px"></asp:TextBox>
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
                    </tr>
                    <tr id="tr_follow_time" runat="server">
                        <td align="right" width="150px">
                            <asp:Label ID="Label16" runat="server" CssClass="Label" Text="وقت المتابعة :" Width="135px" />
                        </td>
                        <td dir="rtl" colspan="4">
                            <asp:TextBox ID="txt_time_follow" runat="server" CssClass="Text" Width="108px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr_follow_doc" runat="server">
                        <td align="right" width="150px">
                            <asp:Label ID="Label40" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                        </td>
                        <td dir="rtl" colspan="4">
                            <asp:FileUpload ID="FileUpload_Visa_Follow" runat="server" onchange="Get_Value()"
                                ForeColor="Maroon" Width="700px" />
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_follow_save" runat="server">
                        <td colspan="5" align="center" dir="rtl">
                            <asp:Button ID="btn_Visa_Follow" OnClick="btn_Visa_Follow_Click" ValidationGroup="VF"
                                Text="حفظ" runat="server" CssClass="Button" />
                            <%# Eval("File_name")%>

                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="VF"
                                ShowMessageBox="true" ShowSummary="false" />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
 --%>


