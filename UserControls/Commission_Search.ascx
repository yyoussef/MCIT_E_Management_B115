﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commission_Search.ascx.cs"
    Inherits="UserControls_Commission_Search" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
           <h2>بحث في التكليفات </h2>
        </td>
    </tr>
   
    <%--<tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="كلمة في الكود:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="Txtcode" Width="323px"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="كلمة في الموضوع:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="Com_name_text" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
    
      <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="lbl_word_visa" runat="server" CssClass="Label" Text="كلمة في نص التكليف:" />
        </td>
        <td >
            <asp:TextBox runat="server" CssClass="Text" ID="txt_word_visa" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
    
     <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="lbl_word_notes" runat="server" CssClass="Label" Text="كلمة في الملاحظات:" />
        </td>
        <td >
            <asp:TextBox runat="server" CssClass="Text" ID="txt_word_notes" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
       <tr>
       <td>
             <asp:Label ID="lbl_emp" runat="server" CssClass="Label" Text="الموظف :" />
      </td>
       <td>
             <uc1:Smart_Search ID="Smart_Emp_ID" runat="server" />
      </td>
       
      </tr>
      
    
    
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label5" runat="server"  Text="تاريخ التكليف:" />
        </td>
        <td >
            <asp:Label ID="Label13" runat="server"  Text="من:" />
                <asp:TextBox ID="Com_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="Com_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="Com_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px" style="vertical-align: bottom;"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label111" runat="server"  Text="الى:" />
            <asp:TextBox ID="Com_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                TargetControlID="Com_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                TargetControlID="Com_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px" style="vertical-align: bottom;"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
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
                OnRowCommand="gvMain_RowCommand" 
                OnPageIndexChanging="gvMain_PageIndexChanging" GridLines="Vertical">
                <Columns>
                  
                   
                    <asp:TemplateField HeaderText=" التاريخ ">
                        <ItemTemplate>
                            <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                            <%# Eval("Date")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="تاريخ الورود" ItemStyle-Width="100">
                            <ItemTemplate>
                                <%# Eval("Date")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                   
                   
                    <asp:TemplateField HeaderText="  الموضوع ">
                        <ItemTemplate>
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Font-Size="Small" Font-Bold="true"
                                Width="350px" runat="server" ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="showItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit1" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   
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
