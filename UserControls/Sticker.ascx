<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Sticker.ascx.vb" Inherits="UserControls_Sticker" %>
<link rel="stylesheet" href="../css/style (2).css" type="text/css" />
<style type="text/css">
    .style3
    {
        height: 20px;
    }
    </style>
    
<table id="TblMain" runat="server" width="100%" class="tbl" dir="rtl" visible="false" align="center">
    <tr>
        <td class="style3">
         &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblProjname_Show" runat="server" CssClass="StickerLabel">اسم المشروع : </asp:Label>
            <asp:Label ID="lblProjName" runat="server" CssClass="tbl1"></asp:Label>
        &nbsp;</td>
        <td class="style3">
            <asp:Label ID="lblDepart_Show" runat="server" CssClass="StickerLabel">الإدارة : </asp:Label>
            <asp:Label ID="lblDepart" runat="server" CssClass="tbl1"></asp:Label>
        </td>
        <td class="style3">
            <asp:Label ID="lblCoast_Show" runat="server" CssClass="StickerLabel">الميزانية : </asp:Label>
            <asp:Label ID="lblCoast" runat="server" CssClass="tbl1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
         &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblProjManger_Show" runat="server" CssClass="StickerLabel">مدير المشروع : </asp:Label>
            <asp:Label ID="lblProjManger" runat="server" CssClass="tbl1"></asp:Label>
        </td>
        <td colspan="1" class="style3">
            <asp:Label ID="lblStartDate_Show" runat="server" CssClass="StickerLabel">تاريخ الاقتراح : </asp:Label>
            <asp:Label ID="lblStartDate" runat="server" CssClass="tbl1"></asp:Label>
        </td>
        <td colspan="1" class="style3">
            <asp:Label ID="lblActStartDate_Show" runat="server" CssClass="StickerLabel">تاريخ البداية : </asp:Label>
            <asp:Label ID="lblActStartDate" runat="server" CssClass="tbl1"></asp:Label>
        </td>
    </tr>
    <tr  class="style3">
        <td class="style3">
         &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
            <asp:Label ID="lblUsesDest_Show" runat="server" CssClass="StickerLabel">الجهات المستفيدة : </asp:Label>
            <asp:Label ID="lblUsesDest" runat="server" CssClass="tbl1"></asp:Label>
        </td>
        <td colspan="1" class="style3">
            <asp:Label ID="lblExeDest_Show" runat="server" CssClass="StickerLabel">الجهات المنفذه : </asp:Label>
            <asp:Label ID="lblExeDest" runat="server" CssClass="tbl1"></asp:Label>
        </td >
         <td colspan="1" class="style3">
            <asp:Label ID="lblproject_type_show" runat="server" CssClass="StickerLabel">نوع المشروع  : </asp:Label>
            <asp:Label ID="lblproject_type" runat="server" CssClass="tbl1"></asp:Label>
        </td>
    </tr>
</table>
