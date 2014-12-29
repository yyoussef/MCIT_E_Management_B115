<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectNeedsMM.aspx.cs" Inherits="WebForms_ProjectNeedsMM" Title="Untitled Page" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
    <tr>
                        <td align="center" colspan="2" dir="rtl" style="height: 39px">
                            <asp:Label ID="Label8" runat="server" CssClass="PageTitle" Font-Bold="False" 
                                Text="تقرير توزيع الموارد المتاحة بمخازن الوزارة"></asp:Label>
                         </td>
    </tr>
    <tr>
                        <td align="center" colspan="2" dir="rtl" style="height: 39px">
                        <asp:Label ID="Label4" runat="server" Font-Bold="false" 
                            ForeColor="Red" CssClass="Label"></asp:Label>
                         </td>
    </tr>
<tr>
        <td >
        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="الإدارة : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 50px">
        <asp:DropDownList ID="Deptdrop" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="Deptdrop_SelectedIndexChanged" CssClass="drop" 
                Width="550px">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
        <td  height: 48px;">
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="مدير المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 48px">
        <asp:DropDownList ID="Projmanagedrop" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="Projmanagedrop_SelectedIndexChanged" CssClass="drop" 
                Width="550px">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
        <td>
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="المشروع : " 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 54px">
        <asp:DropDownList ID="projdrop" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="projdrop_SelectedIndexChanged" CssClass="drop" 
                Width="550px">
        </asp:DropDownList>
        </td>
</tr>    
<tr>
                    <td colspan="2"  >
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                            onclick="LinkButton1_Click" CssClass="Text">تقرير توزيع الموارد المتاحة 
                        بمخازن الوزارة حتي </asp:LinkButton>
                     <asp:DropDownList ID="DropDownList5" runat="server" 
                        Font-Bold="False" onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                             CssClass="drop" Height="28px" Width="300px">
                    </asp:DropDownList>
                    
                     </td>
                    
                   
                    
            </tr>  
</table>

</asp:Content>

