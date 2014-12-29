<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_ViewEXUserRequests.ascx.cs" Inherits="UserControls_Training_ViewEXUserRequests" %>
<table dir="rtl"width="100%" style="line-height: 2; color: Black">
 <tr>
        <td>
            <asp:GridView ID="gv_viewuserrequest" runat="server" 
                AutoGenerateColumns="False"  BackColor="White" 
                ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                            BorderWidth="1px" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                 Font-Size="17px" CellPadding="3" GridLines="Vertical" 
                >
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="رقم الطلب" 
                        SortExpression="empname" />
                    <asp:BoundField DataField="empname" HeaderText="اسم الموظف" />
                    <asp:BoundField DataField="coursename" HeaderText="اسم الدوره التدريبيه" />
                    <asp:BoundField DataField="startdate" HeaderText="تاريخ البديء" 
                        DataFormatString="{0:d}" />
                    <asp:BoundField DataField="enddate" HeaderText="تاريخ الانتهاء" 
                        DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="قبول/رفض">
                        <ItemTemplate >
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="false"
                                RepeatDirection="Horizontal" SelectedValue='<%# Eval("status") %>' >
                                <asp:ListItem Value="1">قبول</asp:ListItem>
                                <asp:ListItem Value="2">رفض</asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                 <FooterStyle BackColor="#CCCCCC" />
                 <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
          
           <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>"                                
                SelectCommand="SELECT     EMPLOYEE.pmp_name AS empname, course.course_name AS coursename, course_details.start_date AS startdate, 
                              course_details.end_date AS enddate, course_employee.id, course_employee.status
                              FROM         course INNER JOIN course_employee ON course.id = course_employee.course_id INNER JOIN                       EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN                      course_details ON course_employee.course_details_id = course_details.id
                              WHERE     (course_employee.status IN (1, 2))">
            </asp:SqlDataSource>--%>
        </td>
    </tr>
</table>
