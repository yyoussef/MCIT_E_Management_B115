<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Project_priority.aspx.vb" Inherits="WebForms_Project_priority" 
 title="Choose project priority" %>
 <%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id= "proj_id" type="hidden" runat ="server" />
    <table width="100%" style="line-height: 2;">
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="أولويـــــه المشروعــــــات"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center" style="height: 61px">
                <table width="100%" style="line-height: 2;">
                    <tr>
                        <td align="right" class="style3" style="width: 158px">
                            <asp:Label ID="label1" runat="server" CssClass="Label" Text="المشـــــــــــروع :"
                                Width="150 px" />
                        </td>
                       <%-- <td align="right">
                            <asp:DropDownList ID="DDLprojects" runat="server" CssClass="Button" 
                                Width="98%" Height="33px" AutoPostBack="True" />
                        </td>--%>
                         <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="3">
                        <uc1:Smart_Search ID="Smart_Search_pr" runat="server" />
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="style3" style="width: 158px">
                            <asp:Label ID="label2" runat="server" CssClass="Label" Text="الأولويــــــــــــة :"
                                Width="150 px" />
                        </td>
                        <td align="right">
                            <asp:DropDownList ID="DDLPriority" runat="server" CssClass="Button" 
                                Width="173px" Height="35px" />
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                 <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" 
                     Width="99px" />
            </td>
        </tr>
        <tr>
            <td align="center" >
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="98%" BackColor="White" ForeColor="Black" 
                    BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" 
                    EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" 
                    AlternatingRowStyle-CssClass="alt" Font-Size="17px" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="المشــــروع" DataField="proj_title" 
                            HeaderStyle-Font-Bold="true" ItemStyle-Width="87%">
<HeaderStyle Font-Bold="True"></HeaderStyle>

<ItemStyle Width="87%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الأولويـــــة" DataField="prio_desc" 
                            ItemStyle-Width="10%">
<ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="3%">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("Proj_ID") %>' />
                            </ItemTemplate>

<ItemStyle Width="3%"></ItemStyle>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Proj_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
    