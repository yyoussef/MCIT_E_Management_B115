<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Database_Backup.aspx.cs" Inherits="Database_Backup" Title="اضافة ادارة" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="line-height: 2;">
        <tr>
            <td align="center">
                <asp:Label ID="lbltitle" runat="server" Font-Size="Larger" Text="نسخة من قاعدة البيانات"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="#EC981F" font-underline="false"></asp:Label>
            </td>
        </tr>
        <%-- <tr>
            <td align="center">
                <asp:Button ID="bt_DB_Backup" runat="server" Text="نسخة من قاعدة البيانات" />
            </td>
        </tr>--%>
        <tr width="100%">
            <td align="center" width="100%">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="30" AssociatedUpdatePanelID="p1">
                    <ProgressTemplate>
                        <div runat="server" id="div1" class="updateprogress">
                            <table id="Table1" runat="server" style="height: 100%; width: 100%">
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" ImageUrl="~/Images/icon-loading.gif" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel runat="server" ID="p1" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="bt_DB_Backup" runat="server" Text="نسخ قاعدة البيانات" OnClick="bt_DB_Backup_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="70%" style="line-height: 2;">
        <tr>
            <td align="center" colspan="4" style="height: 15px">
                <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="تحميل الملفات " />
            </td>
        </tr>
        <tr>
            <td align="center" width="100%">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="200"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText=" الملف" DataField="found_backupfilename" />
                        <asp:BoundField HeaderText=" التاريخ" DataField="date" />
                        <asp:TemplateField HeaderText="تحميل الملف">
                            <ItemTemplate>
                                <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("found_backupfilename") %>'></asp:TextBox>
                                <asp:TextBox ID="Textdate" runat="server" Visible="false" Text='(<%# Eval("date")).Tostring() %>'></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("found_backupfilename") %>'
                                    OnClick="ImgBtnEdit_Click" />
                                <asp:Label ID="Labelwait" runat="server" Text="جارى تحميل الملف برجاء الانتظار"></asp:Label>
                                <asp:Label ID="LabStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                    </PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
