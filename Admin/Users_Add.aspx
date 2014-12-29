<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true" CodeFile="Users_Add.aspx.cs" Inherits="admin_Organizations_Add" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table>
<tr>

 
        <td colspan="2" align="center" style="height: 82px">
            <asp:Label ID="lbl1" runat="server" Text="بيانات المستخدمين " Font-Size="17pt" ForeColor="Black"></asp:Label>
                        <asp:HiddenField ID="hid_user_id" runat="server" />

        </td>
    
</tr>

 <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="lbl2" runat="server" Text="إسم الموظف " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txt_empName" runat="server" CssClass="Text" Width="314px" ></asp:TextBox>
            
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_empName"
                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال إسم الموظف "></asp:RequiredFieldValidator>
        </td>
    </tr>
    
    
 <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label1" runat="server" Text="إسم المستخدم " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txt_username" runat="server" CssClass="Text" Width="314px" ></asp:TextBox>
            
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_username"
                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال إسم المستخدم "></asp:RequiredFieldValidator>
        </td>
    </tr>
    
 <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label2" runat="server" Text="كلمة المرور " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txt_password" runat="server" CssClass="Text" Width="314px"   ></asp:TextBox>
            
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_password"
                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال كلمة المرور "></asp:RequiredFieldValidator>
        </td>
    </tr>
    
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label3" runat="server" Text=" موبايل " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txt_mobile" runat="server" CssClass="Text" Width="314px" 
                MaxLength="11" ></asp:TextBox>
            
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_mobile"
                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال  الموبايل  "></asp:RequiredFieldValidator>
                
            <asp:RegularExpressionValidator  ValidationGroup="C" 
                ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="يجب إدخال ارقام فقط" ControlToValidate="txt_mobile" 
                ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label4" runat="server" Text=" البريد الالكتروني " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:TextBox ID="txt_mail" runat="server" CssClass="Text" Width="314px" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="يجب إدخال البريد الالكتروني بطريقة صحيحة" ValidationGroup="C" 
                ControlToValidate="txt_mail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            
        </td>
    </tr>
    
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label5" runat="server" Text="  الفئة " CssClass="Label"></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:DropDownList ID="ddl_cat" runat="server" CssClass="ddl" 
                onselectedindexchanged="ddl_cat_SelectedIndexChanged" AutoPostBack="true"  >
            </asp:DropDownList>
            
        </td>
    </tr>
    
    <tr>
        <td style="width: 80px; height: 71px;">
            <asp:Label ID="Label6" runat="server" Text="  الجهة " CssClass="Label" Visible="false" ></asp:Label>
        </td>
        <td style="height: 71px">
            <asp:DropDownList ID="ddl_org" runat="server" CssClass="ddl" Visible="false" AutoPostBack="true"  >
            </asp:DropDownList>
            
        </td>
    </tr>
    
    
    
   
    
    
    
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="Button" 
                 ValidationGroup="C" onclick="btnSave_Click"/>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                PageIndex="10" onrowcommand="gvMain_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText=" إسم الموظف" DataField="Emp_Name" ControlStyle-Font-Size="X-Large"/>
                    <asp:BoundField HeaderText=" إسم المستخدم" DataField="User_Name" ControlStyle-Font-Size="X-Large"/>
                    <asp:BoundField HeaderText=" البريد الالكتروني " DataField="mail" ControlStyle-Font-Size="X-Large"/>
                    <asp:BoundField HeaderText=" الموبايل " DataField="mobile" ControlStyle-Font-Size="X-Large"/>

                     <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("User_ID_PK") %>'
                                CommandName="Show" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px" Visible=false>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("User_ID_PK") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                  
                </Columns>
                <PagerStyle CssClass="pgr"></PagerStyle>
                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            </asp:GridView>
        </td>
    </tr>


</table>


</asp:Content>

