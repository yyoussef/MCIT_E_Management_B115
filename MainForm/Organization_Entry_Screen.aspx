<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Organization_Entry_Screen.aspx.vb" Inherits="WebForms_Organization_Entry_Screen" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="Org_ID" runat="server" type="hidden" />
    <table width="" rtl">
         <tr>
        <td colspan="2" align="center" style="height: 27px">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="2" align="center" style="height: 41px">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" 
                    Text="الجهات المستفيدة" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="left" style="width: 157px; height: 41px;">
                <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="اسم الجهه  : " />
            </td>
            <td align="right" style="&gt;
                &lt;asp:TextBox runat=; width: 542px; height: 41px;"server" 
                CssClass="Text"></asp:TextBox>
                <asp:TextBox ID="txt_org_name" runat="server" CssClass="Text" Height="29px" 
                    Width="487px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
            </td>
        </tr>
        
        
    </table>
    <table width="100%" style="line-height: 2;">
        <tr>
            <td align="center" class="Text"  colspan="2">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    CellPadding="3" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="الجهة" DataField="Org_Desc" />
                        
                        <asp:TemplateField HeaderText="تعديل">
                           <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("Org_id") %>' />
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click"  CommandArgument='<%# Eval("Org_id") %>' />
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                    <FooterStyle BackColor="#CCCCCC" />

<PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

<AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>


                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>


