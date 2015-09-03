<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_Descion.ascx.cs" Inherits="UserControls_Training_Descion" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td>
            <asp:RadioButtonList ID="rd_descionlist" runat="server" 
                onselectedindexchanged="rd_descionlist_SelectedIndexChanged" 
                CssClass="PageTitle" AutoPostBack="True">
                <asp:ListItem Value="1">قبول</asp:ListItem>
                <asp:ListItem Value="4">تحويل لبرنامج اخر</asp:ListItem>
                <asp:ListItem Value="2">رفض لاحد الاسباب التاليه</asp:ListItem>
            </asp:RadioButtonList>
        </td>
       
        <td>
            &nbsp;</td>
       
        </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="PageTitle" ForeColor="#EC981F" font-underline="false"></asp:Label>
        </td>
       
        <td>
            &nbsp;</td>
       
        </tr>
        <tr runat="server" id="redirect_tr"  Visible="False" >
         <td>
             <asp:RadioButtonList ID="rb_redirect" runat="server" CssClass="PageTitle"
                 DataSourceID="SqlDataSource1" DataTextField="course_name" 
                 DataValueField="id" CausesValidation="True">
             </asp:RadioButtonList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                 
                 SelectCommand="
 SELECT   course.id,courses.course_id, courses.course_name
FROM courses  INNER JOIN course  on courses.course_id=course.course_id 
INNER JOIN EMPLOYEE AS EMPLOYEE_1  ON EMPLOYEE_1.PMP_ID = course.created_by
 where course.id not in (SELECT course.id FROM course where course.id=@course_id)">
                 <SelectParameters>
                     <asp:Parameter Name="course_id" />
                 </SelectParameters>
             </asp:SqlDataSource>
            </td>
         <td>
             &nbsp;</td>
        </tr>
        <tr runat="server" id="reject_tr"  Visible="False"  >
         <td>
             <asp:RadioButtonList ID="rb_rejected" runat="server" CssClass="PageTitle"
                 DataSourceID="SqlDataSource2" DataTextField="reason" DataValueField="id" 
                 CausesValidation="True">
             </asp:RadioButtonList>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                 SelectCommand="SELECT * FROM [Course_RejectReasonList]"></asp:SqlDataSource>
            </td>
         <td>
             &nbsp;</td>
        </tr>
        <tr >
         <td align="center">
             <asp:Button ID="btn_save" runat="server" Text="حفظ" CssClass="PageTitle"
                 onclick="btn_save_Click" Width="73px"  />
            </td>
         <td align="center">
             &nbsp;</td>
        </tr>
        </table>