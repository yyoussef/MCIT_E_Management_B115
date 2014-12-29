<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Trainig_ViewAllCourses.ascx.cs" Inherits="UserControls_Trainig_ViewAllCourses" %>


<table dir="rtl" width="100%" style="line-height: 2; color: Black >
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/WebForms/Training_Add_NewCourse.aspx?type=1"  CssClass="Text">إضافه دوره تدريبيه</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
           <asp:GridView ID="gv_viewuserrequest" runat="server" 
                AutoGenerateColumns="False" Width="100%" 
                BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                            BorderWidth="1px" AllowPaging="True" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" Font-Size="17px" 
                
                 onrowcommand="gv_viewuserrequest_RowCommand"   OnPageIndexChanging="gv_viewuserrequest_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="course_name" HeaderText="اسم الدوره التدريبيه" 
                        SortExpression="course_name" />
                    <asp:BoundField DataField="track_name" HeaderText="اسم المسار" 
                        SortExpression="track_name" />
                    <asp:BoundField DataField="place_desc" HeaderText="المكان" 
                        SortExpression="course_place" />
                    <asp:BoundField DataField="last_register_date" HeaderText="اخر ميعاد للتسجيل" 
                        SortExpression="last_register_date" />
                    <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("id") %>'/>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                        Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pgr" />
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
           </td>
           <td>
               &nbsp;</td>
    </tr>
</table>

            <p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    
                    SelectCommand="SELECT course.id, Courses.course_id, Courses.course_name, course.last_register_date, course.emp_no, course.created_by, course.organization, course.comments, course.candidate_criteria, course.duration, course.refrences, course.refrance_file, course.inbox_id, Course_Places.place_desc, Course_Tracks.track_name FROM Courses INNER JOIN course ON Courses.course_id = course.course_id INNER JOIN Course_Places ON Course_Places.place_id = course.course_place INNER JOIN EMPLOYEE AS EMPLOYEE_1 ON EMPLOYEE_1.PMP_ID = course.created_by INNER JOIN Course_Tracks ON Courses.course_id = Course_Tracks.course_id">
                </asp:SqlDataSource>
</p>

            

