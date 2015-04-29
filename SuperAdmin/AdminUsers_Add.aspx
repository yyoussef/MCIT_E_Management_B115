<%@ Page Language="C#" MasterPageFile="~/Masters/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="AdminUsers_Add.aspx.cs" Inherits="SuperAdmin_Foundations" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="lbl_found" runat="server" CssClass="Label" Text="مديري النظام "></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
            <input id="adminuser_id" type="hidden" runat="server" />
        </td>
    </tr>
    
    
       <tr>
        <td style="width: 198px">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم الجهة   :  "></asp:Label>
        </td>
        <td>
         <asp:DropDownList ID="ddl_Foundation" runat="server" AutoPostBack="true" CssClass="drop" 
         OnSelectedIndexChanged="ddl_Foundation_SelectedIndexChanged" Width="290">
         
         </asp:DropDownList>
        </td>
    </tr>
    
    
    <tr>
        <td style="width: 198px">
            <asp:Label ID="lbl_UserName" runat="server" CssClass="Label" Text="اسم المستخدم  :  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBox_UserName" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBox_UserName"
                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال اسم المستخدم"></asp:RequiredFieldValidator>
        </td>
    </tr>
    
       <tr>
        <td style="width: 198px">
            <asp:Label ID="lbl_login" runat="server" CssClass="Label" Text="اسم الدخول  :  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_loginname" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_loginname"
                runat="server" Text="*" ValidationGroup="B" ErrorMessage="يجب ادخال اسم الدخول"></asp:RequiredFieldValidator>
        </td>
    </tr>
    
      <tr>
            <td style="width: 198px">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" تفعيل الحساب  :  "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chk_account" runat="server"   />
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
        <td colspan="2">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_RowCommand"
                GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText=" اسم المستخدم" DataField="Name" />
                    <asp:BoundField HeaderText=" اسم الدخول" DataField="User_name" />
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("ID") %>'
                                CommandName="Show" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("ID") %>'  OnClientClick="javascript:return confirm('هل أنت متأكد من الحذف')" />
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

