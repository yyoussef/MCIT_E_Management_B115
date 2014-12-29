<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="SiteUpload.aspx.cs" Inherits="WebForms_SiteUpload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%">
        <tr>
            <td colspan="4" style="text-align: center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 227px">
                <asp:Label ID="lbl_SiteTitle" runat="server" CssClass="Label" Text="اسم الجهة:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtBox_SiteTitle" runat="server" Width="280px" ValidationGroup="A"></asp:TextBox>
                <asp:RequiredFieldValidator ID="SiteTitleRFV" runat="server" ControlToValidate="txtBox_SiteTitle"
                    ErrorMessage="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 227px">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="اسم الإدارة المسئولة عن النظام:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtESignature" runat="server" Width="280px" ToolTip="يتم إدراج هذا النص أسفل كل بريد إلكتروني يتم إرساله من النظام"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBox_SiteTitle"
                    ErrorMessage="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 227px">
                <asp:Label ID="lbl_MainPic" runat="server" CssClass="Label" Text="الصورة الرئيسية :  "></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_sourceImageName" runat="server" Text="Label" CssClass="Label"></asp:Label>
                <asp:FileUpload ID="SiteUploadPic" runat="server" Width="280px" Style="margin-right: 4px" />
                <asp:Label ID="Label3" runat="server" Text="أبعاد الصورة الرئيسية لا تزيد عن 1500*240 pixel"
                    CssClass="Label" Enabled="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 227px; height: 36px;">
            </td>
            <td style="height: 36px" colspan="3">
                <input id="currentPicFileName" type="hidden" runat="server" />
                <img id="prevImg" alt="" style="width: 81px" runat="server" visible="False" /><asp:HiddenField
                    ID="ImageRecordID_HdnF" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 227px">
                <asp:Label ID="lbl_logo" runat="server" CssClass="Label" Text="شعار الجهة :  "></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl_sourcelogoName" runat="server" Text="Label" CssClass="Label"></asp:Label>
                <asp:FileUpload ID="SiteUploadlogo" runat="server" Width="280px" Style="margin-right: 4px" />
                <asp:Label ID="Label1" runat="server" Text="أبعاد الشعار لا تزيد عن 100*100 pixel"
                    CssClass="Label" Enabled="False"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 227px; height: 36px;">
            </td>
            <td style="height: 36px" colspan="3">
                <input id="currentlogoFileName" type="hidden" runat="server" />
                <img id="prevlogo" alt="" style="width: 81px" runat="server" visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" 
                    OnClick="btnSave_Click" Height="41px" ValidationGroup="A" />
            </td>
        </tr>
        <tr>
            <td style="width: 227px">
                &nbsp;
            </td>
            <td colspan="2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
