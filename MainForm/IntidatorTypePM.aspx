<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="IntidatorTypePM.aspx.cs" Inherits="WebForms_IntidatorTypePM" Title="Untitled Page" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
    <tr>
              <td  align="center" colspan="2" style="height: 28px">
                    <asp:Label ID="Label6" runat="server" CssClass="PageTitle" Font-Bold="False" 
                        Text="تقرير مؤشرات القياس"></asp:Label>
            </td>
    
    </tr>
    <tr>
              <td  align="center" colspan="2" style="height: 31px">
                    <asp:Label ID="Label5" runat="server" Font-Bold="false" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
            </td>
    
    </tr>
    <tr>
            <td style="height: 40px">
                    <asp:Label ID="LabProj_Mang" runat="server" Font-Bold="False" 
                        Text="مدير المشروع : " CssClass="Label"></asp:Label>
            </td>
            <td style="height: 40px; width: 593px" class="PageTitle">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" CssClass="Label"></asp:Label>
            </td>
    </tr>
    <tr>
            <td style="height: 40px">
                    <asp:Label ID="LabProj" runat="server" Font-Bold="False" Text="المشروع : " 
                        CssClass="Label"></asp:Label>
            </td>
            <td style="height: 40px">
                    <asp:DropDownList ID="DropProj" runat="server" AutoPostBack="True" 
                    Font-Bold="False" 
                    onselectedindexchanged="DropProj_SelectedIndexChanged" CssClass="drop">
                     </asp:DropDownList>
            </td>
   </tr>
   <tr>
            <td align="justify" colspan="2" style="height: 43px">
                    <asp:LinkButton ID="IndicatortypeLBdeptMang" runat="server" Font-Bold="False" 
                        onclick="IndicatortypeLBdeptMang_Click" CssClass="Text">تقرير 
                    مؤشرات القياس</asp:LinkButton>
            </td>
          
   </tr>
</table>   

</asp:Content>

