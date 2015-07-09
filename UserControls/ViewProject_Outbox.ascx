<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewProject_Outbox.ascx.cs"
    Inherits="UserControls_ViewProject_Outbox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<style type="text/css">
    .style22
    {
        width: 543px;
    }
    .style32bbtn
    {
        height: 129px;
    }
    .style33
    {
        width: 6px;
    }
</style>

<script language="javascript" type="text/javascript">
   

    function ChangeMeCase(divid, imgid, Number) {

        var divname = document.getElementById(divid);
        var img = document.getElementById(imgid);

        document.getElementById('<%=hidden_Number.ClientID%>').value = Number;

        var imgsrc = img.src;


        if (imgsrc.lastIndexOf('collapse') != -1) {
            img.src = "../Images/expand.gif";
        }
        else {
            img.src = "../Images/collapse.gif";
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
<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="30" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
        <div style="position: fixed; background-color: #FAFAFA; z-index: 2147483647 !important;
            opacity: 0.8; overflow: hidden; text-align: center; top: 0; left: 0; height: 100%;
            width: 100%; padding-top: 20%;">
            <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" ImageUrl="~/Images/icon-loading.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr>
                <td align="center" colspan="4" style="height: 33px">
                    <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الخطابات الصادرة" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" style="height: 5px">
                    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="99%" dir="rtl" style="line-height: 2">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr>
                            <td valign="top" align="right" width="95%">
                                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                                    <tr bgcolor="#E6F3FF">
                                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0','0');">
                                            <img border="0" id="image0" src="../Images/expand.gif" />
                                        </td>
                                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
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
                                            <td colspan="1" dir="rtl" valign="top" align="right">
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
                                <td valign="top" height="23">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="النوع :" Font-Bold="true" />
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lblLetterType" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="مرسل بواسطة :" />
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lblSourceType" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
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
                                                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="نوع الارتباط :" />
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lblRelatedType" runat="server" CssClass="Label" Font-Bold="False"
                                                    ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lbl_Inbox_type" runat="server" CssClass="Label" Text="عنوان الخطاب " />
                                            </td>
                                            <td colspan="15">
                                                <asp:HyperLink ID="lbl_letter" runat="server" CssClass="Label" Font-Bold="False"
                                                    ForeColor="Black">HyperLink</asp:HyperLink>
                                                <%--<asp:Label ID="lbl_letter" runat="server"  Text=" " CssClass="Label" Font-Bold="False" ForeColor="Black"  />--%>
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
                                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="الجهة الصادر لها :"
                                                    Font-Bold="true" />
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lblOrgName" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="الإدارة داخل الجهة :" />
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lblDept_in" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label12" runat="server" CssClass="Label" Text="رقم صادر الجهة :" />
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
                            <%--<tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="Label20" runat="server" CssClass="Label" Text=" المرسل داخل الجهة ( صفته / شخصه ) :" />
                                    </td>
                                    <td dir="rtl" valign="top" align="right">
                                        <asp:Label ID="lblOrg_Out_Box_Person" runat="server" CssClass="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                            <tr>
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="تاريخ صادر الجهة :" />
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
                                                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="عدد الصفحات:" />
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="lbl_paper_no" runat="server" CssClass="Label" Font-Bold="False" ForeColor="Black"></asp:Label>
                                            </td>
                                            <td valign="top" width="20">
                                            </td>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label24" runat="server" CssClass="Label" Text="عدد المرفقات :" />
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
                                <td valign="top" width="20">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td dir="rtl" valign="top" align="right">
                                                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="ملاحظات :" />
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
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div16','image16','16');">
                                <img border="0" id="image16" src="../Images/expand.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div16','image16','16');">
                                الخطابات المرتبطة
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <div id="div16" style="display: none">
                        <table style="line-height: 2; width: 96%" align="right">
                            <tr>
                                <td align="center" dir="rtl" colspan="4">
                                    <asp:GridView ID="GrdView_Relation" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                                        GridLines="Vertical" OnRowCommand="GrdView_Relation_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="النوع ">
                                                <ItemTemplate>
                                                    <input type="hidden" runat="server" id="input_type" value='<%# Eval("Related_ID_Type")%>' />
                                                    <%# Get_Type_2(Eval("Related_ID_Type"))%>
                                                    <%-- <%# Eval("inbox_outbox")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الموضوع">
                                                <ItemTemplate>
                                                    <%# Eval("Subject")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="عرض ">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1','1');">
                                <img border="0" id="image1" src="../Images/expand.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1','1');">
                                الوثائق
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <div id="div1" style="display: none">
                        <table style="line-height: 2; width: 96%" align="right">
                            <tr>
                                <td align="center" dir="rtl" colspan="4">
                                    <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
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
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
        <table width="99%" dir="rtl" onload="alert('i am here');">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image2','2');">
                                <img border="0" id="image2" src="../Images/collapse.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image2','2');">
                                التأشيرة
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <div id="div2" style="display: block">
                        <table style="line-height: 2; width: 100%" align="left">
                            <tr id="tr_mngr1" runat="server">
                                <td colspan="4">
                                    <table style="width: 100%;">
                                        <%--  <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="القطاع :" />
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="drop_sectors" AutoPostBack="True" OnSelectedIndexChanged="drop_sectors_SelectedIndexChanged"
                                            runat="server" CssClass="drop" Width="314px" DataTextField="Sec_name" DataValueField="Sec_id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الإدارة التابع لها :" />
                                            </td>
                                            <td colspan="3">
                                                <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl">
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
                                            <td>
                                                <asp:Label ID="Label46" runat="server" CssClass="Label" Text="النوع :" />
                                            </td>
                                            <td align="right" colspan="3">
                                                <asp:RadioButtonList ID="radlst_Type" runat="server" OnSelectedIndexChanged="radlst_Type_SelectedIndexChanged"
                                                    AutoPostBack="True" CssClass="Label" Font-Bold="True" CellPadding="2" CellSpacing="1"
                                                    RepeatColumns="6" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="المفضلة" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="الكل" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="مديري الادارات" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="مسئولي الاتصال" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="  رؤساء اللجان" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="رؤساء الاقسام " Value="6"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr id="tr_emp_list" runat="server">
                                            <td runat="server">
                                                <asp:Label ID="Label47" runat="server" CssClass="Label" Text="الموظف المسئول  :" />
                                            </td>
                                            <td align="right" runat="server">
                                                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px;
                                                    width: 300px" dir="rtl" class="borderControl">
                                                    <asp:CheckBox ID="chk_ALL" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal"
                                                        Text="اختر الكل" AutoPostBack="True" runat="server" OnCheckedChanged="chk_ALL_CheckedChanged">
                                                    </asp:CheckBox>
                                                    <asp:CheckBoxList ID="chklst_Visa_Emp_All" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                                                        CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                        DataValueField="PMP_ID" runat="server">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </td>
                                            <td runat="server">
                                                <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server" CssClass="Button" />
                                                <asp:Button ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server"
                                                    CssClass="Button" />
                                            </td>
                                            <td runat="server">
                                                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                    dir="rtl" class="borderControl">
                                                    <asp:ListBox ID="lst_emp" runat="server" Height="289px" Width="300px" Font-Size="Small">
                                                    </asp:ListBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="tr_old_emp" runat="server">
                                            <td>
                                                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="المسئول عن التنفيذ :" />
                                            </td>
                                            <td align="right" colspan="3">
                                                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                                    dir="rtl">
                                                    <asp:CheckBoxList ID="CheckBoxList1" CellPadding="5" CellSpacing="5" RepeatColumns="6"
                                                        CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                                                        DataValueField="PMP_ID" runat="server">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="tr_old_emp_resp" runat="server">
                                            <td>
                                                <asp:Label ID="Label31" runat="server" CssClass="Label" Text="المسئول عن التنفيذ :" />
                                            </td>
                                            <td align="right" width="100%" colspan="3">
                                                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px;
                                                    width: 100%" dir="rtl" class="borderControl">
                                                    <asp:CheckBoxList ID="chklst_Visa_Emp" CellPadding="5" CellSpacing="5" RepeatColumns="4"
                                                        CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" RepeatLayout="Table"
                                                        TextAlign="Right" DataTextField="pmp_name" DataValueField="PMP_ID" runat="server"
                                                        Width="97%">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="تاريخ التاشيرة :" Width="135px" />
                                            </td>
                                            <td dir="rtl" colspan="3">
                                                <asp:TextBox ID="txt_Visa_date" runat="server" CssClass="Text" Width="153px" Height="20px"></asp:TextBox>
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
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label42" runat="server" CssClass="Label" Text="اخر تاريخ مسموح به  :"
                                                    Width="135px" />
                                            </td>
                                            <td dir="rtl" colspan="3">
                                                <asp:TextBox ID="txt_Dead_Line_DT" runat="server" CssClass="Text" Width="153px" Height="20px"></asp:TextBox>
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
                                            <td align="right" dir="rtl">
                                                <asp:Label ID="Label43" runat="server" CssClass="Label" Text="غرض التاشيرة: " Width="100px" />
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddl_Visa_Goal_ID" runat="server" CssClass="drop" Width="250px">
                                                    <asp:ListItem Text="للدراسة" Value="1" Selected="True"> </asp:ListItem>
                                                    <asp:ListItem Text="للعرض" Value="2"> </asp:ListItem>
                                                    <asp:ListItem Text="للعلم و الإحاطة لإتخاذ اللازم" Value="3"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="نص التأشيرة :" />
                                            </td>
                                            <td align="right" colspan="3">
                                                <asp:TextBox ID="txt_Visa_Desc" runat="server" CssClass="Text" Height="105px" TextMode="MultiLine"
                                                    Width="45%"></asp:TextBox>
                                            </td>
                                        </tr>

                                            <tr>
                                            <td align="right" width="150px">
                                                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                                            </td>
                                            <td dir="rtl" colspan="3">
                                                <asp:FileUpload ID="FileUpload_Visa" runat="server" ForeColor="Maroon" Width="700px" />
                                                <br />
                                            </td>
                                        </tr>

                                    </table>
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
                                        OnRowDataBound="GridView_Visa_rw_data_bound" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        OnRowCommand="GridView_Visa_RowCommand" Font-Size="17px" AllowPaging="true" AllowSorting="true">
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
                                                     <asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("Visa_Desc")%>' Visible ="false" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="الوثيقة">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=outbox_visa&id="+ Eval("Visa_Id") %>'>
                                                        <%# Eval("File_name")%></a>
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
                                                     <asp:Label ID="lbl_emp" runat="server" Text='<%# Eval("Emp_ID")%>' Visible ="false" ></asp:Label>
                                                 
                                                </ItemTemplate>


                                            </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="  الادارة التابع لها ">
                                                            <ItemTemplate>

                                                                <%# Get_Visa_Emp_Dept(Eval("Visa_Id"))%>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="موقف المتابعة">
                                                <ItemTemplate>
                                                    <%# Eval("Follow_Up_Notes")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تم ارسال">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSent" runat="server" Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ارسال" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit123" CommandName="SendItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("Visa_Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("Visa_Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%# Eval("Visa_Id") %>' />
                                                </ItemTemplate>
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
        <table width="99%" dir="rtl" runat="server" id="Trfollow">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35px" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3','3');">
                                <img border="0" id="image3" src="../Images/collapse.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3','3');">
                                المتابعة
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr_follow_person" runat="server">
                <td align="right" colspan="2">
                    <div id="div3" style="display: block">
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
                            <tr id="tr_follow_proj" runat="server" visible="false">
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
                                    <asp:FileUpload ID="FileUpload_Visa_Follow" runat="server" 
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
        <table dir="rtl" style="line-height: 2; width: 99%;">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35px" align="right" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','image5','5');"
                                dir="rtl">
                                <img border="0" id="image5" src="../Images/expand.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','image5','5');"
                                align="right" dir="rtl">
                                المسير
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div id="div5" style="display: none">
                        <table style="line-height: 2; width: 100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left" style="padding-left: 30px" class="style22">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button runat="server" CssClass="Button" Text="طباعة تقرير المسير" ID="btn_print_report"
                                        OnClick="btn_print_report_Click" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:GridView ID="GridView_Visa_Follow" runat="server" AutoGenerateColumns="False"
                                        CellPadding="3" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Visa_Follow_RowCommand"
                                        Font-Size="17px" AllowSorting="True" Width="100%" GridLines="Vertical">
                                        <Columns>
                                            <asp:TemplateField HeaderText="التاريخ">
                                                <ItemTemplate>
                                                    <%# Eval("Date")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الوقت">
                                                <ItemTemplate>
                                                    <%# Eval("time_follow")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الراسل">
                                                <ItemTemplate>
                                                    <%# Eval("pmp_name")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="وصف المتابعة">
                                                <ItemTemplate>
                                                    <%# Eval("Descrption")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الوثيقة" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <a href='<%# "ALL_Document_Details.aspx?type=outbox_follow&id="+ Eval("Follow_ID") %>'>
                                                        <%# Eval("File_name")%></a>
                                                </ItemTemplate>
                                                <ItemStyle Width="40%" HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <%-- <tr>
                        <td align="center" colspan="4" dir="rtl">
                            <asp:LinkButton ID="lnkBtnUnderStudy" runat="server" Text="تحت الدراسة" Font-Bold="true"
                                OnClick="lnkBtnUnderStudy_Click" Visible="false">
                            </asp:LinkButton>
                        </td>
                    </tr>--%>
                            <tr>
                                <td align="center" colspan="4" dir="rtl">
                                    <asp:Button runat="server" CssClass="Button" Text="انهاء حالة التأخير" ID="btn_end_late"
                                        OnClick="btn_end_late_Click" Width="150px" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" dir="rtl">
                                    <asp:Button runat="server" CssClass="Button" Text="إغلاق الموضوع" ID="btn_close_Outbox"
                                        OnClick="btn_close_Outbox_Click" Width="150px" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <table dir="rtl" style="line-height: 2; width: 99%;" runat="server" id="TemplateA"
            visible="false">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35px" align="right" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','Image6','6');"
                                dir="rtl">
                                <img border="0" id="Image6" src="../Images/collapse.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','Image6','6');"
                                align="right" dir="rtl">
                                نماذج عربية
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div id="div6" style="display: none">
                        <table style="line-height: 2; width: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" CssClass="Label" Text="نماذج عربية :" />
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="Drop_arabic_doc" Width="220px" runat="server" CssClass="drop">
                                        <asp:ListItem Text="اختر نموذج ...." Value="0"></asp:ListItem>
                                        <asp:ListItem Text="نموذج خطاب الى مدير مكتب الوزير" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="نموذج ل- احمد فرج" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="نموذج ل ايمن صادق" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="نموذج مذكرة  موارد " Value="7"></asp:ListItem>
                                        <asp:ListItem Text="نموذج مذكرة اتصالات " Value="8"></asp:ListItem>
                                        <asp:ListItem Text="نموذج مذكرة ا-محمد شاهين تلفيات" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="نموذج مذكرة عرض ل-ايمن صادق " Value="10"></asp:ListItem>
                                        <asp:ListItem Text="نموذج مذكرة وزير " Value="11"></asp:ListItem>
                                        <asp:ListItem Text="نموذج تقرير متكامل" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="نموذج تقرير مختصر " Value="2"></asp:ListItem>
                                        <asp:ListItem Text="نموذج خطاب" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button runat="server" CssClass="Button" Text="عرض" ID="btn_arabic_doc" OnClick="btn_arabic_doc_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <table dir="rtl" style="line-height: 2; width: 99%;" runat="server" id="TemplateE"
            visible="false">
            <tr bgcolor="#E6F3FF">
                <td valign="top" align="right" width="95%">
                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                        <tr bgcolor="#E6F3FF">
                            <td width="35px" align="right" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','image7','7');"
                                dir="rtl">
                                <img border="0" id="image7" src="../Images/collapse.gif" />
                            </td>
                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','image7','7');"
                                align="right" dir="rtl">
                                نماذج إنجليزية
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div id="div7" style="display: none">
                        <table style="line-height: 2; width: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="نماذج انجليزية :" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="Drop_english_doc" Width="200" runat="server" CssClass="drop">
                                        <asp:ListItem Text="choose Temp ...." Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Detailed Report Temp" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Short Report Temp" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Letter Temp" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button runat="server" CssClass="Button" Text="عرض" ID="btn_english_doc" OnClick="btn_english_doc_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_Visa_Follow" />
    </Triggers>
    <Triggers>
        <asp:PostBackTrigger ControlID="Button1" />
    </Triggers>
</asp:UpdatePanel>
