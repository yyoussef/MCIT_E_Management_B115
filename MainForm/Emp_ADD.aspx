<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Emp_ADD.aspx.cs" Inherits="WebForms_Emp_ADD" Title="إضافة موظف" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="h1" runat="server" value="0" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="80%" style="line-height: 2; color: Black" >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم المستخدم:" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="Label" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="اسم الادارة التابع لها الموظف:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Dept_ID" AutoPostBack="true" runat="server" CssClass="drop"
                            Width="314px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text="اسم الموظف:" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="txt_emp_name" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="  اختر اسم الموظف باللغة الانجليزية:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="Drop_Names" CssClass="drop" AutoPostBack="true" runat="server"
                            OnSelectedIndexChanged="Drop_Names_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="البريد الإلكتروني:" />
                    </td>
                    <td >
                        <asp:Label runat="server" CssClass="Label" ID="txt_emp_email" Visible="true" Width="200px"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="2">
                        <br />
                        <asp:Button ID="SaveButton" Text="حفظ" runat="server" CssClass="Button" OnClick="SaveButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        
                    </td>
                </tr>
            </table>
            <div align="center">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            AllowPaging="True" Width="90%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                            BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt" 
                    OnRowCommand="gvMain_RowCommand" Font-Size="17px"
                            EmptyDataText="... عفوا لا يوجد بيانات ..." 
                    OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("pmp_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%><asp:TemplateField HeaderText=" اسم الموظف ">
                                    <ItemTemplate>
                                        <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                        <%# Eval("pmp_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="البريد الإلكتروني">
                                    <ItemTemplate>
                                        <%# Eval("mail")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                            CommandArgument='<%# Eval("pmp_id") %>' />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
