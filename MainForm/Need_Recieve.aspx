<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Need_Recieve.aspx.vb" Inherits="mainform_Need_Recieve" Title="صرف إحتياجات المشروع" %>

<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">

        function Get_Value() {
            var file_Upload = document.getElementById('<%= FileUpload1.ClientID %>').value;

            var slashindex = file_Upload.lastIndexOf("\\");
            var dotindex = file_Upload.lastIndexOf(".");

            //alert(slashindex);
            var name = file_Upload.substring(slashindex + 1, dotindex);

            document.getElementById('<%= TxtDocName.ClientID %>').value = name;
            //alert('you selected the file: '+ name);
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="Mode" runat="server" type="hidden" value="new" />
            <input id="need_recieve_id" runat="server" type="hidden" />
            <input id="myRowIndex" runat="server" type="hidden" />
            <table style="line-height: 2; width: 100%;">
                <tr>
                    <td dir="rtl" align="center" style="height: 45px" colspan="2">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="False"
                            Text="صـــرف احتياجات المشـــــــــــــروع"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center" colspan="2">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 85px" colspan="1" dir="rtl">
                        <asp:Label ID="Label17" runat="server" CssClass="Label" Text="اختر المشروع"></asp:Label>
                    </td>
                    <td align="right" style="width: 164px">
                        <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
                    </td>
                </tr>
                </table>
                       <table style="line-height: 2; width: 100%;">
                <tr>
                    <td align="center" class="Text" colspan="2" dir="rtl">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            GridLines="Vertical">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="باقى المنصرف">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRemainGRD" runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                               <%-- <asp:BoundField HeaderText="الباقى" DataField="remain" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                <%-- <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <input id="need_recieve_id" runat="server" type="hidden" value='<%# Eval("need_recieve_id") %>' />
                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                            CommandArgument='<%# Eval("need_recieve_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                            OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("need_recieve_id") %>'
                                            OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%><asp:BoundField HeaderText="إحتياج رئيسى" DataField="NMT_Desc" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="إحتياج فرعى" DataField="NST_Desc" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="البند" DataField="PNed_Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="الكميه المطلوبة" DataField="PNed_Number" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="الكميه المنصرفة" DataField="recieved_amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="تاريخ الصرف" DataField="recieved_amount_date" />
                                <asp:BoundField HeaderText="الجهه المستلمه" DataField="recieve_organization" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="عرض الوثيقة">
                                    <ItemTemplate>
                                        <a href='<%# "ALL_Document_Details.aspx?type=projectrecieve&id=" & Eval("need_recieve_id")%>'>
                                            <%#Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <ItemStyle />
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
                <tr style="display:block" >
                    <td dir="rtl" align="center">
                        <table style="line-height: 2; width: 100%;" dir="rtl">
                            <tr>
                                <td>
                                    <table width="100%" dir="rtl">
                                        <tr>
                                            <td align="right" style="height: 45px; width: 134px;" colspan="1" dir="rtl">
                                                <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="الاحتياح الرئيسى :" />
                                            </td>
                                            <td align="right" colspan="3">
                                                <asp:DropDownList ID="ddlMainCat" runat="server" CssClass="drop" AutoPostBack="True"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                                <%--<asp:ImageButton ID="ImgBtnResearch1" runat="server" Height="20px" 
                                                    ImageUrl="~/Images/search.jpg" Style="height: 16px" Width="20px" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 134px; height: 45px;" colspan="1" dir="rtl">
                                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الاحتياج الفرعى : " />
                                            </td>
                                            <td align="right" colspan="3">
                                                <asp:DropDownList ID="ddlSubCat" runat="server" CssClass="drop" AutoPostBack="True"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 45px; width: 134px;" colspan="1" dir="rtl">
                                                <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" البنــــد : " />
                                            </td>
                                            <td align="right" colspan="3" style="height: 45px;">
                                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="drop" AutoPostBack="True"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 19%;">
                                                <asp:Label ID="Label16" runat="server" CssClass="Label" Text="القيمه التقديريه للوحدة : " />
                                            </td>
                                            <td align="right" style="height: 49px">
                                                <asp:Label ID="lblunitprice" runat="server" align="right" Font-Size="15pt" Font-Bold="True"
                                                    CssClass="Button" Height="30px" Width="100px" Style="vertical-align: middle"></asp:Label>
                                                &nbsp;
                                                <asp:Label ID="lblwe" runat="server" Text="  جنيه مصرى" ForeColor="Black" Style="vertical-align: bottom"></asp:Label>
                                            </td>
                                            <td align="right" dir="rtl" style="width: 155px; height: 44px;">
                                                <asp:Label ID="Label7" runat="server" CssClass="Label" Text="تاريخ طلب الاحتياج: " />
                                            </td>
                                            <td align="right" dir="rtl" style="width: 158px; height: 44px;">
                                                <asp:Label ID="lblNeedDate" runat="server" CssClass="Button" Font-Bold="True" Font-Size="15pt"
                                                    Height="30px" Width="100px" Style="vertical-align: middle" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="1" dir="rtl" style="width: 134px; height: 44px;">
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="  الكميـــــه المطلوبه : " />
                                            </td>
                                            <td align="right" colspan="1" style="width: 154px; height: 44px;">
                                                <asp:Label ID="lblamnt" runat="server" align="right" Font-Size="15pt" Font-Bold="True"
                                                    CssClass="Button" Height="30px" Width="100px" Style="vertical-align: top"></asp:Label>
                                            </td>
                                            <td align="right" dir="rtl" style="height: 49px; width: 155px;">
                                                <asp:Label ID="Label6" runat="server" CssClass="Label" Text="إجمالى الكميه المتاحه : " />
                                            </td>
                                            <td align="right" colspan="1" style="height: 49px">
                                                <asp:Label ID="lblAvailbleAmount" runat="server" Font-Size="15pt" Font-Bold="True"
                                                    CssClass="Button" Height="30px" Width="100px" Style="vertical-align: middle"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 49px; width: 134px;">
                                                <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" الكميه المصدق بها : " />
                                            </td>
                                            <td align="right" style="height: 49px">
                                                <asp:Label ID="lblApprovedAmount" runat="server" align="right" Font-Size="15pt" Font-Bold="True"
                                                    CssClass="Button" Height="30px" Width="100px" Style="vertical-align: middle"></asp:Label>
                                            </td>
                                            <td colspan="1" align="right">
                                                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="باقى المطلوب إتاحته :"
                                                    Visible="true" />
                                            </td>
                                            <td colspan="1" align="right">
                                                <asp:Label ID="lblAvailbleRemain" runat="server" Font-Size="15pt" Font-Bold="True"
                                                    CssClass="Button" Height="30px" Visible="true" Width="100px" Style="vertical-align: middle"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 50px; width: 134px;">
                                                <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" الكميه المنصرفه : " />
                                            </td>
                                            <td align="right" colspan="1" style="height: 50px">
                                                <asp:TextBox ID="txtRecievedAmount" runat="server" Width="100px" Height="30px" AutoPostBack="True"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="Filtered_txtRecievedAmount" runat="server" Enabled="True"
                                                    FilterType="Numbers" TargetControlID="txtRecievedAmount">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right" dir="rtl" style="height: 50px; width: 155px;">
                                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="تاريخ الصرف  : " />
                                            </td>
                                            <td align="right" style="height: 50px">
                                                <asp:TextBox ID="txtRecievedDate" runat="server" CssClass="Text" Width="106px" Height="30px"
                                                    AutoPostBack="True"></asp:TextBox>
                                                <cc1:CalendarExtender ID="recievedDate_CalendarExtender" runat="server" TargetControlID="txtRecievedDate"
                                                    PopupButtonID="ImageButton3" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" FilterType="Custom"
                                                    ValidChars="0987654321/\" TargetControlID="txtRecievedDate" />
                                                <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                    AlternateText="اضغط لعرض النتيجة" Height="23px" Width="23px" ToolTip="تقويم" />
                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRecievedDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" dir="rtl" style="height: 40px; width: 134px;">
                                                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="الجهه المستلمه : " />
                                            </td>
                                            <td align="right" colspan="1" style="height: 40px">
                                                <asp:TextBox ID="TxtOrg" runat="server" CssClass="Text" Width="194px"></asp:TextBox>
                                            </td>
                                            <td align="right" dir="rtl" style="height: 40px; width: 155px;">
                                                <asp:Label ID="Label12" runat="server" CssClass="Label" Text=" اسم المستلم : " />
                                            </td>
                                            <td align="right" colspan="1" style="height: 40px">
                                                <asp:TextBox ID="TxtPerson" runat="server" CssClass="Text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr align="right" dir="rtl">
                                            <td align="right" dir="rtl" style="height: 43px; width: 134px;">
                                                <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" إجمالى المنصرف : " />
                                            </td>
                                            <td style="height: 43px">
                                                <asp:Label ID="lbltotaldelivers" runat="server" CssClass="Button" Font-Bold="True"
                                                    Font-Size="15pt" Height="30px" Width="100px" Style="vertical-align: middle" />
                                            </td>
                                            <td align="right" dir="rtl" style="height: 43px; width: 155px;">
                                                <asp:Label ID="Label10" runat="server" CssClass="Label" Text="باقى صرف المتاح :" />
                                            </td>
                                            <td align="right" colspan="1" style="height: 43px">
                                                <asp:Label ID="lblremain" runat="server" Font-Size="15pt" Font-Bold="True" Style="vertical-align: middle"
                                                    CssClass="Button" Height="30px" Width="100px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr align="right" dir="rtl">
                                            <td align="right" dir="rtl" style="height: 43px; width: 134px;">
                                                <asp:Label runat="server" CssClass="Label" ID="lblName" Text="وثيقة الصرف"></asp:Label>
                                            </td>
                                            <td style="height: 43px">
                                                <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                                                    Width="264px" Height="27px" />
                                            </td>
                                            <td align="right" dir="rtl" style="height: 43px; width: 155px;">
                                                <asp:Label runat="server" CssClass="Label" ID="Label13" Text="اسم الوثيقة:"></asp:Label>
                                            </td>
                                            <td align="right" colspan="1" style="height: 43px">
                                                <asp:TextBox ID="TxtDocName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trActivities" runat="server" visible="false">
                                            <td align="right" style="width: 19%; height: 39px" valign="top">
                                                <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الانشطة المرتبطة :" />
                                            </td>
                                            <td colspan="3" align="right" dir="rtl" style="background-color: #F9fdff">
                                                <div id="divGrid" style="overflow: auto; width: 650px; height: 300px">
                                                    <asp:GridView ID="gvActivities" runat="server" AlternatingRowStyle-CssClass="alt"
                                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                                        BorderWidth="1px" Width="500px" CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                        ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" Font-Strikeout="False"
                                                         font-underline="false" CaptionAlign="Top" OnPreRender="gvSub_PreRender1" 
                                                        GridLines="Vertical">
                                                        <Columns>
                                                            <asp:BoundField DataField="PActv_Desc" HeaderText="النشاط " HeaderStyle-Width="350px"
                                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="350px">
                                                                <HeaderStyle Width="350px" />
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                HeaderText="الكمية">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtamount" runat="server" Width="75px" Text='<%#Eval("amount") %>'>
                                                                    </asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                HeaderText="المبلغ بالجنيه المصرى">
                                                                <ItemTemplate>
                                                                    <%--<asp:TextBox ID="txtLevel" runat="server" Visible="false"  Text='<%#Eval("LVL")%>'></asp:TextBox>--%>
                                                                    <%--<asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false"  Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>--%>
                                                                    <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                                                    <asp:TextBox ID="txttotal" runat="server" Width="75px" ReadOnly="true" Text='<%#Eval("total") %>'></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" />
                                                        <PagerStyle BackColor="#999999" CssClass="pgr" ForeColor="Black" 
                                                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#CCCCCC" CssClass="alt" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ"  ValidationGroup="A"/>
                                                
                                                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="Text" colspan="4" dir="rtl">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
