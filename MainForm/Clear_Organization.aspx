<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Clear_Organization.aspx.cs" Inherits="WebForms_Clear_Organization" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div>
        <table width="90%">
            <tr>
                <td>
                    <asp:Label ID="Label12" CssClass="Label"  runat="server" Text="اسم الجهة" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Name"   CssClass="Text" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btn_Search" runat="server"  CssClass="Button"  Text="بحث" OnClick="btn_Search_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                        dir="rtl" align="right">
                        
                        <asp:CheckBoxList ID="chklst_Org" CellPadding="5" CellSpacing="5" RepeatColumns="3"
                            Font-Size="Small" RepeatDirection="Vertical" RepeatLayout="Table" TextAlign="Right"
                            DataTextField="Org_Desc" DataValueField="Org_ID" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="Label"   runat="server" Text="العدد" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_Count" Enabled="false"  CssClass="Text" ></asp:TextBox>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="Label"  runat="server" Text=" الاسم الجديد" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_new_Name"  CssClass="Text" Width="200px" ></asp:TextBox>
                </td>
            </tr>--%>
             <tr>
                <td colspan="2" align="center" >
                <br />
                <br />
                    <asp:Button ID="Button1" runat="server" Text="إضافة جهة جديدة" Width="200px" OnClientClick="if (confirm('هل تود إضافة هذه الجهة') == false) return false;"  CssClass="Button" OnClick="btn_Save_Click" />
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>

