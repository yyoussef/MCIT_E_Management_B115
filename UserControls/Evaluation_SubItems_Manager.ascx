<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Evaluation_SubItems_Manager.ascx.cs"
    Inherits="UserControls_Evaluation_Sub_Items" %>
  
<div dir="ltr">
    <table style="width: 100%" dir="rtl">
      <tr>
        <td align="center" colspan="3" style="height: 70px">
            <asp:Label ID="Label4" runat="server" CssClass="PageTitle" Text="عناصر التقييم الفرعية للمديرين" />
             <asp:Label ID="Lbl_weight" runat="server" CssClass="PageTitle" Text="0" Visible="false"  />

        </td>
    </tr>
        <tr>
            <td style="width: 112px">
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="عناصر التقييم الرئيسية"
                    CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator id="ds" runat="server" ControlToValidate="ddl_Groups" InitialValue=""></asp:RequiredFieldValidator>--%>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 51px">
                <asp:Label ID="Label3" runat="server" Text="العنصر الفرعى " ForeColor="Black" Font-Bold="True"
                    Font-Size="Large" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_subitem" runat="server" Width="300px" ValidationGroup="A"></asp:TextBox>
                
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_subitem"
                runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال العنصر الفرعي  "></asp:RequiredFieldValidator>
            </td>
            <td style="height: 51px">
                
                   <input id="hid_sub_id" type="hidden" runat="server" />

                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="شرح العنصر الفرعى " ForeColor="Black"
                    Font-Bold="True" Font-Size="Large" CssClass="Label"></asp:Label>
            </td>
            <td style="width: 576px">
                <asp:TextBox ID="txt_notes" TextMode="MultiLine" Width="300px" Rows="3" runat="server" ValidationGroup="A"></asp:TextBox>
            </td>
            <td>
                <asp:HiddenField ID="HiddenField2" runat="server"  />
                &nbsp;
            </td>
        </tr>
        
          <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="الوزن " ForeColor="Black"
                    Font-Bold="True" Font-Size="Large" CssClass="Label"></asp:Label>
            </td>
            <td style="width: 576px">
                <asp:TextBox ID="txt_weight" Width="300px" Rows="3" runat="server"></asp:TextBox>
                
                 <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_weight" ValidationGroup="A"
                ErrorMessage="يجب أن يكون الوزن أقل من 100" MaximumValue="100" MinimumValue="0"
                Type="Double"></asp:RangeValidator>
                   
            </td>
            
           
         </tr>
     
    
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 576px">
                <asp:Button ID="save" runat="server" ForeColor="Black" Font-Size="Large" Text="حفظ"
                    CssClass="Button" OnClick="save_Click" ValidationGroup="A" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        
          <tr>
        <td colspan="3" align="left">
            <asp:Label ID="Label6" runat="server" Font-Size="Medium" ForeColor="Black" Text="إجمالى أوزان العناصر"
                CssClass="Label"></asp:Label>
            <asp:TextBox ID="txt_Total_Weight" Width="100px" runat="server" Font-Size="Medium" ForeColor="Black"
                Enabled="false"></asp:TextBox>
        </td>
    </tr>
    
    
        
        <tr>
            <td colspan="2">
                &nbsp;
                   <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AllowPaging="true" 
                onrowcommand="gvMain_RowCommand" GridLines="Vertical"   OnPageIndexChanging="gvMain_PageIndexChanging" >
                <Columns>
                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FK_Main_Item_Id" HeaderText=" رقم المسلسل" ControlStyle-Font-Size="X-Large" Visible="false" />
                        <asp:BoundField DataField="NAME1" HeaderText=" اسم العنصر الرئيسى" ControlStyle-Font-Size="X-Large" />
                        <asp:BoundField DataField="Name" HeaderText="اسم العنصر الفرعى" ControlStyle-Font-Size="X-Large" />
                        <asp:BoundField DataField="ToolTip" HeaderText="شرح العنصر الفرعى" ControlStyle-Font-Size="X-Large" />
                    <%--   <asp:BoundField DataField="Weight" HeaderText="الوزن" ControlStyle-Font-Size="X-Large" />--%>
                    
                     <asp:TemplateField HeaderText="وزن العنصر">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Weight" runat="server" Text='<%# Eval("Weight")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Sub_Item_Id") %>'
                                CommandName="Show" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("Sub_Item_Id") %>' />
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</div>
