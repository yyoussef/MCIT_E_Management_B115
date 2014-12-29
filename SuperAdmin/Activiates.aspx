<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/SuperAdminMaster.master" 
CodeFile="Activiates.aspx.cs" Inherits="Superadmin_Activiates" %>


<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div>
    <table>
        <tr>
         <td style="width: 112px">
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="النظام" CssClass="Label"></asp:Label>
            </td>
         <td>
              <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_Groups_SelectedIndexChanged">
                </asp:DropDownList></td>
           
           
        </tr>
        <%--<tr>
        <td><asp:Label ID="Label3" runat="server" ForeColor="Black" Text="الإدارة" CssClass="Label"></asp:Label></td>
            <td>
                <uc1:smart_search id="Smart_Search_Dept" runat="server" />
            </td>
        </tr>--%>
        <tr>
            <td colspan="2">
                <asp:CheckBoxList ID="cbl_Employees" CellPadding="5" CellSpacing="5" RepeatColumns="2"
                    CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="pmp_name"
                    DataValueField="PMP_ID" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button runat="server" Text="حفــــــظ" ValidationGroup="A" CssClass="Button"
                    Width="99px" ID="BtnSave" OnClick="btnSave_Click"></asp:Button>
            </td>
        </tr>
    </table>
    
    </div>
    
</asp:Content>