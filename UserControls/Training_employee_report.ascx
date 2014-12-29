<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_employee_report.ascx.cs" Inherits="UserControls_Training_employee_report" %>
<table dir="rtl"width="100%" style="line-height: 2; color: Black">
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="اسم الكورس"></asp:Label>
</td>
<td>
 <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
        DataTextField="course_name" DataValueField="id" style="margin-right: 0px">
 </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [course]"></asp:SqlDataSource>
</td>
</tr>
</table>