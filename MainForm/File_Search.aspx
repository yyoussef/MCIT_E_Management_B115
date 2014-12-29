<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="File_Search.aspx.cs" Inherits="WebForms_File_Search" Title="البحث في الملفات" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الملفات" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 29px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الملف:" />
            </td>
            <td style="width: 10px;">
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="File_name_text" Width="323px"></asp:TextBox>
            </td>
        </tr>
       
        
        <tr>
            <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="سنة فتح الملف:" />
            </td>
            <td style="width: 10px;">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
            </td>
            <td>
                <asp:TextBox ID="File_date_from" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                    TargetControlID="File_date_from" ValidChars="0987654321" />
                
                
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الى:" />
                <asp:TextBox ID="File_date_to" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    TargetControlID="File_date_to" ValidChars="0987654321" />
                
            </td>
        </tr>
        
       
        <tr>
            <td colspan="3" align="center" style="height: 26px">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    OnRowCommand="gvMain_RowCommand" 
                    onpageindexchanging="gvMain_PageIndexChanging" AllowPaging="True" 
                    GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="الملف" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <input id="file_ID" runat="server" type="hidden" value='<%# Eval("Files_id") %>' />
                                <%# Eval("File_Name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملاحظة الملف" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("File_note")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" تاريخ فتح الملف " HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("File_date")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("Files_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("Files_id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
