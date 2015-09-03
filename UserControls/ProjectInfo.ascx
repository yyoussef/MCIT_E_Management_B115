<%@ Control Language="VB" AutoEventWireup="true" CodeFile="ProjectInfo.ascx.vb" Inherits="UserControls_ProjectInfo"  %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 138px;
    }
    #Table1
    {
        height: 960px;
    }
    .style2
    {
        height: 64px;
    }
    .style3
    {
        width: 138px;
        height: 51px;
    }
    .style4
    {
        height: 51px;
    }
    .style9
    {
        width: 199px;
        height: 64px;
    }
    .style11
    {
        width: 199px;
        height: 49px;
    }
    .style12
    {
        height: 65px;
    }
    .style14
    {
        height: 46px;
    }
</style>

<script language="javascript" type="text/javascript">

function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('square_arrow_flipped') != -1)
    { 
        img.src = "../Images/square_arrow_down.gif";
    }
    else
    {
        img.src = "../Images/square_arrow_flipped.gif";
    }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
}
  


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

<div>
    <input id="Proj_id" runat="server" value="0" type="hidden" />
    <input id="Proj_id1" runat="server" type="hidden" />
    <input id="PDOC_id1" runat="server" type="hidden" />
    <input id="PDOC_id2" runat="server" type="hidden" />
    <input id="PDOC_id3" runat="server" type="hidden" />
    <input id="hidden_success" runat="server" type="hidden" />
</div>
<div>
    <table style="line-height: 2; width: 100%;">
        <tr>
            <td dir="rtl" align="center" colspan="4">
                <asp:HiddenField ID="Protocol_ID" runat="server" Value="0" />
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
                            <table id="tblnew" runat="server" visible="true" dir="rtl" width="100%">
                                <tr>
                                    <td dir="rtl" align="center">
                                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                                            Text="البيانات الأساسية للمشروع"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td dir="rtl">
                                        <table id="tbl_Smart_Project" runat="server" visible="false" dir="rtl" width="100%">
                                            <tr runat="server" id="tr_Smart_Project">
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم المشروع : " />
                                                </td>
                                                <td colspan="3" align="right">
                                                    <uc1:Smart_Search ID="Smart_Project_ID" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td dir="rtl">
                                        <table id="Table1" runat="server" dir="rtl" width="100%">
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label1" runat="server" CssClass="Label" Text="ملخص المشــروع : " />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtProjBrief" runat="server" CssClass="Text" TextMode="MultiLine"
                                                        Height="215px" Width="99%" MaxLength="8000" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label3" runat="server" CssClass="Label" Text="تاريخ اقتراح  المشــروع : " />
                                                </td>
                                                <td align="right">
                                                    <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                                                        PopupButtonID="Image1" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                    <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                                                        ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="lblstartproj" runat="server" CssClass="Label" Text="تاريخ بداية المشــروع : " />
                                                </td>
                                                <td align="right">
                                                    <cc1:CalendarExtender ID="txtprojstartdate_CalendarExtender" runat="server" TargetControlID="txtprojstartdate"
                                                        PopupButtonID="imgstartproj" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                    <cc1:FilteredTextBoxExtender ID="txtprojstartdate_filtered" runat="server" FilterType="Custom"
                                                        ValidChars="0987654321/\" TargetControlID="txtprojstartdate" />
                                                    <asp:TextBox ID="txtprojstartdate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                                    <asp:ImageButton runat="Server" ID="imgstartproj" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtprojstartdate"
                                                        ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)" ValidationGroup="xx"  ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$">
                                                        </asp:RegularExpressionValidator>
                                                       
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtStartDate"
                                                        ControlToValidate="txtprojstartdate" ErrorMessage="تاريخ بداية المشروع يجب ان يكون اكبر من او يساوي تاريخ اقتراح المشروع"
                                                        Operator="GreaterThanEqual"  Type="Date" ValidationGroup="xx" ></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="lblendproj" runat="server" CssClass="Label" Text="تاريخ نهاية  المشــروع : " />
                                                </td>
                                                <td align="right">
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtprojenddate"
                                                        PopupButtonID="imgendproj" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                                        ValidChars="0987654321/\" TargetControlID="txtprojenddate" />
                                                    <asp:TextBox ID="txtprojenddate" runat="server" CssClass="Text" Width="142px" Height="29px" />
                                                    <asp:ImageButton runat="Server" ID="imgendproj" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="ادخل التاريخ(يوم/شهر/سنة)"
                                                        ControlToValidate="txtprojenddate" 
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                                        ValidationGroup="xx"></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtprojstartdate"
                                                        ControlToValidate="txtprojenddate" ErrorMessage="تاريخ نهاية المشروع  يجب ان يكون اكبر من تاريخ البداية"
                                                        Operator="GreaterThan" ValidationGroup="xx" Type="Date"  ></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label11" runat="server" CssClass="Label" Text="الأولويـــــــــــة :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:DropDownList ID="DDLPriority" runat="server" CssClass="Button" Width="230px"
                                                        Height="25px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label2" runat="server" CssClass="Label" Text="الفرص  :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtOpportunities" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label5" runat="server" CssClass="Label" Text="الأخطار :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtDangers" runat="server" TextMode="MultiLine" Height="60px" Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label8" runat="server" CssClass="Label" Text="نقاط القوة :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtStrengths" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label9" runat="server" CssClass="Label" Text="نقاط الضعف :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtWeaknesses" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" class="style1">
                                                    <asp:Label ID="label12" runat="server" CssClass="Label" Text="منهجية التنفيذ :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtmethodology" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                             <tr>
                                                <td align="right" dir="rtl" class="style3">
                                                    <asp:Label ID="label7" runat="server" CssClass="Label" Text=" سبب إطلاق المشروع :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txt_cause" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                             <tr>
                                                <td align="right" dir="rtl" class="style3">
                                                    <asp:Label ID="label13" runat="server" CssClass="Label" Text="أوجه الإبتكار أو إلابداع  :" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txt_innovation" runat="server" TextMode="MultiLine" Height="60px"
                                                        Width="700px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            
                                            <tr>
                                                <td align="right" dir="rtl" class="style3">
                                                    <asp:Label ID="label6" runat="server" CssClass="Label" Text="نوع مقترح المشروع :" />
                                                </td>
                                                <td align="right" dir="rtl" class="style4">
                                                    <asp:DropDownList ID="DDLSuggestType" runat="server" CssClass="Button" Width="230px"
                                                        Height="25px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" valign="top" class="style12">
                                                    <asp:Label ID="label17" runat="server" CssClass="Label" Text=" التصنيف الفني للمشروع :" />
                                                </td>
                                                <td align="right" dir="rtl" valign="top" class="style12">
                                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; width: 75%"
                                                        dir="rtl" class="borderControl">
                                                        <asp:CheckBoxList ID="CheckCategory" CellPadding="2" CellSpacing="2" RepeatColumns="4"
                                                            Width="97%" CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" DataTextField="proj_category"
                                                            DataValueField="id" runat="server" DataSourceID="SqlCategory">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" valign="baseline">
                                                    <asp:Label ID="label19" runat="server" CssClass="Label" Text="تصنيفات أخري:" />
                                                </td>
                                                <td align="right" dir="rtl" valign="baseline" class="style14">
                                                    <asp:TextBox ID="txtCategory" runat="server" CssClass="Text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" valign="top" class="style9">
                                                    <asp:Label ID="label18" runat="server" CssClass="Label" Text="تقنية المشروع المستخدمة:" />
                                                </td>
                                                <td align="right" dir="rtl" valign="top" class="style2">
                                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; width: 75%"
                                                        dir="rtl" class="borderControl">
                                                        <asp:CheckBoxList ID="CheckTechnique" CellPadding="2" CellSpacing="2" RepeatColumns="4"
                                                            CssClass="Label" Font-Size="Small" DataTextField="technique" DataValueField="id"
                                                            runat="server" DataSourceID="SqlTechnique" Width="100%">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" valign="middle" class="style11">
                                                    <asp:Label ID="label20" runat="server" CssClass="Label" Text="تقنيات أخري:" />
                                                </td>
                                                <td align="right" dir="rtl">
                                                    <asp:TextBox ID="txtTech" runat="server" CssClass="Text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" rowspan="3">
                                                    <asp:Label ID="label4" runat="server" CssClass="Label" Text="ميزانية المشروع : " />
                                                </td>
                                                <td align="right" colspan="1" dir="rtl" width="300" class="style2">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtCoast" runat="server" CssClass="Text" Width="225px" AutoPostBack="True" />
                                                            <cc1:FilteredTextBoxExtender ID="txtCoast_filtered" runat="server" FilterType="Custom"
                                                                ValidChars=".0123456789" TargetControlID="txtCoast" />
                                                            <asp:Label ID="EGY_POUND" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black"
                                                                Text="ج.م" />
                                                            <asp:Label ID="Label10" runat="server" CssClass="Label" Text="" />
                                                            <asp:Label ID="EGY_POUND1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black"
                                                                Text="ج.م" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="1" dir="rtl" width="300">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" ValidationGroup ="xx"/>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:SqlDataSource ID="SqlTechnique" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            SelectCommand="SELECT * FROM [Technique]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="SqlCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
