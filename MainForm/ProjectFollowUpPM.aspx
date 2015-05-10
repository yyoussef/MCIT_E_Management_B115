<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectFollowUpPM.aspx.cs" Inherits="WebForms_ProjectFollowUpPM" Title="Untitled Page" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

    </script>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
            <td style="height: 81px; " align="center" colspan="2" dir="rtl">
                <asp:Label ID="Label8" runat="server" CssClass="PageTitle" Font-Bold="False" 
                    Text="تقرير الإنجازات ومتابعة الأعمال لمشروعات قطاع البنية المعلوماتية" 
                    Width="550px"></asp:Label>
        </td>
    </tr>
    <tr>
            <td style="height: 43px; " align="center" colspan="2" dir="rtl">
            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" 
            ForeColor="Red"></asp:Label>
        </td>
    </tr>
<tr>
        <td dir="rtl" style="height: 47px" >
        <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="مدير المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 47px;">
        <asp:Label ID="Label6" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
        </td>
</tr>
<tr>    
        <td  dir="rtl" style="height: 33px" >
        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 33px" >
        <asp:DropDownList ID="DropDownList1" runat="server" 
            Font-Bold="False" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                CssClass="Button" Width="500px" Font-Size="Large" AutoPostBack="True">
        </asp:DropDownList>
        </td>
</tr>

<tr>    
        <td colspan="2" style="height: 39px" >
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                onclick="LinkButton1_Click" CssClass="Text">تقرير الإنجازات و 
            متابعة الأعمال لمشروعات قطاع البنية المعلوماتية</asp:LinkButton>
        </td>
        
</tr>
</table>    

</asp:Content>

