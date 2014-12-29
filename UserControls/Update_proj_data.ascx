<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Update_proj_data.ascx.cs"
    Inherits="UserControls_Update_proj_data" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        height: 36px;
    }
</style>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="تعديل بيانات مشروع" />
            <asp:HiddenField ID="hidtype" runat="server" Value="0" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4" style="height: 29px">
        </td>
    </tr>
    <tr id="tr1" runat="server">
        <td> 
            <asp:Label ID="Label443" runat="server" CssClass="Label" Text="المشروع :" />
        </td>
        <td colspan="3">
            <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
        </td>
    </tr>
    <tr >
        <td> 
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم المشروع:" />
        </td>
        <td colspan="3">
            <asp:TextBox runat="server" CssClass="Text" ID="txt_proj_name" Width="323px"></asp:TextBox>
        </td>
    </tr>
     <tr >
        <td> 
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="تاريخ الاقتراح:" />
        </td>
        <td colspan="3">
            <asp:TextBox ID="txt_date" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="txt_date" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="txt_date">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
    </tr>
    <tr >
        <td> 
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="ملخص المشروع:" />
        </td>
        <td colspan="3" align="right">
            <asp:TextBox runat="server" CssClass="Text" ID="txt_Brief" Width="600px" TextMode="MultiLine" Height="70px"></asp:TextBox>
        </td>
    </tr>
    <tr >
        <td> 
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="الادارة :" />
        </td>
        <td colspan="3">
             <uc1:Smart_Search ID="Smart_Search_depts" runat="server" />
        </td>
    </tr>
    <tr >
        <td> 
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="مدير المشروع :" />
        </td>
        <td colspan="3">
             <uc1:Smart_Search ID="Smart_Search_manager" runat="server" />
        </td>
    </tr>
     <tr >
        <td> 
            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الحالة :" />
        </td>
        <td colspan="3">
             <asp:DropDownList ID="ddl_status" runat="server" CssClass="drop" 
                Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr >
        
        <td colspan="4" align="center" class="style1">
           <asp:Button ID="btn_Update" Text="حفظ" OnClick="btn_Update_Click" runat="server"
                    CssClass="Button" Width="40px" />
            <asp:Button ID="Button1" runat="server" Text="إنشاء مشروع جديد" CssClass="Button"
                onclick="Button1_Click" Width="136px" />
            <asp:Button ID="Button2" runat="server" Text="حذف" Width="64px" CssClass="Button" OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" 
                onclick="Button2_Click" />
        </td>
    </tr>
   
    
   
  
    
   
   
    
  
   
     
   
   
</table>
