<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true"
    CodeFile="Project_Activity_Count.aspx.cs" Inherits="WebForms2_Project_Activity_Count"
    Title="Untitled Page" %>
<%@ Register Src ="../UserControls/ProgressBar.ascx"  TagName="ProgressBar" TagPrefix="uc2"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="5px">
        <tr>
            <td colspan="1" dir="rtl" align="center" style="height: 68px; width: 863px;">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="الأنشطة المتأخرة"></asp:Label>
            </td>
            <td align="left" colspan="2" dir="rtl" valign="top" style="height: 68px">
                <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/WebForms2/Default.aspx?return=1"
                    runat="server" Height="39px" ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
            </td>
        </tr>
          <tr>
            <td colspan="2" dir="rtl" align="center" style="height: 79px; width: 863px;">
                <asp:Label ID="Label1" runat="server" CssClass="PageTitle" 
                    Text="ادخل معوق أو تاريخ النهاية الفعلي للأنشطة المتأخرة" ForeColor="#990000"></asp:Label>
            </td>
            </tr> 
         <tr>
            <td colspan="4" align="center">
                <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    ForeColor="Black" PagerStyle-CssClass="pgr" 
                    Font-Size="10pt" Font-Strikeout="False"
                                     font-underline="false" CaptionAlign="Top" 
                    onprerender="gvSub_PreRender1" Height="393px" 
                    onrowdatabound="gvSub_RowDataBound" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                 <%#Eval("Parent_Actv_Num")%> 
                                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="PActv_ID" Visible="false"  HeaderStyle-Width="180px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                                            <HeaderStyle Width="180px" />

<ItemStyle Width="180px"></ItemStyle>
                                        </asp:BoundField>
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
                                        <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <uc2:ProgressBar ID="SubPB" runat="server" MainValue='<%# Eval("PActv_wieght") %>' />
                                            </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PActv_Implementing_person" HeaderText="مسئول التنفيذ"
                                            HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                            <HeaderStyle Width="100px" />

<ItemStyle Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                       
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
