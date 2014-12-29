<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Review_Search.ascx.cs"
    Inherits="UserControls_Review_Search" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الوارد" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 29px">
        </td>
    </tr>
   
    
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كلمة في الكود:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="Txtcode" Width="323px"></asp:TextBox>
        </td>
    </tr>
  
   
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="Inbox_name_text" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
   
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ النشرة:" />
        </td>
        <td style="width: 10px;">
            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
        </td>
        <td>
            <asp:TextBox ID="Review_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="Review_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="Review_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label111" runat="server" CssClass="Label" Text="الى:" />
            <asp:TextBox ID="Review_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                TargetControlID="Review_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                TargetControlID="Review_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
    </tr>
   
    <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" />
                &nbsb
                <%--<asp:Button ID="Button1" runat="server" Text="تصدير الي إكسل" Width="130px" CssClass="Button"
                        OnClick="Button1_Click" />--%>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" class="Text" colspan="3">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                AllowPaging="True" AllowSorting="True" Width="99%" BackColor="White" ForeColor="Black"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                OnRowCommand="gvMain_RowCommand" 
                OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText=" التاريخ ">
                        <ItemTemplate>
                            <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                            <%# Eval("Date")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" الكود ">
                        <ItemTemplate>
                            <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                            <%# Eval("Code")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                                     
                    <asp:TemplateField HeaderText="  الموضوع ">
                        <ItemTemplate>
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Font-Size="Small" Font-Bold="true"
                                Width="500px" runat="server" ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                  
                    <asp:TemplateField HeaderText="عرض" >
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
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
