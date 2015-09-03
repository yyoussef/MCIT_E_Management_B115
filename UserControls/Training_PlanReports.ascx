<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_PlanReports.ascx.cs" Inherits="UserControls_Training_PlanReports" %>

<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table style="width: 100%; display: block; height: 100px; line-height: 2;" id="tbl_Report"
    runat="server">
    <tr>
        <td style="height: 30px; text-align: center;">
            <asp:Label ID="lbl_report_title" Text="تقارير الخطة التدريبية" runat="server" Font-Names="Arial"
                Font-Size="20px" ForeColor="#1F4569" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image35" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
            <asp:LinkButton ID="Training_emp" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Training_emp_Click">  تقرير الخطة التدريبية  </asp:LinkButton>
        </td>
        <td>
            <input type="hidden" runat="server" id="hidden_Rpt_Id" />
        </td>
    </tr>
      <tr>
        <td style="height: 30px; text-align: right;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/arrow.gif"  Style="text-align: right;padding-left:5px" />
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Text" Font-Bold="False"
                OnClick="Training_emp_count_Click">  تقرير بأعداد المتقدمين في الخطة التدريبية  </asp:LinkButton>
        </td>
        <td>
            <input type="hidden" runat="server" id="hidden1" />
        </td>
    </tr>
    
   </table>
   <table style="line-height: 2; width: 100%; display: none; height: 100px" id="tbl_Paramater"
    runat="server">
    <tr>
        <td style="height: 41px" align="center">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle"></asp:Label>
        </td>
        <td>
            <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                Width="37px" OnClick="ImgBtnBack_Click" AlternateText="العودة للتقارير الرئيسية" />
        </td>
    </tr>
</table>
<div id="Div_dept" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label1" runat="server" Text="الإدارة : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" width="400px" dir="rtl">
                <uc1:Smart_Search ID="Smart_dept" runat="server" />
            </td>
        </tr>
    </table>
</div>

<div id="div_course" runat="server" style="display: none">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" dir="rtl" style="width: 110px">
                <asp:Label ID="Label3" runat="server" Text="إسم الدورة التدريبية : " Font-Names="Arial" Font-Size="20px"
                    ForeColor="#1F4569" Font-Bold="false"></asp:Label>
            </td>
            <td align="right" width="400px" dir="rtl">
                <uc1:Smart_Search ID="smart_course" runat="server" />
            </td>
        </tr>
    </table>
</div>



<table style="line-height: 2; width: 100%; display: none;" id="tbl_Paramater1" runat="server">
    <tr>
        <td align="center" dir="ltr">
           
       
            <asp:Button ID="Button1" runat="server" CssClass="Button" Font-Bold="True" Font-Size="Large"
                OnClick="Button1_Click" Text="عرض التقرير" Width="98px" />
        </td>
    </tr>
</table>
