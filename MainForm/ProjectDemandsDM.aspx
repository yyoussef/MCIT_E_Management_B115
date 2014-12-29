<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectDemandsDM.aspx.cs" Inherits="WebForms_ProjectDemandsDM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%">
<tr>

                     <td style="height: 52px" align="center" colspan="2">
                         <asp:Label ID="Label7" runat="server" CssClass="PageTitle" Font-Bold="False" 
                             Text="تقرير مطالب المشروعات من الموارد و الإتصالات"></asp:Label>
                    </td>
</tr>
<tr>

                     <td style="height: 36px" align="center" colspan="2">
                    <asp:Label ID="Label4" runat="server" Font-Bold="false" 
                        ForeColor="Red" CssClass="Label"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" 
                        ForeColor="Blue" CssClass="Label"></asp:Label>
                    </td>
</tr>
        <tr> 
                <td style="width: 188px; height: 49px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="الإدارة :" 
                        CssClass="Label"></asp:Label>
                 </td>
                 <td style="height: 49px">   
                <asp:Label ID="Label6" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
                 </td>
         </tr>
         <tr>
                <td style="width: 188px; height: 62px;">    
                <asp:Label ID="Label2" runat="server" Font-Bold="False" 
                        Text="التاريخ المخطط للتوريد من :" CssClass="Label"></asp:Label>
                </td>
                <td style="height: 62px">
                <asp:TextBox ID="TextBox1" runat="server"
                    CssClass="Label" Font-Bold="True" Width="114px" >
                </asp:TextBox>
                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox1" PopupButtonID ="ImageButton1">
                </cc1:CalendarExtender>
                
                <cc1:FilteredTextBoxExtender ID ="gh" runat="server" FilterType ="Custom" ValidChars ="0123456789/\" TargetControlID="TextBox1">
                </cc1:FilteredTextBoxExtender>                
        
               <asp:ImageButton ID="ImageButton1" runat="Server" 
                ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
                Height="20px" Width="20px" ToolTip="تقويم" />
      
       
          
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 
                                              
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                        Display="Dynamic" Font-Bold="False" Font-Size="Large"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
                    <td style="height: 64px;">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" 
                            Text="التاريخ المخطط للتوريد إلي :" CssClass="Label"></asp:Label>
                    </td>
                    <td style="height: 64px">
                    <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" 
                        Height="29px" Width="114px" ontextchanged="TextBox2_TextChanged" 
                        ondisposed="TextBox2_Disposed" CssClass="Label"></asp:TextBox>
                    <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox2" PopupButtonID="ImageButton2">
                    </cc1:CalendarExtender>
        
       <asp:ImageButton ID="ImageButton2" runat="Server" 
        ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="اضغط لعرض النتيجة" 
        Height="20px" Width="20px" ToolTip="تقويم" />
      
       
          
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="أدخل التاريخ ( يوم / شهر/ سنة )" 
                            
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                            Display="Dynamic" Font-Size="Large"></asp:RegularExpressionValidator>
                    </td>
        </tr>
         <tr>       
                   <td style="width: 294px; height: 41px;" colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                           onclick="LinkButton1_Click" CssClass="Text" Width="307px">تقرير 
                    مطالب المشروعات من الموارد و الإتصالات</asp:LinkButton>
                    </td>
                   
        </tr>
</table>

</asp:Content>

