<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" 

CodeFile="AssignedActivities.aspx.cs" Inherits="MainForm_AssignedActivities" Title="Untitled Page" %>
<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="line-height: 2;" align="center">
        <tr>
            <td align="left" dir="rtl" valign="top">
                <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/MainForm/Default.aspx?return=1"
                    runat="server" Height="39px" ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="GrdAssignedActivities" runat="server" AlternatingRowStyle-CssClass="alt"
                    AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد مشاريع فى الوقت الحالي ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Width="100%" Font-Bold="True" 
                     Font-Size="Larger"  OnRowCommand="GrdAssignedActivities_RowCommand" 
                     BackColor="White" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="اسم المشروع" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text='<%# Eval("Proj_Title") %>' CommandArgument='<%# Eval("Proj_id") %>'  />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="PActv_Desc" HeaderText="اسم النشاط" ItemStyle-Width="400px" />--%>
                         
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
        <tr>
            <td>
                <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Visible="False" 
                    Font-Size="10pt" Font-Strikeout="False"
                    Font-Underline="False" CaptionAlign="Top" OnPreRender="gvSub_PreRender1" 
                    GridLines="Vertical" >
                    <Columns>
                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Eval("Parent_Actv_Num")%>
                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="parent" HeaderText="النشاط الرئيسى" HeaderStyle-Width="180px"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                            <HeaderStyle Width="180px" />

<ItemStyle Width="180px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_Desc" HeaderText=" النشاط الفرعى" HeaderStyle-Width="200px"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderStyle Width="200px" />

<ItemStyle Width="200px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_Start_Date" HeaderText="تاريخ البدايه" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                            <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_End_Date" HeaderText="تاريخ الانتهاء" DataFormatString="{0:dd/MM/yyyy}"
                            HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                            <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_Period" HeaderText="المـده" HeaderStyle-Width="50px"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                            <HeaderStyle Width="50px" />

<ItemStyle Width="50px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_Actual_Start_Date" HeaderText="تاريخ البدايه الفعلى"
                            DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="75px">
                            <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PActv_Actual_End_Date" HeaderText="تاريخ الانتهاء الفعلى"
                            DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="75px">
                            <HeaderStyle Width="75px" />

<ItemStyle Width="75px"></ItemStyle>
                        </asp:BoundField>
                          <asp:BoundField DataField="PActv_wieght" HeaderText="الوزن النسبى" HeaderStyle-Width="50px"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                            <HeaderStyle Width="50px" />

<ItemStyle Width="50px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <uc2:ProgressBar ID="SubPB" runat="server" MainValue='<%# Eval("PActv_Progress") %>' />
                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="الموظف المختص" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:TextBox ID="txtLevel" runat="server" Visible="false" Width="50px" Text='<%#Eval("LVL")%>'></asp:TextBox>
                            <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                            <asp:TextBox ID="txtImplementingEmployee" runat="server" Width="200px" Height="100" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="حفظ" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <input id="RowIndex" runat="server" type="hidden"   />
                                <asp:TextBox ID="txtLevel" runat="server" Visible="false" Width="50px" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                <asp:Button ID="btnRowSave" runat="server" Text="حفظ"  CommandName='<%#Container.DataItemIndex%>'
                                CommandArgument='<%#Eval("PActv_ID")%>'  />
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
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

