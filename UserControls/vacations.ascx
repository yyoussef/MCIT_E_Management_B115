<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacations.ascx.cs" Inherits="UserControls_vacations" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
                <tr>
                    <td dir="rtl" align="center" colspan="2">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                            Text="أجازاتى"></asp:Label>
                    </td>
                </tr>
               
                <tr>
                    <td align="right" colspan="2" dir="rtl" style="width: 144px; height: 36px;">
                        <asp:Label ID="Label23" runat="server" CssClass="Label" Text="رصيد الأجازات" Width="95px"
                            Height="25px" />
                    </td>
                </tr>
                
                <tr>
                    <td align="center" class="Text" dir="rtl" colspan="2">
                        <asp:GridView ID="vacations" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                            ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="إعتيادى" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("unusual")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="25%" />
                                    <ItemStyle Font-Size="Large" Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عارضة" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("exhibitor")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="25%" />
                                    <ItemStyle Font-Size="Large" Width="25%" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="مرضية" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("sick")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="25%" />
                                    <ItemStyle Font-Size="Large" Width="25%" />
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="بدل راحة" ItemStyle-Width="25%" 
                                    HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("day_off_no")%>
                                    </ItemTemplate>
                                     <HeaderStyle Font-Size="Large" Width="25%" />
                                     <ItemStyle Font-Size="Large" Width="25%" />
                                </asp:TemplateField>
                                 <%--<asp:TemplateField HeaderText="أذن" ItemStyle-Width="25%" Visible="true" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("permission")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="25%" />
                                    <ItemStyle Font-Size="Large" Width="25%" />
                                </asp:TemplateField>--%>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="2" dir="rtl">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" colspan="2" dir="rtl" style="width: 144px; height: 36px;">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="أجازاتى" Width="95px"
                            Height="25px" />
                    </td>
                </tr>
                <tr>
                    <td align="left" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" 
                            Text="طلب أجازة" Width="110px" onclick="BtnVacationRequest_Click" />
                    </td>
                    <td align="right" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="BtnRequests" runat="server" CssClass="Button" 
                            Text="الأجازات" Width="110px" onclick="BtnRequests_Click" 
                            Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" dir="rtl" colspan="2">
                        <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                            ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                            onrowdatabound="requests_RowDataBound" OnRowCommand="requests_RowCommand" 
                            GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="تاريخ الطلب" ItemStyle-Width="20%" HeaderStyle-Width="20%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("request_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="20%" />
                                    <ItemStyle Font-Size="Large" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="نوع الأجازة" ItemStyle-Width="15%" HeaderStyle-Width="15%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("vacation_title")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="15%" />
                                    <ItemStyle Font-Size="Large" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المدة باليوم" ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("no_days")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="10%" />
                                    <ItemStyle Font-Size="Large" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="من" ItemStyle-Width="20%" HeaderStyle-Width="20%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("start_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="20%" />
                                    <ItemStyle Font-Size="Large" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلى" ItemStyle-Width="20%" HeaderStyle-Width="20%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <%# Eval("end_date")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="20%" />
                                    <ItemStyle Font-Size="Large" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الحالة" ItemStyle-Width="15%" HeaderStyle-Width="15%" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:Label ID="VocStatus" runat="server" CssClass="Label" Text="" Width="95px" Height="25px" />
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="Large" Width="15%" />
                                    <ItemStyle Font-Size="Large" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" Visible="false" runat="server" ImageUrl="../Images/Edit.jpg"
                                            CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف" HeaderStyle-Font-Size="Large"
                                    ItemStyle-Font-Size="Large">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" Visible="false" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                           
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="Button1" runat="server" CssClass="Button" 
                            Text="طلب أجازة" Width="110px" onclick="BtnVacationRequest_Click" />
                    </td>
                    <td align="right" style="direction: ltr" width="50%">
                       &nbsp; <asp:Button ID="Button2" runat="server" CssClass="Button" 
                            Text="الأجازات" Width="110px" onclick="BtnRequests_Click" 
                            Visible="False" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
