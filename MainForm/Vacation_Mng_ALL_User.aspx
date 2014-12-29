<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Vacation_Mng_ALL_User.aspx.cs" Inherits="WebForms_Vacation_Mng_ALL_User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="أرصدة الأجازات" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label443" runat="server" CssClass="Label" Text="الموظف :" />
            </td>
            <td colspan="3">
                <uc1:Smart_Search ID="Smrt_Srch_user" Validation_Group="Group1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الرصيد المتبقى :" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="إعتيادى :" />
            </td>
            <td>
                <asp:TextBox ID="txt_unusual" runat="server" Enabled="false" Width="80px" CssClass="Label" />
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="عارضة :" />
            </td>
            <td>
                <asp:TextBox ID="txt_exhibitor" runat="server" Enabled="false" Width="80px" CssClass="Label" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="مرضية :" />
            </td>
            <td>
                <asp:TextBox ID="txt_sick" runat="server" Enabled="false" Width="80px" CssClass="Label" />
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="تفاصيل الأجازات :" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label23" runat="server" CssClass="Label" Text="نوع الأجازة :" Width="95px"
                    Height="25px" />
            </td>
            <td>
                <asp:DropDownList ID="DDLVacationType" runat="server" CssClass="Button" Width="230px"
                    Height="25px" DataSourceID="SqlDataSource1" DataTextField="vacation_title" DataValueField="id" />
                &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT [id], [vacation_title] FROM [Vacations]"></asp:SqlDataSource>
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="من" />&nbsp;
            </td>
            <td>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="ImageButton1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Enabled="true" />
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="إلى" />&nbsp;
            </td>
            <td>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" Enabled="true" AutoPostBack="True"
                    OnTextChanged="txtEndDate_TextChanged" />
                <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="Group1" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="عدد أيام الأجازة :"
                    Height="25px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="no_days"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="no_days" runat="server" CssClass="Text" Width="230px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="no_days_filtered" runat="server" FilterType="Custom"
                    ValidChars="0123456789" TargetControlID="no_days" />
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="حفظ" Width="110px"
                    OnClick="BtnVacationRequest_Click" ValidationGroup="Group1" />
                    
                       <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Group1"
                                        ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView_Main" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    Font-Size="17px" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView_Main_PageIndexChanging" 
                    GridLines="Vertical" >
                    <Columns>
                        <asp:TemplateField HeaderText="نوع الأجازة">
                            <ItemTemplate>
                                <%# Eval("vacation_title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الفترة">
                            <ItemTemplate>
                            من
                             <%# Eval("start_date")%>
                            الى 
                             <%# Eval("end_date")%>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="العدد">
                            <ItemTemplate>
                                <%# Eval("no_days")%>
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
    </table>
</asp:Content>
