<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project.aspx.cs" Inherits="WebForms_Project" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript"> 
function validatePage( A ,B) 
{ 
    //Executes all the validation controls associated with group1 validaiton Group1. 
    var flag = Page_ClientValidate(A); 
    if (flag) 
    //Executes all the validation controls associated with group1 validaiton Group2. 
    flag = Page_ClientValidate(B); 
    //  if (flag) 
    //Executes all the validation controls associated with group1 validaiton Group3. 
    //flag = Page_ClientValidate('Group3'); 
    //if (flag) 
    //Executes all the validation controls which are not associated with any validation group. 
    //  flag = Page_ClientValidate(); 
    return flag; 
} 
    </script>

    <div align="center">
        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="وثيقة المشروع"></asp:Label>
    </div>
    <div align="right">
        <table width="100%" style="line-height: 2; text-align: right; color: Black">
            <tr>
                <td>
                    <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="Label" Text=" الإدارة : " />
                            </td>
                            <td>
                                <uc1:Smart_Search ID="Smart_Dept_id" Validation_Group="A" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" مدير المشروع : " />
                            </td>
                            <td>
                                <uc1:Smart_Search ID="Smart_PMP_ID" Validation_Group="A" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                            </td>
                            <td>
                                <uc1:Smart_Search ID="Smart_Project" runat="server" Validation_Group="A" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label31" runat="server" CssClass="Label" Text=" كود المشروع : " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Proj_Code" runat="server" Width="130px" Height="26px" CssClass="Text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="النطاق الزمنى: " />
                            </td>
                            <td>
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="تاريخ البدأ المخطط: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_start_date_Plan" runat="server" Width="130px" Height="26px"
                                                CssClass="Text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" TargetControlID="txt_start_date_Plan"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="Image1" TargetControlID="txt_start_date_Plan" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="Image1" runat="server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_start_date_Plan"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال تاريخ التوقيع "></asp:RequiredFieldValidator>
                                                
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_start_date_Plan"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                                    
                                    
                                    
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ النهاية المخطط: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_End_Date_Plan" runat="server" Width="130px" Height="26px" CssClass="Text"
                                                AutoPostBack="True" OnTextChanged="txt_End_Date_Plan_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_End_Date_Plan"
                                                ValidChars="0987654321/\" Enabled="True" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                                TargetControlID="txt_End_Date_Plan" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="اضغط لعرض النتيجة"
                                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_End_Date_Plan"
                                                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال تاريخ التوقيع "></asp:RequiredFieldValidator>
                                                          
                                                          
                                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_End_Date_Plan"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="مدة التنفيذ بالسنوات: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Period_by_year" Height="26px" MaxLength="2" Width="50px" CssClass="Text"
                                                runat="server"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Label" Text=" النطاق الجغرافى : " />
                            </td>
                            <td>
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <asp:CheckBoxList ID="chk_gov_list" Font-Bold="true" Font-Size="Medium" runat="server"
                                                    DataSourceID="SqlDataSource1" RepeatColumns="8" RepeatDirection="Horizontal"
                                                    DataTextField="gov_name" DataValueField="gov_id" Width="100%" SelectionMode="Multiple"
                                                    ForeColor="Black" Height="21px" />
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                    SelectCommand="SELECT * FROM [Governments ]"></asp:SqlDataSource>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text=" أخرى: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Region_Desc" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" الجهات المشاركة : " />
                            </td>
                            <td>
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_Org_ID1" Validation_Group="B" runat="server" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btn_Org1" Text="إضافة" OnClientClick="javascript:return validatePage('A','B');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView_Org2" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Org_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Org_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text=" الجهات المستفيدة : " />
                            </td>
                            <td>
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <uc1:Smart_Search ID="Smart_Org_ID2" runat="server" Validation_Group="C" />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btn_Org2" Text="إضافة" OnClientClick="javascript:return validatePage('A','C');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="اسم الجهة" DataField="Org_Desc" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Org_ID") %>' />
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
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تكلفة المشروع: " />
                            </td>
                            <td>
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" CssClass="Label" Text="الوصف: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Description" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="السنة المالية: " />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Fincial_Year_ID" Width="170px" runat="server" CssClass="drop">
                                                <asp:ListItem Value="2008" Text="2008 - 2009"></asp:ListItem>
                                                <asp:ListItem Value="2009" Text="2009 - 2010"></asp:ListItem>
                                                <asp:ListItem Value="2010" Text="2010 - 2011"></asp:ListItem>
                                                <asp:ListItem Value="2011" Text="2011 - 2012" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="2012" Text="2012 - 2013"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="بالنقد المحلى: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Balance_Value_LE" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="بالنقد الاجنبى: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Balance_Value_US" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" CssClass="Label" Text="مصدر التمويل: " />
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txt_Source_Desc" Height="40px" Width="95%" TextMode="MultiLine"
                                                Rows="2" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Source_Desc"
                                                runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال تاريخ التوقيع "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" إجمالى التمويل بالنقد المحلى :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Total_Value_LE" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text=" الأجنبى :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Total_Value_US" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="Button1" Text="إضافة" OnClientClick="javascript:return validatePage('A','D');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="السنة المالية" DataField="Fincial_Year_ID" />
                                                    <asp:BoundField HeaderText="إجمالى قيمة التمويل" DataField="Total_Value" />
                                                    <asp:BoundField HeaderText="بالنقد المحلى" DataField="Balance_Value_LE" />
                                                    <asp:BoundField HeaderText="بالنقد الاجنبى" DataField="Balance_Value_US" />
                                                    <asp:BoundField HeaderText="مصدر التمويل" DataField="Source_Desc" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Balnce_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Balnce_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label33" runat="server" CssClass="Label" Text=" إجمالى التمويل بالنقد المحلى :" />
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_Total_Balance_Value_LE" Height="26px" Enabled="false" CssClass="Text"
                                                runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" CssClass="Label" Text=" الأجنبى :" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Total_Balance_Value_US" Height="26px" Enabled="false" CssClass="Text"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" CssClass="Label" Text=" وصف مختصر للمشروع : " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Proj_Brief" Height="70px" Width="100%" TextMode="MultiLine"
                                    Rows="4" CssClass="Text" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="الهدف الاستراتيجى : " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Proj_Goal_Stratege" Height="70px" Width="100%" TextMode="MultiLine"
                                    Rows="4" CssClass="Text" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الأهداف الرئيسية: " />
                            </td>
                            <td align="center">
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_Obj_Description1" Height="50px" Width="95%" TextMode="MultiLine"
                                                Rows="2" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_Obj_Description1"
                                                runat="server" Text="*" ValidationGroup="E" ErrorMessage="يجب ادخال تاريخ التوقيع "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_obj1" Text="إضافة" OnClientClick="javascript:return validatePage('A','E');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="الهدف" DataField="Description" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Object_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Object_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="منهجية التنفيذ: " />
                            </td>
                            <td align="center">
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_Obj_Description2" Height="50px" Width="95%" TextMode="MultiLine"
                                                Rows="2" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_Obj_Description2"
                                                runat="server" Text="*" ValidationGroup="F" ErrorMessage="* "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_obj2" Text="إضافة" OnClientClick="javascript:return validatePage('A','F');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="الهدف" DataField="Description" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Object_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Object_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="Label" Text="مراحل تنفيذ المشروع ومخرجات كل مرحلة: " />
                            </td>
                            <td align="right">
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="مرحلة التنفيذ: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Statge_Name1" TextMode="MultiLine" Rows="2" Height="50px" Width="500px"
                                                CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_Statge_Name1"
                                                runat="server" Text="*" ValidationGroup="G" ErrorMessage="* "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" CssClass="Label" Text="المخرج الرئيسى: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Statge_Out_Put1" TextMode="MultiLine" Rows="2" Height="50px"
                                                Width="500px" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Statge_Out_Put1"
                                                runat="server" Text="*" ValidationGroup="G" ErrorMessage="* "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btn_Steps1" Text="إضافة" OnClientClick="javascript:return validatePage('A','G');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="مرحلة التنفيذ" DataField="Statge_Name" />
                                                    <asp:BoundField HeaderText="المخرج الرئيسى" DataField="Statge_Out_Put" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Steps_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Steps_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="Label" Text=" العائد الرئيسى : " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Return_Value" Height="70px" Width="100%" TextMode="MultiLine"
                                    Rows="4" CssClass="Text" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" CssClass="Label" Text="عناصر النجاح الحرجة لتنفيذ انشطة المشروع: " />
                            </td>
                            <td align="right">
                                <table style="border: 1pt solid #000000;" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="العنصر: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Statge_Name_2" TextMode="MultiLine" Rows="2" Height="50px" Width="500px"
                                                CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txt_Statge_Name_2"
                                                runat="server" Text="*" ValidationGroup="H" ErrorMessage="* "></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="أسلوب التعامل معه: " />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Statge_Out_Put2" TextMode="MultiLine" Rows="2" Height="50px"
                                                Width="500px" CssClass="Text" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txt_Statge_Out_Put2"
                                                runat="server" Text="*" ValidationGroup="H" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="Button5" Text="إضافة" OnClientClick="javascript:return validatePage('A','H');"
                                                Width="100px" runat="server" CssClass="Button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                Font-Size="17px" GridLines="Vertical">
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="العنصر" DataField="Statge_Name" />
                                                    <asp:BoundField HeaderText="أسلوب التعامل معه" DataField="Statge_Out_Put" />
                                                    <asp:TemplateField HeaderText="تعديل">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                CommandArgument='<%# Eval("Project_Steps_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                Style="height: 22px" CommandArgument='<%# Eval("Project_Steps_ID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                    HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="ملاحظات إضافية: " />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Proj_Notes" Height="70px" Width="100%" TextMode="MultiLine"
                                    Rows="4" CssClass="Text" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label35" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Maroon" Width="700px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-right: 280px">
                    <asp:Button ID="btn_Save" Text="حفظ" Width="100px" OnClick="btn_Save_Click" runat="server"
                        ValidationGroup="A" CssClass="Button" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
