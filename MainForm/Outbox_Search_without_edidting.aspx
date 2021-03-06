﻿<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Outbox_Search_without_edidting.aspx.cs" Inherits="WebForms_Outbox_Search_without_edidting" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الصادر" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 29px">
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كلمة في الكود:" />
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" ID="Txtcode" Width="323px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="Text" ID="Inbox_name_text" Width="323px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="الجهة الصادر لها : "></asp:Label>
            </td>
            <td align="right" dir="rtl" colspan="2">
                <uc1:Smart_Search ID="Smrt_Srch_org" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 142px; height: 35px;">
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الصادر:" />
            </td>
            <td style="width: 10px;">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
            </td>
            <td>
                <asp:TextBox ID="Inbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                    TargetControlID="Inbox_date_from" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="Image1" TargetControlID="Inbox_date_from">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label111" runat="server" CssClass="Label" Text="الى:" />
                <asp:TextBox ID="Inbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    TargetControlID="Inbox_date_to" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                    TargetControlID="Inbox_date_to">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            </td>
        </tr>
       
        <tr>
            <td colspan="3">
            <br />
                <div align="center">
                    <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                        CssClass="Button" />
                        &nbsb&nbsb&nbsb&nbsb&nbsb
                         <asp:Button ID="btn_Report" Text="تقرير متابعة الصادر"  runat="server"
                        CssClass="Button" onclick="btn_Report_Click" Width="150px" />
                  
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    OnRowCommand="gvMain_RowCommand" 
                    OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText=" الكود ">
                            <ItemTemplate>
                                <%# Eval("Code")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ الصادر" ItemStyle-Width="100">
                            <ItemTemplate>
                                <%# Eval("Date")%>
                            </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="الجهة الصادر لها">
                            <ItemTemplate>
                                <%# Eval("Org_Desc")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="  الموضوع ">
                            <ItemTemplate>
                                <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="400px" runat="server"
                                    ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' />
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
