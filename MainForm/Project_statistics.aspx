<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Project_statistics.aspx.cs" Inherits="WebForms_Project_statistics" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr align="left">
            <td align="left" class="Text">
                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                    Width="37px" ImageAlign="Left" OnClick="ImgBtnBack_Click" AlternateText="الصحفة الرئيسية" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <div runat="server" id="events" visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" class="Text">
                                <center>
                                    <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الاحداث" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="events_gv" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                    GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="المشروع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <%# Eval("Proj_Title")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الحدث" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <a href='<%# "Project_event.aspx?id="+ Eval("id")+"&project="+ Eval("ProjID") %>'>
                                                    <%# Eval("Event_name")%></a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الحدث" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Event_date")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="مكان الحدث" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Event_location")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <div runat="server" id="protocol" visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" class="Text">
                                <center>
                                    <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="البروتوكولات" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="protocol_gv" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                    GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="المشروع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <%# Eval("Proj_Title")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="البروتوكول" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <a href='<%# "Project_protocol.aspx?id="+ Eval("id")+"&project="+ Eval("ProjID") %>'>
                                                    <%# Eval("Protocol_name")%></a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ بداية البروتوكول" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Protocol_date")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ نهاية البروتوكول" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Protocol_end_date")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <div runat="server" id="meeting" visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" class="Text">
                                <center>
                                    <asp:Label ID="Label1" runat="server" CssClass="PageTitle" Text="الاجتماعات" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="meetings_gv" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                    GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="المشروع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <%# Eval("Proj_Title")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الاجتماع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <a href='<%# "Project_meetings.aspx?id="+ Eval("id")+"&project="+ Eval("ProjID") %>'>
                                                    <%# Eval("Meeting_name")%></a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الاجتماع" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Meeting_date")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="مكان الاجتماع" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Meeting_location")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <div runat="server" id="meetingwithout" visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" class="Text">
                                <center>
                                    <asp:Label ID="Label3" runat="server" CssClass="PageTitle" Text="الاجتماعات بدون محضر" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="meetings_without_gv" runat="server" AutoGenerateColumns="False"
                                    CellPadding="3" Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                                    BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    CssClass="mGrid" PagerStyle-CssClass="pgr" 
                                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="المشروع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <%# Eval("Proj_Title")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الاجتماع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="35%">
                                            <ItemTemplate>
                                                <a href='<%# "Project_meetings.aspx?id="+ Eval("id")+"&project="+ Eval("ProjID") %>'>
                                                    <%# Eval("Meeting_name")%></a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الاجتماع" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Meeting_date")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="مكان الاجتماع" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%">
                                            <ItemTemplate>
                                                <%# Eval("Meeting_location")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text">
                <div runat="server" id="Div_Protocol" visible="false">
                    <table width="100%">
                        <tr>
                            <td align="center" class="Text">
                                <center>
                                    <asp:Label ID="Label_protocol" runat="server" CssClass="PageTitle" Text="بروتوكولات / اتفاقيات" /></center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="grd_View_Protocol" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                    Font-Size="17px" GridLines="Vertical">
                                    <Columns>
                                     <asp:TemplateField HeaderText="الاسم" >
                                            <ItemTemplate>
                                                <a href='<%# "Protocol_Def.aspx?id="+ Eval("Protocol_ID")%>'>
                                                    <%# Eval("Name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="النوع">
                                            <ItemTemplate>
                                                <%# Get_Type(Eval("Type"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="تاريخ البداية" DataField="Signt_Str_DT" />
                                        <asp:BoundField HeaderText=" تاريخ النهاية" DataField="Signt_End_DT" />
                                        <asp:BoundField HeaderText=" الميزانية الكلية" DataField="Total_Balance" />
                                        <asp:BoundField HeaderText="الندة" DataField="Period" />
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
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
