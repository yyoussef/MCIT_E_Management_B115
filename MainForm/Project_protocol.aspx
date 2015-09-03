<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Project_protocol.aspx.cs" Inherits="WebForms_Project_protocol" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
var pattern = '^protocol_attend';
function Check(parentChk) 
{
    var elements =  document.getElementsByTagName("INPUT"); 
    
    for(i=0; i<elements.length;i++) 
    {
        if(parentChk.checked == true) 
        {  
            if( IsCheckBox(elements[i]) && IsMatch(elements[i].id)) 
            {
            elements[i].checked = true; 
            }         
        }
        else 
        {
            elements[i].checked = false; 
        }       
    }    
       
}
function IsCheckBox(chk) 
{
    if(chk.type == 'checkbox') return true; 
    else return false;
}

function IsMatch(id) 
{
    var regularExpresssion = new RegExp(pattern); 
    
    if(id.match(regularExpresssion)) return true; 
    else return false; 
}

</script>
        <input id="Protocol_ID" runat="server" type="hidden" value="0"  />
        <input id="mode" runat="server" type="hidden" value="new"  />
        <input id="id2" runat="server" type="hidden"  />
        <input id="id3" runat="server" type="hidden" />
            <table dir="rtl" style="line-height: 2; width: 99%;">
                <tr>
                    <td align="center" colspan="3" style="height: 33px">
                        &nbsp;<asp:Label ID="Label2" runat="server" CssClass="PageTitle" 
                            Text="البروتوكولات" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 29px">
                        <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" 
                            ForeColor="#EC981F" font-underline="false" CssClass="Label" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" 
                            Text="البروتوكول:" />
                    </td>
                    <td style="width:10px;">
                        <asp:Label ID="Label7" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label" >*</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Protocol_name" 
                            Width="321px"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td align="right" style="width: 173px; height: 42px;">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" 
                            Text="ملف البروتوكول:" Width="160px" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td  dir="rtl" align="right">
                        <asp:FileUpload ID="File_data" runat="server" CssClass="Button" Width="319px" 
                            Height="26px" />&nbsp;&nbsp;&nbsp;
                            <a href='' runat="server" id="linkFile" visible="false" class="Text">عرض</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" 
                            Text="مكان التوقيع:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="Protocol_location" 
                            Width="321px"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ التوقيع:" />
                    </td>
                     <td style="width:10px;">
                        <asp:Label ID="Label10" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label" >*</asp:Label>
                    </td>
                    <td>
                            <asp:TextBox ID="Protocol_date" runat="server" CssClass="Text" 
                                Width="297px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="Protocol_date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image1" TargetControlID="Protocol_date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Protocol_date"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                </tr>
              
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text="تاريخ الانتهاء:" />
                    </td>
                     <td style="width:10px;">
                        <asp:Label ID="Label17" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label" >*</asp:Label>
                    </td>
                    <td>
                            <asp:TextBox ID="Protocol_end_date" runat="server" CssClass="Text" 
                                Width="297px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtenddate_filtered" runat="server" FilterType="Custom"
                                TargetControlID="Protocol_end_date" ValidChars="0987654321/\" />
                            <cc1:CalendarExtender ID="txtenddate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Image11" TargetControlID="Protocol_end_date">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="Image11" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Protocol_end_date"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                        </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="حضور الوزارة:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                            <asp:ListBox ID="Protocol_attendence" runat="server" DataSourceID="SqlDataSource1" 
                                DataTextField="pmp_name" DataValueField="PMP_ID" Height="98px" 
                                SelectionMode="Multiple" Width="321px" 
                                ondatabound="Protocol_attendence_DataBound"></asp:ListBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString%>" 
                            SelectCommand="SELECT [PMP_ID], [pmp_name] FROM [EMPLOYEE]">
                        </asp:SqlDataSource>
                        </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label14" runat="server" CssClass="Label" 
                            Text="حضور من خارج الوزارة:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                        <asp:GridView ID="protocol_attend" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="67%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                OnRowCommand="GrdView_RowCommand" 
                            ondatabinding="protocol_attend_DataBinding" 
                            onrowcreated="protocol_attend_RowCreated" 
                            onrowdatabound="protocol_attend_RowDataBound" 
                            ondatabound="protocol_attend_DataBound" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="الجهة" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                    
                                 <ItemTemplate  >
                                     <asp:HiddenField ID="HiddenField1" Value='<%# Eval("attend")%>' runat="server" />
                                        <%# Eval("Org_Desc")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="الاسم" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <%# Eval("pmp_name")%>
                                        
                                     <asp:Label ID="Employee_ID" runat="server" Text='<%# Eval("PMP_ID")%>' Visible="false"></asp:Label>
                                     
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>  
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="حضور" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  > 
                                     <asp:CheckBox ID="ProductSelector"  runat="server"  />
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
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
                    <td align="right" dir="rtl" style="width: 173px; height: 35px;">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="وصف البروتوكول:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td>
                        <asp:TextBox ID="Notes" runat="server" CssClass="Text" Height="150px" 
                            TextMode="MultiLine" Width="500px"></asp:TextBox>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString%>" 
                            
                            SelectCommand="SELECT EMPLOYEE_EXT.pmp_name, Organization.Org_Desc, Organization.Org_ID FROM EMPLOYEE_EXT INNER JOIN Organization ON EMPLOYEE_EXT.Org_id = Organization.Org_ID ORDER BY Organization.Org_ID">
                        </asp:SqlDataSource>
                    </td>
                </tr>
              
                <tr>
                    <td colspan="3" align="center" style="height: 26px">
                        <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                            CssClass="Button"   ValidationGroup="A"/>
                            
                            
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            OnRowCommand="GrdView_RowCommand" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="البروتوكول" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <input id="Protocol_ID" runat="server" type="hidden" value='<%# Eval("id") %>' />
                                        <%# Eval("Protocol_name")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="ملف البروتوكول" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        <a href='<%# "ALL_Document_Details.aspx?type=Protocol&id="+ Eval("id") %>'  ><%# Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="تاريخ البروتوكول" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                      <%# Eval("Protocol_date")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="مكان البروتوكول" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                      <%# Eval("Protocol_location")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                            Style="height: 22px;" CommandArgument='<%# Eval("id") %>'  OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
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
            </table>
</asp:Content>

