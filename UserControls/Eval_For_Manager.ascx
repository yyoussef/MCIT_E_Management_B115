<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Eval_For_Manager.ascx.cs"
    Inherits="UserControls_Eval_For_manager" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

</script>

<table width="100%" style="line-height: 2; color: Black">
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="نموذج تقييم الأداء لمدير"
                EnableTheming="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <input type="hidden" runat="server" id="hidden_Evaluation_id" />
            <input type="hidden" runat="server" id="hidden_direct_mngr" />
            <input type="hidden" runat="server" id="hidden_top_mngr" />
            <input type="hidden" runat="server" id="hidden_hr" />
        </td>
    </tr>
    <tr runat="server" id="tr3">
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="أولا : البيانات الاساسية " />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%">
                <tr>
                    <td runat="server" visible="false">
                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text=" القطاع : " />
                    </td>
                    <td runat="server" visible="false">
                        <asp:DropDownList ID="Ddl_Sectors" CssClass="drop" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="Sec_name" DataValueField="Sec_id" Width="200px" OnSelectedIndexChanged="Ddl_Sectors_SelectedIndexChanged"
                            AutoPostBack="true" Enabled="false" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand=" select Sec_id,Sec_name from Sectors "></asp:SqlDataSource>
                    </td>
                    <%--<td>
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" الإدارة : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="Smart_Search_Departments" runat="server" />
                    </td>--%>
                    <td>
                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم المدير : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="Smart_Pmp_Id" runat="server" EnableTheming="True" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" CssClass="Label" Text=" تاريخ التعيين : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Hire_date" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" CssClass="Label" Text=" المسمى الوظيفي : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_pmp_title" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text=" الرقم الوظيفي : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_job_no" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr runat="server" id="tr_Grid">
        <td colspan="2">
            <table>
                <tr runat="server" id="tr2">
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" ثانيا : التقييم بتحديد الكفاءات الفنيه والمهنية والصفات الشخصية للموظف " />
                        <asp:GridView ID="gvEvaluateManager" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="العنصر الرئيسى">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_Main_Item_Id" Text='<%#Eval("Main_Item_Id")%>'
                                            Visible="false" />
                                        <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_Main_Item_Text"
                                            Text='<%#Eval("Main_Name")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العنصر الفرعى">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_Sub_Item_Id" Text='<%#Eval("Sub_Item_Id")%>' Visible="false" />
                                        <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_Sub_Item_Text" ToolTip='<%#Eval("ToolTip").ToString().Trim()%>'
                                            Text='<%#Eval("Sub_Name")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدرجة">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_Direct_Emp_Degree_Id" runat="server" Width="150px" CssClass="drop"
                                            DataValueField="Degree_Id" DataTextField="Name" DataSourceID="SqlDepartments">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAll"
                                            TypeName="Evaluation_Degree_DB"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ملاحظات">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="Text" TextMode="MultiLine" Rows="2" ID="txt_emp_Note" Text='<%#Eval("Emp_Note")%>'
                                            Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                            </PagerStyle>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <asp:GridView ID="gvEmpGeneralNotes" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="ملاحظات عامة">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" CssClass="Text" TextMode="MultiLine" Rows="2" ID="txt_Emp_Gen_Notes"
                                        Width="300px" Height="100px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                        </PagerStyle>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                    </asp:GridView>
                </tr>
             
                <tr>
                    <td>
                        <div align="center" width="100%">
                        </div>
                        <asp:SqlDataSource ID="SqlDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="select 0 as Degree_Id,'-- اختر-- ' as Name union SELECT Degree_Id,Name FROM Evaluation_Degree ">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEvalCourses" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="select 0 as Eval_Course_Id,'-- اختر-- ' as Course_Name union SELECT Eval_Course_Id,Course_Name FROM Evaluation_Courses ">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Save" OnClick="btn_Save_Click" Text="حفظ " runat="server" ValidationGroup="C"
                            CssClass="Button" />
                        <asp:Button ID="btn_finish" OnClick="btn_finish_Click" Text="انهاء التقييم " runat="server"
                            CssClass="Button" Width="150px"  Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
