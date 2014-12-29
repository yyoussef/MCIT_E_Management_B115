<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Business_Card_System.aspx.cs" Inherits="MainForm_Business_Card_System" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="h1" runat="server" value="0" />
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="بطاقات العمل" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الاسم:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="Txtname_ar" Width="323px"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" ID="Txtname_eng" Width="323px"></asp:TextBox>
                <asp:Label ID="Label12" runat="server" CssClass="Label" Text=": Name" />
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="الوظيفة : "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txtjob_ar" Width="323px"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" ID="txtjob_eng" Width="323px"></asp:TextBox>
                 <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" : Job Title "></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="الهيئة/الجهة/الشركة: "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txtorg_ar" Width="323px"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" ID="txtorg_eng" Width="323px"></asp:TextBox>
                 <asp:Label ID="Label3" runat="server" CssClass="Label" Text=":organization"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="العنوان : "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" TextMode="MultiLine" Rows="4" Height="70"
                    ID="txtadress_ar" Width="323px"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" TextMode="MultiLine" Rows="4" Height="70"
                    ID="txtadress_eng" Width="323px"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text=":Adress"></asp:Label>
            </td>
           
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="هاتف1 : "></asp:Label>
                 
            </td>
            <td>
            <asp:TextBox runat="server" CssClass="Text" ID="txtphone1" Width="323px"></asp:TextBox>
            </td>
            
            <td align="right" colspan="2">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="هاتف2 : "></asp:Label>
                <asp:TextBox runat="server" CssClass="Text" ID="txtphone2" Width="260px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="هاتف محمول1:" />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txtmobile1" Width="323px"></asp:TextBox>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="هاتف محمول2:" />
                <asp:TextBox runat="server" CssClass="Text" ID="txtmobile2" Width="220px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="فاكس: "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txtfax" Width="323px"></asp:TextBox>
            </td>
            <td align="right" colspan="2">
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الإيميل:" />
                <asp:TextBox runat="server" CssClass="Text" ID="txtmail" Width="266px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmail"
                    ErrorMessage="أدخل بريد الكتروني صحيح" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
           
        </tr>
        <tr>
            <td colspan="4" align="center">
                <br />
                <div align="center">
                    <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                        CssClass="Button" />
                    &nbsb&nbsb&nbsb&nbsb&nbsb
                    <asp:Button ID="Search" Text="بحث" runat="server" CssClass="Button" OnClick="Search_Click" />
                    <%--<asp:Button ID="Button1" runat="server" Text="تصدير الي إكسل" Width="130px" CssClass="Button"
                        OnClick="Button1_Click" />--%>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="4">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    OnRowCommand="gvMain_RowCommand" 
                    OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="الاسم باللغة العربية" ItemStyle-Width="150">
                            <ItemTemplate>
                                <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                <%# Eval("Name_ar")%>
                            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الاسم باللغة الأجنبية " ItemStyle-Width="150">
                            <ItemTemplate>
                                <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                <%# Eval("Name_eng")%>
                            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="هاتف محمول " ItemStyle-Width="100">
                            <ItemTemplate>
                                <%# Eval("mobile1")%>
                            </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" الايميل " ItemStyle-Width="150">
                            <ItemTemplate>
                                <%# Eval("mail")%>
                            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  هاتف ">
                            <ItemTemplate>
                                <%# Eval("tel1")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  فاكس ">
                            <ItemTemplate>
                                <%# Eval("Fax")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="  الجهة/الهيئة/الشركة ">
                            <ItemTemplate>
                                <%# Eval("org")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  الوظيفة ">
                            <ItemTemplate>
                                <%# Eval("job")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
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
</asp:Content>
