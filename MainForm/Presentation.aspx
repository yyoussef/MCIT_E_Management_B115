<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Presentation.aspx.cs" Inherits="WebForms_Presentation" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="5px" dir="rtl" width="100%" align="center" >
        <tr align="center">
            <td align="center" colspan="2" dir="rtl">
                <asp:Label ID="LabPage" runat="server" Text="عروض تقديمية" CssClass="PageTitle"> </asp:Label>
                </td>
         </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label runat="server" ID="labDocName" Text="اسم الوثيقة" CssClass="Label "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDOCName" CssClass="Text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px; height: 45px;">
                <asp:Label runat="server" ID="Label1" Text="ملف الوثيقة" CssClass="Label"></asp:Label>
            </td>
            <td style="height: 45px">
                <asp:FileUpload ID="UploadDoc" runat="server" Font-Bold="True" ForeColor="#808080" font-underline="false"
                    Height="26px" Width="682px" />
            </td>
        </tr>
        <tr>
            <td style="width: 91px; height: 40px;">
                <asp:Label runat="server" ID="Label2" Text="تاريخ العرض" CssClass="Label"></asp:Label>
            </td>
            <td style="height: 40px">
                <asp:TextBox ID="txtDate" runat="server" CssClass="Text"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض التقويم" Height="20px" Width="20px" ToolTip="تقويم" />
            <td>
                <cc1:CalendarExtender ID="CalDate" runat="server" TargetControlID="txtDate" PopupButtonID="ImageButton1"
                    Enabled="True" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label runat="server" ID="Label3" Text="مكان العرض" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPlace" CssClass="Text" Width="260px"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                <asp:Label runat="server" ID="Label4" Text="ملاحظات" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNote" runat="server" CssClass="Text" Height="147px" 
                    TextMode="MultiLine" Width="765px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td align="center">
                <asp:Button ID="Button1" runat="server" CssClass="Button" 
                    onclick="Button1_Click" Text="حفظ" />
            </td>
        </tr>
        <
        <tr>
            <td style="width: 91px">
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="id" DataSourceID="SqlDataSource1" Height="157px" 
                    Width="719px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="ProjID" HeaderText="ProjID" 
                            SortExpression="ProjID" />
                        <asp:BoundField DataField="Document_name" HeaderText="اسم" 
                            SortExpression="Document_name" />
                        <asp:BoundField DataField="Present_date" DataFormatString="تاريخ" 
                            HeaderText="Present_date" SortExpression="Present_date" />
                        <asp:BoundField DataField="Present_location" DataFormatString="مكان" 
                            HeaderText="Present_location" SortExpression="Present_location" />
                        <asp:BoundField DataField="Notes" DataFormatString="ملاحظة" HeaderText="Notes" 
                            SortExpression="Notes" />
                        <asp:BoundField DataField="Document_name" HeaderText="اسم" 
                            SortExpression="Document_name" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MCIT_PROJECTSConnectionString %>" 
                    SelectCommand="SELECT * FROM [Presentations]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
