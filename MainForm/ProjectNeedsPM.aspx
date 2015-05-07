<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectNeedsPM.aspx.cs" Inherits="WebForms_ProjectNeedsPM" Title="Untitled Page" %>


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
                        <td align="center" colspan="2" dir="rtl" style="height: 36px">
                            <asp:Label ID="Label9" runat="server" CssClass="PageTitle" Font-Bold="False" 
                                Text="تقرير توزيع الموارد المتاحة بمخازن الوزارة"></asp:Label>
                          </td>
    </tr>
    <tr>
                        <td align="center" colspan="2" dir="rtl" style="height: 36px">
                        <asp:Label ID="Label4" runat="server" Font-Bold="false" 
                            ForeColor="Red" CssClass="Label"></asp:Label>
                          </td>
    </tr>
<tr>
        <td>
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="مدير المشروع : " 
                CssClass="Label"></asp:Label>
       </td>
       <td style="height: 34px">
        <asp:Label ID="Label7" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
        </td>
</tr>
<tr>    
        <td>
        <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="المشروع :" 
                CssClass="Label"></asp:Label>
        </td>
        <td style="height: 31px">
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            Font-Bold="False" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" CssClass="drop" 
                Width="450px">
        </asp:DropDownList>
        </td>
</tr>
        <tr>
                    <td colspan="2" style="height: 75px" align="justify" dir="rtl"  >
                    <asp:LinkButton ID="LinkButton1" runat="server"  
                            onclick="LinkButton1_Click" CssClass="Text" Height="24px" Width="289px">تقرير توزيع الموارد المتاحة 
                        بمخازن الوزارة حتي </asp:LinkButton>
                    
                     &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                             CssClass="drop" Width="300px">
                    </asp:DropDownList>
                    
                     </td>
                   
            </tr>
</table>

</asp:Content>

