<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_ViewUserRegisteredCourses.ascx.cs"
    Inherits="UserControls_Training_ViewUserRegisteredCourses" %>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:GridView ID="gv_viewuserrequest" runat="server" AutoGenerateColumns="False"
                DataSourceID="SqlDataSource1" Width="100%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Font-Size="17px"
                OnRowDataBound="gv_viewuserrequest_RowDataBound" OnDataBound="gv_viewuserrequest_DataBound"
                OnRowCommand="gv_viewuserrequest_RowCommand" CellPadding="3" 
                GridLines="Vertical">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="رقم الطلب" SortExpression="empname" Visible="false"  />
                    <asp:BoundField DataField="coursename" HeaderText="اسم الدوره التدريبيه" />
                    <asp:BoundField DataField="startdate" HeaderText="تاريخ البدء" DataFormatString="{0:t}" />
                    <asp:BoundField DataField="enddate" HeaderText="تاريخ الانتهاء" DataFormatString="{0:t}" />
                    <asp:BoundField DataField="admin_descion" HeaderText="الحاله" SortExpression="status" />
                    <asp:BoundField DataField="result" HeaderText="نتيجة الدورة" SortExpression="result" />

                
                    <asp:TemplateField HeaderText="تعديل" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("course_id") %>'  Visible="false" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandArgument='<%# Eval("course_id") %>' Visible="false"/>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                   
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT EMPLOYEE.pmp_name AS empname,courses.course_id, courses.course_name AS coursename, course.start_date AS startdate, 
       course.end_date AS enddate, course_employee.id, course_employee.admin_descion,course_employee.result, 
course_employee.course_id as courseid FROM    courses INNER JOIN   course on 
course.course_id=courses.course_id inner join

                      course_employee ON course.id = course_employee.course_id INNER JOIN
                      EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID 
WHERE     (course_employee.emp_id = @emp_id)">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="" Name="emp_id" SessionField="pmp_id" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
