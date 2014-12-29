<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_User_Viewallcourse.ascx.cs" Inherits="UserControls_Training_User_Viewallcourse" %>
<style type="text/css">
    .style1
    {
        height: 31px;
    }
</style>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:GridView ID="Gv_view_courses" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" BackColor="White" 
                ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                            BorderWidth="1px" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد دورات تدريبيه ..."
                                                            PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" Font-Size="17px" CellPadding="3" 
                GridLines="Vertical">
                <Columns>
                    <asp:BoundField DataField="course_name" HeaderText="اسم الدوره التدريبيه" />
                    <asp:BoundField HeaderText="اسم المسار" DataField="track_name" />
                    <asp:HyperLinkField DataNavigateUrlFields="id" 
                        DataNavigateUrlFormatString="~/MainForm/Training_User_Register.aspx?id={0}" 
                        HeaderText="سجل الان" NavigateUrl="~/MainForm/Training_User_Register.aspx" 
                        Text="سجل الان" />
                    
                  
                </Columns>
                 <FooterStyle BackColor="#CCCCCC" />
                 <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                 <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
           </td>
    </tr>
</table>