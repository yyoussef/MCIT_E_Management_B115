<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectDemandsMM.aspx.cs" Inherits="WebForms_ProjectDemandsMM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
<tr>
        <td style="height: 35px" align="center" colspan="2" dir="rtl">
            <asp:Label ID="Label6" runat="server" 
                Text="تقرير مطالب المشروعات من الموارد و الاتصالات" CssClass="PageTitle" 
                Font-Bold="False"></asp:Label>
        </td>    

</tr>
<tr>
        <td style="height: 35px" align="center" colspan="2" dir="rtl">
        <asp:Label ID="Label5" runat="server" Font-Bold="false" Font-Size="Large" 
            ForeColor="Red"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Bold="false" Font-Size="Large" 
            ForeColor="Blue"></asp:Label>
        </td>    

</tr>
<tr>
        <td>
        <asp:Label ID="Label1" runat="server" Text="الإدارة :" CssClass="Label" 
                Font-Bold="False"></asp:Label>
        </td>
        <td style="width: 483px; height: 46px;">
        <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="drop" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
        <td>
        <asp:Label ID="Label2" runat="server" CssClass="Label"
             Text="التاريخ المخطط للتوريد من :" Font-Bold="False"></asp:Label>
         </td>
         <td style="width: 483px; height: 42px;">  
          
        <asp:TextBox ID="TextBox1" runat="server"  
           CssClass="Label"  Width="114px"></asp:TextBox>
           
           
                                              
       <cc1:CalendarExtender ID="CalPlannedDate" runat="server" 
        TargetControlID="TextBox1" PopupButtonID="ImageButton1" Enabled="True" 
        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
        
       <asp:ImageButton ID="ImageButton1" runat="Server" 
        ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
        Height="20px" Width="20px" ToolTip="تقويم" />
      
       
          
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                 ControlToValidate="TextBox1" ErrorMessage="أدخل التاريخ ( يوم /شهر /سنة )" 
                 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                 Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
        </td>
</tr>

<tr>        
    <td>
      <asp:Label ID="Label3" runat="server" Font-Bold="False" 
       Text="التاريخ المخطط للتوريد إلي :" CssClass="Label"></asp:Label>
       </td>
       
        <td style="width: 483px; height: 55px;">
        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" 
            CssClass="Label" Width="114px" EnableViewState="false" ></asp:TextBox>
         
       <asp:ImageButton ID="ImageButton2" runat="Server" 
        ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
        Height="20px" Width="20px" ToolTip="تقويم" />
        
        
        <cc1:CalendarExtender ID="CalPlanned" runat="server" 
        TargetControlID="TextBox2" PopupButtonID="ImageButton2" Enabled="True" 
        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
         <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TextBox2" ErrorMessage="أدخل التاريخ ( يوم /شهر /سنة ) " 
                
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                Display="Dynamic" Font-Size="Large"></asp:RegularExpressionValidator>
        </td>
</tr> 
   
<tr>
        <td style="height: 40px; " colspan="2">
        
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                 onclick="LinkButton1_Click" CssClass="Text">تقرير 
            مطالب المشروعات من الموارد و الاتصالات</asp:LinkButton>
         </td>
</tr>
</table>
</asp:Content>

