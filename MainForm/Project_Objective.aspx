<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Project_Objective.aspx.vb" Inherits="WebForms_Project_Objective" Title="أهداف المشـــــــــــروع " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="PObj_ID" runat="server" type="hidden" />
    <table style="line-height: 2; width: 100%">
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="أهداف المشـــــــــــروع"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" dir="rtl" style="width: 9%">
                <asp:Label ID="label1" runat="server" Text="الهـــــــــدف : " Font-Bold="True" Font-Size="15px"
                    Font-Strikeout="False" ForeColor="Black" />
            </td>
            <td align="justify" dir="rtl" width="100%">
                <asp:TextBox ID="txtProjObjective" runat="server" CssClass="Text" TextMode="MultiLine"
                    Height="50px" Width="98%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="style14" style="height: 60px">
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="98%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="م" DataField="pobj_num" ItemStyle-Width="10px" HeaderStyle-Font-Size="16px"
                            HeaderStyle-Font-Bold="true" ItemStyle-Font-Size="16px" 
                            ItemStyle-Font-Bold="true" >
<HeaderStyle Font-Bold="True" Font-Size="16px"></HeaderStyle>

<ItemStyle Font-Bold="True" Font-Size="16px" Width="10px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الهــــــــــدف" DataField="pobj_desc" HeaderStyle-Font-Size="16px"
                            HeaderStyle-Font-Bold="true" ItemStyle-Font-Size="16px" ItemStyle-Font-Bold="true"
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="500px" 
                            ItemStyle-Wrap="true" >
<HeaderStyle Font-Bold="True" Font-Size="16px" Width="500px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="True" Font-Bold="True" Font-Size="16px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true"
                            HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <input id="PObj_ID" runat="server" type="hidden" value='<%# Eval("PObj_ID") %>' />
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("PObj_ID") %>' />
                            </ItemTemplate>

<HeaderStyle Font-Bold="True" Font-Size="16px" Width="25px"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-Font-Size="14px" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PObj_ID") %>'
                                    OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                            </ItemTemplate>

<HeaderStyle Font-Bold="True" Font-Size="14px" Width="25px"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center"></PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
