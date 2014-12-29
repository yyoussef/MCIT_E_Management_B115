<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Hr_Eval_Grid.ascx.cs"
    Inherits="UserControls_Hr_Eval_Grid" %>
    <%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table width="100%" style="line-height: 2;" align="center">
   <tr>
                    <td align="left" colspan="2" dir="rtl" valign="top">
                        <asp:ImageButton ID="ImgBtnBack" PostBackUrl="~/WebForms/Default.aspx?return=1" runat="server"
                            Height="39px" ImageUrl="~/Images/backIcon.png" Width="37px" AlternateText="الصفحة الرئيسية" />
                    </td>
      </tr>
       <tr>
                    <td align="center" style="height: 39px" rowspan="1">
                        <asp:Label ID="lblMain" runat="server" Text="" CssClass="PageTitle" Visible="true" />
                    </td>
                </tr>
    <tr>
        <td align="center" class="GridTd">
            <table style="width: 100%" id="tbl_grd" runat="server" >
             
                <tr>
                 <td>
                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text=" القطاع : " />
                    </td>
                    <td>
                        <asp:DropDownList ID="Ddl_Sectors" CssClass="drop" runat="server" 
                            DataTextField="Sec_name" DataValueField="Sec_id" Width="200px" OnSelectedIndexChanged="Ddl_Sectors_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand=" select Sec_id,Sec_name from Sectors "></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" الإدارة : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="Smart_Search_Departments" runat="server" />
                    </td>
                </tr>
               
            </table>
        </td>
    </tr>
     <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="search_button" runat="server" Text="بحث"  align="center" 
                        onclick="search_button_Click" CssClass="Button"></asp:Button>
                </td>
                </tr>
               
                <tr>
                    <td>
                        <asp:GridView ID="gvMain" runat="server"  AutoGenerateColumns="False"  Width="100%" 
                BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                            BorderWidth="1px" 
                CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                            PagerStyle-CssClass="pgr" AllowPaging="True"
                AlternatingRowStyle-CssClass="alt" Font-Size="17px"   
                            OnPageIndexChanging="gvMain_PageIndexChanging" 
                            onrowcommand=" gvMain_RowCommand" CellPadding="3" GridLines="Vertical">             
                  
                            <Columns>
                            <asp:TemplateField HeaderText=" # ">
                             <ItemTemplate>
                            <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" القطاع ">
                                    <ItemTemplate>
                                        <%# Eval("Sec_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" الإدارة ">
                                    <ItemTemplate>
                                        <%# Eval("Dept_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" الموظف ">
                                    <ItemTemplate>
                                        <%# Eval("pmp_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عرض">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="show" runat="server"
                                            ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Pmp_Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                        </asp:GridView>
                    </td>
                </tr>
</table>
