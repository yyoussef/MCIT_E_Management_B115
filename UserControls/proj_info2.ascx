<%@ Control Language="VB" AutoEventWireup="true" CodeFile="proj_info2.ascx.vb" Inherits="UserControls_proj_info" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">

function ChangeMeCase(divid, imgid) {
    
    var divname = document.getElementById(divid);
    var img = document.getElementById(imgid);
    
    var imgsrc = img.src;
    

    if (imgsrc.lastIndexOf('collapse') != -1)
    { 
        img.src = "../Images/expand.gif";
    }
    else
    {
        img.src = "../Images/collapse.gif";
    }

    divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
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
    <input id="Proj_id" runat="server" value="" type="hidden" />
    <input id="Proj_id1" runat="server" type="hidden" />
    <input id="PDOC_id1" runat="server" type="hidden" />
    <input id="PDOC_id2" runat="server" type="hidden" />
    <input id="PDOC_id3" runat="server" type="hidden" /> 
    <table style="line-height: 2; width: 100%;">
        <tr>
            <td dir="rtl" align="center" colspan="4">
            <asp:HiddenField ID="Protocol_ID" runat="server" Value="0" />
                <asp:Label ID="lblPageStatus" runat="server" CssClass="Label" ForeColor="Red" Visible="false"></asp:Label>
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
                                        <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                                            Text="البيانات الأساسية للمشروع"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" dir="rtl">
                                        <table id="tbl_Smart_Project" runat="server" visible="false" dir="rtl" width="100%">
                                            <tr runat="server" id="tr_Smart_Project" >
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
                                    <td colspan="2" dir="rtl">
                                        <table id="Table1" runat="server" dir="rtl" width="100%">
                                            
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px">
                                                    <asp:Label ID="label1" runat="server" CssClass="Label" Text="ملخص المشــروع : " />
                                                </td>
                                                <td align="right" dir="rtl" colspan="1">
                                                    <asp:TextBox ID="txtProjBrief" runat="server" CssClass="Text" TextMode="MultiLine"
                                                        Height="215px" Width="99%" MaxLength="8000" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px">
                                                    <asp:Label ID="label3" runat="server" CssClass="Label" Text="تاريخ اقتراح  المشــروع : " />
                                                </td>
                                                <td align="right" colspan="1">
                                                    <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" TargetControlID="txtStartDate"
                                                        PopupButtonID="Image1" Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                    <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                                                        ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="Text" Width="90px" />
                                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                        AlternateText="اضغط لعرض النتيجة" Height="22px" Width="22px" ToolTip="تقويم" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px">
                                                    <asp:Label ID="label11" runat="server" CssClass="Label" Text="الأولويـــــــــــة :" />
                                                </td>
                                                <td align="right" dir="rtl" colspan="1">
                                                    <asp:DropDownList ID="DDLPriority" runat="server" CssClass="Button" Width="230px"
                                                        Height="25px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px">
                                                    <asp:Label ID="label6" runat="server" CssClass="Label" Text="نوع مقترح المشروع :" />
                                                </td>
                                                <td align="right" dir="rtl" colspan="1">
                                                    <asp:DropDownList ID="DDLSuggestType" runat="server" CssClass="Button" Width="230px"
                                                        Height="25px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px" valign="top">
                                                    <asp:Label ID="label17" runat="server" CssClass="Label" Text="تصنيف المشروع:" />
                                                </td>
                                                <td align="right" dir="rtl" colspan="1">
                                                     
                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                        dir="rtl" class="border">
                                        <asp:CheckBoxList ID="CheckCategory" CellPadding="5" CellSpacing="5" RepeatColumns="8"
                                            CssClass="Label" Font-Size="Small" RepeatDirection="Horizontal" 
                                            DataTextField="proj_category" DataValueField="id" runat="server" 
                                            DataSourceID="SqlCategory" RepeatLayout="Flow">
                                        </asp:CheckBoxList>
                                    </div>
                                                                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px" valign="top">
                                                    <asp:Label ID="label18" runat="server" CssClass="Label" 
                                                        Text="تقنية المشروع المستخدمة:-" />
                                                </td>
                                                <td align="right" dir="rtl" colspan="1">
                                    <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px"
                                        dir="rtl" class="border" >
                                        <asp:CheckBoxList ID="CheckTechnique" CellPadding="5" CellSpacing="5" RepeatColumns="6"
                                            CssClass="Label" Font-Size="Small" 
                                            DataTextField="technique" DataValueField="id" runat="server" 
                                            DataSourceID="SqlTechnique">
                                        </asp:CheckBoxList>
                                    </div>
                                                                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right" dir="rtl" style="width: 199px">
                                                    <asp:Label ID="label4" runat="server" CssClass="Label" Text="ميزانية المشروع : " />
                                                </td>
                                                <td align="right" colspan="1">
                                                    <asp:TextBox ID="txtCoast" runat="server" CssClass="Text" Width="225px" />
                                                    <cc1:FilteredTextBoxExtender ID="txtCoast_filtered" runat="server" FilterType="Custom"
                                                        ValidChars=".0123456789" TargetControlID="txtCoast" />
                                                    <asp:Label ID="EGY_POUND" runat="server" Text="ج.م" Font-Bold="True" Font-Size="Larger"
                                                        ForeColor="Black" />
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
                                                        <tr bgcolor="#E6F3FF">
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                                                                <img border="0" id="image1" src="../Images/expand.gif" />
                                                            </td>
                                                            <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                                                                onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');"
                                                                colspan="1">
                                                                تفاصيل الميزانية
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="div1" style="display: block">
                                                        <table id="Table2" width="100%" class="border">
                                                            <tr>
                                                                <td align="right" dir="rtl" style="width: 123px">
                                                                    <asp:Label ID="label5" runat="server" CssClass="Label" Text="الربع السنوى:" />
                                                                </td>
                                                                <td align="right" style="width: 264px">
                                                                    <asp:DropDownList ID="Quarter" runat="server" CssClass="Button" DataSourceID="SqlDataSource1"
                                                                        DataTextField="Quarter_Name" DataValueField="Quarter_NO" Width="240px" 
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right" dir="rtl" style="width: 49px">
                                                                    <asp:Label ID="label7" runat="server" CssClass="Label" Text="السنة:" />
                                                                </td>
                                                                <td align="right">
                                                                    <asp:DropDownList ID="Quarter_year" runat="server" CssClass="Button" Width="150px"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString%>"
                                                                        SelectCommand="SELECT [Quarter_NO], [Quarter_Name] FROM [Project_Period_Quarter]">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" dir="rtl" colspan="4">
                                                                    <asp:GridView ID="provide_src" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                                                        GridLines="Vertical">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("Sources_ID")%>' runat="server" />
                                                                                    <asp:HiddenField ID="HiddenField2" Value='' runat="server" />
                                                                                    <center>
                                                                                        <%#Eval("Source_Name")%></center>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="القيمة" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-Width="20%">
                                                                                <ItemTemplate>
                                                                                    <center>
                                                                                        <asp:TextBox ID="txtpartamount" runat="server" Text='<%# Eval("Value")%>' Width="100px"
                                                                                            Height="30px"></asp:TextBox>
                                                                                        <asp:Label ID="EGY_POUND0" runat="server" Text="ج.م" Font-Bold="True" Font-Size="Larger"
                                                                                            ForeColor="Black" />
                                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                                                                            ValidChars=".0123456789" TargetControlID="txtpartamount" />
                                                                                    </center>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="btnpartfinance" runat="server" CssClass="Button" Text=" حفـــظ الفترة"
                                                                        Height="30px" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="Button1" runat="server" CssClass="Button" Text="فترة جديدة" Height="30px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" dir="rtl" colspan="4">
                                                                    <asp:GridView ID="grdView_Main" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                                                        BorderWidth="1px" CssClass="GridAct" ShowHeader="False" AlternatingRowStyle-CssClass="altAct"
                                                                        Font-Size="17px" OnRowCommand="grdView_Main_RowCommand" 
                                                                        GridLines="Vertical">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr style="background-color: #C2DDF0">
                                                                                            <td>
                                                                                                <table width="100%">
                                                                                                    <tr onclick="ChangeMeCase('<%#Eval("Period_ID")%>','<%#"ImL" & Eval("Period_ID")%>');"
                                                                                                        onmouseover="this.style.cursor='hand'">
                                                                                                        <td align="right" style="width: 5%">
                                                                                                            <img border="0" id='<%#"ImL" & Eval("Period_ID")%>' src="../Images/collapse.gif" />
                                                                                                        </td>
                                                                                                        <td align="right" style="width: 85%">
                                                                                                            <%#Eval("Quarter_Year") & "(" & Eval("Quarter_Name") & ")"%>
                                                                                                        </td>
                                                                                                        <td align="center" style="width: 5%">
                                                                                                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                                                                                                CommandArgument='<%# Eval("Period_ID") %>' />
                                                                                                        </td>
                                                                                                        <td align="center" style="width: 5%">
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
                                                                                                                    ShowHeader="False" AutoGenerateColumns="False" CellPadding="4" Width="99%" BackColor="White"
                                                                                                                    ForeColor="Black" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                                                                                                    EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                                                                                    AlternatingRowStyle-CssClass="alt">
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="80%" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            ItemStyle-Width="80%">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%#Eval("Source_Name")%>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                                                                                                            <ItemStyle Width="80%" HorizontalAlign="Center" />
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="المبلغ" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            ItemStyle-Width="20%">
                                                                                                                            <ItemTemplate>
                                                                                                                                <%#Eval("Value")%>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
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
                                                                    <asp:GridView ID="gvfinance" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                                                                        Width="100%" AllowSorting="True" Visible="False" 
                                                                        EmptyDataText="... عفوا لا توجد تفاصيل للميزانية ..." BackColor="White" 
                                                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                                                        ForeColor="Black" GridLines="Vertical">
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
                                                                                    <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                                                        OnClick="finance_ImgBtnDelete_Click" CommandArgument='<%# Eval("Period_ID") %>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="5%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle BackColor="#CCCCCC" />
                                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
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
                                    <td colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td dir="rtl" class="Text" colspan="2" align="center">
                                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                            Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                            CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                            Visible="False" BorderWidth="1px" GridLines="Vertical">
                                            <Columns>
                                                <asp:BoundField HeaderText="اسم الادارة" DataField="Dept_name" />
                                                <asp:BoundField HeaderText="اسم المشروع" DataField="Proj_Title" />
                                                <asp:BoundField HeaderText="مدير المشروع" DataField="PTem_Name" />
                                                <asp:TemplateField HeaderText="تعديل" Visible="false">
                                                    <ItemTemplate>
                                                        <input id="Proj_id" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                                            CommandArgument='<%# Eval("Proj_id") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="حذف" Visible="false">
                                                    <ItemTemplate>
                                                        <input id="Proj_id1" runat="server" type="hidden" value='<%# Eval("Proj_id") %>' />
                                                        &nbsp;&nbsp;<asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                                            OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("Proj_id") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                                                HorizontalAlign="Center"></PagerStyle>
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:SqlDataSource ID="SqlTechnique" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT * FROM [Technique]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlCategory" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    