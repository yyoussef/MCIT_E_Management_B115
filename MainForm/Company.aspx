<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true"
    CodeFile="Company.aspx.cs" Inherits="WebForms_Company" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="50%" style="line-height: 2; color: Black">
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="الشركات"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                <input type="hidden" runat="server" id="hidden_Bil_ID" />
                <asp:Label ID="lbl_Work_Total_Value" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم الشركة : " />
            </td>
            <td>
                <asp:TextBox ID="txt_Company" Height="27px" Width="200px" CssClass="Text" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Company"
                    runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال الشركة "></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
         <td></td>
            <td  align="center" >
                <br />
                <br />
                <asp:Button ID="btn_Save" OnClick="btnSave_Click" Text="حفظ" runat="server" ValidationGroup="D"
                    CssClass="Button" />
            </td>
           
        </tr>
    </table>
</asp:Content>
