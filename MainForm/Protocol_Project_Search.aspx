<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Protocol_Project_Search.aspx.cs" Inherits="WebForms_Protocol_Project_Search" Title="Untitled Page" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text=" اتفاقيات المشروعات " />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 29px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_emp" runat="server" Text="الاتفاقية" CssClass="Label"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="drop_agrement" runat="server" CssClass="drop" 
                    Width="794px" Height="69px" AutoPostBack="True" >
                </asp:DropDownList>
            </td>  
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="3">
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvMain_RowCommand"
                    OnPageIndexChanging="gvMain_PageIndexChanging" AllowPaging="True" 
                    GridLines="Vertical">
                    <Columns>
                    <asp:TemplateField HeaderText="المشروع" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="70px">
                    <ItemTemplate>
                                <input id="file_ID" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="300" runat="server"
                                    ID="txt2" Text='<%# Eval("Proj_Title")%>'></asp:TextBox>
                 </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" Width="35%" />
                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                    </asp:TemplateField> 
                    
                   <asp:TemplateField HeaderText="مدير المشروع" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="الإدارة" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("Dept_name")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="الميزانية" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# Eval("Value")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
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
       
        <%--<tr>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ البداية:" />
            </td>
            <td colspan="2">
                <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
                <asp:TextBox ID="prot_strt_date_from" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                    TargetControlID="prot_strt_date_from" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    PopupButtonID="Image1" TargetControlID="prot_strt_date_from">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="الى:" />
                <asp:TextBox ID="prot_strt_date_to" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    TargetControlID="prot_strt_date_to" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                    TargetControlID="prot_strt_date_to">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                    ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ النهاية:" />
            </td>
            <td colspan="2">
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
                <asp:TextBox ID="prot_end_date_from" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                    TargetControlID="prot_end_date_from" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                    TargetControlID="prot_end_date_from">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                    Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الى:" />
                <asp:TextBox ID="prot_end_date_to" runat="server" CssClass="Text"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                    TargetControlID="prot_end_date_to" ValidChars="0987654321/\" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                    TargetControlID="prot_end_date_to">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة"
                    Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            </td>
        </tr>--%>
        <%-- <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="اختر الإدارة" CssClass="Label"></asp:Label>
            </td>
            <td colspan="2">
                <uc1:Smart_Search ID="Smrt_Srch_DropDep" runat="server" />

            </td>  
        </tr>
           
             <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="اختر مدير المشروع" CssClass="Label"></asp:Label>
            </td>
            <td colspan="2">
                <uc1:Smart_Search ID="Smart_Search1" runat="server" />

            </td>  
        </tr>--%>
       </table> 
               
</asp:Content>

