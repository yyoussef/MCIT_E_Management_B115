<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Project_Details.aspx.vb" Inherits="MainForm_Project_Details" Title="تفاصيل المشروع" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc1" %>
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
   
    </script>

    <input id="PDOC_id1" runat="server" type="hidden" />
    <table width="100%" cellpadding="5px">
        <tr>
            <td width="100%" align="left" dir="rtl" colspan="4">
                <asp:ImageButton ID="ImgBtnBack" runat="server" Height="37px" ImageUrl="~/Images/backIcon.png"
                    Width="37px" AlternateText="الصفحة الرئيسية" />
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="5px">
        <%--<tr align="right" dir="rtl" style="height: 30px">
            <td colspan="2"  align="center" dir="rtl">
                <asp:Label ID="lblPgTitle" runat="server" Visible="false" CssClass="PageTitle"></asp:Label> 
            </td>
       </tr>--%>
        <tr align="right" dir="rtl" style="height: 30px">
            <%--<td width="45px" align="right" dir="ltr" style="padding: 0px">
                    <asp:ImageButton ID="ImgBtnPrev" runat="server" Height="37px" ImageUrl="~/Images/go-prev.png"
                        Width="45px" AlternateText="المشروع السابق" ImageAlign="Right" />
              </td>--%>
            <td align="right" dir="rtl">
                <asp:HyperLink runat="server" ID="hypPrev" Width="200px" Font-Bold="True" Font-Names="Arial"
                    Font-Size="16px" Font-Underline="False" ForeColor="Blue" Height="20px" Visible="False"></asp:HyperLink>
            </td>
            <td align="left" dir="ltr">
                <asp:HyperLink runat="server" ID="hypNext" Width="200px" Font-Bold="True" Font-Italic="False"
                    Font-Names="Arial" Font-Size="16px" Font-Underline="False" ForeColor="Blue" Height="20px"
                    Visible="False"></asp:HyperLink>
            </td>
            <%-- <td width="37px" align="right" dir="ltr" style="padding: 0px">
                    <asp:ImageButton ID="ImgBtnnext" runat="server" Height="37px" ImageUrl="~/Images/go-next.png"
                        Width="45px" AlternateText="المشروع التالى" ImageAlign="Left"  />
                </td>--%>
        </tr>
    </table>
    <table width="100%" cellpadding="5px">
        <tr align="right" dir="rtl">
            <td colspan="1" align="center" style="height: 39px" rowspan="1">
                <asp:Label runat="server" ID="Label1" Visible="true" Text="تفاصيل المشروع" CssClass="PageTitle"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                            <img border="0" id="image0" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                            ملخص المشروع
                        </td>
                    </tr>
                </table>
            </td>
            <%-- <td width="5%" bgcolor="#E6F3FF">
                <asp:ImageButton ID="imgBreifPrinter" src="../Images/Printer-1.jpg" Height="50px"
                    Width="50px" runat="server" OnClick="imgBreifPrinter_Click" />
            </td>--%>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div0" style="display: block">
                    <table style="line-height: 2; width: 96%" align="left">
                        <tr>
                            <td align="right" dir="rtl" colspan="1">
                                <asp:TextBox ID="txtProjDesc" runat="server" CssClass="Text" BorderStyle="None" Height="170px"
                                    Width="100%" TextMode="MultiLine" ReadOnly="True" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr bgcolor="#E6F3FF" id="tr_doc_header" runat="server">
            <td valign="top" align="right" width="95%">
                <table cellpadding="0" cellspacing="0" style="height: 50px; width: 100%;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                            <img border="0" id="image1" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                            وثائق المشروع
                        </td>
                    </tr>
                </table>
            </td>
            <%--<td width="5%" bgcolor="#E6F3FF">
                <asp:ImageButton ID="Imagedocument" src="../Images/Printer-1.jpg" Height="50px" Width="50px"
                    runat="server" OnClick="Imagedocument_Click" />
            </td>--%>
        </tr>
        <tr id="tr_documents" runat="server">
            <td align="right" colspan="2">
                <div id="div1" style="display: none">
                    <table id="Docs" style="line-height: 2; width: 97%" align="left">
                        <%--  <tr>
                            <td colspan="2" class="Text">
                                <asp:GridView ID="GView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="6px" HeaderStyle-Width="6px" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="3px"></HeaderStyle>
                                            <ItemStyle Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم الوثيقة" HeaderStyle-Width="500px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="500px">
                                            <ItemTemplate>
                                                <input id="PDOC_id1" runat="server" type="hidden" value='<%# Eval("File_ID") %>' />
                                                <a href='<%# "ALL_Document_Details.aspx?type=deprtfile&id=" & Eval("File_ID") %>'>
                                                    <%#Eval("File_name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2" class="Text" valign="top">
                                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                    dir="rtl" align="right">
                                    <asp:TreeView ID="Tree_Files" ShowCheckBoxes="None" ExpandDepth="FullyExpand" runat="server"
                                        ImageSet="Simple" Font-Bold="True" ForeColor="Black" Height="187px">
                                        <NodeStyle ForeColor="#808080" Font-Bold="true" Font-Size="Medium" />
                                        <SelectedNodeStyle BackColor="#C2DDF0" Font-Bold="true" Font-Underline="true" Font-Size="20px"
                                            Font-Italic="true" ForeColor="Gray" />
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id="tblTeam" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divteam','image2');">
                            <img border="0" id="image2" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divteam','image2');">
                            فريق المشروع
                        </td>
                    </tr>
                </table>
            </td>
          
        </tr>
        <tr>
            <td align="right" colspan="2" >
                <div id="divteam" style="display: none">
                    <table id="Table1" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                    HorizontalAlign="Center">
                                    <RowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="3px"></HeaderStyle>
                                            <ItemStyle Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="فئة الوظيفــه" DataField="rol_Desc" ControlStyle-Font-Bold="true"
                                            ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80"
                                            ItemStyle-Wrap="true">
                                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الاســـــم" DataField="pmp_name" ControlStyle-Font-Bold="true"
                                            ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200">
                                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الوظيفة بالمشروع" DataField="JTIT_Desc" ControlStyle-Font-Size="Large"
                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الدور" DataField="PTem_Task" ControlStyle-Font-Bold="true"
                                            ItemStyle-Width="100" ControlStyle-Font-Size="Large" HeaderStyle-HorizontalAlign="Center">
                                            <ControlStyle Font-Bold="True" Font-Size="Large"></ControlStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblobjs" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3');">
                            <img border="0" id="image3" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','image3');">
                            أهداف المشروع
                        </td>
                    </tr>
                </table>
            </td>
          
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div3" style="display: none">
                    <table id="objectives" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" # ">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="الهــــــــــدف" DataField="pobj_desc" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tpatt" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div9','Img3');">
                            <img border="0" id="Img3" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div9','Img3');">
                            الموقف التنفيذي للمشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div9" style="display: none">
                    <table id="Attitudes" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="الموقف التنفيذي " DataField="last_attitude_desc" />
                                        <asp:BoundField HeaderText="تاريخ الموقف التنفيذي" DataField="last_attitude_date" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tpstages" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div13','Img4');">
                            <img border="0" id="Img4" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div13','Img4');">
                            مراحل المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div13" style="display: none">
                    <table id="Table3" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="المرحلة" DataField="proj_stage" />
                                        <asp:BoundField HeaderText="المخرجات" DataField="proj_stage_output" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tplsuccess" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div15','Img6');">
                            <img border="0" id="Img6" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div15','Img6');">
                            عناصر نجاح المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div15" style="display: none">
                    <table id="Table5" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" HeaderText="م"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="عنصر النجاح" DataField="succ_elm_desc" />
                                        <asp:BoundField HeaderText="اسلوب التعامل" DataField="style_deal" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblneeds" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','image4');">
                            <img border="0" id="image4" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div4','image4');">
                            احتياجات المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div4" style="display: none">
                    <table id="needs" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView2" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    ForeColor="Black" PagerStyle-CssClass="pgr" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="NMT_Desc" HeaderText="نوع الاحتياج الرئيسى" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NST_Desc" HeaderText="نوع الاحتياج الفرعى" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PNed_Name" HeaderText="اسم البنــــد" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Availble_Item" HeaderText="اسم الصنف" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PNed_InitValue" HeaderText="القيمه التقديريه للوحدة" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="75px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PNed_Number" HeaderText="المطلوب" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="المصدق" DataField="approved_amount" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Availble_Amount" HeaderText="المتاح" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="50px" ItemStyle-ForeColor="Green">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PNed_Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="مطلوب توفيره قبل"
                                            HeaderStyle-Width="100px" />
                                        <asp:BoundField DataField="Availble_Amount_Date" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderText="تاريخ الإتاحة" HeaderStyle-Width="100px" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblneedsreceive" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','image7');">
                            <img border="0" id="image7" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div7','image7');">
                            صرف احتياجات المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div7" style="display: none">
                    <table id="recieve" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="6" dir="rtl">
                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:BoundField HeaderText="إحتياج رئيسى" DataField="NMT_Desc" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="إحتياج فرعى" DataField="NST_Desc" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="البند" DataField="PNed_Name" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الكميه المطلوبة" DataField="PNed_Number" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الكميه المنصرفة" DataField="recieved_amount" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="الباقى" DataField="remain" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="تاريخ الصرف" DataField="recieved_amount_date" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderStyle-Width="100px" />
                                        <asp:BoundField HeaderText="الجهه المستلمه" DataField="recieve_organization" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblactiv" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div8','image8');">
                            <img border="0" id="image8" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div8','image8');">
                            عرض مجمل بأنشطة المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div8" style="display: none">
                    <table id="activities" style="line-height: 2; width: 97%" align="left">
                        <tr style="background: orange">
                            <td align="center">
                                <asp:Label ID="lbl1" Text="نسبة انجاز المشروع :" runat="server" ForeColor="Red" Font-Bold="true"
                                    Font-Size="Large"></asp:Label>
                                <asp:Label ID="lblProgProgress" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="Text" dir="rtl">
                                <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    ForeColor="Black" PagerStyle-CssClass="pgr" Visible="true" Font-Size="10pt" Font-Strikeout="False"
                                    Font-Underline="False" CaptionAlign="Top">
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#Eval("Parent_Actv_Num")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="parent" HeaderText="النشاط الرئيسى" HeaderStyle-Width="180px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                                            <HeaderStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Desc" HeaderText=" النشاط الفرعى" HeaderStyle-Width="200px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                            <HeaderStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Start_Date" HeaderText="تاريخ البدايه" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                                            <HeaderStyle Width="75px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_End_Date" HeaderText="تاريخ الانتهاء" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                                            <HeaderStyle Width="75px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Period" HeaderText="المـده" HeaderStyle-Width="50px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                            <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Actual_Start_Date" HeaderText="تاريخ البدايه الفعلى"
                                            DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="75px">
                                            <HeaderStyle Width="75px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Actual_End_Date" HeaderText="تاريخ الانتهاء الفعلى"
                                            DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="75px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="75px">
                                            <HeaderStyle Width="75px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="الوزن النسبى" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="txtWeight" runat="server" Width="20px" Text='<%#Eval("PActv_wieght")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLevel" runat="server" Visible="false" Width="50px" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                                <uc1:ProgressBar ID="SubPB" runat="server" MainValue='<%# Eval("PActv_Progress") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PActv_Implementing_person" HeaderText="مسئول التنفيذ"
                                            HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <%--<asp:TemplateField HeaderText="تعديل" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                     <input id="pactv_id" runat="server" type="hidden" value='<%# Eval("PActv_ID") %>' />
                                        <asp:ImageButton ID="ImgBtnEditChild" runat="server" CommandArgument='<%# Eval("PActv_ID") %>'
                                            ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEditChild_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="25px" />
                                </asp:TemplateField>--%>
                                        <%-- <asp:TemplateField HeaderText="حذف" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDeleteChild" runat="server" CommandArgument='<%# Eval("PActv_ID") %>'
                                                ImageUrl="../Images/delete.gif" Style="height: 22px" OnClick="ImgBtnDeleteChild_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblind" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img1');">
                            <img border="0" id="Img1" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div5','Img1');">
                            مؤشرات قياس الأنشطة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div5" style="display: none">
                    <table id="indicators" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" dir="rtl">
                                <asp:GridView ID="GridView3" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    ForeColor="Black" PagerStyle-CssClass="pgr" Visible="true" Font-Size="10pt" Font-Strikeout="False"
                                    Font-Underline="False" CaptionAlign="Top">
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLevel" runat="server" Visible="false" Width="50px" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                                <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Width="50px" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                                <%#Eval("Parent_Actv_Num")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="3px" />
                                            <ItemStyle HorizontalAlign="Center" Width="3px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="parent" HeaderText="النشاط الرئيسى" HeaderStyle-Width="180px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                                            <HeaderStyle Width="180px" />
                                            <ItemStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PActv_Desc" HeaderText=" النشاط الفرعى" HeaderStyle-Width="200px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAI_Desc" HeaderText="اسم المؤشر" HeaderStyle-Width="180px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px">
                                            <HeaderStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IndT_Desc" HeaderText="نوع المؤشر" HeaderStyle-Width="80px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAI_Unit" HeaderText="وحدة القياس" HeaderStyle-Width="100px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAI_attainment_value" HeaderText="القيمة" HeaderStyle-Width="80px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="period_desc" HeaderText="دورية القياس" HeaderStyle-Width="80px"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblProjInd" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','Img2');">
                            <img border="0" id="Img2" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div6','Img2');">
                            مؤشرات قياس المشروع
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div6" style="display: none">
                    <table id="Table2" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" dir="rtl">
                                <asp:GridView ID="GridView4" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                    ForeColor="Black" PagerStyle-CssClass="pgr" Visible="true" Font-Size="10pt" Font-Strikeout="False"
                                    Font-Underline="False" CaptionAlign="Top">
                                    <Columns>
                                    
                                        <asp:BoundField DataField="PAI_Desc" HeaderText="اسم المؤشر" HeaderStyle-Width="50%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50%">
                                            <HeaderStyle Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="indicator_type" HeaderText="نوع المؤشر" HeaderStyle-Width="10%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAI_Unit" HeaderText="وحدة القياس" HeaderStyle-Width="20%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                            <HeaderStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAI_attainment_value" HeaderText="القيمة" HeaderStyle-Width="10%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="indicator_period" HeaderText="دورية القياس" HeaderStyle-Width="10%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <HeaderStyle Width="10%" />
                                        </asp:BoundField>
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblconsts" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div10','image10');">
                            <img border="0" id="image10" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div10','image10');">
                            معوقات المشروع
                        </td>
                    </tr>
                </table>
            </td>
            <%-- <td width="5%" bgcolor="#E6F3FF">
                <asp:ImageButton ID="imgprojcons" src="../Images/Printer-1.jpg" Height="50px" Width="50px"
                    runat="server" OnClick="imgprojcons_Click" />
            </td>--%>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div10" style="display: none">
                    <table id="constrains" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text" colspan="2">
                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <%-- <asp:BoundField HeaderText=" النشاط الرئيسى" DataField="parent" />--%>
                                        <asp:BoundField HeaderText="اسم النشاط " DataField="PActv_Desc" HeaderStyle-Width="45%"
                                            ItemStyle-Width="45%" ItemStyle-Wrap="true" />
                                        <asp:BoundField HeaderText="وصف المعوق" DataField="PCONS_DESC" HeaderStyle-Width="25%"
                                            ItemStyle-Width="25%" ItemStyle-Wrap="true" />
                                        <asp:BoundField HeaderText="مقترح لمواجهة المعوق" DataField="PCONS_Sugg_Solutions"
                                            HeaderStyle-Width="25%" ItemStyle-Width="25%" ItemStyle-Wrap="true" />
                                        <asp:TemplateField HeaderText="تدخل ادارة عليا" HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="tblorgs" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div11','image11');">
                            <img border="0" id="image11" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div11','image11');">
                            الجهات المستفيدة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div11" style="display: none">
                    <table id="organizations" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:BoundField HeaderText="الجهة" DataField="Org_Desc" />
                                        <asp:BoundField HeaderText="مسئول الاتصـــال" DataField="Contact_person" />
                                        <asp:BoundField HeaderText="هاتــــف" DataField="phone" />
                                        <asp:BoundField HeaderText="بريد إلكترونى" DataField="Email" />
                                        <asp:BoundField HeaderText="محمــــول" DataField="mobile" />
                                        <asp:BoundField HeaderText="ملاحظات" DataField="Notes" />
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
                </div>
            </td>
        </tr>
    </table>
    <table id="texctab" width="100%" runat="server">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div14','Img5');">
                            <img border="0" id="Img5" src="../Images/collapse.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div14','Img5');">
                            الجهات المنفذة
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div14" style="display: none">
                    <table id="Table4" style="line-height: 2; width: 97%" align="left">
                        <tr>
                            <td align="center" class="Text">
                                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:BoundField HeaderText="الجهة" DataField="Org_Desc" />
                                        <asp:BoundField HeaderText="مسئول الاتصـــال" DataField="Contact_person" />
                                        <asp:BoundField HeaderText="هاتــــف" DataField="phone" />
                                        <asp:BoundField HeaderText="بريد إلكترونى" DataField="Email" />
                                        <asp:BoundField HeaderText="محمــــول" DataField="mobile" />
                                        <asp:BoundField HeaderText="ملاحظات" DataField="Notes" />
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
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" id="TableNotes">
        <tr bgcolor="#E6F3FF">
            <td valign="top" align="right" width="95%">
                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px;">
                    <tr bgcolor="#E6F3FF">
                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div12','image12');">
                            <img border="0" id="image12" src="../Images/expand.gif" />
                        </td>
                        <td style="font-size: large; color: #0C6AC8; text-decoration: underline; font-weight: bold;"
                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div12','image12');">
                            ملاحظات خاصة بالمشروع
                        </td>
                    </tr>
                </table>
            </td>
            <%--<td width="5%" bgcolor="#E6F3FF">
                <asp:ImageButton ID="imgProj_notes" src="../Images/Printer-1.jpg" Height="50px" Width="50px"
                    runat="server" OnClick="imgProj_notes_Click" />
            </td>--%>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <div id="div12" style="border-width: medium; border-color: #000000; display: block">
                    <table style="width: 100%;" align="left">
                        <tr>
                            <td class="Text">
                                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" EmptyDataText="... لا يوجد ملاحظات خاصة بهذا المشروع ..." CssClass="mGrid"
                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                    <Columns>
                                        <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ملاحظات" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                            DataField="Note_Desc" />
                                        <asp:BoundField HeaderText="تاريخ الملاحظة" DataField="Note_date" HeaderStyle-Width="50px"
                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-Font-Size="16px"
                                            ItemStyle-Font-Bold="true">
                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Width="100px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                     <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="lblnewnote" runat="server" visible="false">
                            <td style="width: 97%;" align="center">
                                <asp:Button ID="btnAddNote" runat="server" CssClass="Button" Text="أضف ملاحظة جديدة"
                                    Height="25px" Width="130px" />
                            </td>
                        </tr>
                        <tr id="newnote" runat="server" visible="false">
                            <td style="width: 97%;" align="left">
                                <asp:TextBox ID="txtEditable" runat="server" Height="56px" TextMode="MultiLine" Width="904px" />
                            </td>
                        </tr>
                        <tr id="rowsavenote" runat="server" visible="false">
                            <td style="width: 97%;" align="center">
                                <asp:Button ID="btnSaveNote" runat="server" CssClass="Button" Text="حفظ الملاحظة"
                                    Height="25px" Width="130px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id="operation" width="100%" runat="server" style="border: medium double #808000;
        margin-bottom: 2px">
        <tr>
            <td align="center" width="33.3%">
                <asp:Button ID="btnCommit" runat="server" Text="اعتماد المشروع" CssClass="Button"
                    Width="130px" />
            </td>
            <td align="center" width="33.3%">
                <asp:Button ID="btnRetry" runat="server" Text="إعادة المشروع" CssClass="Button" Width="130px" />
            </td>
            <td align="center" width="33.3%">
                <asp:Button ID="btnRefuse" runat="server" Text="رفض المشروع" CssClass="Button" Width="130px" />
            </td>
        </tr>
    </table>
    <table id="modify" width="100%">
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnEdit" runat="server" Text="تعديــل" CssClass="Button" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Content>
