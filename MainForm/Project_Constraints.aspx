<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" 
CodeFile="Project_Constraints.aspx.vb" Inherits="WebForms_Project_Constraints" title="معوقات المشروع" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="PCONS_ID" runat="server" type="hidden" />
            <table width="100%" cellpadding="5px">
                <tr>
                    <td dir="rtl" align="center" style="height: 44px" >
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" 
                            Text="معوقـــــات المشــــــــروع"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center" style="height: 33px">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" 
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr dir="rtl">
                    <td dir="rtl" align="center">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" align="left" dir="rtl" style="height: 232px">
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 95px; width: 200px;">
                                                <asp:Label ID="lblClassName" runat="server" CssClass="Label" 
                                                    Text="النشـــــــاط الرئيسى : " />
                                            </td>
                                            <td align="right" dir="rtl" style="height: 51px" >
                                                <uc1:Smart_Search ID="Smart_Search_mac" runat="server" />
                                                <%--<asp:DropDownList ID="DDLParentActv" runat="server" CssClass="drop" 
                                                    Width="95%" AutoPostBack="True"
                                                    Font-Size="Large" />
                                                     <asp:ImageButton ID="ImgBtnResearch1" runat="server" Height="20px" 
                                                    ImageUrl="~/Images/search.jpg" Style="height: 16px" Width="20px" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 93px; width: 200px;">
                                                <asp:Label ID="Label4" runat="server" CssClass="Label" 
                                                    Text="النشــــــــــــــاط الفرعى : " />
                                            </td>
                                            <td align="right" dir="rtl" style="height: 51px" >
                                                <uc1:Smart_Search ID="Smart_Search_sac" runat="server" />
                                                <%--<asp:DropDownList ID="ddlChildActv" runat="server" CssClass="drop" 
                                                    Width="95%" AutoPostBack="True"
                                                    Font-Size="Large" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 53px; width: 200px;" >
                                                <asp:Label ID="label1" runat="server" CssClass="Label" 
                                                    Text="وصـــف المعـــــــــــوق : " />
                                            </td>
                                            <td align="right" dir="rtl" style="height: 53px">
                                                <asp:TextBox ID="txtCONS_DESC" runat="server" Width="95%" Font-Size="Large" 
                                                    Height="46px" Font-Names="Times New Roman" AutoPostBack="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="width: 200px" >
                                                <asp:Label ID="label2" runat="server" CssClass="Label" Text="مقترحات لمواجهة المعوق : " />
                                            </td>
                                            <td align="right" dir="rtl">
                                                <asp:TextBox ID="txtSugg_Solution" runat="server" Width="95%" Font-Size="Large"
                                                    Height="60px" TextMode="MultiLine" Font-Names="Times New Roman" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 30px; width: 200px">
                                                <asp:Label ID="label3" runat="server" CssClass="Label" 
                                                    Text="تدخل إدارة عليــــا : " />
                                            </td>
                                            <td align="right" colspan="1" dir="rtl" style="height: 30px">
                                                <asp:CheckBox ID="ChBIs_Critical" runat="server" AutoPostBack="True" 
                                                    Enabled="False" />
                                            </td>
                                        </tr>
                                    </table>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" />
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="Text" colspan="4">
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        GridLines="Vertical">
                                        <Columns>
                                            
                                            <asp:BoundField HeaderText="اسم النشاط " DataField="PActv_Desc" />
                                            <asp:BoundField HeaderText="وصف المعوق" DataField="PCONS_DESC" />
                                            <asp:BoundField HeaderText="مقترح لمواجهة المعوق" DataField="PCONS_Sugg_Solutions" />
                                            <asp:TemplateField HeaderText="تدخل ادارة عليا">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" checked='<%# Eval("PCONS_IS_CRITICAL") %>'
                                                        Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                <input id="PCONS_ID" runat="server" type="hidden" value='<%# Eval("PCONS_ID") %>' />
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                        CommandArgument='<%# Eval("PCONS_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                        OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PCONS_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
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

