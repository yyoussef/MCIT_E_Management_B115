<%@ Control Language="VB" AutoEventWireup="true" CodeFile="proj_info.ascx.vb" Inherits="UserControls_proj_info" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 138px;
    }
    #Table1
    {
        height: 960px;
    }
    .style2
    {
        height: 64px;
    }
    .style3
    {
        width: 138px;
        height: 51px;
    }
    .style4
    {
        height: 51px;
    }
    .style9
    {
        width: 199px;
        height: 64px;
    }
    .style11
    {
        width: 199px;
        height: 49px;
    }
    .style12
    {
        height: 65px;
    }
    .style14
    {
        height: 46px;
    }
</style>
<table style="line-height: 2; width: 100%;" dir="rtl">
    <tr>
        <td align="center">
            <asp:HiddenField ID="Protocol_ID" runat="server" Value="0" />
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="lblID" runat="server" CssClass="Label" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                            Text="البيانات الأساسية للمشروع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr runat="server" id="tr_Smart_Project">
                                <td>
                                    <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                                </td>
                                <td colspan="3" align="right">
                                    <uc1:Smart_Search ID="Smart_Project_ID" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label1" runat="server" CssClass="Label" Text="ملخص المشــروع : " />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtProjBrief" runat="server" CssClass="Text" TextMode="MultiLine"
                                        Height="215px" Width="99%" MaxLength="8000" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label3" runat="server" CssClass="Label" Text="تاريخ اقتراح  المشــروع : " />
                                </td>
                                <td align="right">
                                    <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                                        PopupButtonID="Image1" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="lblstartproj" runat="server" CssClass="Label" Text="تاريخ بداية المشــروع : " />
                                </td>
                                <td align="right">
                                    <cc1:CalendarExtender ID="txtprojstartdate_CalendarExtender" runat="server" TargetControlID="txtprojstartdate"
                                        PopupButtonID="imgstartproj" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="txtprojstartdate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtprojstartdate" />
                                    <asp:TextBox ID="txtprojstartdate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                    <asp:ImageButton runat="Server" ID="imgstartproj" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtprojstartdate"
                                        ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)" ValidationGroup="A"  ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">
                                        </asp:RegularExpressionValidator>
                                        
                             <%--       <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtStartDate"
                                        ControlToValidate="txtprojstartdate" ErrorMessage="تاريخ بداية المشروع يجب ان يكون اكبر من او يساوي تاريخ اقتراح المشروع"
                                        Operator="GreaterThanEqual" Type="Date" ValidationGroup="A"></asp:CompareValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="lblendproj" runat="server" CssClass="Label" Text="تاريخ نهاية  المشــروع : " />
                                </td>
                                <td align="right">
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtprojenddate"
                                        PopupButtonID="imgendproj" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtprojenddate" />
                                    <asp:TextBox ID="txtprojenddate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                    <asp:ImageButton runat="Server" ID="imgendproj" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"
                                        ControlToValidate="txtprojenddate" 
                                        
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                               <%--     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtprojstartdate"
                                        ControlToValidate="txtprojenddate" ErrorMessage="تاريخ نهاية المشروع  يجب ان يكون اكبر من تاريخ البداية"
                                        Operator="GreaterThan" ValidationGroup="A" Type="Date"></asp:CompareValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label11" runat="server" CssClass="Label" Text="الأولويـــــــــــة :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:DropDownList ID="DDLPriority" runat="server" CssClass="Button" Width="230px"
                                        Height="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label2" runat="server" CssClass="Label" Text="الفرص  :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtOpportunities" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label5" runat="server" CssClass="Label" Text="الأخطار :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtDangers" runat="server" TextMode="MultiLine" Height="60px" Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label8" runat="server" CssClass="Label" Text="نقاط القوة :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtStrengths" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label9" runat="server" CssClass="Label" Text="نقاط الضعف :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtWeaknesses" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style1">
                                    <asp:Label ID="label12" runat="server" CssClass="Label" Text="منهجية التنفيذ :" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtmethodology" runat="server" TextMode="MultiLine" Height="60px"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" class="style3">
                                    <asp:Label ID="label6" runat="server" CssClass="Label" Text="نوع مقترح المشروع :" />
                                </td>
                                <td align="right" dir="rtl" class="style4">
                                    <asp:DropDownList ID="DDLSuggestType" runat="server" CssClass="Button" Width="230px"
                                        Height="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" valign="top" class="style12">
                                    <asp:Label ID="label17" runat="server" CssClass="Label" Text=" التصنيف الفني للمشروع :" />
                                </td>
                                <td align="right" dir="rtl" valign="top" class="style12">
                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; width: 75%"
                                        dir="rtl" class="borderControl">
                                        <asp:CheckBoxList ID="CheckCategory" CellPadding="2" CellSpacing="2" RepeatColumns="4"
                                            Width="97%" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="proj_category"
                                            DataValueField="id" runat="server" DataSourceID="SqlCategory">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" valign="baseline">
                                    <asp:Label ID="label19" runat="server" CssClass="Label" Text="تصنيفات أخري:" />
                                </td>
                                <td align="right" dir="rtl" valign="baseline" class="style14">
                                    <asp:TextBox ID="txtCategory" runat="server" CssClass="Text"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" valign="top" class="style9">
                                    <asp:Label ID="label18" runat="server" CssClass="Label" Text="تقنية المشروع المستخدمة:" />
                                </td>
                                <td align="right" dir="rtl" valign="top" class="style2">
                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; width: 75%"
                                        dir="rtl" class="borderControl">
                                        <asp:CheckBoxList ID="CheckTechnique" CellPadding="2" CellSpacing="2" RepeatColumns="4"
                                            CssClass="Label" Font-Size="Small" DataTextField="technique" DataValueField="id"
                                            runat="server" DataSourceID="SqlTechnique" Width="100%">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" valign="middle" class="style11">
                                    <asp:Label ID="label20" runat="server" CssClass="Label" Text="تقنيات أخري:" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:TextBox ID="txtTech" runat="server" CssClass="Text"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" dir="rtl" rowspan="3">
                                    <asp:Label ID="label4" runat="server" CssClass="Label" Text="ميزانية المشروع : " />
                                </td>
                                <td align="right" colspan="1" dir="rtl" width="300" class="style2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCoast" runat="server" CssClass="Text" Width="225px" AutoPostBack="True" />
                                            <cc1:FilteredTextBoxExtender ID="txtCoast_filtered" runat="server" FilterType="Custom"
                                                ValidChars=".0123456789" TargetControlID="txtCoast" />
                                            <asp:Label ID="EGY_POUND" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black"
                                                Text="ج.م" />
                                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="" />
                                            <asp:Label ID="EGY_POUND1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black"
                                                Text="ج.م" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="1" dir="rtl" width="300">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" ValidationGroup="A" />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tblfinance" runat="server" width="100%" dir="rtl">
                            <tr>
                                <td valign="top" align="right" colspan="2">
                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                        <tr >
                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                                                <img border="0" id="image1" src="../Images/square_arrow_down.gif" />
                                            </td>
                                            <td 
                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');"
                                                colspan="1">
                                                تفاصيل الميزانية
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="div1" style="display: block">
                                        <table id="Table2" width="100%" class="border">
                                            <tr>
                                                <td align="right" colspan="4">
                                                    <asp:Label ID="label7" runat="server" CssClass="Label" Text="السنة المالية:" />
                                                    &nbsp;
                                                    <asp:DropDownList ID="Quarter_year" runat="server" CssClass="drop" Width="150px">
                         
                                                    </asp:DropDownList>
                                                  
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="Grid_Supply" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="GridAct" ShowHeader="False" AlternatingRowStyle-CssClass="altAct"
                                                        Font-Size="17px" OnRowCommand="grdView_Main_RowCommand" 
                                                        GridLines="Vertical">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                                        <tr style="background-color: #C2DDF0">
                                                                            <td>
                                                                                <table width="100%">
                                                                                    <tr onclick="ChangeMeCase('<%#"DV" & Eval("Sources_ID")%>','<%#"Src" & Eval("Sources_ID")%>');"
                                                                                        onmouseover="this.style.cursor='hand'">
                                                                                        <td align="right" style="width: 5%">
                                                                                            <img border="0" id='<%#"Src" & Eval("Sources_ID")%>' src="../Images/square_arrow_flipped.gif" />
                                                                                        </td>
                                                                                        <td align="right" style="width: 85%">
                                                                                            <%#Eval("Source_Name")%>
                                                                                            <asp:HiddenField ID="Sources_ID" runat="server" Value='<%#Eval("Sources_ID")%>' />
                                                                                        </td>
                                                                                        <td align="center" style="width: 5%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="center" style="width: 5%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" style="padding-right: 40px;">
                                                                                <div id='<%#"DV" & Eval("Sources_ID")%>'>
                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:GridView ID="Grid_Supply_Sub" runat="server" DataSource='<%#GetDataSetProvider(Eval("Sources_ID").ToString())%>'
                                                                                                    AutoGenerateColumns="False" CellPadding="4" Width="99%" BackColor="White" ForeColor="Black"
                                                                                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="70%" HeaderStyle-HorizontalAlign="Center"
                                                                                                            ItemStyle-Width="70%">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:HiddenField ID="AmountValue" Value='' runat="server" />
                                                                                                                <asp:HiddenField ID="Provider_ID" runat="server" Value='<%#Eval("Provider_ID")%>' />
                                                                                                                <%#Eval("Provider_Name")%>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="70%" />
                                                                                                            <ItemStyle Width="70%" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="القيمة" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                                                            ItemStyle-Width="20%">
                                                                                                            <ItemTemplate>
                                                                                                                <center>
                                                                                                                    <asp:TextBox ID="txtpartamount" runat="server" Text='<%# Eval("Value")%>' Width="100px"
                                                                                                                        Height="30px"></asp:TextBox>
                                                                                                                    <asp:Label ID="EGY_POUND0" runat="server" Text="ج.م" Font-Bold="True" Font-Size="Larger"
                                                                                                                        ForeColor="Black" />
                                                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                                                                                                        ValidChars=".0123456789" TargetControlID="txtpartamount" />
                                                                                                                </center>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="تم إستلام الشيك" HeaderStyle-Width="5%"
                                                                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                                                            <ItemTemplate>
                                                                                                                <center>
                                                                                                                    <asp:CheckBox ID="Cheque_Received" Visible='<%# Eval("Cheque")%>' runat="server" />
                                                                                                                </center>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" />
                                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Button ID="btnpartfinance" runat="server" CssClass="Button" Text=" حفـــظ الفترة"
                                                        Height="30px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button1" runat="server" CssClass="Button" Text="فترة جديدة" Height="30px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" dir="rtl" colspan="4">
                                                    <asp:GridView ID="grdView_Main" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="GridAct" ShowHeader="False" AlternatingRowStyle-CssClass="altAct"
                                                        Font-Size="17px" OnRowCommand="grdView_Main_RowCommand" 
                                                        GridLines="Vertical">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                                        <tr style="background-color: #C2DDF0">
                                                                            <td>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="right" style="width: 5%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td align="right" style="width: 85%">
                                                                                            <%#Eval("Quarter_Year")%>
                                                                                        </td>
                                                                                        <td align="center" style="width: 5%">
                                                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                                                CommandArgument='<%# Eval("Period_ID") %>' />
                                                                                        </td>
                                                                                        <td align="center" style="width: 5%">
                                                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                                                Style="height: 22px;" CommandArgument='<%# Eval("Period_ID") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" />
                                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" dir="rtl" style="text-align: center" class="Text" colspan="4">
                                                    <asp:GridView ID="gvfinance" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                                                        Width="100%" AllowSorting="True" Visible="False" 
                                                        EmptyDataText="... عفوا لا توجد تفاصيل للميزانية ..." BackColor="White" 
                                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                                        ForeColor="Black" GridLines="Vertical">
                                                        <Columns>
                                                            <%--<asp:BoundField DataField="PDOC_FileName" HeaderText="اسم الوثيقة" />--%>
                                                            <asp:BoundField HeaderText="تاريخ بداية الفترة" DataField="Strt_Date" />
                                                            <asp:BoundField HeaderText="تاريخ نهاية الفترة" DataField="End_Date" />
                                                            <asp:BoundField HeaderText="القيمة" DataField="int_Init_Value" />
                                                            <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="finance_ImgBtnEdit_Click"
                                                                        CommandArgument='<%# Eval("Period_ID") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="حذف" ItemStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                                        OnClick="finance_ImgBtnDelete_Click" CommandArgument='<%# Eval("Period_ID") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" />
                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Text" align="center">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                            Visible="False" BorderWidth="1px" GridLines="Vertical">
                            <Columns>
                                <asp:BoundField HeaderText="اسم الادارة" DataField="Dept_name" />
                                <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                <asp:BoundField HeaderText="مدير المشروع" DataField="PTem_Name" />
                                <asp:TemplateField HeaderText="تعديل" Visible="false">
                                    <ItemTemplate>
                                        <input id="Proj_id" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                            CommandArgument='<%# Eval("Proj_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف" Visible="false">
                                    <ItemTemplate>
                                        <input id="Proj_id1" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                        &nbsp;&nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                            OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Proj_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                HorizontalAlign="Center"></PagerStyle>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <input id="Proj_id" runat="server" value="0" type="hidden" />
            <input id="Proj_id1" runat="server" type="hidden" />
            <input id="PDOC_id1" runat="server" type="hidden" />
            <input id="PDOC_id2" runat="server" type="hidden" />
            <input id="PDOC_id3" runat="server" type="hidden" />
            <asp:SqlDataSource ID="SqlTechnique" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT * FROM [Technique]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
        </td>
    </tr>
</table>

<script language="javascript" type="text/javascript">

    function ChangeMeCase(divid, imgid) {

        var divname = document.getElementById(divid);
        var img = document.getElementById(imgid);

        var imgsrc = img.src;


        if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
            img.src = "../Images/square_arrow_down.gif";
        }
        else {
            img.src = "../Images/square_arrow_flipped.gif";
        }
        divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
    }



    function SelectAll(Div_ID, Div_Chk_ID) {

                var Chk_ID;

                // alert(Div_Chk_ID);
                var elements = document.getElementById(Div_Chk_ID).getElementsByTagName("input");
                //  alert(elements.length);
                for (xx = 0; xx < elements.length; xx++) {
                    if (IsCheckBox(elements[xx]))
                        Chk_ID = elements[xx];

                }

                var DIVs = document.getElementsByTagName("DIV");
                for (i = 0; i < DIVs.length; i++) {
                    //alert(DIVs[i].ID);
                    if (DIVs[i].id == Div_ID) {
                        var elements = DIVs[i].getElementsByTagName("input");
                        for (x = 0; x < elements.length; x++) {
                            if (IsCheckBox(elements[x])) {
                                if (Chk_ID.checked)
                                    elements[x].checked = true;
                                else
                                    elements[x].checked = false;
                            }
                        }
                        //alert("here");
                    }

         }




    }


    function IsCheckBox(chk) {
               if (chk.type == 'checkbox') return true;
                else return false;
    }
        
        
</script>

