<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Outbox_Search.ascx.cs"
    Inherits="UserControls_Outbox_Search" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        height: 29px;
    }
</style>

<div ng-app="SmartSearch" ng-controller="SmartSearchCtrl" ng-init="type=3;loadOrganization()">
<input type="hidden" runat="server" id="OrgDesc" name="OrgDesc" value="--Choose Organization--" />
<input type="hidden" runat="server" id="OrgID" name="OrgID" value="0" />
    <input type="hidden" runat="server" id="type" name="type" value="4" />
<table dir="rtl" style="line-height: 2; width: 99%;">
    <tr>
        <td align="center" colspan="3" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الصادر" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" class="style1">
        </td>
    </tr>
      <tr>
            <td >
                <asp:Label ID="Label8" runat="server"  Text="اسم المجموعة" CssClass="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Groups" runat="server" CssClass="ddl" Width="279px" AutoPostBack="True" onselectedindexchanged="ddl_Groups_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>

    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label112" runat="server" Text="التصنيف الرئيسي:" CssClass="Label"></asp:Label>
        </td>
        <td colspan="2">
            <asp:DropDownList ID="ddlMainCat" runat="server" Width="400px" CssClass="Button"
                AutoPostBack="True" OnSelectedIndexChanged="ddlMainCat_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label113" runat="server" Text="التصنيف الفرعي:" CssClass="Label"></asp:Label>
        </td>
        <td colspan="2">
            <asp:DropDownList ID="ddlSubCat" runat="server" Width="400px" CssClass="Button" AutoPostBack="True">
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
                AutoPostBack="True">
                <asp:ListItem Text="....إختر نوع الارتباط ...." Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="صادر جديد" Value="1"></asp:ListItem>
                <asp:ListItem Text="رد على وارد" Value="2"></asp:ListItem>
                <asp:ListItem Text="رد على تأشيرة وزير" Value="4"></asp:ListItem>
                <asp:ListItem Text="استعجال صادر" Value="3"></asp:ListItem>
                <asp:ListItem Text="أخري.." Value="5"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td id="Td3" colspan="2" runat="server">
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
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="الجهة الصادر لها : "></asp:Label>
        </td>
        <td align="right" dir="rtl" colspan="2">
            <%--<uc1:Smart_Search ID="Smrt_Srch_org" runat="server" />--%>
             <div id="myDiv">
                                                        <ui-select ng-model="organization.selected" theme="select2"  ng-disabled="disabled" style="min-width: 300px;" on-select="setHiddenWithOrg4($item)">
                                                              <ui-select-match placeholder="{{initialSelectedOrganization2}}">{{$select.selected.name}}</ui-select-match>
                                                                <ui-select-choices repeat="organization in organizations | propsFilter: {name: $select.search}">
                                                                  <div ng-bind-html="organization.name | highlight: $select.search"></div>                                                                    
                                                                </ui-select-choices>
                                                              </ui-select>  
                                                      </div>
        </td>
    </tr>
    <tr>
       <%-- <td align="right" dir="rtl" style="width: 142px">
            <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" الادارة الداخلية الصادر لها : "></asp:Label>
        </td>
        <td align="right" dir="rtl" colspan="2">
            <uc1:Smart_Search ID="Smart_Search_depts" runat="server" />
        </td>--%>
          <td>
                                            <asp:Label ID="Label6" runat="server" Text="  الادارة الصادر له :" CssClass="Label" Font-Underline="False"></asp:Label>
                                        </td>
                                     <td>
                                          <uc1:Smart_Search ID="Smart_Search_depts" runat="server"  />
                                    </td>
    </tr>
    <tr>
        <td align="right" dir="rtl" style="width: 142px; height: 35px;">
            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ الصادر:" />
        </td>
        <td>
            <asp:Label ID="Label13" runat="server" CssClass="Label" Text="من:" />
            <asp:TextBox ID="Inbox_date_from" runat="server" CssClass="Text"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                TargetControlID="Inbox_date_from" ValidChars="0987654321/\" />
            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                PopupButtonID="Image1" TargetControlID="Inbox_date_from">
            </cc1:CalendarExtender>
            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Inbox_date_from"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"> </asp:RegularExpressionValidator>
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
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Inbox_date_to"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"> </asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br />
            <div align="center">
                <asp:Button ID="SaveButton" Text="بحث" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button" ValidationGroup="A" />
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
                    <asp:TemplateField HeaderText=" الكود ">
                        <ItemTemplate>
                            <%# Eval("Code")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تاريخ الصادر" ItemStyle-Width="100">
                        <ItemTemplate>
                            <%# Eval("Date")%>
                        </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الجهة الصادر لها">
                        <ItemTemplate>
                            <%# Eval("Org_Desc")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="  الموضوع ">
                        <ItemTemplate>
                            <asp:TextBox TextMode="MultiLine" Rows="3" ReadOnly="true" Width="400px" runat="server"
                                ID="txt1" Text='<%# Eval("Subject")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit123" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("ID") %>' />
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
