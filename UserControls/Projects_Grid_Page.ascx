<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Projects_Grid_Page.ascx.cs"
    Inherits="UserControls_Projects_Grid_Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <input id="proj_id" runat="server" type="hidden" />
        <table width="100%" style="line-height: 2;" align="center">
            <tr>
                <td align="center" class="GridTd">
                    <table style="width: 100%" id="tbl_grd" runat="server">
                        <tr>
                            <td align="left" colspan="2" dir="rtl" valign="top">
                                <asp:ImageButton ID="ImgBtnBack" OnClick="ImgBtnBack_Click" runat="server" Height="39px"
                                    ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                            </td>
                        </tr>
                      
                      
                     
                     
                        <tr>
                            <td align="center" style="height: 39px" rowspan="1">
                                <asp:Label ID="lblMain" runat="server"  CssClass="PageTitle"
                                    Visible="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <asp:GridView ID="gvMain"  runat="server" AlternatingRowStyle-CssClass="alt"
                                        AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..."
                                        ForeColor="Black" PagerStyle-CssClass="pgr" Width="100%" Font-Bold="True" Font-Size="Larger"
                                        BackColor="White" GridLines="Vertical" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvMain_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="Row_Number" HeaderText="م" />
                                            <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Get_url(Eval("Proj_id")) %>'
                                                        Target="_self" Text='<%# Eval("Proj_Title") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="pmp_name" HeaderText="مدير المشروع" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proj_InitValue" HeaderText="الميزانية" ItemStyle-Width="125px">
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proj_Notes" HeaderText="ملاحظات" />
                                            <asp:BoundField DataField="Name" HeaderText="البروتوكول" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                    </asp:GridView>
                                    
                                    
                                     <asp:GridView ID="Gv_Proj_const"  runat="server" AlternatingRowStyle-CssClass="alt"
                                        AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..."
                                        ForeColor="Black" PagerStyle-CssClass="pgr" Width="100%" Font-Bold="True" Font-Size="Larger"
                                        BackColor="White" GridLines="Vertical" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvMain_PageIndexChanging">
                                        <Columns>
                                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                                               ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                             <ItemTemplate>
                                              <%#Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Get_url(Eval("Proj_id")) %>'
                                                        Target="_self" Text='<%# Eval("Proj_Title") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="pmp_name" HeaderText="مدير المشروع" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proj_InitValue" HeaderText="الميزانية" ItemStyle-Width="125px">
                                                <ItemStyle Width="125px" />
                                            </asp:BoundField>
                                           
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
