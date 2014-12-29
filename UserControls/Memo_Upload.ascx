<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Memo_Upload.ascx.cs" Inherits="UserControls_Memo_Upload" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
 <table style="width: 100%">
 
<%--  <tr>
        <td>
            <asp:Label ID="Label30" runat="server" CssClass="Label" Text="القطاع :" />
        </td>
        <td colspan="2">
            <uc1:Smart_Search ID="smart_Search_sector" runat="server" />
        </td>
        
 </tr>--%>
 
 <tr>
            <td style="width: 227px">
                <asp:Label ID="lbl_logo" runat="server" CssClass="Label" Text="تحميل ملف الوثيقة  :  "></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="SiteUploadlogo" runat="server" Width="280px" Style="margin-right: 4px"  />
             
            </td>
 </tr>
<tr>
            <td>
                 <asp:Label ID="Label1" runat="server" CssClass="Label" Text="عنوان الوثيقة  :  "></asp:Label>
  
            </td>
            <td>
                <asp:TextBox ID="txt_name" runat="server" TextMode="MultiLine" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="req_adress" runat="server" ControlToValidate="txt_name" ValidationGroup="A"  ErrorMessage="*"  Text="*">
                
                </asp:RequiredFieldValidator>
            </td>
 </tr>
     
 <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="A"
                    OnClick="btnSave_Click" Height="41px" />
            </td>
</tr>

  <tr>
        <td colspan="2">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                onrowcommand="gvMain_RowCommand" GridLines="Vertical" >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText=" عنوان الوثيقة" DataField="File_Title" />
                   
                 
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center"></PagerStyle>
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>

 </table>
