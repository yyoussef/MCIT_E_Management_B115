<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectActivitiesPM.aspx.cs" Inherits="WebForms_ProjectActivitiesPM" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
    <tr>
    <td style="height: 65px; " align="center" colspan="2" dir="rtl">
        <asp:Label ID="Label9" runat="server" CssClass="PageTitle" Font-Bold="False" 
            Text="تقرير الخطة التنفيذية لمشروع"></asp:Label>
            </td>
    </tr>
    <tr>
    <td style="height: 31px; " align="center" colspan="2" dir="rtl">
        <asp:Label ID="Label5" runat="server" Font-Bold="False" 
            ForeColor="#EC981F" font-underline="false" CssClass="Label" Font-Overline="False"></asp:Label>
            </td>
    </tr>
<tr>
        <td style="width: 105px">    
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="مدير المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 39px;" >
        <asp:Label ID="Label8" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
        </td>
</tr>
<tr>         
        <td style="width: 105px" >  
        <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="المشروع :" 
                CssClass="Label"></asp:Label>
         </td>
         <td style="height: 40px"  >
        <asp:DropDownList ID="DropDownList2" runat="server" 
            Font-Bold="False" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" CssClass="drop" 
                 Width="400px">
        </asp:DropDownList>
        </td>
</tr>

<tr>    
        <td colspan="2" style="height: 42px">
        <asp:LinkButton ID="PActivitiesReportLink" runat="server" Font-Bold="False" 
            onclick="PActivitiesReportLink_Click" CssClass="Text" ForeColor="#808080" font-underline="false" >تقرير 
        الخطة التنفيذية لمشروع</asp:LinkButton>
            
        </td>
        
        
</tr>
           
</table>

</asp:Content>

