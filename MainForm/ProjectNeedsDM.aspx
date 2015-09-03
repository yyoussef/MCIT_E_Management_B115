<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="ProjectNeedsDM.aspx.cs" Inherits="WebForms_ProjectNeedsDM" Title="Untitled Page" %>

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
                        <td align="center" colspan="2" dir="rtl" class="Label" style="height: 43px" >
                            <asp:Label ID="Label9" runat="server" CssClass="PageTitle" Font-Bold="False" 
                                Text="تقرير توزيع الموارد المتاحة بمخازن الوزارة"></asp:Label>
                            </td>
                            
    </tr>
    <tr>
                        <td align="center" colspan="2" dir="rtl" class="Label" style="height: 27px" >
                        <asp:Label ID="Label4" runat="server"  
                            ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                            </td>
                            
    </tr>
            <tr>
                        <td  colspan="1" >
                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="الإدارة :" 
                                CssClass="Label"></asp:Label>
                        </td>
                        
                     <td >
                    <asp:Label ID="Label7" runat="server" CssClass="Label" 
                             Font-Bold="False"></asp:Label>
                     </td>
                    
            
            </tr>
            <tr>
                   <td  dir="rtl">
                        <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="مدير المشروع : " 
                             CssClass="Label"></asp:Label>
                             
                   </td>
                   <td>
                   
                      
                     <asp:DropDownList ID="projmangdrop" runat="server" AutoPostBack="True" 
                            Font-Bold="False" 
                            onselectedindexchanged="projmangdrop_SelectedIndexChanged" 
                            CssClass="drop" Width="400px">
                        </asp:DropDownList>         
                             
                      
                   </td>
             </tr>
             <tr>
                     <td  dir="rtl" >
                     <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="المشروع : " 
                            CssClass="Label"></asp:Label>
                    
                     </td>
                     <td style="height: 44px; ">
                     
                              <asp:DropDownList ID="projdrop" runat="server" AutoPostBack="True" 
                            Font-Bold="False" 
                            onselectedindexchanged="projdrop_SelectedIndexChanged" 
                            CssClass="drop" Width="400px">
                        </asp:DropDownList>
                    
                         </td>
                    
              </tr> 
            <tr>
                    <td colspan="2" style="height: 63px" align="justify" dir="rtl"  >
                    <asp:LinkButton ID="LinkButton1" runat="server"  
                            onclick="LinkButton1_Click" CssClass="Text" Height="24px" Width="289px">تقرير توزيع الموارد المتاحة 
                        بمخازن الوزارة حتي </asp:LinkButton>
                    
                     &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" 
                        onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                             CssClass="Button" Height="41px" Width="190px">
                    </asp:DropDownList>
                    
                     </td>
                   
            </tr>
</table>

</asp:Content>

