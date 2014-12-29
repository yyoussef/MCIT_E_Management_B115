<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Training_userresult.ascx.cs" Inherits="UserControls_Training_userresult" %>

<style type="text/css">
    .style1
    {
        height: 36px;
    }
</style>

<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td>
            <asp:label id="label2" runat="server"  CssClass="Label" text="اسم الدوره التدريبيه :"></asp:label></td>
        <td>
            <asp:TextBox ID="txt_coursename"  runat="server" CssClass="Text" Width="270px" 
                Enabled="False" /></td>
    </tr>
    <tr>
        <td>
           <asp:label id="label3" runat="server"  CssClass="Label" text="النتيجه"/></td>
        <td>          <asp:DropDownList ID="ddl_result" runat="server" Height="22px" 
                Width="111px" AutoPostBack="true">
              <asp:ListItem Value="0">.......إختر النتيجة.......</asp:ListItem>
            <asp:ListItem Value="1">ناجح</asp:ListItem>
            <asp:ListItem Value="2">راسب</asp:ListItem>
            <asp:ListItem Value="3">معتذر</asp:ListItem>
            </asp:DropDownList>  </td>
    </tr>
    <tr runat="server" id="filerow">
        <td>
          <asp:label id="label4" runat="server"  CssClass="Label" text="الملف"/>
            </td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload></td>
    </tr>
    <tr runat="server" id="hyperlinkrow">
        <td>
            <asp:Label ID="Label5" runat="server" Text="الملف"></asp:Label>
            </td>
        <td>
            <asp:GridView ID="gv_referancefile" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CssClass="mGrid" Font-Size="17px" ForeColor="Black" 
                OnRowCommand="gv_referancefile_RowCommand" utoGenerateColumns="False" 
                Width="100%" CellPadding="3" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="الوثيقة">
                        <ItemTemplate>
                            <a href='<%# "ALL_Document_Details.aspx?type=training&category=3&id="+ Eval("id") %>'>
                                                        <%# Eval("file_name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" 
                                CommandArgument='<%#Eval("id")%>' CommandName="RemoveItem" 
                                ImageUrl="../Images/delete.gif" Style="height: 22px" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
            </asp:GridView>
        </td>
    </tr>
    <tr  runat="server" id="buttonrow" align="center">
        <td colspan="2">
           <asp:Button ID="Button1" runat="server" Text="حفظ" onclick="Button1_Click" CssClass="Button" ></asp:Button></td>
           </tr>
               
</table>
