<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Inbox_Search.ascx.cs" Inherits="UserControls_Inbox_Search" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<input type="hidden" runat="server" id="OrgDesc" name="OrgDesc" value="--اختر الجهة--" />
<input type="hidden" runat="server" id="OrgID" name="OrgID" value="0" />

<div ng-app="SmartSearch" ng-controller="SmartSearchCtrl" ng-init="type=4;loadOrganization()">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table dir="rtl" style="line-height: 2; width: 99%;" >
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الوارد" />
        </td>
    </tr>
    <%--<tr>
        <td align="center" colspan="3" style="height: 29px">
        </td>
    </tr>--%>
    <tr id="tr_smart_proj" runat="server" visible="false">
        <td> 
            <asp:Label ID="Label443" runat="server" CssClass="Label" Text="المشروع :" />
        </td>
        <td colspan="3">
            <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
        </td>
    </tr>
        <tr>
            <td >
                <asp:Label ID="Label8" runat="server"  Text="اسم المجموعة" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True"  onselectedindexchanged="ddl_Groups_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
        </tr>

    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label9" runat="server" CssClass="Label" Text="التصنيف الرئيسي:" />
        </td>
        <td colspan="2">
           <asp:DropDownList ID="ddlMainCat" runat="server" CssClass="Button" AutoPostBack="true"
                Width="400px" onselectedindexchanged="ddlMainCat_SelectedIndexChanged" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label12" runat="server" CssClass="Label" Text="التصنيف الفرعي:" />
        </td>
        <td colspan="2">
           <asp:DropDownList ID="ddlSubCat" runat="server" CssClass="Button" AutoPostBack="true"
                Width="400px" >
            </asp:DropDownList>
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
            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="رقم صادر الجهة:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="txt_out_code" Width="323px"></asp:TextBox>
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
            <asp:Label ID="lbl_word_visa" runat="server" CssClass="Label" Text="كلمة في التأشيرة:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="txt_word_visa" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
    
     <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="lbl_word_notes" runat="server" CssClass="Label" Text="كلمة في الملاحظات:" />
        </td>
        <td colspan="2">
            <asp:TextBox runat="server" CssClass="Text" ID="txt_word_notes" Width="323px"></asp:TextBox>
        </td>
    </tr>
    
    
    
        <tr runat="server" id="tr_Related_Type">
                                <td id="Td1" runat="server">
                                    <asp:Label ID="Label14" runat="server" CssClass="Label" Text=" نوع الارتباط المباشر" />
                                    <asp:TextBox runat="server" CssClass="Text" ID="txt_Name" Visible="False" Width="319px"></asp:TextBox>
                                </td>
                                <td id="Td2" runat="server">
                                    <asp:DropDownList ID="ddl_Related_Type" runat="server" CssClass="drop" Width="319px"
                                        AutoPostBack="True" >
                                        <asp:ListItem Text="....إختر نوع الارتباط ...." Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="وارد جديد" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="رد على صادر" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="استعجال وارد" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="استكمال وارد" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="وارد لصادر داخلي " Value="6"></asp:ListItem>
                                        <asp:ListItem Text="أخري.." Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
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
        <td align="right" dir="rtl" style="width: 142px">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="جهة الورود : "></asp:Label>
        </td>
        <td align="right" dir="rtl" colspan="2">
             <div id="myDiv">  
                <ui-select ng-model="organization.selected" theme="select2"  ng-disabled="disabled" style="min-width: 300px;" on-select="setHiddenWithOrg($item)">
                  <ui-select-match placeholder="{{initialSelectedOrganization}}">{{$select.selected.name}}</ui-select-match>
                  <ui-select-choices repeat="organization in organizations | propsFilter: {name: $select.search}">
                   <div ng-bind-html="organization.name | highlight: $select.search"></div>                                                                    
                    </ui-select-choices>
                    </ui-select>  
                </div>  
        </td>
    </tr>
    <tr>
       <%-- <td align="right" dir="rtl" style="width: 142px">
            <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" االادارة : "></asp:Label>
        </td>
        <td align="right" dir="rtl" colspan="2">
            <uc1:Smart_Search ID="Smart_Search_depts" runat="server" />
        </td>--%>
         <td align="right" dir="rtl" style="width: 142px">
                                    <asp:Label ID="txt_Dept_ID_Txt" runat="server" CssClass="Label" Width="293px"></asp:Label></td></tr>
    <tr>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" CssClass="Label" Text="الادارة :" />
                                            </td>
                                            <td colspan="3">
                                                <uc1:Smart_Search ID="Smart_Search_depts" runat="server" />
                                            </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الورود:" />
        </td>
        <td >
            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
              <asp:TextBox ID="Inbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="Inbox_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="Inbox_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label111" runat="server" CssClass="Label" Text="الى:" />
            <asp:TextBox ID="Inbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                TargetControlID="Inbox_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image2"
                TargetControlID="Inbox_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image2" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
        </td>
        
    </tr>
      <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="تاريخ صادر الجهة:" />
        </td>
        <td >
            <asp:Label ID="Label11" runat="server" CssClass="Label" Text="من:" />
                  <asp:TextBox ID="Outbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                TargetControlID="Outbox_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                TargetControlID="Outbox_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton1" runat="Server" AlternateText="اضغط لعرض النتيجة"
                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="الى:" />
            <asp:TextBox ID="Outbox_date_to" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                TargetControlID="Outbox_date_to" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                TargetControlID="Outbox_date_to">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="ImageButton2" runat="Server" AlternateText="اضغط لعرض النتيجة"
                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
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
                    <asp:TemplateField HeaderText=" رقم القيد ">
                        <ItemTemplate>
                            <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                            <%# Eval("incombination")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" رقم القيد ">
                        <ItemTemplate>
                            <%-- <%# Eval("Code")%>/<%# Eval("Date")%>--%>
                            <%# Eval("Code")%>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                    <asp:TemplateField HeaderText="جهة الورود">
                        <ItemTemplate>
                            <%# Eval("Org_Desc")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                        <ItemTemplate>
                            <%-- %><%# Eval("Org_Out_Box_Code")%>/<%# Eval("Org_Out_Box_DT")%>--%>
                            <%# Eval("outcombination")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" رقم صادر الجهة ">
                        <ItemTemplate>
                            <%# Eval("Org_Out_Box_Code")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" تاريخ صادر الجهة ">
                        <ItemTemplate>
                            <%# Eval("Org_Out_Box_DT")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="  الموضوع ">
                        <ItemTemplate>
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Font-Size="Small" Font-Bold="true"
                                Width="350px" runat="server" ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض">
                        <ItemTemplate>
                            <a href="<%# "Project_Inbox.aspx?ID="+Get_Encrypted_ID(Eval("ID")) %>" target="_blank"   >show</a>
                            <%--<a href="<%String.Format("Project_Inbox.aspx?ID={0}",  Get_Encrypted_ID(Eval("ID"))) %>" target="_blank"  id="lnk_newtab" runat="server"  >--%>
                            <%--<asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" 
                                CommandArgument='<%# Eval("ID") %>'   />--%>


                               

                            </a>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="عرض" Visible="false">
                        <ItemTemplate>
                         
                             <%--<a href="<%# String.Format("Project_Inbox.aspx?ID={0}",  Get_Encrypted_ID(Eval("ID"))) %>" target="_blank"  >--%>
                              <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" 
                                CommandArgument='<%# Eval("ID") %>' />
                            </a>

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
</ContentTemplate>
</asp:UpdatePanel>
</div>