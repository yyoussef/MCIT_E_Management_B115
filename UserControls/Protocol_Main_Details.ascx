<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Protocol_Main_Details.ascx.cs"
    Inherits="UserControls_Protocol_Main_Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

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

<div align="center">
    <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="بروتوكولات / اتفاقيات"></asp:Label>
</div>
<div>
    <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px" 
        ActiveTabIndex="0"   onactivetabchanged="TabPanel_All_ActiveTabChanged" >
        <cc1:TabPanel ID="TabPanel_Main" runat="server"   >
            <HeaderTemplate>
                <asp:Label ID="Label16" runat="server" CssClass="Label" Font-Size="11px" Text="البيانات الرئيسية" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%" style="line-height: 2; color: Black">
                    <tr>
                        <td dir="rtl" align="center">
                            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl" align="center" style="height: 61px">
                            <table width="100%">
                                <tr>
                                    <td align="right" dir="rtl" colspan="2">
                                        <asp:Label ID="Label14" runat="server" CssClass="Label" Text=" النوع : " />
                                        <asp:Label ID="lblType" runat="server" CssClass="Label"  />
                                    </td>
                                   
                                    
                                    <td align="right" dir="rtl" colspan="2" >
                                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" الاسم : " />
                                         <asp:TextBox ID="txt_Name" Height="50px" CssClass="Text" runat="server" TextMode="MultiLine" ReadOnly="True" Width="500px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Name"
                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال الاسم "></asp:RequiredFieldValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" colspan="2">
                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" المسئول : " />
                                         <asp:Label ID="lbl_resp_emp" runat="server" CssClass="Label"  />
                                    </td>
                                   
                                    <td align="right" dir="rtl">
                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" تاريخ التوقيع : " />
                                         <asp:Label ID="lbl_sign_date" runat="server" CssClass="Label"  />
                                    </td>
                                    <td align="right" dir="rtl" >
                                        <asp:Label ID="Label30" runat="server" CssClass="Label" Text=" تاريخ البداية : " />
                                        <asp:Label ID="lbl_start_date" runat="server" CssClass="Label" Text=" تاريخ البداية : " />
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" colspan="2">
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" تاريخ النهاية : " />
                                         <asp:Label ID="lbl_end_date" runat="server" CssClass="Label"  />
                                    </td>
                                    <td align="right" dir="rtl" colspan="2">
                                     <asp:Label ID="Label28" runat="server" CssClass="Label" Text=" موقف البروتوكول : " />
                                     <asp:Label ID="lbl_prot_sit" runat="server" CssClass="Label" />
                                     
                                    </td>
                                    
                                </tr>
                               
                                <tr>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" CssClass="Label" Text="المدة : " />
                                    </td>
                                    <td colspan="3" align="right">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="يوم  " />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="شهر  " />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="سنة  " />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                         <asp:Label ID="lbl_Period_Day" runat="server" CssClass="Label" ></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Period_month" runat="server" CssClass="Label" ></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lbl_Period_year" runat="server" CssClass="Label" ></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td valign="top" align="right">
                            <table id="Table2" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                                <tr id="Tr3" >
                                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','img2');">
                                        <img border="0" id="img2" src="../Images/square_arrow_down.gif" />
                                    </td>
                                    <td 
                                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','img2');"
                                        colspan="2">
                                        الجهات المشاركة
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr4">
                        <td>
                            <div id="div2" style="display: block" dir="rtl">
                                <table width="100%">
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView_Org1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                 Font-Size="17px" GridLines="Vertical">
                                                <Columns>
                                                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                    <asp:BoundField HeaderText="المبلغ بالعملة المحلية" DataField="Total_Balance_LE" />
                                                    <asp:BoundField HeaderText="المبلغ بالعملة الاجنبية" DataField="Total_Balance_US" />
                                                </Columns>
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="اجمالى الموازنة التقديرية بالعملة المحلية: " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Total_Balance_LE" Height="26px" Enabled="False" CssClass="Text"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text="ج.م" />
                                                    </td>
                                                    <td width="50px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="بالاجنبية: " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Total_Balance_US" Height="26px" Enabled="False" CssClass="Text"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td valign="top" align="right">
                            <table id="Table1" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                                <tr id="Tr1" >
                                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','img1');">
                                        <img border="0" id="img1" src="../Images/square_arrow_down.gif" />
                                    </td>
                                    <td 
                                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','img1');"
                                        colspan="2">
                                        الجهات المستفيدة
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr2">
                        <td>
                            <div id="div1" style="display: block" dir="rtl">
                                <table width="100%">
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView_Org2" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <Columns>
                                                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                </Columns>
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td valign="top" align="right">
                            <table id="Table3" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                                <tr id="Tr5" >
                                    <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','img3');">
                                        <img border="0" id="img3" src="../Images/square_arrow_down.gif" />
                                    </td>
                                    <td 
                                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','img3');"
                                        colspan="2">
                                        الجهات المنفذة
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr6">
                        <td>
                            <div id="div3" style="display: block" dir="rtl">
                                <table width="100%">
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView_Org3" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                 Font-Size="17px" GridLines="Vertical">
                                                <Columns>
                                                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                </Columns>
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_Project" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label17" runat="server" CssClass="Label" Font-Size="11px" Text="المشروعات" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%" style="line-height: 2; color: Black">
                    <tr>
                        <td dir="rtl" align="center">
                            <asp:Label ID="Label19" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="70%">
                               <%-- <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                                    </td>
                                    <td align="right">
                                        <uc1:Smart_Search ID="Smart_all_Project" runat="server" Validation_Group="P" />
                                        <asp:TextBox ID="txt_Project" Height="26px" Width="500px" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_Project"
                                                runat="server" Text="*" ValidationGroup="P" ErrorMessage="يجب ادخال اسم المشروع  "></asp:RequiredFieldValidator>
                                    </td>
                                </tr>--%>
                                <%--<tr>
                                    <td colspan="2" align="center" style="height: 26px">
                                        <br />
                                        <asp:Button ID="btn_save_Project" Enabled="false" Text="حفظ" OnClick="btn_save_Project_Click"
                                            Width="100px" runat="server" CssClass="Button" ValidationGroup="P" />
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_Projects" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                Font-Size="17px">
                                <Columns>
                                    <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                    <%--   <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                    CommandArgument='<%# Eval("Proj_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px" CommandArgument='<%# Eval("Proj_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_Files" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label18" runat="server" CssClass="Label" Font-Size="11px" Text="الملفات" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="نوع الوثيقة:" Width="135px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_File_Kind" runat="server" CssClass="drop">
                                <asp:ListItem Text="اتفاقية/بروتوكول" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="خطابات" Value="2"></asp:ListItem>
                                <asp:ListItem Text="مذكرات عرض" Value="3"></asp:ListItem>
                                <asp:ListItem Text="أخرى" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label22" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="txtFileName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtFileName"
                                runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال اسم الوثيقــــــــة  "></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="الوثيقة:" />
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" Width="300px" />
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label24" runat="server" CssClass="Label" Text="تاريخ الوثيقة: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_File_Date" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                TargetControlID="txt_File_Date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton6"
                                TargetControlID="txt_File_Date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton6" runat="Server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label25" runat="server" CssClass="Label" Text="وصف الوثيقة:" Width="135px" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="txt_File_desc" TextMode="MultiLine"
                                Rows="4" Height="50px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td colspan="2" align="center">
                            <br />
                            <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" ValidationGroup="D" Enabled="false"
                                Text="حفظ الوثيقة" runat="server" CssClass="Button" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                Font-Size="17px">
                                <Columns>
                                    <asp:TemplateField HeaderText="الوثيقة">
                                        <ItemTemplate>
                                            <a href='<%# "ALL_Document_Details.aspx?type=protocolmain&id="+ Eval("id") %>'>
                                                <%# Eval("File_name")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="نوع الوثيقة">
                                        <ItemTemplate>
                                            <%# Get_Type(Eval("File_Kind"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تاريخ الوثيقة">
                                        <ItemTemplate>
                                            <%# Eval("File_Date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="وصف الوثيقة">
                                        <ItemTemplate>
                                            <%# Eval("File_desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px" CommandArgument='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_committee" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label313" runat="server" CssClass="Label" Font-Size="11px" Text=" لجنة البروتوكول / الاتفاقية" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td dir="rtl" align="center" style="height: 100%">
                            <table width="100%">
                               <%-- <tr>
                                    <td align="right" dir="rtl">
                                        <asp:Label ID="Label32" runat="server" CssClass="Label" Text="  الاسم / الصفة: " />
                                    </td>
                                    <td align="right" dir="rtl">
                                        <asp:TextBox ID="Txt_Person_data" Height="26px" CssClass="Text" Width="500px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <%--<tr id="tr_org_out" runat="server">
                                    <td align="right" dir="rtl">
                                        <asp:Label ID="Label35" runat="server" CssClass="Label" Text="الجهة  :" />
                                    </td>
                                    <td align="right" dir="rtl">
                                        <uc1:Smart_Search ID="Smart_Org_ID" runat="server" />
                                    </td>
                                </tr>--%>
                               <%-- <tr>
                                    <td align="right" dir="rtl">
                                        <asp:Label ID="Label44" runat="server" CssClass="Label" Text="ملاحظات : " />
                                    </td>
                                    <td align="right" dir="rtl">
                                        <asp:TextBox ID="Txt_notes" Height="70px" CssClass="Text" Width="500px" runat="server"></asp:TextBox>
                                </tr>--%>
                                <%--<tr>
                                    <td colspan="2">
                                        <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave_committee"
                                            ValidationGroup="A" Width="99px" OnClick="BtnSave_committee_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="GridView_Protocole_Committee" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC"
                                            BorderStyle="None" BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                                            AllowPaging="true" AllowSorting="true" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="الاسم / الصفة">
                                                    <ItemTemplate>
                                                        <%# Eval("Person_Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="الجهة / الادارة">
                                                    <ItemTemplate>
                                                        <%# Eval("Org_desc")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                            CommandArgument='<%# Eval("ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                            Style="height: 22px" CommandArgument='<%# Eval("ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <PagerStyle CssClass="pgr" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
        ShowMessageBox="true" ShowSummary="false" />
</div>
<div>
    <input type="hidden" runat="server" id="hidden_Doc_ID" />
    <input type="hidden" runat="server" id="hidden_committe_id" />
    <input id="hidden_Balance_ID" type="hidden" runat="server" />
    <input type="hidden" runat="server" id="hidden_Protocol_ID" />
    <input id="hidden_Status" runat="server" type="hidden" value="1" />
    <input type="hidden" runat="server" id="hidden_Protocol_Org_ID1" />
    <input id="hidden_LE" runat="server" type="hidden" />
    <input id="hidden_US" runat="server" type="hidden" />
    <input type="hidden" runat="server" id="hidden_Protocol_Org_ID2" />
    <input type="hidden" runat="server" id="hidden_Protocol_Org_ID3" />
    <input type="hidden" runat="server" id="hidden1" />
    <input type="hidden" runat="server" id="hidden_Proj_id" />
    <input type="hidden" runat="server" id="hidden_Related_ID" />
    <input type="hidden" runat="server" id="hidden_org_type" />
    <input type="hidden" runat="server" id="hidden_job" />
    <input type="hidden" runat="server" id="hidden_dept_id" />
</div>
