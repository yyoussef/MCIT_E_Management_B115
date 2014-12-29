<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="project_End.aspx.vb" Inherits="WebForms_project_End" Title="إنهاء المشروع" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
            function Get_Value()
            {
                var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

                var slashindex = file_Upload.lastIndexOf("\\");  
                var dotindex = file_Upload.lastIndexOf(".");

                //alert(slashindex);
                var name = file_Upload.substring(slashindex+1,dotindex);

                document.getElementById('<%= txtFileName.ClientID %>').value = name;
                //alert('you selected the file: '+ name);
            }
            
            
function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('collapse') != -1)
       { img.src = "../Images/expand.gif";
        }
    else
        {img.src = "../Images/collapse.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}
  
    </script>

    <input runat="server" id="Proj_doc_id" type="hidden" value="0" />
    <table style="line-height: 2; width: 100%;">
        <tr align="right" dir="rtl">
            <td colspan="2" align="center" style="height: 39px;" rowspan="1" dir="rtl">
                <asp:Label runat="server" ID="Label1" Visible="true" Text="إنهاء المشروع" CssClass="PageTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 29px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" dir="rtl" style="width: 144px; height: 41px;">
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="حالة الإنهاء :" Width="95px" />
            </td>
            <td style="height: 41px">
                <asp:DropDownList ID="ddlprojSit" runat="server" CssClass="Button" Width="150px"
                    Height="30px" />
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl" style="width: 165px">
                <asp:Label ID="label4" runat="server" CssClass="Label" Text="تاريخ الإنهاء : " />
            </td>
            <td align="right" colspan="1">
                <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="Image1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                    ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="Text" Width="133px" Height="30px" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                     
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" dir="rtl" style="width: 165px; height: 42px;">
                <asp:Label ID="Label27" runat="server" CssClass="Label" Text="ملاحظــــــات :" Width="95px"
                    Height="25px" />
            </td>
            <td style="height: 42px">
                <asp:TextBox ID="txtEndNote" runat="server" CssClass="Text" Width="700px" TextMode="MultiLine"
                    Height="60px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="style14">
                <asp:Button ID="saveEndProject" Text="حفظ  " runat="server" CssClass="Button"       ValidationGroup="A"/>
                
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="100%" colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image0');">
                            <img border="0" id="image0" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image0');">
                            وثيقة انهاء المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="div1" style="display: block" width="100%">
                    <table style="width: 922px">
                        <tr>
                            <td style="width: 127px">
                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="وثيقة الإنهاء:" />
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" Height="35px"
                                    ForeColor="Maroon" Width="518px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" dir="rtl" style="width: 127px">
                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Height="30px" Width="608px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="saveDoc" Text="حفظ  " runat="server" CssClass="Button" />
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="DocumentGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="85%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." 
                                    CssClass="mGrid" GridLines="Vertical">
                                    <Columns>
                                        <asp:TemplateField HeaderText="اسم الوثيقة">
                                            <ItemTemplate>
                                               
                                               <a href='<%# "ALL_Document_Details.aspx?type=projectend&id=" & Eval("End_Doc_ID")%>'>
                                               
                                                    <%#Eval("File_name")%></a>
                                                   
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                            <ItemStyle Width="80%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تعديل">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="~/Images/Edit.jpg"
                                                    Style="height: 22px;" CommandArgument='<%# Eval("End_Doc_ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                            <ItemStyle Width="18%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="حذف">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                    Style="height: 22px;" CommandArgument='<%# Eval("End_Doc_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                            <ItemStyle Width="25%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                        HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
