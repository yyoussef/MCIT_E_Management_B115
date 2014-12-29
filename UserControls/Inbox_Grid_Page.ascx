<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Inbox_Grid_Page.ascx.cs"
    Inherits="UserControls_Inbox_Grid_Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <input id="proj_id" runat="server" type="hidden" />
        <table width="100%" style="line-height: 2;">
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td width="50%" align="right">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="30" AssociatedUpdatePanelID="p1">
                                    <ProgressTemplate>
                                        <div runat="server" id="div1" class="updateprogress">
                                            <table id="Table1" runat="server" style="height: 100%; width: 100%">
                                                <tr>
                                                    <td align="center">
                                                        <img alt="" src="../Images/icon-loading.gif" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="p1">
                                    <ContentTemplate>
                                        <asp:Button runat="server" CssClass="Button" Text="عرض الوارد مرتب بالتاريخ " ID="btn_show_inbox"
                                            OnClick="btn_show_inbox_Click" Width="200px" />
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="50%" align="left">
                               <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="30" AssociatedUpdatePanelID="p2">
                                    <ProgressTemplate>
                                       
                                        <div runat="server" id="div2" class="updateprogress">
                                            <table id="Table2" runat="server" style="height: 100%; width: 100%">
                                                <tr>
                                                    <td align="center">
                                                        <img alt="" src="../Images/icon-loading.gif" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                         <asp:UpdatePanel runat="server" ID="p2">
                                    <ContentTemplate>
                                        <asp:Button runat="server" CssClass="Button" Text="عرض الوارد مرتب بالموظف " ID="btn_show_emp"
                                            OnClick="btn_show_emp_Click" Width="200px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" dir="ltr" valign="top">
                    <asp:ImageButton ID="ImgBtnBack" OnClick="ImgBtnBack_Click" runat="server" Height="39px"
                        ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 39px" rowspan="1">
                    <asp:Label ID="lblMain" runat="server" CssClass="PageTitle" Visible="true" />
                </td>
            </tr>
        </table>
        <table id="emp_tb" runat="server" visible="false" width="100%" style="line-height: 2;">
            <tr>
                <td>
                    <asp:ListView ID="lv1" runat="server" OnItemDataBound="lv1_ItemDataBound">
                        <LayoutTemplate>
                            <table cellpadding="2" runat="server" id="tblEvents" style="width: 100%; height: 100%;
                                border-width: thin">
                                <tr runat="server" id="itemPlaceholder">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" ForeColor="Black" Font-Size="X-Large" runat="server" Text='<%#Eval("pmp_name") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="id" runat="server" type="hidden" value='<%#Eval("pmp_id") %>' />
                                    <asp:GridView ID="gv_in" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        AllowPaging="false" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                                        BorderColor="#999999" BorderStyle="Solid" Font-Size="Medium" BorderWidth="1px"
                                        CssClass="mGrid" PageSize="10" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        GridLines="Vertical" OnRowCommand="gv_in_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" رقم القيد ">
                                                <ItemTemplate>
                                                    <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                                    <%# Eval("incombination")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" التاريخ ">
                                                <ItemTemplate>
                                                    <%# Eval("Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="جهة الورود">
                                                <ItemTemplate>
                                                    <%# Eval("Org_Desc")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                                <ItemTemplate>
                                                    <%# Eval("outcombination")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                                                <ItemTemplate>
                                                    <%# Eval("Org_Out_Box_Code")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="  الموضوع ">
                                                <ItemTemplate>
                                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField HeaderText="عرض">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="show_inbox_Details" runat="server"
                                                        ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            
                                            
                                              <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:HyperLink   ID="hyp" CommandName="show_inbox_Details" runat="server" target="_self"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>'  NavigateUrl='<%# GetUrl(Eval("inbox_id"))%>'/>
                                                   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
        <table id="inbox_tb" runat="server" visible="false" width="100%" style="line-height: 2;"
            align="center">
            <tr>
                <td align="center" class="GridTd">
                    <table style="width: 100%" id="tbl_grd" runat="server" visible="false">
                        <tr>
                            <td align="left">
                                <asp:Button runat="server" CssClass="Button" Font-Bold="false" Text="إغلاق " ID="btn_close_inbox"
                                    OnClick="btn_close_inbox_Click" Width="40px" />
                            </td>
                        </tr>
                        <tr runat="server" id="tr_lbl_notsent">
                            <td align="center" style="height: 39px" rowspan="1">
                                <asp:Label ID="Label_not_Send" runat="server" Text=" قائمة الوارد له تأشيرة لم يتم إرسالها"
                                    CssClass="PageTitle" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMain_Not_send_Visa" Visible="false" runat="server" AutoGenerateColumns="False"
                                    CellPadding="3" AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White"
                                    ForeColor="Black" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                    EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_Not_send_Visa_RowCommand"
                                    OnPageIndexChanging="gvMain_Not_send_Visa_PageIndexChanging" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" رقم القيد ">
                                            <ItemTemplate>
                                                <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                                <%# Eval("incombination")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" التاريخ ">
                                            <ItemTemplate>
                                                <%# Eval("Date")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="جهة الورود">
                                            <ItemTemplate>
                                                <%# Eval("Org_Desc")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                            <ItemTemplate>
                                                <%# Eval("outcombination")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                                            <ItemTemplate>
                                                <%# Eval("Org_Out_Box_Code")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="  الموضوع ">
                                            <ItemTemplate>
                                                <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                    ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="ImgBtnEdit" CommandName="show_inbox_Details" runat="server"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        
                                          <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:HyperLink   ID="hyp" CommandName="show_inbox_Details" runat="server" target="_self"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>'  NavigateUrl='<%# GetUrl(Eval("inbox_id"))%>'/>
                                                   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="تم الارسال">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSent" runat="server" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="حذف">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_lbl_sent">
                            <td align="center" style="height: 39px" rowspan="1">
                                <asp:Label ID="Label_sent" runat="server" Text=" قائمة الوارد له تأشيرة تم إرسالها"
                                    CssClass="PageTitle" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnRowCommand="gvMain_RowCommand"
                                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                    OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" رقم القيد ">
                                            <ItemTemplate>
                                                <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                                                <%# Eval("incombination")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" التاريخ ">
                                            <ItemTemplate>
                                                <%# Eval("Date")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="جهة الورود">
                                            <ItemTemplate>
                                                <%# Eval("Org_Desc")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                                            <ItemTemplate>
                                                <%# Eval("outcombination")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                                            <ItemTemplate>
                                                <%# Eval("Org_Out_Box_Code")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="  الموضوع ">
                                            <ItemTemplate>
                                                <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                    ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" المشروع ">
                                            <ItemTemplate>
                                                <%# Eval("proj_title")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                      <%--   <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="show_inbox_Details" runat="server"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        
                                          <asp:TemplateField HeaderText="عرض">
                                            <ItemTemplate>
                                                <asp:HyperLink   ID="hyp" CommandName="show_inbox_Details" runat="server" target="_self"
                                                    ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>'  NavigateUrl='<%# GetUrl(Eval("inbox_id"))%>'/>
                                                   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk1" runat="server" />
                                                <asp:Label ID="lbl_inbox_id" runat="server" Text='<%# Eval("inbox_id") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
