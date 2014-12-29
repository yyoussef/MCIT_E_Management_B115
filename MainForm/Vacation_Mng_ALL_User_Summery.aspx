<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Vacation_Mng_ALL_User_Summery.aspx.cs" Inherits="WebForms_Vacation_Mng_ALL_User_Summery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="أرصدة الأجازات" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="الإدارة :" CssClass="Label"></asp:Label>
            </td>
            <td colspan="3">
                <uc1:Smart_Search ID="Smart_Search_mang" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label443" runat="server" CssClass="Label" Text="الموظف :" />
            </td>
            <td colspan="3">
                <uc1:Smart_Search ID="Smrt_Srch_user" Validation_Group="Group1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" الرصيدالحالي " />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="إعتيادى :" />
            </td>
            <td>
                <asp:TextBox ID="txt_unusual" runat="server" CssClass="Label" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_unusual"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="عارضة :" />
            </td>
            <td>
                <asp:TextBox ID="txt_exhibitor" runat="server" CssClass="Label" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_exhibitor"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="مرضية :" />
            </td>
            <td>
                <asp:TextBox ID="txt_sick" runat="server" CssClass="Label" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_sick"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
            <td colspan="2">
            </td>
        </tr>
         <tr>
            <td colspan="4">
                <asp:Label ID="Label9" runat="server" CssClass="Label" Text=" الرصيدالسنوي " />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="إعتيادى :" />
            </td>
            <td>
                <asp:TextBox ID="txt_unusual_total" runat="server" CssClass="Label" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_unusual_total"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="عارضة :" />
            </td>
            <td>
                <asp:TextBox ID="txt_exihib_total" runat="server" CssClass="Label" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_exihib_total"
                    ErrorMessage="*" ValidationExpression="^[0-9]*$" ValidationGroup="Group1"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="حفظ" Width="110px"
                    OnClick="BtnVacationRequest_Click" ValidationGroup="Group1" />
            </td>
        </tr>
    </table>
</asp:Content>
