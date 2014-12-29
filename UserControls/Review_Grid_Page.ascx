<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Review_Grid_Page.ascx.cs"
    Inherits="UserControls_Review_Grid_Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <input id="proj_id" runat="server" type="hidden" />
        <table width="100%" style="line-height: 2;" align="center">
            <tr>
                <td align="center" class="GridTd">
                    <table style="width: 100%" id="tbl_grd" runat="server" visible="false">
                        <tr>
                            <td align="left" colspan="2" dir="rtl" valign="top">
                                <asp:ImageButton ID="ImgBtnBack" OnClick="ImgBtnBack_Click" runat="server" Height="39px"
                                    ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                            </td>
                        </tr>
                      <%--  <tr>
                            <td align="left">
                                <asp:Button runat="server" CssClass="Button" Font-Bold="false" Text="إغلاق " ID="btn_close_inbox"
                                    OnClick="btn_close_inbox_Click" Width="40px" />
                            </td>
                        </tr>--%>
                       
                        <tr>
                            <td align="center" style="height: 39px" rowspan="1">
                                <asp:Label ID="lblMain" runat="server"  CssClass="PageTitle"
                                    Visible="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnRowCommand="gvMain_RowCommand"
                                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                    OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText=" التاريخ ">
                                            <ItemTemplate>
                                                <%# Eval("Date")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                       
                                        <asp:TemplateField HeaderText="  الموضوع ">
                                            <ItemTemplate>
                                                <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                    ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="show_Bulliten_Details" runat="server"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
