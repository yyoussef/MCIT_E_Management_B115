<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="FDocuments.aspx.cs" Inherits="MainForm_FDocuments" Title="الملفات" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
 
 function Get_Value()
{
var file_Upload =  document.getElementById('<%= Upload_File_data.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex+1,dotindex);

document.getElementById('<%= TextBox3.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
 function ChangeMeCase(divid, imgid) 
{
    
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

    <input id="doc_ID" runat="server" type="hidden" value="0" />
    <input id="mode" runat="server" type="hidden" value="new" />
    <input id="File_id" runat="server" type="hidden" value="0" />
    <input id="Doc_File_id" runat="server" type="hidden" value="0" />
    <input id="id3" runat="server" type="hidden" />
    <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="2" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="ملف جديد" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 29px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="اسم الملف" />
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="Text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="التاريخ:" />
            </td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" CssClass="Text"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="Server" ImageUrl="~/images/Calendar_scheduleHS.png"
                        AlternateText="تقويم" Height="20px" Width="20px" />

                
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                  TargetControlID="txtdate" ValidChars="0987654321/\" />
                 <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdate"
                        PopupButtonID="ImageButton1" Enabled="True" Format="dd/MM/yyyy" PopupPosition="Left">
                    </cc1:CalendarExtender>
                    
                         
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdate"
                                 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="ملاحظات:" />
            </td>
            <td>
                <asp:TextBox ID="doctxt" runat="server" TextMode="MultiLine" Height="116px" Width="514px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" dir="rtl">
                <asp:Button ID="SaveButton" Text="حفظ" OnClick="SaveButton_Click" runat="server"
                    CssClass="Button"  ValidationGroup="A"/>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                     <asp:Button ID="btn_ClearFileds" runat="server" CssClass="Button" Text="جديد" 
                                             OnClick="btn_ClearFileds_Click"  Visible="false" />
                             <asp:Button ID="btn_SendToManager" runat="server" CssClass="Button" 
                                      Text="إرسال الي المدير المختص " 
                                  onclick="btn_SendToManager_Click" Width="220px" Visible="false" />
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" width="95%" colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                    <tr bgcolor="#E6F3FF" align="center">
                        <td onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img1');"
                            align="right" dir="rtl" style="width: 37px">
                            <img border="0" id="Img1" alt="" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;
                            direction: rtl" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img1');"
                            align="right" dir="rtl">
                            تحميل الوثيقة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div1" style="display: block">
                    <table id="tbDoc" runat="server" style="border-right: 1px; border-left: 1px; border-bottom: 1px;
                        border-top: 1px; line-height: 2; width: 97%" align="left" visible="true" runat="server">
                        <tr>
                            <td align="right" dir="rtl">
                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text="اسم الوثيقة" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="Text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" dir="rtl">
                                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="نوع المصدر:" />
                            </td>
                            <td dir="rtl" align="right">
                                <asp:DropDownList runat="server" ID="Source_name" CssClass="drop" Width="162px" Height="26px"
                                    >
                                    <asp:ListItem Value="0">اختر المصدر</asp:ListItem>
                                    <asp:ListItem Value="1">ماسح ضوئي</asp:ListItem>
                                    <asp:ListItem Value="2">نسخة كمبيوتر</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
        
                        <tr>
                            <td align="right" dir="rtl">
                                <asp:Label ID="Label5" runat="server" CssClass="Label" Text="ملف الوثيقة:" />
                            </td>
                            <td dir="rtl" align="right">
                                <asp:FileUpload ID="Upload_File_data" runat="server" CssClass="Button" Width="544px"
                                    Height="26px" onchange="Get_Value()" />
                            </td>
                        </tr>
                        <tr>
                            <td dir="rtl" align="center" colspan="2">
                                <asp:Button ID="SaveButnDoc" Text="حفظ الوثيقة" OnClick="SaveButnDoc_Click" runat="server"
                                    CssClass="Button" Width="107px" />
                             
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center" colspan="2" class="Text">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" CssClass="mGrid" EmptyDataText="... عفواَ لاتوجد بيانات ..."
                                    OnRowCommand="GridView1_RowCommand" Width="100%" 
                                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" 
                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                    ForeColor="Black" GridLines="Vertical" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="ملف الوثيقة " HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <a href='<%# "ALL_Document_Details.aspx?type=file&id="+ Eval("Doc_ID") %>'>
                                                    <%# Eval("Doc_name")%></a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                            <ItemStyle Width="20%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تعديل">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="~/Images/Edit.jpg"
                                                    CommandArgument='<%# Eval("Doc_ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="حذف">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                    Style="height: 22px;" CommandArgument='<%# Eval("Doc_ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="Doc_name" HeaderText="Doc_name" SortExpression="Doc_name"
                                            Visible="False" />
                                        <asp:BoundField DataField="Source_id" HeaderText="Source_id" SortExpression="Source_id"
                                            Visible="False" />
                                        <asp:BoundField DataField="Files_id" HeaderText="Files_id" SortExpression="Files_id"
                                            Visible="False" />
                                        <asp:BoundField DataField="File_date" HeaderText="File_date" SortExpression="File_date"
                                            Visible="False" />
                                        <asp:BoundField DataField="Doc_ID" HeaderText="Doc_ID" InsertVisible="False" ReadOnly="True"
                                            SortExpression="Doc_ID" Visible="False" />
                                        <asp:BoundField DataField="File_Name" HeaderText="File_Name" SortExpression="File_Name"
                                            Visible="False" />
                                        <asp:BoundField DataField="File_note" HeaderText="File_note" SortExpression="File_note"
                                            Visible="False" />--%>
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
                </div>
            </td>
        </tr>
        <%--<tr>
    <td style="width: 10px;" colspan="2">
        &nbsp;
    </td>
</tr>
<tr align="center">
    <td align="center" dir="rtl" colspan="2">
        &nbsp;</td>
    
</tr>--%>
        <tr>
            <td colspan="2" align="center" style="height: 26px">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT File_Documents.Doc_name, File_Documents.Doc_ID, File_Documents.Source_id, Files.File_Name, Files.File_note, Files.File_date, File_Documents.Files_id FROM File_Documents LEFT OUTER JOIN Files ON File_Documents.Files_id = Files.Files_id">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" class="Text" colspan="2" dir="rtl">
                <%--<asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Width="90%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" EmptyDataText="... ���� �� ���� ������ ..." CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" DataKeyNames="Files_id"
                DataSourceID="SqlDataSource2" onrowcommand="gvMain_RowCommand">
                <Columns>
                    <asp:BoundField DataField="File_Name" HeaderText="��� �����" SortExpression="File_Name" />
                    <asp:BoundField DataField="File_date" HeaderText="����� ����� " SortExpression="File_date" />
                    <asp:BoundField DataField="File_note" HeaderText="�������" SortExpression="File_note" />
            <asp:BoundField DataField="Files_id" HeaderText="Files_id" InsertVisible="False"
                ReadOnly="True" Visible="false"  SortExpression="Files_id" />
                
                <asp:TemplateField HeaderText="�����">
                    <ItemTemplate>
                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="~/Images/Edit.jpg"
                     Style="height: 22px;" CommandArgument='<%# Eval("Files_id") %>' />
                     <input id="File_id" runat="server" type="hidden" visible="false" value='<%# Eval("Files_id") %>' />                                 
            </ItemTemplate>
                    
                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                            Style="height: 22px;" CommandArgument='<%# Eval("Files_id") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pgr" />
                <AlternatingRowStyle CssClass="alt" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT [File_Name], [File_date], [File_note], [Files_id] FROM [Files]">
                    </asp:SqlDataSource>--%>
            </td>
        </tr>
    </table>
</asp:Content>
