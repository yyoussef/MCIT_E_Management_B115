<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="Indicators_History.aspx.cs" Inherits="WebForms_Indicators_History"
    Title="قياس المؤشرات" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('collapse') != -1) {
                img.src = "../Images/expand.gif";
            }
            else {
                img.src = "../Images/collapse.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
  
    </script>

    <input id="PAIH_ID" runat="server" type="hidden" />
    <input id="PActv_id" runat="server" type="hidden" />
    <input id="Pai_ID" runat="server" type="hidden" />
    <table width="100%">
        <tr>
            <td dir="rtl" align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 29px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" width="100%" class="style14" style="height: 60px">
                <asp:RadioButtonList ID="RblIndType" runat="server" RepeatDirection="Horizontal"
                    CssClass="Label" AutoPostBack="True" Visible="true" Width="575px" OnSelectedIndexChanged="RblIndType_SelectedIndexChanged">
                    <asp:ListItem Text="مؤشرات قياس الأنشطة" Value="0" Selected="True" />
                    <asp:ListItem Text="مؤشرات قياس المشروع" Value="1" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="treeActv" runat="server">
            <td dir="rtl" align="center" colspan="2" style="height: 375px" valign="top">
                <div style="border: 1px solid #000000; overflow: scroll; height: 350px; background-color: #C2DDF0;
                    color: #000000; width: 100%;" dir="rtl" align="right">
                    <asp:TreeView ID="TreeView1" ExpandDepth="1" runat="server" ImageSet="Simple" BorderColor="Black"
                        Font-Bold="True" ForeColor="Black" Height="154px" Width="166px" Style="text-align: right"
                        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <NodeStyle ForeColor="#808080" Font-Bold="true" Font-Size="Medium" />
                        <SelectedNodeStyle BackColor="WhiteSmoke" ForeColor="Black" />
                        <ParentNodeStyle CssClass="Label" />
                    </asp:TreeView>
                </div>
            </td>
        </tr>
        <tr>
            <td width="60%">
                <table>
                    <tr>
                        <td style="width: 25%;" dir="rtl">
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="اسم المؤشر:"></asp:Label>
                        </td>
                        <td dir="rtl">
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="3" Width="250px" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" dir="rtl">
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="وحدة القياس:"></asp:Label>
                        </td>
                        <td dir="rtl">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="2" Width="250px" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" dir="rtl">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="نوع المؤشر:"></asp:Label>
                        </td>
                        <td dir="rtl">
                            <asp:DropDownList ID="ddlInd" runat="server" CssClass="ddl" Width="250"
                                DataSourceID="SqlDataSource3" DataTextField="IndT_Desc" DataValueField="IndT_id"
                                AppendDataBoundItems="True">
                                <asp:ListItem Value="0">..اختر النوع..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                SelectCommand="SELECT top 2 [IndT_id], [IndT_Desc] FROM [Indicators_Type] ">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" dir="rtl">
                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="القيمة المستهدفة:"></asp:Label>
                        </td>
                        <td dir="rtl" style="height: 33px">
                            <asp:TextBox ID="TextBox4" runat="server" Height="27px" Width="250px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                TargetControlID="TextBox4" />
                        </td>
                    </tr>
                    <tr align="right">
                        <td dir="rtl" style="width: 25%;">
                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="دورية القياس :"></asp:Label>
                        </td>
                        <td dir="rtl">
                            <asp:DropDownList ID="IndicatorPeiod" runat="server" CssClass="ddl" Width="250">
                                
                            </asp:DropDownList>
                          
                        </td>
                    </tr>
                    <tr id="trsaveind" runat="server">
                        <td colspan="2" align="center" dir="rtl">
                            <asp:Button ID="saveInd" Text="حفظ  " runat="server" CssClass="Button" OnClick="saveInd_Click" />
                            <asp:Button ID="Button1" Text="مؤشر جديد  " runat="server" CssClass="Button" OnClick="save_New_Click" />
                        </td>
                    </tr>
                    <tr id="trsaveind1" runat="server">
                        <td colspan="2" align="center" dir="rtl">
             <asp:GridView ID="GridView_Indic" runat="server" Width="100%" 
                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="3" CssClass="mGrid" 
                                ForeColor="Black" PagerStyle-CssClass="pgr" Visible="False" Font-Size="10pt"
                                Font-Strikeout="False" Font-Underline="False" 
                    CaptionAlign="Top" HorizontalAlign="Center"
                                OnRowCommand="GridView_Indic_RowCommand" GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText="م" ItemStyle-Width="4%" HeaderStyle-Width="4%" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="4%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PAI_Desc" HeaderText="اسم المؤشر" />
                                        
                                    <asp:BoundField DataField="PAI_Unit" HeaderText="وحدة القياس" />
                                        
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit0" runat="server" CommandArgument='<%# Eval("PAI_ID") %>'
                                                CommandName="EditItem" ImageUrl="../Images/Edit.jpg" />
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete0" runat="server" CommandArgument='<%# Eval("PAI_ID") %>'
                                                CommandName="RemoveItem" ImageUrl="../Images/delete.gif" Style="height: 22px"
                                                
                                                OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle Width="25px" />
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
            </td>
            <td valign="top" align="left"  width="40%">
                &nbsp;</td>
        </tr>
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%" colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                    <tr bgcolor="#E6F3FF">
                        <td width="35px" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img2');">
                            <img border="0" id="Img2" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','Img2');">
                            قياسات المؤشر
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" width="width: 100%">
                <table id="Mesuare" style="line-height: 2; width: 100%" align="left" visible="True"
                    runat="server">
                    <tr>
                        <td style="width: 15%">
                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="قيمة المؤشر:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" Height="27px" Width="300px" MaxLength=3></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredtxtAvailalbeAmnt" runat="server" FilterType="Numbers"
                                TargetControlID="TextBox6" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="جهة القياس:"></asp:Label>
                        </td>
                        <td style="height: 40px">
                            <uc1:Smart_Search ID="Smart_Search_org" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="تاريخ القياس:"></asp:Label>
                        </td>
                        <td>
                            <cc1:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" TargetControlID="TextBox5"
                                PopupButtonID="Image1" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <asp:TextBox ID="TextBox5" runat="server" Height="27px"></asp:TextBox>
                            <asp:ImageButton ID="Image1" runat="Server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            <cc1:FilteredTextBoxExtender ID="TextBox5_filtered" runat="server" FilterType="Custom"
                                ValidChars="0987654321/\" TargetControlID="TextBox5" />
                                
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                            <%--      <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                            PopupButtonID="Image1" Format="dd/MM/yyyy" >
                        </cc1:CalendarExtender>
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Width="100px" 
                            OnTextChanged="txtStartDate_TextChanged" AutoPostBack="True" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" 
                            ToolTip="تقويم" />
                         <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom" ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                    --%>
                        </td>
                    </tr>
                    <tr id="trsaveindhist" runat="server">
                        <td colspan="2" align="center">
                            <asp:Button ID="saveIndHist" Text="حفظ  " runat="server" CssClass="Button" OnClick="saveIndHist_Click"   ValidationGroup="A"/>
                            
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="Text" align="center">
                            <asp:GridView ID="gvInd" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                ForeColor="Black" PagerStyle-CssClass="pgr" Visible="False" Font-Size="10pt"
                                Font-Strikeout="False" Font-Underline="False" CaptionAlign="Top" HorizontalAlign="Center"
                                OnRowCommand="GrdView_RowCommand" GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText="م" ItemStyle-Width="4%" HeaderStyle-Width="4%" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="4%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PAIH_Value" HeaderText="قيمة المؤشر" HeaderStyle-Width="13%"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="13%" />
                                        <ItemStyle Width="13%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PAIH_Date" HeaderText="تاريخ القياس" HeaderStyle-Width="13%"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="13%" />
                                        <ItemStyle Width="13%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Org_Desc" HeaderText="جهة القياس" HeaderStyle-Width="70%"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="70%" />
                                        <ItemStyle Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <input id="PAIH_ID" runat="server" type="hidden" value='<%# Eval("PAIH_ID") %>' />
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" CommandArgument='<%# Eval("PAIH_ID") %>'
                                                CommandName="EditItem" ImageUrl="../Images/Edit.jpg" />
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" CommandArgument='<%# Eval("PAIH_ID") %>'
                                                CommandName="RemoveItem" ImageUrl="../Images/delete.gif" Style="height: 22px"
                                                OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle Width="25px" />
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
            </td>
        </tr>
    </table>
</asp:Content>
