<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Needs_Approvment.aspx.vb" Inherits="MainForm_Needs_Approvment" Title="تصديق الاحتياجات" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        function Get_Value() {
            var file_Upload = document.getElementById('<%= FileUpload1.ClientID %>').value;

            var slashindex = file_Upload.lastIndexOf("\\");
            var dotindex = file_Upload.lastIndexOf(".");

            //alert(slashindex);
            var name = file_Upload.substring(slashindex + 1, dotindex);

            document.getElementById('<%= txtFileName.ClientID %>').value = name;
            //alert('you selected the file: '+ name);
        }

  
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <br />
                <br />
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                    Text="تصديق الاحتياجات"></asp:Label>
                <asp:Label ID="count" runat="server" Visible="false"></asp:Label>
            </div>
            <table style="width: 100%; height: 386px; vertical-align: top" align="right" dir="rtl"
                cellpadding="5px">
                <tr>
                    <td dir="rtl" valign="top" align="right">
                        <table>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" CssClass="Label" Text="اختر المشروع"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblID" runat="server" Text="0" CssClass="Label" Visible="false"></asp:Label>
                                    <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
                                    <input id="doc_id" runat="server" type="hidden" value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center" valign="top" class="Text">
                        <asp:GridView ID="gvMain" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                            CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                            PagerStyle-CssClass="pgr" Width="99%" Font-Bold="False" Font-Overline="False"
                            Height="125px" BorderStyle="Solid" BorderWidth="1px" BackColor="White" 
                            BorderColor="#999999" ForeColor="Black" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3px" />
                                    <ItemStyle Width="3px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NMT_Desc" HeaderText="إحتياج رئيسى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NST_Desc" HeaderText="إحتياج فرعى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PNed_Name" HeaderText="البند" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="moneyv" HeaderText="القيمه التقديريه للوحده" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PNed_Number" HeaderText="المطلوب" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="multiply_money_integer" HeaderText="اجمالى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="المصدق" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtApprove" runat="server" Enabled="true" Text='<%# Eval("approved_amount") %>'
                                            Width="65" />
                                        <asp:Label ID="astrisk" runat="server" Visible="false" Text="*" ForeColor="red" Width="10px" />
                                        <cc1:FilteredTextBoxExtender ID="txtApproveFiltered" runat="server" FilterType="Numbers"
                                            TargetControlID="txtApprove">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ادخال وثيقة" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عرض الوثيقة">
                                    <ItemTemplate>
                                        <a href='<%# "ALL_Document_Details.aspx?type=projectneed&id=" & Eval("id")%>'>
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
                <tr>
                    <td dir="rtl" align="right">
                        <table id="tbl_doc" runat="server" visible="false">
                            <tr bgcolor="#E6F3FF" runat="server" id="TRdoc">
                                <td valign="top" align="right" width="100%">
                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                                        <tr bgcolor="#E6F3FF">
                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image0');">
                                                <img border="0" id="image0" src="../Images/expand.gif" />
                                            </td>
                                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image0');">
                                                وثيقة تصديق احتياجات المشروع
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="div1" style="display: block" width="100%">
                                        <table style="width: 922px">
                                            <tr>
                                                <td style="height: 33px">
                                                    <asp:Label ID="Label2" runat="server" Text="ملف الوثيقة" CssClass="Label"></asp:Label>
                                                </td>
                                                <td style="height: 33px">
                                                    <asp:FileUpload ID="FileUpload1" onchange="Get_Value()" runat="server" Width="380px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 127px; height: 33px;">
                                                    <asp:Label ID="Label1" runat="server" Text="اسم الوثيقة" CssClass="Label"></asp:Label>
                                                </td>
                                                <td style="height: 33px">
                                                    <asp:TextBox ID="txtFileName" runat="server" Height="27px" Width="383px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 127px">
                                                    <asp:Label ID="Label3" runat="server" Text="وصف الوثيقة" CssClass="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtDes" runat="server" Height="65px" Width="374px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="GridNeed" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                                        GridLines="Vertical">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="اسم الوثيقة">
                                                                <ItemTemplate>
                                                                    <a href='<%# "ALL_Document_Details.aspx?type=projectneed&id=" & Eval("id")%>'>
                                                                        <%#Eval("File_name")%></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="60%" />
                                                                <ItemStyle Width="60%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="تعديل">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="~/Images/Edit.jpg"
                                                                        Style="height: 22px;" CommandArgument='<%# Eval("id") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="حذف">
                                                                <ItemTemplate>
                                                                    <%-- <input id="NeedId" runat="server" type="hidden" value='<%# Eval("PNed_ID") %>' />--%>
                                                                    <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                        Style="height: 22px;" CommandArgument='<%# Eval("id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                            <tr>
                                <td align="center" style="height: 47px">
                                    <asp:Button ID="saveAll" runat="server" Text="حفــــــظ " CssClass="Button" />
                                    <asp:Button ID="UpdateDoc" runat="server" CssClass="Button" Text="تعديل الوثيقة "
                                        Visible="False" Width="101px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="saveAll" />
            <asp:PostBackTrigger ControlID="UpdateDoc" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
