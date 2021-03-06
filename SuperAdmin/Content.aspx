﻿<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master" AutoEventWireup="true"
    CodeFile="Content.aspx.cs" Inherits="suber_admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="اسم النظام " ForeColor="Black" Font-Bold="True"
                    Font-Size="Large"></asp:Label>
            </td>
            <td style="width: 576px">
                <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl2" runat="server" Text="الحاله" ForeColor="Black" Font-Size="Large"></asp:Label>
            </td>
            <td style="width: 576px">
                <asp:CheckBox ID="chkb1" runat="server" />
            </td>
            <td>
                &nbsp;`
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 576px">
                <asp:Button ID="save" runat="server" ForeColor="Black" Font-Size="Large" Text="حفظ"
                   CssClass="Button"  OnClick="save_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr> 
            <td colspan="2">
                &nbsp;
                <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand " runat="server"
                    Height="100%" Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    onpageindexchanging="GridView1_PageIndexChanging" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" PageIndex="20">
                   
                    <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                        <asp:BoundField DataField="pk_ID" HeaderText=" رقم المسلسل" ControlStyle-Font-Size="X-Large"/>
                        <asp:BoundField DataField="Name" HeaderText="اسم النشاط" ControlStyle-Font-Size="X-Large"/>
                        <asp:BoundField DataField="Active" HeaderText=" الحاله" ControlStyle-Font-Size="X-Large"/>
                        <asp:TemplateField HeaderText="حذف"  HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif" CommandName="Delette" Text="ألغاء"  Style="height: 22px" CommandArgument='<%# Eval("pk_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل"  HeaderStyle-Width="25px" >
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" ImageUrl="../Images/Edit.jpg" CommandName="Updates" Text="تعديل" runat="server" Style="height: 22px" CommandArgument='<%# Eval("pk_ID") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
