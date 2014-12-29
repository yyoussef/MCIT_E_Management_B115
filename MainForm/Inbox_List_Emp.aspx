<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Inbox_List_Emp.aspx.cs" Inherits="WebForms2_Inbox_List_Emp" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="proj_id" runat="server" type="hidden" />
            <table width="100%" style="line-height: 2;" align="center">
                <tr>
                    <td align="center" class="GridTd">
                        <table style="width: 100%" id="tbl_grd" runat="server" visible="false">
                            <tr>
                                <td align="left" colspan="2" dir="rtl" valign="top">
                                    <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/WebForms2/Default.aspx?return=1"
                                        runat="server" Height="39px" ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 39px" rowspan="1">
                                    <asp:Label ID="lblMain" runat="server" Text="قائمة المشروعات الجارية" CssClass="PageTitle"
                                        Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        AllowPaging="true" AllowSorting="true" Width="99%" BackColor="White" ForeColor="Black"
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" OnRowCommand="gvMain_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" 
                                        AlternatingRowStyle-CssClass="alt" 
                                        onpageindexchanging="gvMain_PageIndexChanging" GridLines="Vertical">
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
                                                    <asp:TextBox TextMode="MultiLine"  ReadOnly="true" Width="350px" runat="server"
                                                        ID="txt1" Text='<%# Eval("Subject")%>' Height="70px"></asp:TextBox>
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" المشروع ">
                                                <ItemTemplate>
                                                
                                                    <%# Eval("proj_title")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="عرض">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="show_inbox_Details" runat="server"
                                                        ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("inbox_id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                    <asp:GridView ID="gv_com" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        AllowPaging="true" AllowSorting="true" Width="99%" BackColor="White" ForeColor="Black"
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" OnRowCommand="gv_com_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" 
                                        AlternatingRowStyle-CssClass="alt" 
                                        onpageindexchanging="gv_com_PageIndexChanging">
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
                                          
                                           
                                            <asp:TemplateField HeaderText="  الموضوع ">
                                                <ItemTemplate>
                                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                        ID="txt1" Text='<%# Eval("Subject")%>' ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="عرض">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="show_com_Details" runat="server"
                                                        ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                     <asp:GridView ID="gv_Review" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        AllowPaging="true" AllowSorting="true" Width="99%" BackColor="White" ForeColor="Black"
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" OnRowCommand="gv_Review_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="gv_Review_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" رقم القيد ">
                                                <ItemTemplate>
                                                   
                                                    <%# Eval("incombination")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" التاريخ ">
                                                <ItemTemplate>
                                                    <%# Eval("Date")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                          
                                            <asp:TemplateField HeaderText="  الموضوع ">
                                                <ItemTemplate>
                                                    <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="350px" runat="server"
                                                        ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="عرض">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="show_Review_Details" runat="server"
                                                        ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                        <AlternatingRowStyle CssClass="alt" />
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

