<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add_Fav.ascx.cs" Inherits="UserControls_Add_Fav" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <h2>إضافة للمفضلة</h2>
        </td>
    </tr>
    
   <%-- <tr>
        <td>
            <asp:Label ID="Label30" runat="server"  Text="القطاع :" />
        </td>
        <td colspan="2">
            <uc1:Smart_Search ID="smart_Search_sector" runat="server" />
        </td>
    </tr>--%>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server"  Text="الادارة :" />
        </td>
        <td colspan="2">
            <uc1:Smart_Search ID="Smart_Search_dept" runat="server" />
        </td>
    </tr>
    <tr id="tr_emp_list" runat="server">
        <td id="Td1" runat="server">
            <asp:Label ID="Label47" runat="server"  Text="الموظف   :" />
        </td>
        <td id="Td2" align="right" runat="server">
            <div style="overflow: scroll; background-color: #F9fdff;width:500px; color: #000000; height: 289px; border: 1px solid #bbb;" 
                dir="rtl" >
              <%--  <asp:CheckBox ID="chk_ALL"  Font-Size="Small" RepeatDirection="Horizontal"
                    Text="اختر الكل" AutoPostBack="True" runat="server" OnCheckedChanged="chk_ALL_CheckedChanged">
                </asp:CheckBox>--%>
                <asp:CheckBoxList ID="chklst_Visa_Emp_All" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                    Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                    DataValueField="PMP_ID" runat="server" Width=500px>
                </asp:CheckBoxList>
            </div>
        </td>
        <td id="Td3" runat="server">
            <asp:Button ID="btn_add" OnClick="btn_add_Click" Text="إضافة" runat="server"  />
            <asp:Button ID="btn_delete" OnClick="btn_delete_Click" Text="مسح" runat="server"
                 />
        </td>
        <td id="Td4" runat="server">
            
                <asp:ListBox ID="lst_emp" runat="server" Width="500px" Height="289px" style="background-color: #F9fdff;">
                </asp:ListBox>
            
        </td>
    </tr>
  <tr style="height:50px"></tr>
    <tr>
        <td colspan="4" align="center">
            <asp:Button ID="SaveButton" Text="حفظ" runat="server" 
                Width="150px" OnClick="SaveButton_Click" />
        </td>
    </tr>
</table>
