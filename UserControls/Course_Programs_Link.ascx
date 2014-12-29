<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Course_Programs_Link.ascx.cs" 
Inherits="UserControls_Course_Programs" %>
<style type="text/css">
    .Label
    {
        font-family: Arial;
        font-weight: bold;
        font-size: 18px;
        color: #1F4569;
        margin-left: 3px;
        text-align: right;
    }
    .Text
    {
        font-family: Arial;
        font-size: 19px;
        height: 27px;
        text-align: right;
    }
    .Button
    {
        font-family: Arial;
        font-weight: 500;
        font-size: large;
        color: #1F4569;
        background-color: #C2DDF0;
        width: 85px;
    }
</style>
<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="lbl_prog" runat="server" CssClass="Label" Text="الـــــدورات الـــــتدريبية "></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
            <input id="course_id" type="hidden" runat="server" />
        </td>
    </tr>
    
     <tr>
                      <td>
                         <asp:Label ID="lbl_programs" runat="server" CssClass="Label" Text="إسم البرنامج   :  "></asp:Label>
                      </td>
                      <td>
                      <asp:DropDownList ID="ddl_programs" runat="server" CssClass="drop" Width="200px" 
                              AutoPostBack="True" DataTextField="prog_name" 
                       DataValueField="prog_id" 
                              onselectedindexchanged="ddl_programs_SelectedIndexChanged"   ValidationGroup="A">
                       </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddl_programs"
                          runat="server" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                         </td>
       </tr>
       
       
                      
        <tr>
                         <td>
                          <asp:label id="label1" runat="server"  CssClass="Label" text="اسم الدوره التدريبييه :"></asp:label>
                          
                          </td>
                          <td>
                          <asp:TextBox ID="tx_coursename"  runat="server" CssClass="Text" 
                                  TextMode="MultiLine" Width="270px" ValidationGroup="A"></asp:TextBox>
                          
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ErrorMessage="مطلوب ادخال اسم الدوره التدريبيه" ControlToValidate="tx_coursename"  ValidationGroup="A" ></asp:RequiredFieldValidator>
                        </td>
      </tr>
 
    <tr>
        <td style="width: 198px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" 
                ValidationGroup="A" onclick="btnSave_Click"
                />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvcourses" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                GridLines="Vertical" onrowcommand="gvcourses_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText=" إسم الدورة التدريبية  " DataField="course_name" />
                 
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("course_id") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("course_id") %>'
                                CommandName="Show"  />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("course_id") %>' />
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
