<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Copy of Need_Recieve.aspx.vb" Inherits="MainForm_Need_Recieve" Title="صرف إحتياجات المشروع" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script type="text/javascript">
    function OpenModelPopup()
    { 
        document.getElementById ('tdDisplayName').innerHTML='';
        document.getElementById ('txtName').value='';
        document.getElementById ('ModalPopupDiv').style.visibility='visible';
        document.getElementById ('ModalPopupDiv').style.display='';
        document.getElementById ('ModalPopupDiv').style.top= Math.round ((document.documentElement.clientHeight/2)+ document.documentElement.scrollTop)-100 + 'px';
        document.getElementById ('ModalPopupDiv').style.left='400px';
        
        document.getElementById ('MaskedDiv').style.display='';
        document.getElementById ('MaskedDiv').style.visibility='visible';
        document.getElementById ('MaskedDiv').style.top='0px';
        document.getElementById ('MaskedDiv').style.left='0px';
        document.getElementById ('MaskedDiv').style.width=  document.documentElement.clientWidth + 'px';
        document.getElementById ('MaskedDiv').style.height= document.documentElement.clientHeight+ 'px';
    }
     
        function showPopup() {
            document.getElementById("overlay").style.display = "block";
            document.getElementById("popup").style.display = "block";
        }
        function closePopup() {
            document.getElementById("overlay").style.display = "none";
            document.getElementById("popup").style.display = "none";
        }
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
        
         <input id="need_id" runat="server" type="hidden" />
                <input id="Need_Av_Ids" runat="server" type="hidden" />
            <input id="Mode" runat="server" type="hidden" value="new" />
            <input id="need_recieve_id" runat="server" type="hidden" />
            <input id="myRowIndex" runat="server" type="hidden" />
            <input id="myRowIndex1" runat="server" type="hidden" />
            <input id="myRowIndex2" runat="server" type="hidden" />
            <input id="myRowIndex3" runat="server" type="hidden" />
            <input id="myRowIndex4" runat="server" type="hidden" />
            <input id="chktype" runat="server" type="hidden" value="0"/>
             <input id="doc_id" runat="server" type="hidden" value="0" />
            
         <%-- <a href="#" onclick="javascript:showPopup();return false;">Show Popup</a>--%>
    <div id="overlay" class="overlay" runat="server">
    </div>
    <div id="popup" class="popup" runat="server" align="center">
        <br />
         <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الانشطة المرتبطة" />
         <br />
         <asp:Label ID="lblpopupStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
        <%--OnPreRender="gvSub_PreRender1" OnDataBinding="get_gvActivities" --%>                     
        <div id="div1" style="overflow: auto; width: 690px; height: 350px">
      
            <asp:GridView ID="gvActivities" runat="server" AlternatingRowStyle-CssClass="alt"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" Width="500px" CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                ForeColor="Black" PagerStyle-CssClass="pgr" Visible="true" Font-Size="10pt" Font-Strikeout="False"
                 font-underline="false" CaptionAlign="Top" >
                <Columns>
                    <asp:BoundField DataField="PActv_Desc" HeaderText="النشاط " HeaderStyle-Width="350px"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="350px">
                        <HeaderStyle Width="350px" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderText="الكمية">
                        <ItemTemplate>
                            <asp:TextBox ID="txtamount" runat="server" Width="75px">
                            </asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="Filteredtxtamount" runat="server" FilterType="Numbers"
                                         TargetControlID="txtamount" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderText="المبلغ بالجنيه المصرى">
                        <ItemTemplate>
                            
                            <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                            <asp:TextBox ID="txttotal" runat="server" Width="75px" ReadOnly="true" ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <table>
            <tr align="center" dir="rtl">
                <td align="left" dir="rtl">
                <asp:Button ID="btncommit" CssClass="Button" runat="server" onclick="savePopupGrid" Text="حـــفظ"></asp:Button>
                </td>
                  <td align="center" dir="rtl">
                  <asp:Button ID="Button1" CssClass="Button" runat="server" onclick="cancelPopupGrid" Text="إلـــغاء"></asp:Button>
                </td>
                  <td align="right" dir="rtl">
                   <asp:Button ID="btnClose" CssClass="Button" runat="server" onclick="closePopupGrid" Text="رجـــوع"></asp:Button>
                </td>
            </tr>
        </table>
         
         
       
    </div>
             <div id="divGrid" style="overflow: auto; width: 1000px; height: 550px">
            
            <table >
                <tr>
                    <td dir="rtl" align="center" style="height: 45px">
                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="False"
                            Text="صـــرف احتياجات المشـــــــــــــروع"></asp:Label>
                             
                           
                    </td>
                 
                </tr>
                <tr>
                    <td dir="rtl" align="center">
                        <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                    </td>
                </tr>
             
        
                <tr>
                    <td>
                        <table style="border: 1px solid #C2DDF0">
                          
                            <tr>
                                <td align="center" class="Text" colspan="4" dir="rtl">
                                    <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                         BackColor="White" ForeColor="Black" BorderColor="#999999" 
                                        BorderStyle="Solid" Width="1500px"
                                        
                                        BorderWidth="1px" 
                                        EmptyDataText="... عفوا لا توجد بيانات إحتياجات متاحة يمكن صرفها  ..." CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        GridLines="Vertical">
                                        <Columns>
                    <%-- <asp:BoundField HeaderText="باقى الصرف المتاح" DataField="remain" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                                        
                    <%-- <asp:TemplateField HeaderText="وثيقة الصرف" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server"  ForeColor="Maroon"
                                        Width="264px" Height="27px" />
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                     <%--<asp:TemplateField HeaderText="الانشطة المرتبطة" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtActivIDs" runat="server" Visible="false"></asp:TextBox>
                           <asp:TextBox ID="txtAmounts" runat="server" Visible="false"></asp:TextBox>
                           <asp:TextBox ID="txtMoneys" runat="server" Visible="false"></asp:TextBox>

                            <asp:Button id="btnshow" tabIndex="7" runat="server"
                             CssClass="Button" Text="ربط بالأنشطة" Width="97px" ></asp:Button>

                            

                            <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" 
                                    TargetControlID="btnshow"
                                     PopupControlID="PanelPopUp" 
                                     OkControlID="btnFinalConfirm"
                                     CancelControlID="btnFinalCancel" 
                                     DropShadow="True"
                                     PopupDragHandleControlID="PanelDrag"  />           
                        <asp:Panel ID="PanelPopUp" runat="server"  Width ="600px">
                                    <asp:Label ID="Label15" runat="server" CssClass="Label" Text="الانشطة المرتبطة :" />
                             
                                    <div id="div1" style="overflow: auto; width: 650px; height: 300px">
                                        <asp:GridView ID="gvActivities" runat="server" AlternatingRowStyle-CssClass="alt"
                                            AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                            BorderWidth="1px" Width="500px" CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                            ForeColor="Black" PagerStyle-CssClass="pgr" Visible="true" Font-Size="10pt" Font-Strikeout="False"
                                            ForeColor="#808080" font-underline="false" CaptionAlign="Top" OnPreRender="gvSub_PreRender1" OnDataBinding="get_gvActivities">
                                            <Columns>
                                                <asp:BoundField DataField="PActv_Desc" HeaderText="النشاط " HeaderStyle-Width="350px"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="350px">
                                                    <HeaderStyle Width="350px" />
                                                </asp:BoundField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="الكمية">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtamount" runat="server" Width="75px" Text='<%#Eval("amount") %>'>
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="المبلغ بالجنيه المصرى">
                                                    <ItemTemplate>
                                                        
                                                        <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                                        <asp:TextBox ID="txttotal" runat="server" Width="75px" ReadOnly="true" Text='<%#Eval("total") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                           

                            </asp:Panel>
                             
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <%-- <asp:TemplateField HeaderText="باقى صرف المتاح">
                            <ItemTemplate>
                                <asp:Label ID="lblRemainGRD" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                                           <%-- <asp:BoundField HeaderText="الباقى" DataField="remain" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                        <%--<asp:BoundField HeaderText="تاريخ الصرف" DataField="recieved_amount_date" />--%>
                       <%-- <asp:BoundField HeaderText="الجهه المستلمه" DataField="recieve_organization" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                       <%-- <asp:TemplateField HeaderText="عرض الوثيقة">
                            <ItemTemplate>
                                <a href='<%# "ALL_Document_Details.aspx?type=projectrecieve&id=" & Eval("need_recieve_id")%>'>
                                    <%#Eval("File_name")%></a>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>--%>
                                           <%-- <asp:TemplateField HeaderText="تعديل">
                                                <ItemTemplate>
                                                    <input id="need_recieve_id" runat="server" type="hidden" value='<%# Eval("need_recieve_id") %>' />
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                        CommandArgument='<%# Eval("need_recieve_id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                           <%-- <asp:TemplateField HeaderText="حذف">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                        OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("need_recieve_id") %>'
                                                        OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%><asp:BoundField HeaderText="إحتياج رئيسى" DataField="NMT_Desc" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="إحتياج فرعى" DataField="NST_Desc" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="البند" DataField="PNed_Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="الكميه المطلوبة" DataField="PNed_Number" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                    
                                          
                    <asp:BoundField HeaderText="مطلوب توفيره قبل" DataField="PNed_Date" ItemStyle-HorizontalAlign="Center" Visible="false" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="moneyv" HeaderText="القيمه التقديريه للوحده" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                         <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="multiply_money_integer" HeaderText="اجمالى" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75px">
                        <HeaderStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:BoundField HeaderText="الكميه المصدق بها" DataField="approved_amount" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="الكميه المتاحه" DataField="Availble_Amount_edited" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75px">
                        <HeaderStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                
                    <asp:BoundField HeaderText="إجمالى الكميه المنصرفة" DataField="recieved_amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="75px">
                        <HeaderStyle Width="75px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="صرف كمية جديدة" ItemStyle-Width="100px">
                        <ItemTemplate>
                          <%--<asp:TextBox ID="txtavailble" runat="server"  Visible="false" Text='<%# Eval("remain") %>'></asp:TextBox>--%>
                                <asp:TextBox ID="txtPnedid" runat="server" Visible="false" Text='<%# Eval("PNed_ID") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtnewrecievedAmount" runat="server" Width="75px" MaxLength="9"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredtxtnewrecievedAmount" runat="server" FilterType="Numbers"
                                         TargetControlID="txtnewrecievedAmount" />
                                    <asp:Label ID="lblError" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label> 
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مبلغ الصرف الفعلي" HeaderStyle-Width="136px">
                        <ItemTemplate>
                         <%-- <asp:TextBox ID="txtexchange" runat="server"  Visible="false" Text='<%# Eval("remain") %>'></asp:TextBox>--%>
                                <asp:TextBox ID="txtPnedid1" runat="server" Visible="false" Text='<%# Eval("PNed_ID") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtexchange" runat="server" Width="75px" MaxLength="9"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="Filteredtxtexchange" runat="server" FilterType="Custom"
                                         TargetControlID="txtexchange" ValidChars="0123456789." />
                                   <asp:Label ID="lblwe0" runat="server" ForeColor="Black" 
                                        Style="vertical-align: bottom" Text=" ج .م" Font-Size="12px"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                        <HeaderStyle Width="136px" />
                    </asp:TemplateField>
                    
                       <asp:TemplateField HeaderText="تاريخ الصرف" ItemStyle-Width="150px">
                        <ItemTemplate>
                           <asp:TextBox ID="txtRecieveDate" runat="server"  Height="26px"
                                CssClass="Text" Width="90px" Text='<%#System.DateTime.Now.ToString("dd/MM/yyyy") %>'/>
                                 <asp:Label ID="lblError2" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label>  
                            <cc1:CalendarExtender ID="txtRecieveDate_CalendarExtender" runat="server" TargetControlID="txtRecieveDate"
                                PopupButtonID="ImageButton3" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTxtRecieveDate" runat="server" FilterType="Custom"
                                TargetControlID="txtRecieveDate" ValidChars="0123456789/\" />
                            <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="اضغط لعرض النتيجة" Height="23px" Width="23px" ToolTip="تقويم" />
                                
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtRecieveDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                        </ItemTemplate>
                           <ItemStyle Width="150px" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="الجهه المستلمه" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRecieve_organization" runat="server" Width="145px"></asp:TextBox>
                            
                        </ItemTemplate>
                          <ItemStyle Width="150px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="اسم المستلم" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRecieve_person" runat="server" Width="145px"></asp:TextBox>
                            
                        </ItemTemplate>
                         <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="ربط بوثيقة الصرف" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                </asp:TemplateField>
                   <asp:TemplateField HeaderText="الانشطة"   HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                        <asp:TextBox ID="txtneedID" runat="server" Visible="false" Text='<%# Eval("PNed_ID") %>'></asp:TextBox>
                         <asp:TextBox ID="txtActivIDs" runat="server" Visible="false"></asp:TextBox>
                           <asp:TextBox ID="txtAmounts" runat="server" Visible="false"></asp:TextBox>
                           <asp:TextBox ID="txtMoneys" runat="server" Visible="false"></asp:TextBox>

                            <asp:Button id="btnshow"  runat="server"
                             CssClass="Button" Text="ربط"  onclick="showPopupGrid" 
                             CommandArgument='<%# Eval("PNed_ID") %>'  CommandName= '<%#Container.DataItemIndex %>' Width="50px"></asp:Button>
                         </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="عرض تفاصيل" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgBtnveiw" runat="server" ImageUrl="../Images/Clipboard.png"
                                            OnClick="ImgBtnveiw_Click" Style="height: 22px" CommandArgument='<%# Eval("PNed_ID") %>'
                                             CommandName= '<%#Container.DataItemIndex %>'  />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
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
                                    <table id="tbl_doc" runat="server" visible="true" style="border: 1px solid #C2DDF0">
                                        <tr  runat="server" id="TRdoc">
                                            <td valign="top" align="right" width="100%">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                                                    <tr >
                                                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image0');">
                                                            <img border="0" id="image0" src="../Images/square_arrow_down.gif" />
                                                        </td>
                                                        <td 
                                                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div2','image0');">
                                                            وثيقة صرف احتياجات المشروع
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
                                             
                                    
                                                    <table style="width: 700px" id="newone" runat="server">
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
                                                   
                                                              
                                                              
                                                   <%-- <table style="width: 922px" id="oldone" runat="server" visible="false">
                                                    <tr>
                                                            <td colspan="2">
                                                                <asp:GridView ID="GridNeed" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="اسم الوثيقة">
                                                                            <ItemTemplate>
                                                                                <a href='<%# "ALL_Document_Details.aspx?type=projectrecievenew&id=" & Eval("id")%>'>
                                                                                    <%#Eval("File_name")%></a>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" Width="60%" />
                                                                            <ItemStyle Width="60%" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="اختر">
                                                                            <ItemTemplate>
                                                                            <asp:TextBox ID="txtdocid" runat="server" Visible="false" Text='<%# Eval("id") %>'></asp:TextBox>
                                                                               <asp:ImageButton ID="ImgBtnChoose" runat="server" ImageUrl="../Images/unchecked.png" OnClick="ImgBtnEdit_Click"
                                                                             CommandArgument='<%#Container.DataItemIndex %>' CommandName= 'choose' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                                                                               <input id="NeedId" runat="server" type="hidden" value='<%# Eval("PNed_ID") %>' />
                                                                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                                    Style="height: 22px;" CommandArgument='<%# Eval("id") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                </div>
                                            </td>
                                        </tr>
                                       
                                       
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"  height="60px" valign="middle" align=center>
                                    <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text=" حفــــظ الصرف "  Width="150px" />
                                </td>
                            </tr>
                             <tr  runat="server" id="TR2">
                                            <td valign="top" align="right" width="100%" colspan="2">
                                                <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                                                    <tr >
                                                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img1');">
                                                            <img border="0" id="Img1" src="../Images/square_arrow_down.gif" />
                                                        </td>
                                                        <td 
                                                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div3','Img1');">
                                                            تفاصيل صرف إحتياج المشروع
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td align="right" colspan="2" dir="rtl" style=" font-family: Arial, Helvetica, sans-serif; font-size: 16px;">
                                          <div id="div3" style="display: block" width="100%">
                                               <%-- <asp:CheckBoxList ID="chklistchoose" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chklistchoose_changed" ForeColor="Black" Font-Size="16">
                                                    
                                                    <asp:ListItem   Value="0" Text="اضف وثيقة جديدة" Selected="True" ></asp:ListItem>
                                                    <asp:ListItem  Value="1" Text="اختر من وثيقة موجودة سابقا" ></asp:ListItem>
                                                   
                                                </asp:CheckBoxList>--%>
                                                     <br />
                           
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6"
                    BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                    BorderWidth="1px" EmptyDataText="... عفوا لا توجد بيانات صرف لهذا الإحتياج..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Width="50%" 
                    Visible="false" OnRowEditing="rowEdit">
                    <Columns>
                        
                           <asp:TemplateField HeaderText="الكميه المصروفة" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRecieve_amount" runat="server" ReadOnly="true" Width="145px"
                                     Text='<%# Eval("recieved_amount") %>'></asp:TextBox>
                                     <asp:Label ID="lblError" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label>  
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="مبلغ الصرف الفعلي" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtexchange_amount" runat="server" ReadOnly="true" Width="145px"
                                     Text='<%# Eval("exchange_amount") %>'></asp:TextBox>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ الصرف" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrecieved_amount_date" runat="server" ReadOnly="true" Width="75px"
                                     Text='<%# Eval("recieved_amount_date") %>'></asp:TextBox>
                                     <asp:Label ID="lblError2" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label>  
                                <cc1:CalendarExtender ID="txtrecieved_amount_date_CalendarExtender" runat="server" TargetControlID="txtrecieved_amount_date"
                                    PopupButtonID="ImageButton3" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender ID="Filteredtxtrecieved_amount_date" runat="server" FilterType="Custom"
                                    TargetControlID="txtrecieved_amount_date" ValidChars="0123456789/\" />
                                <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="اضغط لعرض النتيجة" Height="23px" Width="23px" ToolTip="تقويم" Visible="False" />
                                    
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtrecieved_amount_date"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                   ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                     
                       <asp:TemplateField HeaderText="الجهه المستلمه" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrecieve_organization" runat="server" ReadOnly="true" Width="145px"
                                     Text='<%# Eval("recieve_organization") %>'></asp:TextBox>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="اسم المستلم" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrecieve_organization_person" runat="server" ReadOnly="true" Width="145px"
                                     Text='<%# Eval("recieve_organization") %>'></asp:TextBox>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="عرض الوثيقة" HeaderStyle-Width="250px">
                    <ItemTemplate>
                          <a id="hrefDoc" runat="server" href='<%# "ALL_Document_Details.aspx?type=projectrecieveNew&id=" & Eval("Recieve_Doc_id")%>'>
                                                <%#Eval("File_name")%> </a>
                             <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" Visible="false" />
                             
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                    <%--OnClick="ImgBtnEdit_Click"--%>
                           <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px" >
                            <ItemTemplate>
                             <asp:TextBox ID="txtneedid" runat="server" Visible="false" Text='<%# Eval("PNed_PNed_ID") %>'></asp:TextBox>
                               <asp:TextBox ID="txtrecieveid" runat="server" Visible="false" Text='<%# Eval("need_recieve_id") %>'></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%#Container.DataItemIndex %>' CommandName= 'edit' />
                                <asp:ImageButton ID="ImgBtnSave" runat="server" ImageUrl="../Images/save.png" OnClick="ImgBtnEdit_Click"
                                CommandArgument='<%#Container.DataItemIndex %>' CommandName= 'save' Visible="False" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- OnClick="ImgBtnDelete_Click"--%>
                           <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                        Style="height: 22px" CommandArgument='<%# Eval("need_recieve_id") %>' OnClick="ImgBtnDelete_Click"
                                         CommandName= '<%# Eval("PNed_PNed_ID") %>' OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                       
                    </Columns>
                    <PagerStyle CssClass="pgr" />
                    <AlternatingRowStyle CssClass="alt" />
                </asp:GridView>
             
                          
                               <asp:GridView ID="GridView2" runat="server" AlternatingRowStyle-CssClass="alt"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" Width="700px" CellPadding="4" CssClass="mGrid" EmptyDataText="... عفوا لا توجد أنشطة مرتبطة بهذا الإحتياج..."
                ForeColor="Black" PagerStyle-CssClass="pgr"   Font-Strikeout="False"
                 font-underline="false" CaptionAlign="Top" Visible="False" >
                <Columns>
                    <asp:BoundField DataField="PActv_Desc" HeaderText="النشاط " HeaderStyle-Width="350px"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="350px">
                        <HeaderStyle Width="350px" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderText="الكمية">
                        <ItemTemplate>
                            <asp:TextBox ID="txtamount" runat="server" Width="50px" ReadOnly="true" Text='<%# Eval("amount") %>'>
                            </asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="Filteredtxtamount" runat="server" FilterType="Numbers"
                                         TargetControlID="txtamount" />
                                    <asp:Label ID="lblError" runat="server" Text="*" Visible="False" ForeColor="#EC981F" font-underline="false"></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                        HeaderText="المبلغ بالجنيه المصرى">
                        <ItemTemplate>
                            
                            
                            <asp:TextBox ID="txttotal" runat="server" Width="80px" ReadOnly="true" Text='<%# Eval("total") %>'></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="Filteredtxttotal" runat="server" FilterType="Custom"
                                         TargetControlID="txttotal" ValidChars="0123456789." />
                                   &nbsp;<asp:Label ID="lblwe0" runat="server" ForeColor="Black" 
                                        Style="vertical-align: bottom" Text=" ج .م"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="25px" >
                            <ItemTemplate>
                             <asp:TextBox ID="txtneedid" runat="server" Visible="false" Text='<%# Eval("need_id") %>'></asp:TextBox>
                               <asp:TextBox ID="txtActivId" runat="server" Visible="false" Text='<%# Eval("actv_id") %>'></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%#Container.DataItemIndex %>' CommandName= 'editActiv' />
                                <asp:ImageButton ID="ImgBtnSave" runat="server" ImageUrl="../Images/save.png" OnClick="ImgBtnEdit_Click"
                                CommandArgument='<%#Container.DataItemIndex %>' CommandName= 'saveActiv' Visible="False" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
           
                                        </div>
                                        </td>
                                        </tr>
                        </table>
                    </td>
                </tr>
             
              
            </table>
        
                    
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
             <asp:PostBackTrigger ControlID="btnSaveDoc" />
            
           <%-- <asp:PostBackTrigger ControlID="ImgBtnSave" />
            <asp:PostBackTrigger ControlID="ImgBtnEdit" />--%>
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
