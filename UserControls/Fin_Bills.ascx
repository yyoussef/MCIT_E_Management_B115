<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Fin_Bills.ascx.cs" Inherits="UserControls_Fin_Bills" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    function Get_Value()
{
var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex+1,dotindex);

document.getElementById('<%= txtFileName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
</script>

<input id="proj_id" type="hidden" runat="server" />
<table width="100%" style="line-height: 2; color: Black">
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="الفواتير"></asp:Label>
        </td>
    </tr>
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            <input type="hidden" runat="server" id="hidden_Bil_ID" />
            <asp:Label ID="lbl_Work_Total_Value" Visible="false" runat="server"></asp:Label>
        </td>
    </tr>
    <tr runat="server" id="tr_Smart_Project">
        <td>
            <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم المشروع : " />
        </td>
        <td>
            <uc1:Smart_Search ID="Smart_Project_ID" runat="server" />
        </td>
    </tr>
    <tr>
        <td dir="rtl" align="right" style="height: 61px" colspan="2">
            <asp:Panel ID="pnl_bil" runat="server" Visible="false">
                <table width="100%">
                    <tr>
                        <td>
                            <div valign="Top">
                                <cc1:TabContainer runat="server" ID="TabPanel_All" Height="300px" ActiveTabIndex="0">
                                    <cc1:TabPanel ID="TabPanel_dtl" runat="server" TabIndex="0">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="تفاصيل الفواتير" />
                                            <input type="hidden" runat="server" id="hidden1" />
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table align="right">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" النوع : " />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_Type" runat="server" CssClass="drop">
                                                            <asp:ListItem Text="فاتورة" Value="1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="إشعار خصم" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" أمر التوريد : " />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="ddl_Work_Order" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Work_Order_SelectedIndexChanged"
                                                            runat="server" CssClass="drop">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" رقم الفاتورة : " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Code" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Code"
                                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال رقم الفاتورة "></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" التاريخ : " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Date" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" TargetControlID="txt_Date"
                                                            ValidChars="0987654321/\" Enabled="True" />
                                                        <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="Image1" TargetControlID="txt_Date" Enabled="True">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="Image1" runat="server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                                            ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Date"
                                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" CssClass="Label" Text=" النسبة : " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Bil_Percent" Height="26px" AutoPostBack="True" OnTextChanged="txt_Bil_Percent_TextChanged"
                                                            CssClass="Text" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" CssClass="Label" Text=" القيمة: " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Bil_Value" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Bil_Value"
                                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال قيمة الفاتورة "></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ControlToValidate="txt_Bil_Value" ErrorMessage="قيمة الفاتورة يجب ان تكون اكبر من صفر"
                                                            ID="RangeValidator2" Type="Double" runat="server" Display="Dynamic" MaximumValue="1000000000"
                                                            MinimumValue="1" ValidationGroup="A">*</asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="مصدر التمويل: " />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_Source" Width="250px" runat="server" CssClass="Button"
                                                            Font-Bold="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_Source_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddl_Provider" runat="server" CssClass="Button" DataTextField="Provider_Name"
                                                            DataValueField="Provider_ID" Font-Bold="True" Width="368px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" ملاحظات : " />
                                                    </td>
                                                    <td colspan="3" align="right">
                                                        <asp:TextBox ID="txt_Notes" Width="350px" TextMode="MultiLine" Rows="3" Height="50px"
                                                            CssClass="Text" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel ID="TabPanel_Needs" runat="server">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label17" runat="server" CssClass="Label" Font-Size="11px" Text="البنود" />
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" width="150px">
                                                        <asp:Label ID="Label18" runat="server" CssClass="Label" Text="البند الرئيسى:" />
                                                        <input type="hidden" runat="server" id="hidden_Fin_Need_ID" />
                                                    </td>
                                                    <td dir="rtl">
                                                        <asp:DropDownList ID="ddl_NMT_ID" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_NMT_ID_SelectedIndexChanged"
                                                            runat="server" CssClass="drop">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ControlToValidate="ddl_NMT_ID" ErrorMessage="يجب اختيار الشركة"
                                                            ID="RangeValidator3" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                                            MinimumValue="1" ValidationGroup="C">*</asp:RangeValidator>
                                                    </td>
                                                    <td align="right" dir="rtl">
                                                        <asp:Label ID="Label22" runat="server" CssClass="Label" Text="البند الفرعى: " />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_NST_ID" runat="server" Width="200px" CssClass="drop">
                                                        </asp:DropDownList>
                                                        <asp:RangeValidator ControlToValidate="ddl_NST_ID" ErrorMessage="يجب اختيار الشركة"
                                                            ID="RangeValidator1" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                                            MinimumValue="1" ValidationGroup="C">*</asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" dir="rtl">
                                                        <asp:Label ID="Label23" runat="server" CssClass="Label" Text="القيمة : " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Value" Height="26px" runat="server" CssClass="Text"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_Value"
                                                            runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال القيمة "></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Button ID="btn_Needs" OnClick="btn_Needs_Click" Text="حفظ " runat="server" ValidationGroup="C"
                                                            CssClass="Button" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="GridView_Needs" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                            BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Needs_RowCommand"
                                                            Font-Size="17px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="البند الرئيسى">
                                                                    <ItemTemplate>
                                                                        <%#Eval("NMT_Desc")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="البند الفرعى">
                                                                    <ItemTemplate>
                                                                        <%#Eval("NST_Desc")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="القيمة">
                                                                    <ItemTemplate>
                                                                        <%#Eval("Value")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                            CommandArgument='<%# Eval("Fin_Need_ID") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                            Style="height: 22px" CommandArgument='<%# Eval("Fin_Need_ID") %>' />
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
                                    <cc1:TabPanel ID="TabPanel_Visa" runat="server">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label24" runat="server" CssClass="Label" Font-Size="11px" Text="الملفات" />
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" width="150px">
                                                        <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الملف:" Width="135px" />
                                                        <input type="hidden" runat="server" id="hidden_File_ID" />
                                                    </td>
                                                    <td dir="rtl">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                                                            Width="300px" />
                                                        <br />
                                                    </td>
                                                    <td align="right" dir="rtl">
                                                        <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم الملف: " />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" dir="rtl">
                                                        <asp:Label ID="Label21" runat="server" CssClass="Label" Text="وصف الملف : " />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txt_File_Desc" runat="server" CssClass="Text" Height="30px" Width="90%"
                                                            Rows="6" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="حفظ الملف" runat="server"
                                                            CssClass="Button" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 150px">
                                                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                Width="90%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                                                                Font-Size="17px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="اللف">
                                                                        <ItemTemplate>
                                                                            <a href='<%# "ALL_Document_Details.aspx?type=work&id="+ Eval("File_ID") %>'>
                                                                                <%#Eval("File_name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="وصف الملف">
                                                                        <ItemTemplate>
                                                                            <%#Eval("File_Desc")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                                CommandArgument='<%# Eval("File_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                                Style="height: 22px" CommandArgument='<%# Eval("File_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                </cc1:TabContainer>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label13" runat="server" CssClass="Label" Text=" الأنشطة المستفيدة: " />
                                </legend>
                                <div>
                                    <asp:GridView ID="grdView_Bil_Dtl" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        OnRowCommand="grdView_Bil_Dtl_RowCommand" Font-Size="17px" OnRowDeleting="grdView_Bil_Dtl_RowDeleting"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField HeaderText="اسم النشاط" DataField="PActv_Desc" />
                                            <asp:TemplateField HeaderText="ملاحظات">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Notes" Height="50px" Text='<%# Eval("Notes") %>' TextMode="MultiLine"
                                                        Rows="2" CssClass="Text" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الكمية">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Quantity" Height="26px" CssClass="Text" Text='<%# Eval("Quantity") %>'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="سعر الوحدة">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_unit_value" Height="26px" Text='<%# Eval("unit_value") %>' CssClass="Text"
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="الإجمالى">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_PActv_ID" Text='<%# Eval("PActv_ID") %>' runat="server" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="txt_Bil_Dtl_ID" Text='<%# Eval("Bil_Dtl_ID") %>' runat="server"
                                                        Visible="false"></asp:TextBox>
                                                    <asp:Label ID="lbl_Total_Value" runat="server" Text='<%# Eval("Total_Value") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%# Eval("Bil_Dtl_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                                ValidationGroup="A" Width="99px" />
                            <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btn_New" OnClick="btn_New_Click"
                                Width="99px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="   الباقي من قيمة امر التوريد: " Visible="false" />
                        <asp:Label ID="lblval" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false" Text='<%# Eval("sub")%>'  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text=" الفواتير: " />
                                  
                                </legend>
                                <div>
                                    <asp:GridView ID="GridView_Bil" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        OnRowCommand="GridView_Bil_RowCommand" Font-Size="17px" GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField HeaderText="رقم أمر التوريد" DataField="Work_Order_Code" />
                                            <asp:TemplateField HeaderText="النوع">
                                                <ItemTemplate>
                                                    <%# Get_Type(Eval("Type")) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="رقم الفاتورة" DataField="Code" />
                                            <asp:BoundField HeaderText="التاريخ" DataField="Date" />
                                            <asp:BoundField HeaderText="القيمة" DataField="Bil_Value" />
                                            <asp:BoundField HeaderText="ملاحظات" DataField="Notes" />
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("Bil_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Bil_Value" Visible="false" runat="server" Text='<%# Eval("Bil_Value") %>'></asp:Label>
                                                    <asp:Label ID="lbl_Type" Visible="false" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%# Eval("Bil_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </div>
                                <div align="left" style="display: none">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" إجمالى الفواتير : " />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_bils_Totala2" Height="26px" CssClass="Text" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txt_bils_Totala_hidden" Height="26px" CssClass="Text" Visible="false"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
