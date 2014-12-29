<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_event_search.aspx.cs" Inherits="WebForms_Project_event_search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <table dir="rtl" style="line-height: 2; width: 99%;">
                <tr>
                    <td align="center" colspan="3" style="height: 33px">
                        <asp:Label ID="Label2" runat="server" CssClass="PageTitle" 
                            Text="الاحداث" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 29px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" 
                            Text="الحدث:" />
                    </td>
                    <td style="width:10px;">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Event_name" 
                            Width="323px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" 
                            Text="مكان الحدث:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Event_location" 
                            Width="324px"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الحدث:" />
                    </td>
                     <td style="width:10px;">
                        <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
                    </td>
                    <td>
                            <asp:TextBox ID="Event_date_from" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="Event_date_from" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="Event_date_from">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الى:" />
                                <asp:TextBox ID="Event_date_to" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                TargetControlID="Event_date_to" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image2" TargetControlID="Event_date_to">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="height: 26px">
                        <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                            CssClass="Button" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="الحدث" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <input id="Event_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                        <%# Eval("Event_name")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="ملف الحدث" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <a href='<%# "ALL_Document_Details.aspx?type=Event&id="+ Eval("id") %>'  ><%# Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="تاريخ الحدث" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                      <%# Eval("Event_date")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="مكان الحدث" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                      <%# Eval("Event_location")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
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

