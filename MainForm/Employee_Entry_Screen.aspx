<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Employee_Entry_Screen.aspx.vb" Inherits="WebForms_Employee_Entry_Screen" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
   
        
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <input id="pmp_ID" runat="server" type="hidden" />
    
    <table width="100%" style="line-height: 2; height: 248px;" dir="rtl">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text=" الموظفيـــــن" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl"  class="style3" style="width: 123px">
                <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="اســـــم المــوظف : " />
            </td>
            <td align="right">
                <asp:TextBox ID="txt_emp_name" runat="server" CssClass="Text" Height="47px" 
                    Width="524px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td dir="rtl" CssClass="Label" style="width: 123px" >
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="فئه الوظيفة : " />
            </td>
            <td align="right" >
                <asp:DropDownList ID="ddl_job_desc" runat="server"  CssClass="drop" />
            </td>
        </tr>
        <tr>
            <td dir="rtl"  style="width: 123px" class="style3">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الإدارة:" />
            </td>
            <td align="right">
                <asp:DropDownList ID="ddl_dept" runat="server" CssClass="drop" />
            </td>
        </tr>
        
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــظ" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" style="line-height: 2;">
        <tr>
            <td align="center" class="Text"  colspan="2">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    CellPadding="3" GridLines="Vertical">
                    <Columns>
                        <asp:BoundField HeaderText="الاسم" DataField="pmp_name" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الإدارة" DataField="dept_name" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="فئه الوظيفه" DataField="jtit_desc" 
                            ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="تعديل" ItemStyle-HorizontalAlign="Center">
                           <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("pmp_id") %>' />
                                   
                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click"  CommandArgument='<%# Eval("pmp_id") %>' />
                                   
                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>


                    <FooterStyle BackColor="#CCCCCC" />


<PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

<AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>


                </asp:GridView>
            </td>
        </tr>
    </table>
   
</asp:Content>
