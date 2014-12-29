<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_Classfication.aspx.cs" Inherits="WebForms2_Project_Classfication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table dir="rtl" style="line-height: 2; width: 100%;">
        <tr>
            <td align="left" colspan="2" dir="rtl" valign="top">
                <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/WebForms2/Default.aspx?return=1"
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
            <td class="GridTd">
                <asp:GridView ID="GridView_proj"  runat="server" AlternatingRowStyle-CssClass="alt"
                                        AutoGenerateColumns="False" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..."
                                        ForeColor="Black"  PagerStyle-CssClass="pgr"
                                        Width="100%" Font-Bold="True" Font-Size="Larger" 
                    BackColor="White" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText=" م">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/WebForms2/Project_Details.aspx?proj_id=" + Eval("Proj_id") %>'
                                    Target="_self" Text='<%# Eval("Proj_Title") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="pmp_name" HeaderText="مدير المشروع" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Proj_InitValue" HeaderText="الميزانية" 
                            ItemStyle-Width="125px" >
<ItemStyle Width="125px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Proj_Notes" HeaderText="ملاحظات" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
