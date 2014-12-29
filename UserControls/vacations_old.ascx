<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacations_old.ascx.cs"
    Inherits="UserControls_vacations_manager" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 144px;
    }
</style>
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                Text="الاجازات السابقة والتقارير خاصة بها"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2" class="style1">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات الأجازات" Width="95px"
                Height="25px" />
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="2">
            <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" OnRowCommand="requests_RowCommand"
                GridLines="Vertical">
                <Columns>
                     
                     
                     
                    <asp:TemplateField HeaderText="طالب الأجازة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("pmp_name")%>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="نوع الأجازة" HeaderStyle-Wrap="false" ItemStyle-Width="10%"
                        HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("vacation_title")%>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="المدة باليوم" HeaderStyle-Wrap="false" ItemStyle-Width="5%"
                        HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("no_days")%>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>
                        <ItemStyle Font-Size="Large" Width="5%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_date")%>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("end_date")%>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    
                    
                     <asp:TemplateField HeaderText="عرض تقرير الاجازة " HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                        
                            <asp:Button ID="btn_show" runat="server" CssClass="Button"  Text="عرض تقرير الاجازة"
                            
                            CommandName="dlt" CommandArgument='<%# Eval("id")+ "," + Eval("vacation_id") %>'  Width="150"  />
                  
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>
                        <ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    
                    
                    
                    
                    
                
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center" style="direction: ltr">
            <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="عودة"
                Width="110px" OnClick="BtnVacationRequest_Click" />
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="2">
            &nbsp;
        </td>
    </tr>
</table>
