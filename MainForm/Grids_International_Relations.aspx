<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Grids_International_Relations.aspx.cs" Inherits="WebForms_Grids_International_Relations" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="proj_id" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;" align="center">
                <tr>
                    <td align="center" class="GridTd">
                        <table style="width: 100%" id="tbl_grd" runat="server" visible="false">
                            <tr>
                                <td align="left" colspan="2" dir="rtl" valign="top">
                                    <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/WebForms/Default.aspx?return=1"
                                        runat="server" Height="39px" ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 39px" rowspan="1">
                                    <asp:Label ID="lblMain" runat="server" Text="قائمة المشروعات الجارية" CssClass="PageTitle"
                                        Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnRowCommand="gvMain_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" 
                                        AlternatingRowStyle-CssClass="alt" 
                                        onpageindexchanging="gvMain_PageIndexChanging" GridLines="Vertical">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" رقم القيد ">
                                                <ItemTemplate>
                                                    <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                                    <%# Eval("incombination")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" التاريخ ">
                                                <ItemTemplate>
                                                    <%# Eval("Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="جهة الورود">
                                                <ItemTemplate>
                                                    <%# Eval("Org_Desc")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                                <ItemTemplate>
                                                    <%# Eval("outcombination")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                                                <ItemTemplate>
                                                    <%# Eval("Org_Out_Box_Code")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="  الموضوع ">
                                                <ItemTemplate>
                                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText=" المشروع ">
                                                <ItemTemplate>
                                                    <%# Eval("proj_title")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="عرض">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="show_inbox_Details" runat="server"
                                                        ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>' />
                                                </ItemTemplate>
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
