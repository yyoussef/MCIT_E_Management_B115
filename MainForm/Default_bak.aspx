<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Default_bak.aspx.vb" Inherits="WebForms_Default" Title=" الرئيسية" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="proj_id" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;" align="center">
                <tr>
                    <td align="center">
                        <table style="width: 100%">
                            <tr id="backMain" visible="false" runat="server">
                                <td align="left" colspan="2" dir="rtl" valign="top">
                                    <asp:ImageButton ID="ImgBtnBack" runat="server" Height="39px" ImageUrl="~/Images/backIcon.png"
                                        Width="37px" AlternateText="الصفحة الرئيسية" />
                                </td>
                            </tr>
                            <tr id="count" runat="server">
                                <td align="left" style="width: 368px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%-- <asp:LinkButton runat ="server" id="linkno" Font-Underline="True"
                                        Font-Size="20px" ForeColor="#314a62" Text="لديك عدد"></asp:LinkButton>  --%>
                                    <%--<asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد" Font-Underline="False"></asp:Label>--%>
                                    <%-- <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع جديد معتمد" Font-Underline="False"></asp:Label>--%>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text="لديك عدد" ForeColor="#275078"
                                        Font-Bold="True" Font-Size="20px">
                                        لديك عدد<asp:LinkButton ID="LBtnProj_count" runat="server" ForeColor="Red" Font-Bold="True"
                                            Font-Size="22px" Visible="true" Font-Underline="true" />
                                        <asp:LinkButton runat="server" ID="link3" Font-Size="20px" ForeColor="#275078" Font-Bold="True"
                                            CssClass="link" Text="مشروع جديد معتمد" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="Current" runat="server">
                                <td align="left" style="width: 368px">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%--<asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد"></asp:Label>--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" Font-Size="20px"
                                        ForeColor="#275078" CssClass="link" Font-Bold="true" Text="لديك عدد">
                                        <asp:LinkButton ID="LBtnCurrentProj" runat="server" CssClass="link" Font-Size="20px"
                                            Visible="true" Font-Underline="true" ForeColor="red" />
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link" Visible="true" Font-Underline="true"
                                            Text="مشروع جاري" Font-Size="20px" ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                                    <%--<asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع جاري"></asp:Label>--%>
                                    <br />
                                </td>
                            </tr>
                            <tr id="repeadted" runat="server">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%-- <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد"></asp:Label>--%>
                                    <asp:LinkButton ID="LinkR" runat="server" Font-Bold="true" ForeColor="#275078" Font-Size="20px"
                                        Text="لديك عدد">
                                        <asp:LinkButton ID="lbtnProj_repeadted" runat="server" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="Red" Visible="true" />
                                        <asp:LinkButton runat="server" ID="LinkRep" Font-Bold="true" ForeColor="#275078"
                                            Font-Size="20px" Text="مشروع مطلوب تعديله" />
                                    </asp:LinkButton>
                                    <%--<asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع مطلوب تعديله"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr id="refused" runat="server">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%-- <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد"></asp:Label>--%>
                                    <asp:LinkButton runat="server" ID="linkRefused" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true">
                                        <asp:LinkButton ID="lbtnProj_refused" runat="server" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="Red" Visible="true" />
                                        <asp:LinkButton ID="LinkRef" runat="server" Font-Underline="true" Font-Bold="true"
                                            ForeColor="#275078" Font-Size="20px" Visible="true" Text="مشروع تم رفضه" />
                                    </asp:LinkButton>
                                    <%--<asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع تم رفضه"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr id="done" runat="server">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%-- <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد"></asp:Label>--%>
                                    <asp:LinkButton runat="server" ID="Lbtdone" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true">
                                        <asp:LinkButton ID="lbtnProj_done" runat="server" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="Red" Visible="true" />
                                        <asp:LinkButton ID="Linkdone" runat="server" Font-Underline="true" Font-Bold="true"
                                            ForeColor="#275078" Font-Size="20px" Visible="true" Text="مشروع منتهى بنجاح" />
                                    </asp:LinkButton>
                                    <%--<asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع تم رفضه"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr id="canceled" runat="server">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image10" runat="server" ImageUrl="~/new_images/a1.gif" />
                                </td>
                                <td align="right">
                                    <%-- <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="لديك عدد"></asp:Label>--%>
                                    <asp:LinkButton runat="server" ID="Llbtcancel" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true">
                                        <asp:LinkButton ID="lbtnProj_cancel" runat="server" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="Red" Visible="true" />
                                        <asp:LinkButton ID="Linkcancel" runat="server" Font-Underline="true" Font-Bold="true"
                                            ForeColor="#275078" Font-Size="20px" Visible="true" Text="مشروع تم إلغائه" />
                                    </asp:LinkButton>
                                    <%--<asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="20px" 
                                        ForeColor="Blue" Text="مشروع تم رفضه"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr id="MeetingWNo" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkMeetingWithout" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=MeetingWithout">
                                        لديك عدد<asp:LinkButton ID="LinkButton7" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?show=MeetingWithout" />
                                        <asp:LinkButton ID="LinkButton8" runat="server" Text="اجتماع لم يتم ارفاق محضر الاجتماع له"
                                            Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="#275078" Visible="true"
                                            PostBackUrl="Project_statistics.aspx?show=MeetingWithout" />
                                    </asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr id="MeetingNo" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkMeeting" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Meeting">
                                        لديك عدد<asp:LinkButton ID="LinkButton4" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?show=Meeting" />
                                        <asp:LinkButton ID="LinkButton6" runat="server" Text="اجتماع" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="#275078" Visible="true" PostBackUrl="Project_statistics.aspx?show=Meeting" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="nEvents" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkEvents" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Events">
                                        لديك عدد<asp:LinkButton ID="LinkButton10" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?show=Events" />
                                        <asp:LinkButton ID="LinkButton11" runat="server" Text="حدث" Font-Bold="True" Font-Size="20px"
                                            Font-Underline="TRUE" ForeColor="#275078" Visible="true" PostBackUrl="Project_statistics.aspx?show=Events" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="TrProtocol" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkProtocol" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Protocol">
                                        لديك عدد<asp:LinkButton ID="LinkButton9" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?show=Protocol" />
                                        <asp:LinkButton ID="LinkButton12" runat="server" Text="بروتوكول أوشك على الانتهاء"
                                            Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="#275078" Visible="true"
                                            PostBackUrl="Project_statistics.aspx?show=Protocol" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="Tr_Protocol_Active" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image11" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkButton5" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Protocol">
                                        لديك عدد<asp:LinkButton ID="lnk_prot_1" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?Protocol=1" />
                                        <asp:LinkButton ID="LinkButton14" runat="server" Text="بروتوكولات / اتفاقيات جارية"
                                            Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="#275078" Visible="true"
                                            PostBackUrl="Project_statistics.aspx?show=Protocol" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                             <tr id="Tr_Protocol_Done" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image12" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkButton13" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Protocol">
                                        لديك عدد<asp:LinkButton ID="LinkButton15" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?Protocol=2" />
                                        <asp:LinkButton ID="LinkButton16" runat="server" Text="بروتوكولات / اتفاقيات منجزة"
                                            Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="#275078" Visible="true"
                                            PostBackUrl="Project_statistics.aspx?show=Protocol" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="Tr_Protocol_Stop" runat="server" visible="false">
                                <td align="left" class="style7" style="width: 368px">
                                    <asp:Image ID="Image13" runat="server" ImageUrl="~/new_images/a1.gif" Visible="true" />
                                </td>
                                <td align="right" dir="rtl">
                                    <asp:LinkButton runat="server" ID="LinkButton17" Text="لديك عدد" ForeColor="#275078"
                                        Font-Size="20px" Font-Bold="true" Visible="true" PostBackUrl="Project_statistics.aspx?show=Protocol">
                                        لديك عدد<asp:LinkButton ID="LinkButton18" runat="server" Text="" Font-Bold="True"
                                            Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true" PostBackUrl="Project_statistics.aspx?Protocol=3" />
                                        <asp:LinkButton ID="LinkButton19" runat="server" Text="بروتوكولات / اتفاقيات متوقفة"
                                            Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="#275078" Visible="true"
                                            PostBackUrl="Project_statistics.aspx?show=Protocol" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="main" runat="server">
                    <td align="center" style="height: 39px" rowspan="1">
                        <asp:Label ID="lblMain" runat="server" CssClass="PageTitle" Visible="true" />
                    </td>
                </tr>
                <tr id="Tr1" runat="server" visible="true">
                    <td align="center" class="GridTd">
                        <asp:GridView ID="gvMain" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                            CellPadding="3" CssClass="mGrid"
                            EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..." ForeColor="Black"
                            PagerStyle-CssClass="pgr" Visible="False" Width="100%" Font-Bold="True" 
                            Font-Size="Larger" BackColor="White" GridLines="Vertical">
                            <Columns>
                                <asp:BoundField DataField="Dept_name" HeaderText="الإدارة المختصة" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pmp_name" HeaderText="مدير الإدارة" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/WebForms2/Project_Details.aspx?proj_id=" & Eval("proj_id") %>'
                                            Target="_self" Text='<%# Eval("Proj_Title") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTem_Name" HeaderText="مدير المشروع" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proj_InitValue_integer" HeaderText="الميزانية" />
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
                <tr id="Tr2" runat="server" visible="false">
                    <td align="center" class="GridTd">
                        <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                            CellPadding="3" CssClass="mGrid"
                            EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..." ForeColor="Black"
                            PagerStyle-CssClass="pgr" Visible="False" Width="100%" Font-Bold="True" 
                            Font-Size="Larger" BackColor="White" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="400px">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/WebForms2/Project_Details.aspx?proj_id=" & Eval("proj_id") %>'
                                            Target="_self" Text='<%# Eval("Proj_Title") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTem_Name" HeaderText="مدير المشروع" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proj_InitValue_integer" HeaderText="الميزانية" 
                                    ItemStyle-Width="125px" >
                                    <ItemStyle Width="125px" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
