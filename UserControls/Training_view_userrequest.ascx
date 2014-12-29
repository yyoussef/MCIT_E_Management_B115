<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_view_userrequest.ascx.cs" 
    Inherits="UserControls_Training_view_userrequest" %>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <%--<tr>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/WebForms/Training_ViewEXUserRequests.aspx">عرض طلبات الدورات التدريبيه السابقه</asp:HyperLink>
        </td>
    </tr>--%>
    <tr>
        <td>
       
            <asp:GridView ID="gv_viewuserrequest" runat="server" AutoGenerateColumns="False"
                 BackColor="White" ForeColor="Black" BorderColor="#999999"
                BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnDataBound="gv_viewuserrequest_DataBound"
                Font-Size="17px" CellPadding="3" GridLines="Vertical" 
                onselectedindexchanged="gv_viewuserrequest_SelectedIndexChanged">
                <Columns>

                  
                   <asp:TemplateField  HeaderText="إسم الموظف">
                        <ItemTemplate>
                       <asp:Label  ID="txt_name" runat="server" Text='<%# Eval("empname") %>' ></asp:Label>
                           <asp:TextBox ID="txt_id" runat="server" Text='<%# Eval("id") %>'  Visible="false"   ></asp:TextBox>
                           <asp:TextBox ID="txt_c_id" runat="server" Text='<%# Eval("c_id") %>'  Visible="false"   ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:BoundField DataField="coursename" HeaderText="اسم الدوره التدريبيه" />
                    <asp:BoundField DataField="startdate" HeaderText="تاريخ البدء" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="enddate" HeaderText="تاريخ الانتهاء" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="قبول/رفض">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server"  
                                RepeatDirection="Horizontal" >
                                <asp:ListItem Value="1" >قبول</asp:ListItem>
                                <asp:ListItem Value="2">رفض</asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعليق">
                        <ItemTemplate>
                           <asp:TextBox ID="tx_comment" runat="server" Text='<%# Eval("comment") %>' 
                                TextMode="MultiLine"></asp:TextBox>
                           <asp:TextBox ID="tx_course_id" runat="server" Text='<%# Eval("course_id") %>'  Visible="false" ></asp:TextBox>
                           <asp:TextBox ID="txt_emp_id" runat="server" Text='<%# Eval("PMP_ID") %>'  Visible="false" ></asp:TextBox>

                                
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
                
                
                SelectCommand="SELECT EMPLOYEE.pmp_name AS empname, course.course_name AS coursename, course_details.start_date AS startdate, course_details.end_date AS enddate, course_employee.id, course_employee.status FROM course INNER JOIN course_employee ON course.id = course_employee.course_id INNER JOIN EMPLOYEE ON course_employee.emp_id = EMPLOYEE.PMP_ID INNER JOIN course_details ON course_employee.course_details_id = course_details.id WHERE (course_employee.status = 3)">
            </asp:SqlDataSource>--%>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="موافق" CssClass="Button" />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="طلبات سابقة" CssClass="Button" />
       
        </td>
    </tr>
</table>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

