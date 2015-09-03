<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Need_Available.aspx.vb" Inherits="MainForm_Need_Available" Title="إتاحة الاحتياجات" %>

<%@ Register Src="~/UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script type="text/javascript">
    function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
                img.src = "../Images/square_arrow_down.gif";
            }
            else {
                img.src = "../Images/square_arrow_flipped.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
        </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="Need_Av_Ids" runat="server" type="hidden" />
             <input id="Need_Av_Id" runat="server" type="hidden"  value="0" />
             <input id="myRowIndex1" runat="server" type="hidden" />
             <input id="myRowIndex2" runat="server" type="hidden" />
               <input id="doc_id" runat="server" type="hidden" value="0" />
              <div id="divGrid" style="overflow: auto; width: 1000px; height: 550px">
            <table style="border: 1px solid #C2DDF0">
                <tr>
                    <td dir="rtl" align="center" colspan="2">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                            Text="إتاحة الاحتياجات"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td dir="rtl" align="center" colspan="2">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 200px" dir="rtl"  >
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text="اختر المشروع : " ></asp:Label>
                         
                    </td>
                    <td align="right" style="width: 1400px" dir="rtl" >
                        <uc1:Smart_Search ID="Smart_Search_Proj" runat="server" />
                    </td>
                  
                </tr>
                <%--<tr>
                    <td align="right" style="width: 164px" colspan="1" dir="rtl">
                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" Text="الاحتياج الرئيسى   :" />
                    </td>
                    <td align="right" colspan="3">
                        <asp:DropDownList ID="ddlMainCat" runat="server" CssClass="Button" Width="700px"
                            AutoPostBack="True" Font-Bold="True">
                        </asp:DropDownList>
                        <asp:ImageButton ID="ImgBtnResearch1" runat="server" Height="20px" 
                            ImageUrl="~/Images/search.jpg" Style="height: 16px" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px" dir="rtl">
                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الاحتياج الفرعى : " />
                    </td>
                    <td align="right" colspan="3">
                        <asp:DropDownList ID="ddlSubCat" runat="server" Width="700px" CssClass="Button" AutoPostBack="True"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px" dir="rtl">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" البنــــد : " />
                    </td>
                    <td align="right" colspan="3">
                        <asp:DropDownList ID="ddlItem" runat="server" Width="700px" CssClass="Button" AutoPostBack="True"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px" dir="rtl">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="  الكميـــــه المطلوبه : " />
                    </td>
                    <td align="right" colspan="1" style="width: 379px" class="style7">
                        <asp:Label ID="lblamnt" runat="server" align="right" Font-Size="12pt" Font-Bold="True"
                            CssClass="Button" Height="25px" Width="100px"></asp:Label>
                    </td>
                    <td align="left" dir="rtl" colspan="1">
                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text="مطلوب توفيره قبل: " />
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblNeedDate" runat="server" CssClass="Button" Font-Bold="True" Font-Overline="False"
                            Font-Size="12pt" Height="25px" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px" dir="rtl">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="  الكميـــــه المصدق بها : " />
                    </td>
                    <td align="right" colspan="1" style="width: 379px">
                        <asp:Label ID="lblApprovedAmnt" runat="server" align="right" Font-Size="12pt" Font-Bold="True"
                            CssClass="Button" Height="25px" Width="100px"></asp:Label>
                    </td>
                    <td dir="rtl" style="height: 49px" align="left">
                        <asp:Label ID="Label9" runat="server" CssClass="Label" Text="إجمالى الكميه المتاحه : "
                            Visible="true" />
                    </td>
                    <td align="right" colspan="1" style="height: 49px">
                        <asp:Label ID="lblAvailbleAmount" runat="server" Font-Size="12pt" Font-Bold="True"
                            CssClass="Button" Height="25px" Visible="true" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="1" align="left">
                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="باقى المتاح : " Visible="true" />
                    </td>
                    <td colspan="1">
                        <asp:Label ID="lblAvailbleRemain" runat="server" Font-Size="12pt" Font-Bold="True"
                            CssClass="Button" Height="25px" Visible="true" Width="100px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px; height: 44px;" dir="rtl">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="  الصنف : " />
                    </td>
                    <td colspan="3" style="height: 44px">
                        <asp:TextBox ID="txtsanf" runat="server" Height="26px" CssClass="Text" />
                        444
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px" dir="rtl">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="  الكميه المتاحه : " />
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAvailalbeAmnt" runat="server" AutoPostBack="True" Height="26px"
                            CssClass="Text" />
                        <cc1:FilteredTextBoxExtender ID="FilteredtxtAvailalbeAmnt" runat="server" FilterType="Numbers"
                            TargetControlID="txtAvailalbeAmnt" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 164px; height: 44px;" dir="rtl">
                        <asp:Label ID="Label7" runat="server" CssClass="Label" Text="  تاريخ الإتاحة : " />
                    </td>
                    <td colspan="3" style="height: 44px">
                        <asp:TextBox ID="txtAvailbleDate" runat="server" AutoPostBack="True" Height="26px"
                            CssClass="Text" />
                        <cc1:CalendarExtender ID="txtAvailbleDate_CalendarExtender" runat="server" TargetControlID="txtAvailbleDate"
                            PopupButtonID="ImageButton3" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTxtAvailbleDate" runat="server" FilterType="Custom"
                            TargetControlID="txtAvailbleDate" ValidChars="0123456789/\" />
                        <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="اضغط لعرض النتيجة" Height="23px" Width="23px" ToolTip="تقويم" />
                    </td>
                </tr>--%>
               
               <%-- <tr align="left" dir="rtl">
                    <td colspan="2">
                    </td>
                </tr>--%>
                <tr>
                    <td align="center" class="Text" colspan="2">
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="1600px" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            GridLines="Vertical" >
                            <Columns>
                                <asp:BoundField HeaderText="الاحتياج الرئيسى" DataField="NMT_Desc" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="الاحتياج الفرعى" DataField="NST_Desc" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="اسم البند" DataField="PNed_Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                               <asp:BoundField HeaderText="الكميه المطلوبه" DataField="PNed_Number" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="مطلوب توفيره قبل" DataField="PNed_Date" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="moneyv" HeaderText="القيمه التقديريه للوحده" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="multiply_money_integer" HeaderText="اجمالى" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="المصدق" DataField="approved_amount" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                               <%-- <asp:BoundField HeaderText="الصنف" DataField="Availble_Item" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                                <asp:BoundField HeaderText="إجمالى المتاح" DataField="Availble_Amount_edited" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="إتاحة كمية جديدة" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                     <asp:TextBox ID="txtApproved" runat="server"  Visible="false" Text='<%# Eval("approved_amount") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtPnedid" runat="server" Visible="false" Text='<%# Eval("PNed_ID") %>'></asp:TextBox>
                                        <asp:TextBox ID="txtnewAvailbleAmount" runat="server" Width="80px" MaxLength="9"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredtxtAvailalbeAmnt" runat="server" FilterType="Numbers"
                            TargetControlID="txtnewAvailbleAmount" />
                                        <asp:Label ID="lblError" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label>  
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="اسم الصنف المتاح" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtnewAvailbleName" runat="server" Width="145px"></asp:TextBox>
                                        
                                    </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="تاريخ الإتاحة" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                       <asp:TextBox ID="txtAvailbleDate" runat="server"  Height="26px"
                                            CssClass="Text" Width="90px" Text='<%#System.DateTime.Now.ToString("dd/MM/yyyy") %>'/>
                                             <asp:Label ID="lblError2" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label>  
                                        <cc1:CalendarExtender ID="txtAvailbleDate_CalendarExtender" runat="server" TargetControlID="txtAvailbleDate"
                                            PopupButtonID="ImageButton3" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTxtAvailbleDate" runat="server" FilterType="Custom"
                                            TargetControlID="txtAvailbleDate" ValidChars="0123456789/\" />
                                        <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                            AlternateText="اضغط لعرض النتيجة" Height="23px" Width="23px" ToolTip="تقويم" />
                                            
                                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAvailbleDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                </asp:TemplateField>
                               <%-- <asp:BoundField HeaderText="تاريخ الإتاحة" DataField="Availble_Amount_Date" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-HorizontalAlign="Center" ControlStyle-Width="200px" ControlStyle-Font-Size="Medium">
                                    <ControlStyle Font-Size="Medium" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>--%>
                               <%-- <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <input id="Need_Av_Id" runat="server" type="hidden" value='<%# Eval("Need_Availble_Id") %>' />
                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                            CommandArgument='<%# Eval("Need_Availble_Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="ربط بوثيقة الإتاحة" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عرض تفاصيل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnveiw" runat="server" ImageUrl="../Images/Clipboard.png"
                                            OnClick="ImgBtnveiw_Click" Style="height: 22px" CommandArgument='<%# Eval("PNed_ID") %>'
                                             CommandName= '<%#Container.DataItemIndex %>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                            OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Need_Availble_Id") %>'
                                            OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
                                <td dir="rtl" align="center" colspan="2">
                                    <table id="tbl_doc" runat="server" visible="false" style="border: 1px solid #C2DDF0">
                                        <tr  runat="server" id="TRdoc">
                                            <td valign="top" align="right" width="100%">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                                                    <tr >
                                                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image0');">
                                                            <img border="0" id="image0" src="../Images/square_arrow_down.gif" />
                                                        </td>
                                                        <td 
                                                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image0');">
                                                            وثيقة إتاحة احتياجات المشروع
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="div2" style="display: block" width="100%">
                                               <%-- <asp:CheckBoxList ID="chklistchoose" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chklistchoose_changed" ForeColor="Black" Font-Size="16">
                                                    
                                                    <asp:ListItem   Value="0" Text="اضف وثيقة جديدة" Selected="True" ></asp:ListItem>
                                                    <asp:ListItem  Value="1" Text="اختر من وثيقة موجودة سابقا" ></asp:ListItem>
                                                   
                                                </asp:CheckBoxList>--%>
                                                     <br />
                                             
                                    
                                                    <table style="width: 922px" id="newone" runat="server">
                                                        <tr >
                                                             <td colspan="2" align="center" height="50px">
                                                              <asp:Label ID="lblAddExistDoc" runat="server" CssClass="Label" Font-Bold="False"
                                                            Text= "اضف وثيقة جديدة"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 33px" width="150px">
                                                                <asp:Label ID="Label2" runat="server" Text="ملف الوثيقة" CssClass="Label"></asp:Label>
                                                            </td>
                                                            <td style="height: 33px" align="right">
                                                                <asp:FileUpload ID="FileUpload1"  runat="server" Width="380px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 33px;">
                                                                <asp:Label ID="Label1" runat="server" Text="اسم الوثيقة" CssClass="Label"></asp:Label>
                                                            </td>
                                                            <td style="height: 33px" align="right">
                                                                <asp:TextBox ID="txtFileName" runat="server" Height="27px" Width="383px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px">
                                                                <asp:Label ID="Label3" runat="server" Text="وصف الوثيقة" CssClass="Label"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:TextBox ID="TxtDes" runat="server" Height="65px" Width="500px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                            <asp:Button ID="btnSaveDoc" runat="server" CssClass="Button" Text="تحميل الوثيقة" OnClick="saveAddAnotherDoc" CommandName="save"/>
                                                           
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                            <table style="width: 922px" id="editCurrentDoc" runat="server" visible="false">
                                             <tr>
                                                     <td colspan="2" align="center" height="50px">
                                                      <asp:Label ID="lbledit" runat="server" CssClass="Label" Font-Bold="False"
                                             Text= "اضف وثيقة جديدة"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                            <tr>
                                                <td colspan="2" align="right" style="font-size: 16px; text-decoration: none">
                                                <a id="hrefDoc" runat="server" > </a>
                                                     
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                  <asp:Button ID="btnchangeDoc" runat="server" CssClass="Button" Text="إلغاء الوثيقة" OnClick="saveAddAnotherDoc" CommandName="change" />
                                                </td>
                                            </tr>
                                            </table>
                                                   
                                                              
                                                              
                                                   
                                                </div>
                                            </td>
                                        </tr>
                                       
                                       
                                    </table>
                                </td>
                            </tr>
                
                 <tr>
                    <td  align="center" colspan="2" dir="rtl" height="60px" valign="middle">
              
                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفـــظ الإتاحة" Width="100px" />
                    </td>
                    
                </tr>
                <caption>
                    <br />
                    <br />
                    </tr>
                    <tr ID="TR2" runat="server" >
                        <td align="right" colspan="2" valign="top" width="100%">
                            <table cellpadding="0" cellspacing="0" style="height: 50px" width="100%">
                                <tr >
                                    <td onclick="ChangeMeCase('div3','image0');" 
                                        onmouseover="this.style.cursor='hand'" width="35">
                                        <img ID="Img1" border="0" src="../Images/square_arrow_down.gif" />
                                    </td>
                                    <td onclick="ChangeMeCase('div3','image0');" 
                                        onmouseover="this.style.cursor='hand'" 
                                        >
                                        تفاصيل إتاحة إحتياج المشروع
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" dir="rtl" 
                            style=" font-family: Arial, Helvetica, sans-serif; font-size: 16px;">
                            <div ID="div3" style="display: block" width="100%">
                                <%-- <asp:CheckBoxList ID="chklistchoose" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chklistchoose_changed" ForeColor="Black" Font-Size="16">
                                                    
                                                    <asp:ListItem   Value="0" Text="اضف وثيقة جديدة" Selected="True" ></asp:ListItem>
                                                    <asp:ListItem  Value="1" Text="اختر من وثيقة موجودة سابقا" ></asp:ListItem>
                                                   
                                                </asp:CheckBoxList>--%>
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-CssClass="alt" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="6" CssClass="mGrid" 
                                    EmptyDataText="... عفوا لا يوجد بيانات ..." ForeColor="Black" 
                                    PagerStyle-CssClass="pgr" Visible="False" Width="50%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="الصنف" ItemStyle-Width="250px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAvailble_Item" runat="server" ReadOnly="true" 
                                                    Text='<%# Eval("Availble_Item") %>' Width="250px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الكميه المتاحة" ItemStyle-Width="90px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAvailble_Amount" runat="server" ReadOnly="true" 
                                                    Text='<%# Eval("Availble_Amount") %>' Width="75px"></asp:TextBox>
                                                <asp:Label ID="lblError" runat="server" ForeColor="#EC981F" font-underline="false" Text="*" 
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ الإتاحة" ItemStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtavailble_amount_date" runat="server" ReadOnly="true" 
                                                    Text='<%# Eval("Availble_Amount_Date") %>' Width="75px"></asp:TextBox>
                                                <asp:Label ID="lblError2" runat="server" ForeColor="#EC981F" font-underline="false" Text="*" 
                                                    Visible="False"></asp:Label>
                                                <cc1:CalendarExtender ID="txtavailble_amount_date_CalendarExtender" 
                                                    runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3" 
                                                    TargetControlID="txtavailble_amount_date">
                                                </cc1:CalendarExtender>
                                                <cc1:FilteredTextBoxExtender ID="Filteredtxtrecieved_amount_date" 
                                                    runat="server" FilterType="Custom" TargetControlID="txtavailble_amount_date" 
                                                    ValidChars="0123456789/\" />
                                                <asp:ImageButton ID="ImageButton3" runat="Server" 
                                                    AlternateText="اضغط لعرض النتيجة" Height="23px" 
                                                    ImageUrl="~/images/Calendar_scheduleHS.png" ToolTip="تقويم" Visible="False" 
                                                    Width="23px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="200px" HeaderText="عرض الوثيقة">
                                            <ItemTemplate>
                                                <a ID="hrefDoc" runat="server" 
                                                    href='<%# "ALL_Document_Details.aspx?type=projectneedavailble&id=" & Eval("Availble_Doc_id")%>'>
                                                <%#Eval("File_name")%> </a>
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" 
                                                    Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="25px" HeaderText="تعديل">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtneedid" runat="server" Text='<%# Eval("PNed_PNed_ID") %>' 
                                                    Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtAvailbleId" runat="server" 
                                                    Text='<%# Eval("Need_Availble_Id") %>' Visible="false"></asp:TextBox>
                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" 
                                                    CommandArgument="<%#Container.DataItemIndex %>" CommandName="edit" 
                                                    ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click" />
                                                <asp:ImageButton ID="ImgBtnSave" runat="server" 
                                                    CommandArgument="<%#Container.DataItemIndex %>" CommandName="save" 
                                                    ImageUrl="../Images/save.png" OnClick="ImgBtnEdit_Click" Visible="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="25px" HeaderText="حذف">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnDelete" runat="server" 
                                                    CommandArgument='<%# Eval("Need_Availble_Id") %>' 
                                                    CommandName='<%# Eval("PNed_PNed_ID") %>' ImageUrl="../Images/delete.gif" 
                                                    OnClick="ImgBtnDelete_Click" 
                                                    OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" 
                                                    Style="height: 22px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </caption>
                
            </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="btnSaveDoc" />
            
          
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
