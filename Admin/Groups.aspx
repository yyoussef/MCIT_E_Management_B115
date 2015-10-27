<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="WebForms2_Groups" Title="Untitled Page"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="المجموعات الادارية للموظفين " />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="اسم المجموعة" 
                    CssClass="label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Group_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 37px">
            </td>
            <td style="height: 37px">
                <asp:Button ID="btn_Dept_Save" runat="server" Text="حفظ" OnClick="btn_Dept_Save_Click"
                    Width="74px" CssClass="Button" />
            </td>
            <td style="height: 37px">
                &nbsp;
            </td>
            <td style="height: 37px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="اسم المجموعة" DataField="name" />
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("id") %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                    </PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Label" Visible ="false" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

