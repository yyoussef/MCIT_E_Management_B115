<%@ Control Language="C#" AutoEventWireup="true" CodeFile="proj_classification.ascx.cs"
    Inherits="UserControls_proj_classification" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="تصنيـــف المشروع" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
        </td>
    </tr>
      
    <tr>
        <td   >
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="الخطة التابع لها :" />
        </td>
        <td colspan="2">
            <asp:DropDownList ID="Drop_class" runat="server"  Font-Bold="False"
                CssClass="drop" Height="39px" Width="300px">
                <asp:ListItem Text="اختر الخطة" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text=" الخطة الاستراتيجية" Value="1"></asp:ListItem>
                <asp:ListItem Text=" المناطق المهمشة" Value="2"></asp:ListItem>
                <asp:ListItem Text="خطة الاولويات " Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
      <tr>
        <td  >
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="نوعية المشروع :" />
        </td>
        <td colspan="2">
            <asp:DropDownList ID="drop_type" runat="server" AutoPostBack="True" Font-Bold="False"
                CssClass="drop" Height="39px" Width="300px" 
                onselectedindexchanged="drop_type_SelectedIndexChanged">
                 <asp:ListItem Text="اختر النوع" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text=" داخلي" Value="1"></asp:ListItem>
                <asp:ListItem Text=" خارجي" Value="2"></asp:ListItem>
              
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="tr_proj" runat="server" visible="false">
        <td >
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text=" المشروع التابع له :" />
        </td>
        <td colspan="2">
            <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </div>
        </td>
    </tr>
    
   
   
    
    
     
</table>
