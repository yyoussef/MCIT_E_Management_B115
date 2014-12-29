<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Evaluation_Dept_Weightl.ascx.cs"
    Inherits="UserControls_Evaluation_Dept_Weightl" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<table style="width: 100%" dir="rtl">
    <tr>
        <td style="width: 211px; height: 30px">
            &nbsp;
        </td>
        <td style="height: 30px; width: 301px;">
            <asp:Label ID="Lbl_Eval_item_wight" runat="server" Font-Size="Medium" ForeColor="Black"
                CssClass="Label" Text="بيانات أوزان العناصر لكل إدارة"></asp:Label>
       <asp:Label ID="Lbl_weight" runat="server" CssClass="PageTitle" Text="0" Visible="false"  />

        </td>
        <td style="height: 30px">
        </td>
    </tr>
       <tr>
       <td>
          <asp:Label ID="sectors" runat="server" Text="القطاع" CssClass="Label"></asp:Label>
       </td>
       <td>
           <asp:DropDownList ID="ddl_sectors" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
            DataTextField="Sec_name" DataValueField="Sec_id" OnSelectedIndexChanged="ddl_sectors_SelectedIndexChanged">
            </asp:DropDownList>
       </td>
        <td>
          <asp:Label ID="Label40" runat="server" CssClass="Label" Visible="false" Text=" إجمالي عدد الموظفين بالقطاع:"></asp:Label>
           <asp:Label ID="lbl_sec_count" runat="server" CssClass="Label" Visible="false"></asp:Label>
       </td>
   </tr>
    <tr>
        <td style="width: 211px">
            <asp:Label ID="Label1" runat="server" Text="الإدارة" Font-Size="Medium" ForeColor="Black"
                CssClass="Label"></asp:Label>
        </td>
        <td style="width: 301px">
            <uc1:Smart_Search ID="Smart_Search_depts" runat="server" Validation_Group="A" />
        </td>
        <td>
            <input id="hidden_id" type="hidden" runat="server" />
        </td>
    </tr>
     <tr>
        <td style="width: 211px">
            <asp:Label ID="Label6" runat="server" Font-Size="Medium" ForeColor="Black" Text="الفئه"
                CssClass="Label"></asp:Label>
        </td>
        <td style="width: 301px">
            <uc1:Smart_Search ID="Smart_search_category" runat="server" Validation_Group="A" />
        </td>
        <td>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="width: 211px; height: 42px;">
            <asp:Label ID="Label2" runat="server" Text="اسم العنصر الرئيسى" Font-Size="Medium"
                ForeColor="Black" CssClass="Label"></asp:Label>
        </td>
        <td style="height: 42px; width: 301px">
            <asp:DropDownList ID="DdlMain_Item_Name" runat="server"  OnSelectedIndexChanged="DdlMain_Item_Name_SelectedIndexChanged" 
                DataTextField="Name" DataValueField="Main_Item_Id" Height="25px" Width="148px"
                AutoPostBack="True" >
            </asp:DropDownList>
             <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="DdlMain_Item_Name"
                ErrorMessage="*" MaximumValue="100" MinimumValue="0" ValidationGroup="A"
                Type="Integer">*</asp:RangeValidator>
            
        </td>
        <td style="height: 42px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 211px; height: 27px;">
            <asp:Label ID="Label3" runat="server" Text="اسم العنصر الفرعى" Font-Size="Medium"
                CssClass="Label" ForeColor="Black"></asp:Label>
        </td>
        <td style="height: 27px; width: 301px">
            <asp:DropDownList ID="Ddl_Sub_Item_Name" runat="server" 
                DataTextField="Name" DataValueField="Sub_Item_Id" Height="25px" AutoPostBack="True"
                OnSelectedIndexChanged="Ddl_Sub_Item_Name_SelectedIndexChanged" 
                AppendDataBoundItems="True">
            </asp:DropDownList>
          <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="Ddl_Sub_Item_Name"
                ErrorMessage="*" MaximumValue="100" MinimumValue="0" ValidationGroup="A"
                Type="Integer">*</asp:RangeValidator>
        </td>
        <td style="height: 27px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 211px">
            <asp:Label ID="Label5" runat="server" Font-Size="Medium" ForeColor="Black" Text="وزن العنصر"
                CssClass="Label"></asp:Label>
        </td>
        <td style="width: 301px">
            <asp:TextBox ID="Txtwight" runat="server" Width="260px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="A" ErrorMessage="يجب ادخال اسم الدوره التدريبيه"
                                        ControlToValidate="Txtwight" Text="*">*</asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txtwight"
                ErrorMessage="من فضلك أدخل أرقام فقط" Style="z-index: 101; left: 154px; position: absolute;
                top: 360px; height: 20px; width: 182px;" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
        </td>
        <td>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Txtwight" ValidationGroup="A"
                ErrorMessage="يجب أن يكون الوزن أقل من 100" MaximumValue="100" MinimumValue="0"
                Type="Double"></asp:RangeValidator>
        </td>
    </tr>
   
    <tr>
        <td style="width: 211px">
            &nbsp;
        </td>
        <td style="width: 301px" align="center">
            <asp:Button ID="Btnsave" runat="server" OnClick="Btnsave_Click" Text="حفظ" Width="62px"  ValidationGroup="A"  CssClass="Label" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="3" align="left">
            <asp:Label ID="Label4" runat="server" Font-Size="Medium" ForeColor="Black" Text="إجمالى أوزان العناصر"
                CssClass="Label"></asp:Label>
            <asp:TextBox ID="txt_Total_Weight" Width="100px" runat="server" Font-Size="Medium" ForeColor="Black"
                Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnRowCommand="GridView1_RowCommand" Font-Size="17px" 
                OnPageIndexChanging="GridView1_PageIndexChanging" GridLines="Vertical">
                <Columns>
                    <asp:BoundField HeaderText="اسم العنصر الأساسي" DataField="Name" />
                    <asp:BoundField HeaderText="اسم العنصر الفرعي" DataField="Name1" />
                    <asp:TemplateField HeaderText="وزن العنصر">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Weight" runat="server" Text='<%# Eval("Weight")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                Style="height: 22px" CommandArgument='<%# Eval("Weight_Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                CommandArgument='<%# Eval("Weight_Id")%>' Style="height: 22px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />

<PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />

<AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            &nbsp;
        </td>
    </tr>
</table>
