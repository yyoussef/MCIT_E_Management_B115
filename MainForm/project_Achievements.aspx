<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="project_Achievements.aspx.cs" Inherits="WebForms2_project_Achievements" Title="إنجازات المشروع" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<input id="achievement_ID" runat="server" type="hidden"  />
    <table width="100%">
        <tr>
            <td colspan="2" align="center" style="height: 44px">
                <asp:Label ID="lblPagestatus" runat="server" Text="إنجازات المشروع" 
                    ForeColor="Black" Font-Size="18px" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="#EC981F" font-underline="false" Font-Size="12px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="الإنجاز :" CssClass="Label" 
                    ForeColor="Black"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAchiveDesc" runat="server" Width="600px" 
                    TextMode="MultiLine" Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style14" style="height: 22px">
                <asp:Label ID="lbltype" runat="server" CssClass="Label" Font-Bold="True">النوع :</asp:Label>
            </td>
            <td class="style14" style="height: 22px" valign="top">
                <asp:DropDownList ID="ddlAchiveTypes" runat="server" AutoPostBack="true" 
                    CssClass="Button" Width="200px" Height="29px" 
                    onselectedindexchanged="ddlAchiveTypes_SelectedIndexChanged"></asp:DropDownList>
                <asp:TextBox ID="txtOther" runat="server" Visible="false" Width="400px" 
                    Height="25px" ></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" CssClass="Label" Font-Bold="True">من تاريخ :</asp:Label>
            </td>
            <td>
                 <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="Image1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
             <td>
                 <asp:Label ID="Label3" runat="server" CssClass="Label" Font-Bold="True">الى تاريخ :</asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" />
                <asp:ImageButton ID="ImageButton3" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton3" Format="dd/MM/yyyy" />
                <cc1:FilteredTextBoxExtender ID="txtEndDate_BoxExtender1" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 88px">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="حفظ" 
                    onclick="btnSave_Click"  ValidationGroup="A"/>
                      
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
            </td>
            
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gvAchievements" runat="server" AlternatingRowStyle-CssClass="alt" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" CellPadding="3" 
                        CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="10pt" 
                        Font-Strikeout="False"  font-underline="false" ForeColor="Black" 
                        PagerStyle-CssClass="pgr"  
                    OnRowCommand="GrdView_RowCommand" onprerender="gvAchievements_PreRender" 
                    GridLines="Vertical" >
                    <Columns>
                        <asp:TemplateField HeaderText="م" HeaderStyle-Width="5px">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="الإنجاز" DataField="ach_desc" 
                            HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" 
                            ItemStyle-Font-Size="16px" ItemStyle-Font-Bold="true" 
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="500px" 
                            ItemStyle-Wrap="true">
<HeaderStyle Font-Bold="True" Font-Size="16px" Width="500px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="True" Font-Bold="True" Font-Size="16px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="من تاريخ" DataField="ach_from_date" 
                            HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" 
                            ItemStyle-Font-Size="16px" ItemStyle-Font-Bold="true" 
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" 
                            ItemStyle-Wrap="true">
<HeaderStyle Font-Bold="True" Font-Size="16px" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="True" Font-Bold="True" Font-Size="16px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="الى تاريخ" DataField="ach_to_date" 
                            HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" 
                            ItemStyle-Font-Size="16px" ItemStyle-Font-Bold="true" 
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" 
                            ItemStyle-Wrap="true">
<HeaderStyle Font-Bold="True" Font-Size="16px" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="True" Font-Bold="True" Font-Size="16px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="النوع" DataField="type_desc" 
                            HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" 
                            ItemStyle-Font-Size="16px" ItemStyle-Font-Bold="true" 
                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="150px" 
                            ItemStyle-Wrap="true">
<HeaderStyle Font-Bold="True" Font-Size="16px" Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Wrap="True" Font-Bold="True" Font-Size="16px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                           <ItemTemplate >
                                
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("ach_id") %>' CommandName="Show" />
                                    
                            </ItemTemplate>

<HeaderStyle Font-Bold="True" Font-Size="16px" Width="25px"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                            <ItemTemplate >
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px" CommandName="dlt" CommandArgument='<%# Eval("ach_id") %>' 
                                    OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                 </ItemTemplate>

<HeaderStyle Font-Bold="True" Font-Size="14px" Width="25px"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
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
        
        
    </table>
</asp:Content>

