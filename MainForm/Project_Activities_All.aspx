<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Project_Activities_All.aspx.vb" Inherits="WebForms_Project_Activities_All" title="Untitled Page" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="PActv_id" runat="server" type="hidden" />
    <table width="100%" style="line-height: 1.5;">
        <tr>
            <td dir="rtl" align="center" colspan="8">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                    Text="عرض مجمل لأنشطة المشــــــــــــــــروع"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:RadioButtonList ID="RblActType" runat="server" RepeatDirection="Horizontal"
                    CssClass="Label" Width="605px" AutoPostBack="True">
                    <asp:ListItem Text="عرض شبكي" Value="0" Selected="True" />
                    <asp:ListItem Text="عرض شجرة" Value="1" />
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <table id="tblGridView" runat="server" width="100%" style="line-height: 1.5;">
        <tr>
            <td align="center" class="Text" dir="rtl" colspan="2">
                <asp:GridView ID="gvMain" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Width="98%" 
                    GridLines="Vertical">
                    <Columns>
                        <asp:BoundField DataField="Parent_PActv_Desc" HeaderText=" النشاط الرئيسى" />
                        <asp:BoundField DataField="PActv_Desc" HeaderText=" النشاط الفرعي" />
                        <asp:BoundField DataField="PActv_Implementing_person" HeaderText="مسئول التنفيذ" />
                        <asp:BoundField DataField="PActv_Start_Date" HeaderText="تاريخ البدايه" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="PActv_Period" HeaderText="المــــــــده" />
                       <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <uc1:ProgressBar ID="MainPB" runat="server" MainValue='<%# Eval("PActv_wieght") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
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
    <table id="tblTreeView" runat="server" visible="false"  width="98%">
        <tr>
            <td>
                <div style="overflow: scroll; height: 350px; background-color: #C2DDF0; color: #000000;" 
                    dir="rtl">
                    <asp:TreeView ID="TreeView1" ExpandDepth="1" runat="server" ImageSet="Simple" 
                        BorderColor="Black" Font-Bold="True" ForeColor="Black" Height="154px" 
                        Width="166px">
                        <NodeStyle ForeColor="#808080" font-underline="false" Font-Bold="true" Font-Size="Medium" />
                        <SelectedNodeStyle BackColor="WhiteSmoke" ForeColor="Black" />
                        <ParentNodeStyle CssClass="Label" />
                    </asp:TreeView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


