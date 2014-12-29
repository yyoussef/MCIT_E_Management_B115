<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Protocol_Main_Control.ascx.cs" Inherits="UserControls_Protocol_Main_Control" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
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

    <div align="center">
        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="بروتوكولات / اتفاقيات"></asp:Label>
    </div>
    <div>
        <cc1:TabContainer runat="server" ID="TabPanel_All" Height="1500px" ActiveTabIndex="0">
            <cc1:TabPanel ID="TabPanel_Main" runat="server">
                <HeaderTemplate>
                    <asp:Label ID="Label16" runat="server" CssClass="Label" Font-Size="11px" Text="البيانات الرئيسية" />
                </HeaderTemplate>
                <ContentTemplate>
                    <table width="100%" style="line-height: 2; color: Black">
                        <tr>
                            <td dir="rtl" align="center">
                                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td dir="rtl" align="center" style="height: 61px">
                                <table width="100%">
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label14" runat="server" CssClass="Label" Text=" النوع : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop">
                                                <asp:ListItem Value="1" Selected="True" Text="بروتوكول"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="اتفاقية"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="موافقة سلطة مختصة"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" الاسم : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:TextBox ID="txt_Name" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Name"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال الاسم "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" المسئول : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                                <uc1:Smart_Search ID="Smart_PMP_ID" runat="server" />
                                        
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" تاريخ التوقيع : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:TextBox ID="txt_Signt_DT" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Signt_DT"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال تاريخ التوقيع "></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" TargetControlID="txt_Signt_DT"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="Image1" TargetControlID="txt_Signt_DT" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="Image1" runat="server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text=" تاريخ البداية : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:TextBox ID="txt_Strt_DT" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Strt_DT"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال تاريخ البداية "></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_Strt_DT"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton7"
                                                TargetControlID="txt_Strt_DT" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton7" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" تاريخ النهاية : " />
                                        </td>
                                        <td align="right" dir="rtl">
                                            <asp:TextBox ID="txt_End_DT" runat="server" Height="26px" CssClass="Text" AutoPostBack="True"
                                                OnTextChanged="txt_End_DT_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_End_DT"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال تاريخ النهاية "></asp:RequiredFieldValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_End_DT"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                                TargetControlID="txt_End_DT" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
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
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txt_Period_Day" runat="server" Height="20px" MaxLength="2" Width="30px"
                                                                CssClass="Text"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_Period_Month" runat="server" Height="20px" MaxLength="2" Width="30px"
                                                                CssClass="Text"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt_Period_Year" runat="server" Height="20px" Width="60px" MaxLength="4"
                                                                CssClass="Text"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                         <asp:Button runat="server"  Text="..." ID="Button1" OnClick="btnCalc_Click" Width="20px" />
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
                        <tr>
                            <td align="center">
                                <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                                    ValidationGroup="A" Width="99px" />
                                <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btn_New" Width="99px" OnClick="btn_New_Click" />
                            </td>
                        </tr>
                        <tr style="width: 100%">
                            <td valign="top" align="right">
                                <table id="Table2" cellpadding="0" cellspacing="0" style="height: 27px; width: 100%;">
                                    <tr id="Tr3" bgcolor="#E6F3FF">
                                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','img2');">
                                            <img border="0" id="img2" src="../Images/expand.gif" />
                                        </td>
                                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
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
                                            <td>
                                                <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" الجهة : " />
                                            </td>
                                            <td>
                                                <uc1:Smart_Search ID="Smart_Org1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl">
                                                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="المبلغ بالعملة المحلية : " />
                                            </td>
                                            <td align="right" dir="rtl">
                                                <asp:TextBox ID="txtAmountLE" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtAmountLE" Enabled="True" />
                                            </td>
                                            <td align="right" dir="rtl">
                                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="بالاجنبية: " />
                                            </td>
                                            <td align="right" dir="rtl">
                                                <asp:TextBox ID="txtAmountUS" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtAmountUS" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 26px">
                                                <asp:Button ID="btn_Org1" Enabled="False" Text="حفظ" OnClick="btn_Org1_Click" Width="100px"
                                                    runat="server" CssClass="Button" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="GridView_Org1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                    OnRowCommand="GridView_Org1_RowCommand" Font-Size="17px" 
                                                    GridLines="Vertical">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                        <asp:BoundField HeaderText="المبلغ بالعملة المحلية" DataField="Total_Balance_LE" />
                                                        <asp:BoundField HeaderText="المبلغ بالعملة الاجنبية" DataField="Total_Balance_US" />
                                                        <asp:TemplateField HeaderText="تعديل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="حذف">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                    Style="height: 22px" CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
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
                                    <tr id="Tr1" bgcolor="#E6F3FF">
                                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','img1');">
                                            <img border="0" id="img1" src="../Images/expand.gif" />
                                        </td>
                                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
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
                                            <td>
                                                <asp:Label ID="Label13" runat="server" CssClass="Label" Text=" الجهة : " />
                                                
                                            </td>
                                            <td>
                                                <uc1:Smart_Search ID="Smart_Org2" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 26px">
                                                <asp:Button ID="btn_Org2" Enabled="False" Text="حفظ" OnClick="btn_Org2_Click" Width="100px"
                                                    runat="server" CssClass="Button" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="GridView_Org2" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                    OnRowCommand="GridView_Org2_RowCommand" Font-Size="17px" 
                                                    GridLines="Vertical">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                        <asp:TemplateField HeaderText="تعديل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="حذف">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                    Style="height: 22px" CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
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
                                    <tr id="Tr5" bgcolor="#E6F3FF">
                                        <td colspan="1" width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','img3');">
                                            <img border="0" id="img3" src="../Images/expand.gif" />
                                        </td>
                                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
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
                                            <td>
                                                <asp:Label ID="Label15" runat="server" CssClass="Label" Text=" الجهة : " />
                                                
                                            </td>
                                            <td>
                                                <uc1:Smart_Search ID="Smart_Org3" Validation_Group="A3" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 26px">
                                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="btn_Org3" OnClick="btn_Org3_Click"
                                    ValidationGroup="A3" Width="99px" Enabled="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="GridView_Org3" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                    OnRowCommand="GridView_Org3_RowCommand" Font-Size="17px" 
                                                    GridLines="Vertical">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                        <asp:TemplateField HeaderText="تعديل">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                    CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="حذف">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                    Style="height: 22px" CommandArgument='<%# Eval("Protocol_Org_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
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
                                <asp:Label ID="Label19" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="70%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                                        </td>
                                        <td align="right">
                                         <uc1:Smart_Search ID="Smart_all_Project" runat="server" Validation_Group="P" />
                                            <%--<asp:TextBox ID="txt_Project" Height="26px" Width="500px" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_Project"
                                                runat="server" Text="*" ValidationGroup="P" ErrorMessage="يجب ادخال اسم المشروع  "></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="height: 26px">
                                            <br />
                                            <asp:Button ID="btn_save_Project" Enabled="false" Text="حفظ" OnClick="btn_save_Project_Click"
                                                Width="100px" runat="server" CssClass="Button" ValidationGroup="P" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView_Projects" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    OnRowCommand="GridView_Projects_RowCommand" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                    Font-Size="17px">
                                    <Columns>
                                        <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                     <%--   <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                    CommandArgument='<%# Eval("Proj_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                    Style="height: 22px" CommandArgument='<%# Eval("Proj_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                        <tr>
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
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="Text" ID="txtFileName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtFileName"
                                    runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال اسم الوثيقــــــــة  "></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="الوثيقة:" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" Width="300px" />
                            </td>
                        </tr>
                        <tr>
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
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="Label" Text="وصف الوثيقة:" Width="135px" />
                                
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="Text" ID="txt_File_desc" TextMode="MultiLine"
                                    Rows="4" Height="50px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <br />
                                <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" ValidationGroup="D" Enabled="false"
                                    Text="حفظ الوثيقة" runat="server" CssClass="Button" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
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
                                        <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
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
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
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
    </div>