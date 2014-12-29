<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Evaluation_courses.ascx.cs"
    Inherits="UserControls_Project_Attitude" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الدورات التدريبية"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
            <input id="Course_ID" type="hidden" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="إسم الدورة التدريبية :  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_course" runat="server" Width="282px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_course"
                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال إسم الدورة التدريبية "></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="width: 198px">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="وصف الدورة التدريبية : "></asp:Label>
        </td>
       <td>
       <asp:TextBox ID="txt_course_desc" runat="server" Width="282px" TextMode="MultiLine" 
               Height="154px"></asp:TextBox>
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
            <asp:Button ID="btn_Save" runat="server" CssClass="Button" Text="حفظ" ValidationGroup="C"
                OnClick="btn_Save_Click" />
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
                    <asp:BoundField HeaderText=" إسم الدورة التدريبية" DataField="Course_Name" />
                    <asp:BoundField HeaderText="وصف الدورة التدريبية" DataField="Course_Description" />
                    <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtid" runat="server" Visible="false" Text='<%# Eval("Eval_Course_Id") %>'></asp:TextBox>
                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Eval_Course_Id") %>'
                                CommandName="Show" />
                        </ItemTemplate>
                        <HeaderStyle Width="25px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("Eval_Course_Id") %>'  OnClientClick="return confirm(&quot;هل تريد الحذف?&quot;);" />
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
