<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_Activities_Months.ascx.cs"
    Inherits="UserControls_Project_Activities_Months" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
    <script type="text/javascript">
    //isFormSubmitted variable is used to prevent the form submission while the server execution is in progress
    var isFormSubmitted = false;
    //If the form is already submitted, this function will return false preventing the form submission again.
    function SubmitForm(msg) {
        try {
            if (isFormSubmitted == true) {
                alert('A post back is already in progress. Please wait');
                return false;
            }
            else {
                var res = false;
                if (msg) {
                    res = confirm(msg);
                }
                if (res == true) {
                    isFormSubmitted = true;
                } return res;
            }
        } catch (ex) { }
    }

    function VerifySubmit() {
        if (isFormSubmitted == true) {
            alert('يرجى الإنتظار حتى يتم الانتهاء من تنفيذ طلبك السابق'); return false;
        }
        else
         {
            isFormSubmitted = true;
            return true;
        }
    }  
</script>
<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="شهور تنفيذ خطة المشروع"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
            <input id="hidden_ID" type="hidden" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="السنة :  "></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddl_Year" runat="server" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged"
                AutoPostBack="True" Font-Bold="False" CssClass="drop" Height="39px" Width="200px">
                <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                <asp:ListItem Text="2011" Value="2011 " Selected="True"></asp:ListItem>
                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="الشهر :  "></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DDL_month" runat="server" OnSelectedIndexChanged="DDL_month_SelectedIndexChanged"
                AutoPostBack="True" CssClass="drop" Height="39px" Width="200px">
                <asp:ListItem Text="يناير" Value="01"></asp:ListItem>
                <asp:ListItem Text="فبراير" Value="02"></asp:ListItem>
                <asp:ListItem Text="مارس" Value="03"></asp:ListItem>
                <asp:ListItem Text="ابريل" Value="04"></asp:ListItem>
                <asp:ListItem Text="مايو" Value="05"></asp:ListItem>
                <asp:ListItem Text="يونيو" Value="06"></asp:ListItem>
                <asp:ListItem Text="يوليو" Value="07"></asp:ListItem>
                <asp:ListItem Text="أغسطس" Value="08"></asp:ListItem>
                <asp:ListItem Text="سبتمبر" Value="09"></asp:ListItem>
                <asp:ListItem Text="اكتوبر" Value="10"></asp:ListItem>
                <asp:ListItem Text="نوفمبر" Value="11"></asp:ListItem>
                <asp:ListItem Text="ديسمبر" Selected="True" Value="12"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الحالة : "></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="chk_Active" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="الاسم : "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_Notes" TextMode="MultiLine" Rows="3" Width="200px" Height="60px" runat="server"
                CssClass="Text" />
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="تاريخ الانتهاء : "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_End_DT" runat="server" CssClass="Text"  Width="200px"></asp:TextBox>
            <cc1:filteredtextboxextender id="FilteredTextBoxExtender3" runat="server" targetcontrolid="txt_End_DT"
                validchars="0987654321/\" enabled="True" />
            <cc1:calendarextender id="CalendarExtender3" runat="server" format="dd/MM/yyyy" popupbuttonid="ImageButton3"
                targetcontrolid="txt_End_DT" enabled="True">
                                    </cc1:calendarextender>
            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="اضغط لعرض النتيجة"
                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
        <asp:Button ID="Button2" runat="server" CssClass="Button" Text="جديد"  OnClientClick="return VerifySubmit();"
                OnClick="btn_new_Click" />
            <asp:Button ID="btn_Save" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="A" OnClientClick="return VerifySubmit();"
                OnClick="btn_Save_Click" />
            <asp:Button ID="btn_Send" runat="server" CssClass="Button" Text="ارسال ايميل " ValidationGroup="A" Enabled="false" OnClientClick="return VerifySubmit();"
                OnClick="btn_Send_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                OnRowCommand="gvMain_RowCommand" GridLines="Vertical">
                <Columns>
                    <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="السنة" DataField="Year" />
                    <asp:BoundField HeaderText="الشهر" DataField="Month" />
                    <asp:BoundField HeaderText="الاسم" DataField="Notes" />
                    <asp:BoundField HeaderText="تاريخ الانتهاء" DataField="End_dt" />
                    <asp:TemplateField HeaderText="نشط" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_Active" runat="server" Checked='<%# Eval("Active") %>' Enabled="false" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("id") %>' OnClientClick="return VerifySubmit();"
                                CommandName="Show" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif" OnClientClick="return VerifySubmit();"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center"></PagerStyle>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
</table>
