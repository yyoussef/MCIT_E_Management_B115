<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_adminapprove.ascx.cs"
    Inherits="UserControls_Training_adminapprove" %>
<table dir="rtl" style="line-height: 2; color: Black" width="100%">
    <%--<tr>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/WebForms/Training_ViewEXUserRequests.aspx">عرض طلبات الدورات التدريبيه السابقه</asp:HyperLink>
        </td>
    </tr>--%>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="اختر الدوره التدريبيه" CssClass="Label"></asp:Label>
            <asp:DropDownList ID="ddl_course" CssClass="drop" runat="server" DataTextField="course_name"
                DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged"
                AppendDataBoundItems="True" DataSourceID="SqlDataSource1">
                <asp:ListItem Value="0">--اختر كورس--</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_adminapprove" runat="server" AlternatingRowStyle-CssClass="alt"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                Font-Size="17px" ForeColor="Black" PagerStyle-CssClass="pgr" OnRowDataBound="gv_adminapprove_RowDataBound"
                OnDataBound="gv_adminapprove_DataBound" CellPadding="3" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="إسم الموظف">
                        <ItemTemplate>
                            <asp:Label ID="txt_name" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                            <asp:TextBox ID="txt_id" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="empname" HeaderText="اسم الموظف" Visible="false" />
                    <asp:BoundField DataField="coursename" HeaderText="اسم الدوره التدريبيه" />
                    <asp:BoundField DataField="startdate" DataFormatString="{0:d}" HeaderText="تاريخ البدء" />
                    <asp:BoundField DataField="enddate" DataFormatString="{0:d}" HeaderText="تاريخ الانتهاء" />
                    <asp:BoundField DataField="admindescion" HeaderText="الحاله" />
                    <asp:TemplateField HeaderText="إتخاذ القرار">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id", "~/MainForm/Training_Descion.aspx?id={0}") %>'>HyperLink</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض النتيجه">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("course_id", "~/MainForm/Training_userresult.aspx?type=2&course_id={0}") %>'
                                Text='<%# Eval("result") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
            <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                
                
                SelectCommand="SELECT EMPLOYEE.pmp_name AS empname, course.course_name AS coursename, course_details.start_date AS startdate, course_details.end_date AS enddate, course_employee.id, course_employee.status FROM course INNER JOIN course_employee ON course.id = course_employee.course_id INNER JOIN EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course_details ON course_employee.course_details_id = course_details.id WHERE (course_employee.status = 3)">
            </asp:SqlDataSource>--%>
        </td>
    </tr>
    <tr>
        <td align="center" class="style1">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT   course.id,courses.course_id, courses.course_name, course.course_place, course.last_register_date, course.emp_no, course.created_by, course.organization, course.comments, course.candidate_criteria,course.duration, course.refrences, course.refrance_file, course.inbox_id FROM courses  INNER JOIN course  on courses.course_id=course.course_id INNER JOIN EMPLOYEE AS EMPLOYEE_1  ON EMPLOYEE_1.PMP_ID = course.created_by ">
            </asp:SqlDataSource>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </td>
    </tr>
</table>
