<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" 
CodeFile="project_condition.aspx.vb" Inherits="WebForms_project_condition" title="Untitled Page" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" style="line-height: 2;">
    <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="حالـــــه المشــــــروع"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <table width="100%" style="line-height: 2;">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="right" style="width: 149px">
                                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="المشـــــــــروع : " />
                                    </td>
                                    <td align="right" dir="rtl" style="height: 51px" >
                                        <uc1:Smart_Search ID="Smart_Search_pr" runat="server" />
                                    </td>
                                    <%--<td align="right">
                                        <asp:DropDownList ID="DDLProjects" runat="server" CssClass="Button" Width="500px" />
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 149px">
                                        <asp:Label ID="label1" runat="server" CssClass="Label" Text="الحالــــــه : " />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="DDLStat" runat="server" Width="440px" CssClass="Button" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button2" Text="حفــــــظ" />
                                    </td>
                                </tr>
                         </table>
                        </td>
                     </tr>
                 </table>
                 </td>
             </tr>
         </table>
                         
</asp:Content>


