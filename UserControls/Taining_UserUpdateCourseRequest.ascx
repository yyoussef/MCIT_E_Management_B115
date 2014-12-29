<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Taining_UserUpdateCourseRequest.ascx.cs" Inherits="UserControls_Taining_UserUpdateCourseRequest" %>
<table dir="rtl" width="100%" style="line-height: 2; color: Black">
    <tr>
        <td>
            <asp:Label ID="label1" runat="server" Text="اسم الدوره التدريبييه" CssClass="PageTitle" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tx_coursename" runat="server" Enabled="False" CssClass="Text"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label2" runat="server" Text="مكان اللانعقاد" CssClass="PageTitle" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tx_courseplace" runat="server" Enabled="False" CssClass="Text" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label3" runat="server" Text="الهيئه المانحه" CssClass="PageTitle" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tx_organization" runat="server" Enabled="False" CssClass="Text"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label4" runat="server" Text="اخر تاريخ للتسجيل" CssClass="PageTitle" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tx_lastgenertiondate" runat="server" CssClass="Text" 
                Enabled="False" Height="22px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="label5" runat="server" Text="عدد الموظفين المطلوب" CssClass="PageTitle" ></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tx_noofemployee" runat="server" CssClass="Text" 
                Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:RadioButtonList ID="rb_coursedates" runat="server" CssClass="PageTitle" 
                DataTextField="start_date" DataValueField="id" onselectedindexchanged="rb_coursedates_SelectedIndexChanged" 
                >
                <asp:ListItem></asp:ListItem>
            </asp:RadioButtonList>
           
        </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="Button1" runat="server" Text="عدل التاريخ" onclick="Button1_Click" 
            CssClass="Button"></asp:Button>
    </td>
    </tr>
    </table>
