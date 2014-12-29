<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true"
    CodeFile="Vocations_Confirm.aspx.cs" Inherits="WebForms2_Vocations_Confirm" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width=100%>
<tr>
<td style="height: 65px" align=center >
<asp:Label ID="Label1" runat="server" Text="إجازات القطاع" CssClass="Label"></asp:Label>
</td>
</tr>
<tr>
<td style="height: 50px" align=center >
<asp:Label ID="lblerror" runat="server" CssClass="Label" Visible="False" 
        Font-Bold="False" Font-Size="16pt" ForeColor="#990000"></asp:Label>
</td>
</tr>
<tr>
<td >
<asp:GridView ID="GVrequests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
        CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
        ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
        Height="217px" onrowcommand="GVrequests_RowCommand" GridLines="Vertical">
        <Columns>
         <%--<asp:TemplateField HeaderText="الإدارة" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("Departments.Dept_name")%>
                </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="15%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="15%"></ItemStyle>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="الاسم" ItemStyle-Width="20%" HeaderStyle-Width="20%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("pmp_name")%>
                </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="20%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="20%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نوع الأجازة" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("vacation_title")%>
                </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="15%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="15%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="المدة باليوم" ItemStyle-Width="10%" HeaderStyle-Width="10%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("vacation_days")%>
                </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="10%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="من" ItemStyle-Width="20%" HeaderStyle-Width="20%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("start_date")%>
                </ItemTemplate>

<HeaderStyle Font-Size="Large" Width="20%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="20%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="إلى" ItemStyle-Width="20%" HeaderStyle-Width="20%"
                HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                <ItemTemplate>
                    <%# Eval("end_date")%>
                </ItemTemplate>
                

<HeaderStyle Font-Size="Large" Width="20%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="20%"></ItemStyle>
                

            </asp:TemplateField>
                       
             <asp:TemplateField HeaderText=" موافقة" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                    <input id="Voc_id" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>
                                
                              <asp:TemplateField HeaderText=" رفض" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                     <input id="VocR_id" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                                </asp:TemplateField>    
           
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
    </asp:GridView>

</td>
</tr>

<tr>
<td align=center >

    <asp:Button ID="approved" runat="server" Text="حفــــــظ" CssClass ="Button" 
        onclick="approved_Click" />

</td>
</tr>

</table>
    
</asp:Content>
