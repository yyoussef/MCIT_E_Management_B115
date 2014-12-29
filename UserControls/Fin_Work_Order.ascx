<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Fin_Work_Order.ascx.cs" Inherits="UserControls_Fin_Work_Order" %>

<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <script language="javascript" type="text/javascript">
    
    function PagePicker(cntrl_ID) {
    window.open('Company.aspx?field=' + cntrl_ID + '', 'Organization', 'titlebar=no,left=470,top=300,width=545px,height=520px,resizable=no');
}

    
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
//  
//        function SelectAll(ID)
//        {
//              //var DIV =  document.getElementById(ID);
//              
//                var chks =  document.forms[0].elements;
//                for (i=0; i<chks.length; i++)
//                {
//                     var type = chks[i].type;
//                     if (type=="checkbox") 
//                //     if (chk.checked) 
//                  //   {
//                         chks[i].checked = true; 
//                    // }
//                    // else chks[i].checked = false; 
//                }
//        }

function SelectAll(Div_ID,Div_Chk_ID)
        {
        
            var Chk_ID;
            
       // alert(Div_Chk_ID);
        var elements = document.getElementById(Div_Chk_ID).getElementsByTagName("input");
       //  alert(elements.length);
          for(xx=0; xx<elements.length;xx++) 
              {
                   if( IsCheckBox(elements[xx]) ) 
                                Chk_ID = elements[xx];
                                            
                           }               
//              var DIVs =  document.getElementsByTagName("DIV");
//              alert(DIVs.length);
//               for(z=0; z<DIVs.length;i++) 
//                   {
//                   
//                        if(DIVs[z].id == Div_Chk_ID)
//                       {
//                       alert("here");
//                           var elements = DIVs[z].getElementsByTagName("input");
//                           for(xx=0; xx<elements.length;xx++) 
//                           {
//                               if( IsCheckBox(elements[xx]) ) 
//                                Chk_ID = elements[xx];
//                                
//                           }  
//                   
//                        }
//                   }
                   //alert(Chk_ID.id);
                    var DIVs =  document.getElementsByTagName("DIV");
               for(i=0; i<DIVs.length;i++) 
                   {
                   //alert(DIVs[i].ID);
                   if(DIVs[i].id == Div_ID)
                   {
                   var elements = DIVs[i].getElementsByTagName("input");
                   for(x=0; x<elements.length;x++) 
                   {
                       if( IsCheckBox(elements[x]) ) 
                        {
                        if(Chk_ID.checked)
                            elements[x].checked = true; 
                        else
                            elements[x].checked = false; 
                        }   
                   }  
                   //alert("here");
                   }
                   
                   }
                   
                   
              
                
        }
        
        
        function IsCheckBox(chk) 
{
    if(chk.type == 'checkbox') return true; 
    else return false;
}
        
        
    </script>

    <style type="text/css">
        .GridAct
        {
            width: 100%;
            background-color: #fff;
            margin: 5px 5px 10px 0;
            border: solid 1px #A1D4E9;
            border-collapse: collapse;
            text-align: right;
        }
        .GridAct .altAct
        {
            /*background-color: #EEEEEE;*/
            background: #ffffff url(../grd_alt.png) repeat-x top;
        }
        .GridAct th
        {
            padding: 4px 2px;
            color: #000000;
            background: #C2DDF0 url(../grd_head.png) repeat-x top;
            border: solid 1px #3A5976;
            font-size: 0.9em;
        }
    </style>
    <input id="proj_id" type="hidden" runat="server" />
    <cc1:TabContainer runat="server" ID="TabPanel_All" Height="2000px" ActiveTabIndex="0">
        <cc1:TabPanel ID="TabPanel_dtl" runat="server" TabIndex="0">
            <HeaderTemplate>
                <asp:Label ID="Label14" runat="server" CssClass="Label" Font-Size="11px" Text="أوامر التوريد" />
                <input type="hidden" runat="server" id="hidden_Work_Order_ID" />
                
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%" style="line-height: 2; color: Black" >
                    <tr>
                        <td dir="rtl" align="center" style="height: 61px">
                            <table width="100%">
                                <tr runat="server" id="tr_Smart_Project" >
                                    <td>
                                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                                    </td>
                                    <td colspan="3" align="right">
                                        <uc1:Smart_Search ID="Smart_Project_ID" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" رقم أمر التوريد : " />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Code" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_Code"
                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال الكود "></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" التاريخ : " />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Date" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtdate_filtered" runat="server" TargetControlID="txt_Date"
                                            ValidChars="0987654321/\" Enabled="True" />
                                        <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            PopupButtonID="Image1" TargetControlID="txt_Date" Enabled="True">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="Image1" runat="server" AlternateText="اضغط لعرض النتيجة" Height="23px"
                                            ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Date"
                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text=" الشركة : " />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Company_ID" runat="server" CssClass="drop">
                                        </asp:DropDownList>
                                        <asp:RangeValidator ControlToValidate="ddl_Company_ID" ErrorMessage="يجب اختيار الشركة"
                                            ID="RangeValidator2" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                            MinimumValue="1" ValidationGroup="A">*</asp:RangeValidator>
                                        <a href="#" onclick="javascript:PagePicker('<%=txt_comapny_ID.ClientID%>');" >
                                            <input type="button" value="..." onmouseover="this.style.cursor='hand'" />
                                        </a>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="  المدة التنفيذية : " />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Comapny_Period" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label15" runat="server" CssClass="Label" Font-Size="15px" Text="بالشهر" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_Comapny_Period"
                                            runat="server" Text="*" ValidationGroup="A" ErrorMessage="يجب ادخال المدة التنفيذية "></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" نوع المناقصة : " />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDl_Tender_Type_ID" runat="server" CssClass="drop">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="  رقم المناقصة : " />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Tender_NO" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="Label" Text=" سنة المناقصة : " />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Tender_Year" runat="server" CssClass="drop">
                                            
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" صورة أمر التوريد : " />
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_Work_Image" runat="server" CssClass="Button" Width="250px"
                                            Height="26px" />
                                        <a id="A1" runat="server" visible="False" style="font-weight: bold; font-size: medium">
                                            عرض</a>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" CssClass="Label" Text="  ملف أمر التوريد : " />
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_Work_File" runat="server" CssClass="Button" Width="250px"
                                            Height="26px" />
                                        <a id="A2" runat="server" visible="False" style="font-weight: bold; font-size: medium">
                                            عرض</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="  صورة العقد : " />
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_Contract_Image" runat="server" CssClass="Button" Width="250px"
                                            Height="26px" />
                                        <a id="A3" runat="server" visible="False" style="font-weight: bold; font-size: medium">
                                            عرض</a>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" ملف العقد : " />
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload_Contract_File" runat="server" CssClass="Button" Width="250px"
                                            Height="26px" />
                                        <a id="A4" runat="server" visible="False" style="font-weight: bold; font-size: medium">
                                            عرض</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text="  القيمة الإجمالية : " />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Work_Total_Value" Height="26px" CssClass="Text" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="Filteredtxt_Work_Total_Value" runat="server" TargetControlID="txt_Work_Total_Value"
                                ValidChars="0987654321" Enabled="True" />
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label13" runat="server" CssClass="Label" Text=" الأنشطة المستهدفة: " />
                                </legend>
                                <asp:GridView ID="grdView_Main" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="1px" CssClass="GridAct" ShowHeader="False" Font-Size="17px">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                    <tr style="background-color: #C2DDF0">
                                                        <td>
                                                            <table>
                                                                <tr onclick='ChangeMeCase(&#039;<%#Eval("PActv_ID")%>&#039;,&#039;<%#"ImL" + Eval("PActv_ID")%>&#039;);'
                                                                    onmouseover="this.style.cursor='hand'">
                                                                    <td>
                                                                        <img id='<%#"ImL" + Eval("PActv_ID")%>' border="0" src="../Images/collapse.gif" />
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval(" PActv_Desc")%>
                                                                    </td>
                                                                    <td width="200px">
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lbl_Parent_ID" runat="server" Text='<%#Eval("PActv_ID")%>' Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CheckBox ID="Chk_Parent" runat="server" onclick="SelectAll('<%#Eval("PActv_ID")%>',this)" />
                                                 <input type="checkbox" id="Chk_Parent" name="Chk_Parent" onclick="SelectAll('<%#Eval("PActv_ID")%>',this)" runat="server" /> --%>
                                                            <%--<asp:CheckBox ID="Chk_Parent" runat="server"  onclick="SelectAll('<%#Eval("PActv_ID")%>',this)"  />--%>
                                                            <div id='<%#"Div" + Eval("PActv_ID")%>' onclick='SelectAll(&#039;<%#Eval("PActv_ID")%>&#039;,&#039;<%#"Div" + Eval("PActv_ID")%>&#039;)'>
                                                                <input id="Chk_Parent" runat="server" name="Chk_Parent" type="checkbox" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding-right: 40px;">
                                                            <div id='<%#Eval("PActv_ID")%>' style="display: none">
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grdView_Sub" runat="server" DataSource='<%#GetDataSet(Eval("PActv_ID").ToString())%>'
                                                                                Width="100%" ShowHeader="False" AutoGenerateColumns="False" CellPadding="0" BorderWidth="0px">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="5" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%#Eval("PActv_Desc")%>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label ID="lbl_Child_ID" runat="server" Text='<%#Eval("PActv_ID")%>' Visible="false"></asp:Label>
                                                                                                        <input type="checkbox" runat="server" id="Chk_Child" name="chk_child" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" CssClass="Button" Text="حفــــــظ" ID="BtnSave" OnClick="btnSave_Click"
                                ValidationGroup="A" Width="99px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" CssClass="Button" Text="جديد" ID="btn_New" OnClick="btn_New_Click"
                                Width="99px" />
                        </td>
                    </tr>
                    <tr >
                        <td align="center">
                            <asp:GridView ID="grd_View_Mng" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="mGrid"
                                Font-Size="17px" ForeColor="Black" OnRowCommand="GrdView_RowCommand" Width="100%">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:BoundField DataField="Code" HeaderText="رقم امر التوريد" />
                                    <asp:BoundField DataField="Date" HeaderText="التاريخ" />
                                    <asp:BoundField DataField="Company_Name" HeaderText="الشركة" />
                                    <asp:BoundField DataField="Comapny_Period" HeaderText=" المدة التنفيذية" />
                                    <asp:BoundField DataField="Name" HeaderText=" نوع المناقصة" />
                                    <asp:BoundField DataField="Tender_NO" HeaderText="رقم المناقصة" />
                                    <asp:BoundField DataField="Tender_Year" HeaderText="سنة المناقصة" />
                                    <asp:BoundField DataField="Work_Total_Value" HeaderText="إجمالى أمر التوريد" />
                                    <asp:TemplateField HeaderText="تعديل">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" CommandArgument='<%# Eval("Work_Order_ID") %>'
                                                CommandName="EditItem" ImageUrl="../Images/Edit.jpg" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" CommandArgument='<%# Eval("Work_Order_ID") %>'
                                                CommandName="RemoveItem" ImageUrl="../Images/delete.gif" Style="height: 22px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_Needs" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label17" runat="server" CssClass="Label" Font-Size="11px" Text="البنود" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label18" runat="server" CssClass="Label" Text="البند الرئيسى:" />
                            <input type="hidden" runat="server" id="hidden_Fin_Need_ID" />
                        </td>
                        <td dir="rtl">
                            <asp:DropDownList ID="ddl_NMT_ID" AutoPostBack="true" OnSelectedIndexChanged="ddl_NMT_ID_SelectedIndexChanged"
                                runat="server" CssClass="drop">
                            </asp:DropDownList>
                            <asp:RangeValidator ControlToValidate="ddl_NMT_ID" ErrorMessage="يجب اختيار الشركة"
                                ID="RangeValidator3" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                MinimumValue="1" ValidationGroup="C">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label22" runat="server" CssClass="Label" Text="البند الفرعى: " />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_NST_ID" runat="server" CssClass="drop">
                            </asp:DropDownList>
                            <asp:RangeValidator ControlToValidate="ddl_NST_ID" ErrorMessage="يجب اختيار الشركة"
                                ID="RangeValidator1" Type="Integer" runat="server" Display="Dynamic" MaximumValue="1000000"
                                MinimumValue="1" ValidationGroup="C">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label23" runat="server" CssClass="Label" Text="القيمة : " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Value" Height="26px" runat="server" CssClass="Text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_Value"
                                runat="server" Text="*" ValidationGroup="C" ErrorMessage="يجب ادخال القيمة "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Needs" OnClick="btn_Needs_Click" Text="حفظ " runat="server" ValidationGroup="C"
                                CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView_Needs" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Needs_RowCommand"
                                Font-Size="17px">
                                <Columns>
                                    <asp:TemplateField HeaderText="البند الرئيسى">
                                        <ItemTemplate>
                                            <%#Eval("NMT_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="البند الفرعى">
                                        <ItemTemplate>
                                            <%#Eval("NST_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="القيمة">
                                        <ItemTemplate>
                                            <%#Eval("Value")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("Fin_Need_ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px" CommandArgument='<%# Eval("Fin_Need_ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_Visa" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label24" runat="server" CssClass="Label" Font-Size="11px" Text="الملفات" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الملف:" Width="135px" />
                            <input type="hidden" runat="server" id="hidden_File_ID" />
                        </td>
                        <td dir="rtl">
                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                                Width="700px" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم الملف: " />
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="700px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="وصف الملف : " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_File_Desc" runat="server" CssClass="Text" Height="70px" Width="90%"
                                Rows="6" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="حفظ الملف" runat="server"
                                CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GrdView_Documents_RowCommand"
                                Font-Size="17px">
                                <Columns>
                                    <asp:TemplateField HeaderText="اللف">
                                        <ItemTemplate>
                                            <a href='<%# "ALL_Document_Details.aspx?type=work&id="+ Eval("File_ID") %>'>
                                                <%#Eval("File_name")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="وصف الملف">
                                        <ItemTemplate>
                                            <%#Eval("File_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("File_ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px" CommandArgument='<%# Eval("File_ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel_letter" runat="server">
            <HeaderTemplate>
                <asp:Label ID="Label25" runat="server" CssClass="Label" Font-Size="11px" Text="خطابات الضمان" />
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label26" runat="server" CssClass="Label" Text="تاريخ البداية:" />
                            <input type="hidden" runat="server" id="hidden1" />
                        </td>
                        <td dir="rtl">
                            <asp:TextBox ID="txt_Strt_DT" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_Strt_DT"
                                ValidChars="0987654321/\" Enabled="True" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton1"
                                TargetControlID="txt_Strt_DT" Enabled="True">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_Strt_DT"
                                runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label27" runat="server" CssClass="Label" Text="تاريخ النهاية: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_End_Dt" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_Strt_DT"
                                ValidChars="0987654321/\" Enabled="True" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton2"
                                TargetControlID="txt_End_Dt" Enabled="True">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_End_Dt"
                                runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label31" runat="server" CssClass="Label" Text="النوع:" />
                            <input type="hidden" runat="server" id="hidden_Letter_Id" />
                        </td>
                        <td dir="rtl">
                            <asp:DropDownList ID="ddl_type" runat="server" CssClass="drop">
                                <asp:ListItem Text="ابتدائى" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="نهائى" Value="2"></asp:ListItem>
                                <asp:ListItem Text="مقابل دفعة مقدمة" Value="3"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label32" runat="server" CssClass="Label" Text="البنك: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Bank" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label29" runat="server" CssClass="Label" Text="النسبة:" />
                            <input type="hidden" runat="server" id="hidden2" />
                        </td>
                        <td dir="rtl">
                            <asp:TextBox ID="txt_Letter_Percent" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label30" runat="server" CssClass="Label" Text="القيمة: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Letter_Value" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_Letter_Value"
                                runat="server" Text="*" ValidationGroup="D" ErrorMessage="يجب ادخال التاريخ "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label33" runat="server" CssClass="Label" Text=" الملف: " />
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload_letter" runat="server" CssClass="Button" Width="250px"
                                Height="26px" />
                            <a id="A5" runat="server" visible="False" style="font-weight: bold; font-size: medium">
                                عرض</a>
                        </td>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label28" runat="server" CssClass="Label" Text="تاريخ الانذار : " />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Alarm_DT" Height="26px" runat="server" CssClass="Text"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_Alarm_DT"
                                ValidChars="0987654321/\" Enabled="True" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="ImageButton3"
                                TargetControlID="txt_Alarm_DT" Enabled="True">
                            </cc1:CalendarExtender>
                            <asp:ImageButton ID="ImageButton3" runat="server" AlternateText="اضغط لعرض النتيجة"
                                Height="23px" ImageUrl="~/images/Calendar_scheduleHS.png" Width="23px" ToolTip="تقويم" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <br />
                            <br />
                            <asp:Button ID="btn_Letter" OnClick="btn_Letter_Click" Text="حفظ" runat="server"
                                ValidationGroup="D" CssClass="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView_Letter" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowCommand="GridView_Letter_RowCommand"
                                Font-Size="17px">
                                <Columns>
                                  <asp:TemplateField HeaderText="النوع">
                                        <ItemTemplate>
                                         <%# Get_Type(Eval("Type"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تاريخ البداية">
                                        <ItemTemplate>
                                            <%#Eval("Strt_DT")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تاريخ النهاية">
                                        <ItemTemplate>
                                            <%#Eval("End_Dt")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="القيمة">
                                        <ItemTemplate>
                                            <%#Eval("Letter_Value")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="البنك">
                                        <ItemTemplate>
                                            <%#Eval("Bank")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                CommandArgument='<%# Eval("Letter_Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف" ItemStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                Style="height: 22px" CommandArgument='<%# Eval("Letter_Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
        ShowMessageBox="true" ShowSummary="false" />
        <asp:TextBox ID="txt_comapny_ID" Height="26px" CssClass="Text" Width="0px" runat="server"
                    OnTextChanged="txt_comapny_ID_TextChanged"></asp:TextBox>
