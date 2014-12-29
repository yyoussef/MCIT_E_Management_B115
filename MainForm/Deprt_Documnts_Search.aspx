<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Deprt_Documnts_Search.aspx.cs" Inherits="WebForms_Deprt_Documnts_Search"
    Title="Untitled Page" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="بحث عن الوثائق" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الإدارة :" />
            </td>
            <td>
                <asp:DropDownList ID="ddl_Dept_ID" AutoPostBack="true" OnSelectedIndexChanged="ddl_Dept_ID_SelectedIndexChanged"
                    runat="server" CssClass="drop" Width="314px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="الموظف :" />
            </td>
            <td>
                <uc1:smart_search id="Smart_Emp_ID" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم الوثيقة: " />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txt_FileName" Width="700px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="وصف الوثيقة : " />
            </td>
            <td>
                <asp:TextBox ID="txt_File_Desc" runat="server" CssClass="Text" Height="70px" Width="90%"
                    Rows="6" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="نوع الوثيقة : " />
            </td>
            <td>
                <asp:DropDownList ID="ddl_File_Type" runat="server" CssClass="drop">
                <asp:ListItem Text=" --- اختر --- " Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Word"  Value="1"></asp:ListItem>
                    <asp:ListItem Text="Excel" Value="2"></asp:ListItem>
                    <asp:ListItem Text="PDF" Value="3"></asp:ListItem>
                    <asp:ListItem Text="IMAGE" Value="4"></asp:ListItem>
                    <asp:ListItem Text="PowerPoint" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="بحث" runat="server" CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                    Font-Size="17px" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="الإدارة">
                            <ItemTemplate>
                                <%#Eval("Dept_name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الموظف">
                            <ItemTemplate>
                                <%#Eval("pmp_name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اسم الوثيقة">
                            <ItemTemplate>
                                <a href='<%# "ALL_Document_Details.aspx?type=deprtfile&id="+ Eval("File_ID") %>'>
                                    <%#Eval("File_name")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="وصف الوثيقة">
                            <ItemTemplate>
                                <%#Eval("File_Desc")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="نوع الوثيقة">
                            <ItemTemplate>
                             <%# Get_Type(Eval("File_Type"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("File_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px" CommandArgument='<%# Eval("File_ID") %>' />
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
