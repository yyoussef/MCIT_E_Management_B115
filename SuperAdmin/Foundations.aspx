<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master" AutoEventWireup="true"
    CodeFile="Foundations.aspx.cs" Inherits="SuperAdmin_Foundations" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" >
        function fun1() {
            if (document.getElementById("CheckBox1").checked == true) {
                document.getElementById("panel1").visible = true;
            }
            else
                document.getElementById("panel1").visible = false;
             if (document.getElementById("CheckBox2").checked == true) {
                 document.getElementById("panel2").visible = true;
            }
            document.getElementById("panel2").visible = false;
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lbl_found" runat="server" CssClass="Label" Text="الجهات"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
            </td>
            <td>
                <input id="found_id" type="hidden" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_FoundName" runat="server" CssClass="Label" Text="اسم الجهة  :  "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_FoundName" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBox_FoundName"
                    runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال اسم الجهة"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كود الارشيف  :  "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chk_code" runat="server" />
            </td>
        </tr>
        
        <tr>
            <td>
            <asp:Label ID="Label4" runat="server"  CssClass="Label" Text="Mail"></asp:Label>
            </td>            
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" OnClick="fun1()" />            
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label5" runat="server"  CssClass="Label" Text="SMS"></asp:Label>
            </td>
            <td>
            <asp:CheckBox ID="CheckBox2" runat="server" OnClick="fun1()" />
            </td>
        </tr>
        
        <asp:Panel ID="panel1" runat="server" >
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_Port" runat="server" CssClass="Label" Text="Port :" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_Port"  runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_Host" runat="server" CssClass="Label" Text="Host :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_Host" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_UserName_mail" runat="server" CssClass="Label" Text="UserName_mail :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_UserName_mail" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_Password" runat="server" CssClass="Label" Text="Password :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_Password" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="lbl_FromAddress" runat="server" CssClass="Label" Text="FromAddress :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBox_FromAddress" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
        
        <asp:Panel ID="panel2" runat="server">
        <tr>
            <td style="width: 198px">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="SMS_Url :" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1"  runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="SMS_Enable :" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2"  runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        
         <tr>
            <td style="width: 198px">
                <asp:Label ID="Label6" runat="server" CssClass="Label" Text=" قاعدة بيانات داخلية لحفظ الملفات :  "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="Chk_islocal" runat="server"  OnCheckedChanged="Chk_islocal_CheckedChanged" AutoPostBack="true"   />
            </td>
        </tr>
            <tr visible="false" id="tr_local" runat="server" >
            <td style="width: 198px">
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="مسار قاعدة البيانات"  ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_connstring"  runat="server" Width="282px"  Height="70px" TextMode="MultiLine" Text="Data Source=...;Initial Catalog=...;Persist Security Info=True;User ID=...;Password=..."></asp:TextBox>
                
                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="برجاء ملئ مكان النقاط بالبيانات الفعلية "  ></asp:Label>
                
            </td>
        </tr>
        
        
        </asp:Panel>
        
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="B"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 52px">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_RowCommand"
                    GridLines="Vertical" onselectedindexchanged="gvMain_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText=" اسم الجهة" DataField="Foundation_Name" />
                        <asp:TemplateField HeaderText="كود الأرشيف">
                            <ItemTemplate>
                                <%# Get_Type(Eval("code_archiving"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Port">
                        <ItemTemplate>
                         <%# Eval("Port")%>
                        </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Host">
                        <ItemTemplate>
                          <%# Eval("Host")%>
                        </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Foundation_ID") %>'
                                    CommandName="Show" />
                            </ItemTemplate>
                            <HeaderStyle Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("Foundation_ID") %>'
                                    OnClientClick="javascript:return confirm('هل أنت متأكد من الحذف')" />
                            </ItemTemplate>
                            <HeaderStyle Width="25px" />
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
