<%@ Control Language="C#" AutoEventWireup="true" CodeFile="~/UserControls/Emp_Search.ascx.cs"
    Inherits="Emp_Search" %>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="بحث عن بيانات الموظفين" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
        </td>
    </tr>
    <%--  <tr>
           <td>
            <asp:Label ID="sectors" runat="server" Text="القطاع" CssClass="Label"></asp:Label>
           </td>
     <td>
         <asp:DropDownList ID="ddl_sectors" runat="server" CssClass="drop" Width="200px" AutoPostBack="True"
            DataTextField="Sec_name" DataValueField="Sec_id" OnSelectedIndexChanged="ddl_sectors_SelectedIndexChanged">
                  </asp:DropDownList>
      </td>
                                     
     </tr>--%>
         <tr>
          <td>
         <asp:Label ID="Label6" runat="server" Text="الإدارة  :" CssClass="Label"></asp:Label>
           </td>
           <td>
             <uc1:Smart_Search ID="Smart_Search_mang" runat="server" />
             </td>
            
        
           </tr>
            <tr>
           <td>
            <asp:Label ID="Label3" runat="server" Text="الرقم الوظيفي :" CssClass="Label"></asp:Label>
        </td>
           <td>
           <asp:TextBox ID="job_no_txt" CssClass="Text" runat="server"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txt_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321" TargetControlID="job_no_txt" />
           </td>
        </tr>
     
    
    <tr id="tr_smart_proj" runat="server" visible="true">
        <td>
            <asp:Label ID="Label443" runat="server" CssClass="Label" Text="كلمة في إسم الموظف  :" />
        </td>
        <td colspan="3">
            <asp:TextBox ID="txt_pmp_name" runat="server" Height="26px" CssClass="Text" Width="327px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="3">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnRowCommand="gvMain_RowCommand" OnPageIndexChanging="gvMain_PageIndexChanging"
                GridLines="Vertical">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbPmpID" runat="server" Text='<%# Eval("pmp_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%--    <asp:TemplateField HeaderText="  القطاع " HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblSecID" runat="server" Text='<%# Eval("sec_id")%>' Visible="false"></asp:Label>
                            <asp:Label ID="lblSecName" runat="server" Text='<%# Eval("Sec_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="الهيكل التنظيمي" HeaderStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("dept_id")%>' Visible="false"></asp:Label>
                            <asp:Label ID="lblDeptName" runat="server" Text='<%# Eval("Dept_name")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الاسم " HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblPmpName" runat="server" Text='<%# Eval("pmp_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    <asp:TemplateField HeaderText=" المسمى الوظيفي" HeaderStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblpmpTitle" runat="server" Text='<%# Eval("pmp_title")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الرقم الوظيفي" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lbljobNo" runat="server" Text='<%# Eval("job_no")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض" HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="Show_Details" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument= '<%# DataBinder.Eval( Container.DataItem ,"pmp_id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
        </td>
    </tr>
</table>
