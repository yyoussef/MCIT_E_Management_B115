<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectActivitiesMM.aspx.cs" Inherits="WebForms_ProjectActivitiesMM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
    <td  align="center" colspan="2" style="height: 34px">
        <asp:Label ID="Label6" runat="server" CssClass="PageTitle" Font-Bold="False" 
            Text="تقرير الخطة التنفيذية لمشروع"></asp:Label>
        </td>
    </tr>
    <tr>
    <td  align="center" colspan="2" style="height: 23px">
        <asp:Label ID="Label5" runat="server" Font-Bold="false" 
            ForeColor="Red" CssClass="Label"></asp:Label>
        </td>
    </tr>
<tr>    
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="الإدارة :" 
                CssClass="Label"></asp:Label>
        </td>
        <td  colspan="1">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" CssClass="drop" 
                Width="500px">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
        <td>
        <asp:Label ID="Label2" runat="server"  
            CssClass="Label" Text="المشروع :" Font-Bold="False"></asp:Label>
        </td>
        <td  colspan="1">
        <asp:DropDownList ID="DropDownList2" runat="server" 
            Font-Bold="False" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" CssClass="drop" 
                Width="500px">
        </asp:DropDownList>
        </td>
</tr>   
<tr>
        <td 
            colspan="2" style="height: 34px" >
        <asp:LinkButton ID="PActivitiesReportLink" runat="server" CssClass="Text" 
            onclick="PActivitiesReportLink_Click" Font-Underline="False" >تقرير الخطة 
            التنفيذية لمشروع</asp:LinkButton>
        </td>
        
</tr>    
</table>
</asp:Content>

