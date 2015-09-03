<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false" CodeFile="Projects2.aspx.vb" Inherits="WebForms_Projects" 
Title="تسجبل مشاريع جديدة" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script  language="javascript" type="text/javascript" >
function Get_Value()
{
var file_Upload =  document.getElementById('<%= DocUpload.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex+1,dotindex);

document.getElementById('<%=txtDocName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('square_arrow_flipped') != -1)
       { img.src = "../Images/square_arrow_down.gif";
        }
    else
        {img.src = "../Images/square_arrow_flipped.gif";
        }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}
  
function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('square_arrow_flipped') != -1)
       { img.src = "../Images/square_arrow_down.gif";
        }
    else
        {img.src = "../Images/square_arrow_flipped.gif";
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
    <input id="Proj_id" runat="server" value="" type="hidden" />
    <input id="Proj_id1" runat="server" type="hidden" />
    <input id="PDOC_id1" runat="server" type="hidden" />
    <input id="PDOC_id2" runat="server" type="hidden" />
    <input id="PDOC_id3" runat="server" type="hidden" /> 
    
    <table style="line-height: 2; width: 100%;">
        
        <tr>
            <td dir="rtl" align="center" colspan="4">
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="#EC981F" font-underline="false" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblID" runat="server" CssClass="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="rtl" align="center">
                <table dir="rtl" width="100%">
                    <tr>
                        <td>
                            <table id="tblnew" runat="server" visible="false" dir="rtl" width="100%">
                                <tr>
                                    <td dir="rtl" align="center" colspan="2">
                                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="true"
                                            Text="مقترح مشروع جديد"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                <td colspan="2" dir="rtl">
                                <table id="Table1" runat="server" dir="rtl" width="100%">
                                <tr>
                                    <td align="right" dir="rtl" style="width: 199px" >
                                        <asp:Label ID="lblClassName" runat="server" CssClass="Label" 
                                            Text="اسم مقترح المشـــــروع : " />
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:TextBox ID="txtProjTitle" runat="server" CssClass="Text" Width="99%"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" style="width: 199px">
                                        <asp:Label ID="label1" runat="server" CssClass="Label" Text="ملخص مقترح المشــروع : " />
                                    </td>
                                    <td align="right" dir="rtl" colspan="1">
                                        <asp:TextBox ID="txtProjBrief" runat="server" CssClass="Text" TextMode="MultiLine"
                                            Height="215px" Width="99%" MaxLength="8000" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" style="width: 199px">
                                        <asp:Label ID="label2" runat="server" CssClass="Label" 
                                            Text="المدير المقتــرح للمشــروع :" />
                                    </td>
                                    <td align="right" dir="rtl" class="style14" style="height: 53px" colspan="1">
                                     <uc1:Smart_Search ID="Smart_Search_man" runat="server" />
                                        <%--<asp:DropDownList ID="DDLProjectManager" CssClass="drop" runat="server" 
                                            Width="99%" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" dir="rtl" style="width: 199px">
                                        <asp:Label ID="label3" runat="server" CssClass="Label" 
                                            Text="تاريخ اقتراح  المشــروع : " />
                                    </td>
                                    <td align="right" colspan="1">
                                        <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                                            PopupButtonID="Image1" format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom" ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Width="90px" />
                                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                            AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" 
                                            ToolTip="تقويم" />
                                            
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"
                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="*"  > </asp:RegularExpressionValidator>
                                    </td>
                                    
                                    
                                   
                                </tr>
                                <tr>
                                     <td align="right" dir="rtl" style="width: 199px">
                                        <asp:Label ID="label11" runat="server" CssClass="Label" 
                                            Text="الأولويـــــــــــة :" />
                                    </td>
                                    <td align="right" dir="rtl" colspan="1">
                                        <asp:DropDownList ID="DDLPriority" runat="server" CssClass="Button" 
                                            Width="199px" Height="25px" />
                                    </td>
                                </tr>
                                <tr>
                                     <td align="right" dir="rtl" style="width: 199px" >
                                        <asp:Label ID="label4" runat="server" CssClass="Label" Text="ميزانية المشروع : " />
                                    </td>
                                    <td align="right" colspan="1">
                                        <asp:TextBox ID="txtCoast" runat="server" CssClass="Text" Width="200px" />
                                            <cc1:FilteredTextBoxExtender ID="txtCoast_filtered" runat="server" FilterType="Custom" ValidChars=".0123456789" TargetControlID="txtCoast" />
                                            <asp:label ID="EGY_POUND" runat="server" Text="ج.م" Font-Bold="True" 
                                            Font-Size="Larger" ForeColor="Black"  />
                                    </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                               <tr>
                                <td colspan="2" dir="rtl">
                             <table id="tblfinance" runat="server" width="100%" dir="rtl">
                                <tr>
                                    <td valign="top" align="right" colspan="2">
                                        <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                            <tr >
                                                <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                                                    <img border="0" id="image1" src="../Images/square_arrow_down.gif" />
                                                </td>
                                                <td 
                                                    onmouseover="this.style.cursor='hand'" 
                                                    onclick="ChangeMeCase('div1','image1');" colspan="1">
                                                    تفاصيل الميزانية
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="div1" style="display: block">
                                            <table id="Table2" width="100%" border="1" frame="border" 
                                                style="border-color: #000000">
                                                <tr>
                                <td align="right" dir="rtl" style="width: 123px" >
                                        <asp:Label ID="label5" runat="server" CssClass="Label" 
                                            Text="الربع السنوى:" />
                                    </td>
                                <td align="right" style="width: 264px">
                                        <asp:DropDownList ID="Quarter" runat="server" CssClass="Button" 
                                            DataSourceID="SqlDataSource1" DataTextField="Quarter_Name" 
                                            DataValueField="Quarter_NO" Width="240px" AutoPostBack="True" 
                                            Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" dir="rtl" style="width: 49px" >
                                        <asp:Label ID="label7" runat="server" CssClass="Label" 
                                            Text="السنة:" />
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="Quarter_year" runat="server" CssClass="Button" 
                                            Width="150px" AutoPostBack="True" Enabled="False">
                                        </asp:DropDownList>
                                   
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ConnectionString%>" 
                                            SelectCommand="SELECT [Quarter_NO], [Quarter_Name] FROM [Project_Period_Quarter]">
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" dir="rtl" colspan="4" >
                        <asp:GridView ID="provide_src" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="67%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                    
                                 <ItemTemplate>
                                     <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Sources_ID")%>' runat="server" />
                                     <asp:HiddenField ID="HiddenField2" Value='' runat="server" />
                                        <center> <%#Eval("Source_Name")%></center>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="القيمة" HeaderStyle-Width="20%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                 <ItemTemplate  >
                                        
                                        <center>
                                      <asp:TextBox ID="txtpartamount" runat="server" Text='<%# Eval("Value")%>'  
                                             Width="100px" Height="30px"></asp:TextBox>
                                            <asp:label ID="EGY_POUND0" runat="server" Text="ج.م" Font-Bold="True" 
                                            Font-Size="Larger" ForeColor="Black"  />
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom" ValidChars=".0123456789" TargetControlID="txtpartamount" />
                                     </center>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Center"/>  
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
                                    <td colspan="4">
                                        <asp:Button ID="btnpartfinance" runat="server" CssClass="Button" Text=" حفـــظ الفترة" 
                                             Height="30px"  ValidationGroup="A"/>
                                             
                                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="A"
                                        ShowMessageBox="True" ShowSummary="False" />
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Button ID="Button1" runat="server" CssClass="Button" Text="فترة جديدة" 
                                             Height="30px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" dir="rtl" colspan="4">
                    <asp:GridView ID="grdView_Main" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="70%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" CssClass="GridAct" ShowHeader="False" AlternatingRowStyle-CssClass="altAct"
                        Font-Size="17px" OnRowCommand="grdView_Main_RowCommand" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                        <tr style="background-color: #C2DDF0">
                                            <td>
                                                <table width="100%">
                                                
                                                    <tr onclick="ChangeMeCase('<%#Eval("Period_ID")%>','<%#"ImL" & Eval("Period_ID")%>');"
                                                        onmouseover="this.style.cursor='hand'">
                                                        <td align="right" style="width:5%">
                                                            <img border="0" id='<%#"ImL" & Eval("Period_ID")%>' src="../Images/square_arrow_flipped.gif" />
                                                        </td>
                                                        <td align="right" style="width:85%">
                                                            <%#Eval("Quarter_Year") & "(" & Eval("Quarter_Name") & ")"%>
                                                        </td>
                                                        <td align="center" style="width:5%">
                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" CommandArgument='<%# Eval("Period_ID") %>' />
                                                        </td>
                                                        <td align="center" style="width:5%">
                                                        <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                                                                    Style="height: 22px;" CommandArgument='<%# Eval("Period_ID") %>' />
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-right: 40px;">
                                                <div id='<%#Eval("Period_ID")%>' style="display: none">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdView_Sub" runat="server" DataSource='<%#GetDataSet(Eval("Period_ID").ToString())%>'
                                                                    ShowHeader="False" AutoGenerateColumns="False" CellPadding="4"
                                                                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                                                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="80%" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80%" >
                                                                         <ItemTemplate  >
                                                                                <%#Eval("Source_Name")%>
                                                                         </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                                                            <ItemStyle Width="80%" HorizontalAlign="Center"/>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="المبلغ" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                                                                         <ItemTemplate  >
                                                                                <%#Eval("Value")%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Center"/>
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
            <td align="center" dir="rtl" style="text-align: center" class="Text" colspan="4">
                <asp:GridView ID="gvfinance" runat="server" CssClass="mGrid" 
                    AutoGenerateColumns="False" Width="100%" AllowSorting="True" 
                    Visible="False" EmptyDataText="... عفوا لا توجد تفاصيل للميزانية ..." 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <%--<asp:BoundField DataField="PDOC_FileName" HeaderText="اسم الوثيقة" />--%>
                       <asp:BoundField HeaderText="تاريخ بداية الفترة" DataField="Strt_Date" />
                       <asp:BoundField HeaderText="تاريخ نهاية الفترة" DataField="End_Date" />
                       <asp:BoundField HeaderText="القيمة" DataField="int_Init_Value" />
                            <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="5%">
                                <ItemTemplate>
                                
                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="finance_ImgBtnEdit_Click"
                                        CommandArgument='<%# Eval("Period_ID") %>' />
                                </ItemTemplate>

                          <ItemStyle Width="5%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حذف" ItemStyle-Width="5%">
                                <ItemTemplate>
                                  
                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif" OnClick="finance_ImgBtnDelete_Click"
                                        CommandArgument='<%# Eval("Period_ID") %>' />
                                </ItemTemplate>

                     <ItemStyle Width="5%"></ItemStyle>
                            </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                </asp:GridView>
                
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
                <td colspan="2" dir="rtl">
             <table id="tbldoc1" runat="server" width="100%" dir="rtl">
                <tr>
                    <td valign="top" align="right" colspan="2">
                        <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                            <tr >
                                <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div0','image0');">
                                    <img border="0" id="image0" src="../Images/square_arrow_down.gif" />
                                </td>
                                <td 
                                    onmouseover="this.style.cursor='hand'" 
                                    onclick="ChangeMeCase('div0','image0');" colspan="2">
                                    وثائق المشروع
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                        <td colspan="2">
                            <div id="div0" style="display: block">
                                <table id="tbldoc" width="100%" border="1" frame="border" 
                                    style="border-color: #000000">
                                    <tr>
                    <td align="right" dir="rtl" style="width: 123px" >
                            <asp:Label ID="label12" runat="server" CssClass="Label" 
                                Text="ملف المشروع:" />
                        </td>
                    <td align="right" dir="rtl">
                            <asp:FileUpload ID="DocUpload" runat="server" CssClass="Button" Width="99%" 
                                onchange="Get_Value()"/>
                                
                           
                    </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl" style="width: 123px" >
                     <asp:Label ID="lblname" runat="server" Text="اسم الوثيقة: " CssClass="Label"></asp:Label>
                        </td>
                        <td align="center" dir="rtl" >
                        <asp:TextBox ID="txtDocName" runat="server"  
                                CssClass="Text" Width="99%" Height="30px"></asp:TextBox>
                                  <br />
                            <asp:Button ID="BtnDocUpload" runat="server" CssClass="Button" Text="حفظ الوثيقة" 
                                ValidationGroup="a" Height="30px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtDocName" Display="Dynamic" 
                                ErrorMessage="لابد من إدخال وثيقة" Font-Bold="True" Font-Size="12pt" 
                                ValidationGroup="a"></asp:RequiredFieldValidator>
                                
                           
                            <br />
                                            
                                       
                                    </td>
                                </tr>
                                       <tr>
            <td align="center" dir="rtl" style="text-align: center" class="Text" colspan="2">
                <asp:GridView ID="GView" runat="server" CssClass="mGrid" 
                    AutoGenerateColumns="False" Width="100%" AllowSorting="True" 
                    Visible="False" EmptyDataText="... عفوا لا توجد وثائق ..." 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <%--<asp:BoundField DataField="PDOC_FileName" HeaderText="اسم الوثيقة" />--%>
                        <asp:TemplateField HeaderText="وثيقة المشروع" ItemStyle-Width="90%">
                           <ItemTemplate >
                                  
                                       <input id="PDOC_id1" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>'/>
                                       <a href='<%# "Peoject_Document_Details.aspx?PDOC_id=" & Eval("PDOC_id") %>'  ><%# Eval("PDOC_FileName") %></a>
                                      
                                    
                           </ItemTemplate>

<ItemStyle Width="90%"></ItemStyle>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="تعديل" ItemStyle-Width="5%">
                                <ItemTemplate>
                                   <input id="PDOC_id2" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>'/>
                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="Doc_ImgBtnEdit_Click"
                                        CommandArgument='<%# Eval("PDOC_id") %>' />
                                </ItemTemplate>

<ItemStyle Width="5%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حذف" ItemStyle-Width="5%">
                                <ItemTemplate>
                                   <input id="PDOC_id3" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>'/>
                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif" OnClick="Doc_ImgBtnDelete_Click"
                                        CommandArgument='<%# Eval("PDOC_id") %>' />
                                </ItemTemplate>

<ItemStyle Width="5%"></ItemStyle>
                            </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                </asp:GridView>
                
            </td>
            
        </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                <tr align="center" >
                                
                                   
                                      
                                      <%-- <asp:GridView ID="GViewDoc" runat="server" CssClass="mGrid"> 
                                           
                                            <Columns>
                                <asp:BoundField HeaderText="اسم الوثيقة" DataField="PDOC_FileName"/>
                               <asp:TemplateField HeaderText="عرض الوثيقة">
                               <ItemTemplate>
                               <input id="PDOC_id" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>' />
                            <asp:LinkButton ID="Linkview" runat="server" PostBackUrl='<%# "~/WebForms2/Peoject_Document_Details.aspx?PDOC_id=" & Eval("PDOC_id") %>'>عرض الوثيقة</asp:LinkButton>
                            </ItemTemplate>
                            
                          </asp:TemplateField>
                                 <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgEdit_Click"
                                            CommandArgument='<%# Eval("PDOC_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="../Images/delete.gif"
                                         OnClick="ImgDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PDOC_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                            </Columns>
                             </asp:GridView>--%>
                                    
                                      
                                  </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnAnother" runat="server" CssClass="Button" 
                                            Text="إدخال مقترح آخر" Width="140px" Visible="False" />
                                    </td>
                                </tr>
                                
 <tr>
                        <td dir="rtl" class="Text" colspan="2" align="center">
                            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" 
                                BorderStyle="Solid"  CssClass="mGrid"
                                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                Visible="False" BorderWidth="1px" GridLines="Vertical">
                                <Columns>
                                    <asp:BoundField HeaderText="اسم الادارة" DataField="Dept_name" />
                                    <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                    <asp:BoundField HeaderText="مدير المشروع" DataField="PTem_Name" />
                                    <%-- <asp:TemplateField HeaderText =" ????? ???????">
                                    <ItemTemplate >
                                  
                                       <input id="PDOC_id1" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>'/>
                                      
                                      <asp:LinkButton ID="Linkview" runat="server"  Text='<%# Eval("PDOC_FileName") %>' PostBackUrl='<%# "~/WebForms2/Peoject_Document_Details.aspx?PDOC_id=" & Eval("PDOC_id") %>'> </asp:LinkButton>
                                    
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="تعديل" Visible="false">
                                        <ItemTemplate>
                                            <input id="Proj_id" runat="server" type="hidden" value='<%# Eval("Proj_id") %>'/>
                                            <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                CommandArgument='<%# Eval("Proj_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="حذف" Visible="false">
                                        <ItemTemplate>
                                        <input id="Proj_id1" runat="server" type="hidden" value='<%# Eval("Proj_id") %>'/>
                                          &nbsp;&nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                            OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Proj_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                </Columns>

                                <FooterStyle BackColor="#CCCCCC" />

           <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />

     <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
     </asp:GridView>
         </td>
                    </tr>
                            </table>
                        </td>
                    </tr>
                                         
                   
                   
                </table>
            </td>
        </tr>
        
    </table>
    
</asp:Content>
