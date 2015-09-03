<%@ Control Language="VB" AutoEventWireup="true" CodeFile="BudDetails.ascx.vb" Inherits="UserControls_BudDetails" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    #Table1
    {
        height: 960px;
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
                                    <td dir="rtl">
                                        <table id="tblfinance" runat="server" width="100%" dir="rtl">
                                            <tr>
                                                <td valign="top" align="right" colspan="2">
                                                    <table width="100%" cellpadding="0" cellspacing="0" style="height: 14px">
                                                        <tr >
                                                            <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1','image1');">
                                                                <img border="0" id="image1" src="../Images/square_arrow_down.gif" />
                                                            </td>
                                                            <td 
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
                                                                <td align="right" colspan="4">
                                                                    <asp:Label ID="label7" runat="server" CssClass="Label" Text="السنة المالية:" />
                                                                    &nbsp;
                                                                    <asp:DropDownList ID="Quarter_year" runat="server" CssClass="Button" Width="150px">
                                                                 <%--   <asp:ListItem Text="2008/2007" Value="2007"></asp:ListItem>
                                                                   <asp:ListItem Text="2009/2008" Value="2008"></asp:ListItem>
                                                                   <asp:ListItem Text="2010/2009" Value="2009"></asp:ListItem>
                                                                   <asp:ListItem Text="2011/2010" Value="2010"></asp:ListItem>
                                                                   <asp:ListItem Text="2012/2011" Value="2011"></asp:ListItem>
                                                                   <asp:ListItem Text="2013/2012" Value="2012"></asp:ListItem>
                                                                   <asp:ListItem Text="2014/2013" Value="2013"></asp:ListItem>
                                                                   <asp:ListItem Text="2015/2014" Value="2013"></asp:ListItem>
                                                                   <asp:ListItem Text="2016/2015" Value="2013"></asp:ListItem>
                                                                   <asp:ListItem Text="2017/2016" Value="2013"></asp:ListItem>
                                                                   <asp:ListItem Text="2018/2017" Value="2013"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" dir="rtl" colspan="4">
                                                                    <!--
                                                                    <asp:GridView ID="provide_src" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                                                        BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                                                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
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
                                                                        <PagerStyle CssClass="pgr" />
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                    </asp:GridView>
                                                                    -->
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:GridView ID="Grid_Supply" runat="server" AutoGenerateColumns="False" CellPadding="3"
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
                                                                                                    <tr onclick="ChangeMeCase('<%#"DV" & Eval("Sources_ID")%>','<%#"Src" & Eval("Sources_ID")%>');"
                                                                                                        onmouseover="this.style.cursor='hand'">
                                                                                                        <td align="right" style="width: 5%">
                                                                                                            <img border="0" id='<%#"Src" & Eval("Sources_ID")%>' src="../Images/square_arrow_flipped.gif" />
                                                                                                        </td>
                                                                                                        <td align="right" style="width: 85%">
                                                                                                            <%#Eval("Source_Name")%>
                                                                                                            <asp:HiddenField ID="Sources_ID" runat="server" Value='<%#Eval("Sources_ID")%>' />
                                                                                                        </td>
                                                                                                        <td align="center" style="width: 5%">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td align="center" style="width: 5%">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="padding-right: 40px;">
                                                                                                <div id='<%#"DV" & Eval("Sources_ID")%>' style="display: none">
                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:GridView ID="Grid_Supply_Sub" runat="server" DataSource='<%#GetDataSetProvider(Eval("Sources_ID").ToString())%>'
                                                                                                                    AutoGenerateColumns="False" CellPadding="4" Width="99%" BackColor="White" ForeColor="Black"
                                                                                                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                                                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderText="مصدر التمويل" HeaderStyle-Width="70%" HeaderStyle-HorizontalAlign="Center"
                                                                                                                            ItemStyle-Width="70%">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:HiddenField ID="AmountValue" Value='' runat="server" />
                                                                                                                                <asp:HiddenField ID="Provider_ID" runat="server" Value='<%#Eval("Provider_ID")%>' />
                                                                                                                                <%#Eval("Provider_Name")%>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="70%" />
                                                                                                                            <ItemStyle Width="70%" HorizontalAlign="Center" />
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
                                                                                                                        <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="تم إستلام الشيك" HeaderStyle-Width="5%"
                                                                                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                                                                                            <ItemTemplate>
                                                                                                                                <center>
                                                                                                                                    <asp:CheckBox ID="Cheque_Received" Visible='<%# Eval("Cheque")%>' runat="server" />
                                                                                                                                </center>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
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
                                                                                                    <tr>
                                                                                                        <td align="right" style="width: 5%">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td align="right" style="width: 85%">
                                                                                                            <%#Eval("Quarter_Year")%>
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
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td dir="rtl" class="Text" align="center">
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
</div>
