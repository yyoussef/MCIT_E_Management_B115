<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Smart_Search.ascx.cs"
    Inherits="Smart_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>

<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

  
<link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css"
        rel="stylesheet" />
    <link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css"
        rel="stylesheet" />


    <script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>

    <script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>

    <script type="text/javascript">

        function dndStartHandler(elem) {

        }
        function dndCompletingHandler(elem, newParent) {

        }
        function dndCompletedHandler2(elem) {
            var curNodeValue = elem.parentNode.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=btnPostBackTrigger2.ClientID %>').click();
        }
        function dndCompletedHandler(elem, newParent) {
            var curNodeValue = elem.getAttribute("treeNodeValue");
            var newParentValue = newParent.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
            document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
        }

        function fireClick() {
            alert('');
            document.getElementById('<%=btnPostBackTrigger3.ClientID %>').click();
            alert('');
        }

 
    </script>
<script language="javascript" type="text/javascript">
    function ChangeDivCase(id) {


        // alert(id);
        var divname = document.getElementById(id);


        if (divname != null) {

            //     if( divname.style.display != "none")
            //    {
            // alert(divname.style.display );
            //divname.style.display = divname.style.display == 'none' ? 'block' : 'none';

            divname.style.display = 'block';
            // }
        }   //alert(divname.style.display);
    }




</script>

<script type="text/javascript">
    document.onclick = check;
    function check(e) {
        if (event.srcElement.id.indexOf('txt_Name') < 0 && event.srcElement.id.indexOf('txt_Id') < 0) {
            var target = (e && e.target) || (event && event.srcElement);
            var elem = document.getElementsByTagName("div");
            for (var i = 0; i < elem.length; i++) {
                if (elem[i].id.indexOf("Div_Rdo_btn") >= 0 || elem[i].id.indexOf("Div_Grid") >= 0) {
                    var obj = document.getElementById(elem[i].id);
                    obj.style.display = 'none';
                }
            }
        }
    }

 

</script>

 
<style type="text/css">
    .Grd_Search
    {
        width: 100%;
        background-color: #fff;
        margin: 5px 5px 10px 0;
        border: solid 1px #A1D4E9;
        border-collapse: collapse;
    }
    .Grd_Search .altSeearch
    {
        /*background-color: #EEEEEE;*/
        background: #ffffff url(../grd_alt.png) repeat-x top;
    }
    .Grd_Search .pgrSeearch
    {
        background: #C2DDF0 url(../grd_pgr.png) repeat-x top;
    }
    .Grd_Search .thSearch
    {
        padding: 4px 2px;
        color: #000000;
        background: #C2DDF0 url(../grd_head.png) repeat-x top;
        border: solid 1px #3A5976;
        font-size: 0.9em;
    }
</style>

<div id="main" style="font-size: medium">
    <table cellpadding="0" cellspacing="0"  >
        <tr>
            <td>
                <div  runat="server" id="Div_Code" onclick="ChangeDivCase('<%=Div_Grid.ClientID%>');">
                    <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txt_Id"
                        WatermarkText="--- البحث بالكود ----" WatermarkCssClass="watermarked" />
                    <asp:TextBox ID="txt_Id" AutoPostBack="true" BackColor="#C8C8C8" OnTextChanged="txt_Id_TextChanged"
                        runat="server" Width="80px" ></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_Id"
                                        ValidChars="0987654321" Enabled="True"  />
                </div>
            </td>
            <td>
                <div onclick="ChangeDivCase('<%=Div_Grid.ClientID%>');">
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txt_Name"
                        WatermarkText="--- البحث بالإسم ----" WatermarkCssClass="watermarked" />
                    <asp:TextBox ID="txt_Name" runat="server" BackColor="#C8C8C8" Width="200px" AutoPostBack="true"
                        OnTextChanged="txt_Name_TextChanged"  ></asp:TextBox>
                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_Name"
                            Enabled="True"  FilterMode="InvalidChars"  InvalidChars="+-=*()'_[]@%$#^~?;:\,’&}{|><"  FilterType="UppercaseLetters,LowercaseLetters"/>
           


                        
                </div>
            </td>
            <td>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Visible="false" ControlToValidate="lbl_Value"
                        runat="server" Text="*" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </td>
               <td>
              <%-- <asp:LinkButton ID="btn_show_tree" runat="server" OnClick ="btn_show_Click" Text="عرض الهيكل التنظيمي" Visible="false" >
               
               </asp:LinkButton>--%>
               
                <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" ImageUrl="~/Images/organizational-chart.jpg"
                        ToolTip="عرض الهيكل التنظيمي" Width="30px" OnClick="btn_show_Click"  Visible="false"/>
           </td>
            <td>
                <div>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/Images/Clear.jpg"
                        ToolTip="مسح" Width="30px" OnClick="btn_Clear_Click" />
                </div>
            </td>
            <td>
                <div onmouseover="ChangeDivCase('<%=Div_Rdo_btn.ClientID%>');">
                    <asp:ImageButton ID="btn_Search" runat="server" Height="25px" ImageUrl="~/Images/search.jpg"
                        Width="30px" OnClick="btn_Search_Click" />
                </div>
            </td>
            <td valign="top" style="padding-right: 0px">
                <div id="Div_Rdo_btn" runat="server" style="position: absolute; display: none; background-color: #C2DDF0;
                    width: 90px; height: 70px; padding: 2px; color: black; border: 2px solid #C4C4C4;">
                    <asp:RadioButtonList ID="rdl_Search" runat="server">
                        <asp:ListItem Text="يحتوى على" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="يبدأبـــ" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </td>
           
        </tr>
        <tr>
            <td colspan="6" valign="top"  >
                <div id="Div_Grid" runat="server" style="position: absolute; display: none; background-color: White;
                    vertical-align: top; padding-right: 10px; width:350px;  padding: 0px; color: black;
                    border: 2px solid #C4C4C4;">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td valign="top">
                                <asp:GridView ID="Grdvew_Search" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="100%" BackColor="White" ForeColor="Black" BorderColor="#3366CC" BorderStyle="None"
                                    BorderWidth="0px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="Grd_Search"
                                    HeaderStyle-CssClass="thSearch" PagerStyle-CssClass="pgrSeearch" AlternatingRowStyle-CssClass="altSeearch"
                                    OnRowCommand="Grdvew_Search_RowCommand" AllowPaging="true" PageSize="10" OnDataBound="Grdvew_Search_DataBound">
                                    <PagerSettings Mode="NextPreviousFirstLast" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="الكود">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk1" CommandName="Select" runat="server" CommandArgument='<%# Eval(Value_Field)+","+Eval(Text_Field) %>'
                                                    Text='<%# Eval(Value_Field) %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="الاسم">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnk2" CommandName="Select" runat="server" CommandArgument='<%# Eval(Value_Field)+","+Eval(Text_Field) %>'
                                                    Text='<%# Eval(Text_Field) %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="img_btn_first" CommandName="first" runat="server" ToolTip="الأول"
                                                        ImageUrl="~/Images/page-first.gif" />
                                                    <asp:ImageButton ID="img_btn_prev" CommandName="prev" ToolTip="السابق" runat="server"
                                                        ImageUrl="~/Images/page-prev.gif" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Page_Info" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="img_btn_nextPage" CommandName="nextPage" runat="server" ToolTip="التالى"
                                                        ImageUrl="~/Images/page-next.gif" />
                                                    <asp:ImageButton ID="img_btn_lastPage" CommandName="lastPage" ToolTip="الأخير" runat="server"
                                                        ImageUrl="~/Images/page-last.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Bottom"></PagerStyle>
                                    <AlternatingRowStyle CssClass="altSeearch"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>


<div>
    <asp:TextBox ID="lbl_Value" runat="server" Style="display: none"></asp:TextBox>
    <input type="hidden" runat="server" id="hidden_Value" />
    <input type="hidden" runat="server" id="hidden_Searched" value="2" />
    <asp:TextBox ID="hiden_Query" runat="server" Visible="false"></asp:TextBox>
    <%--<input type="hidden" runat="server" id="hiden_Query" />--%>
    <asp:TextBox Visible="false" runat="server" ID="hiden_Con_Query" />
    <asp:TextBox Visible="false" runat="server" ID="Txt_Original_Query" />
    <asp:TextBox Visible="false" runat="server" ID="hiden_Orderby" />
    
    <asp:TextBox Visible="false" runat="server" ID="hidden_Text_Field" />
    <asp:TextBox runat="server" Visible="false" ID="hidden_Value_Field" />
</div>

<div id="divtree" runat="server"  style="position: absolute; display: none; background-color: White;
                    vertical-align: top; padding-right: 10px; width:350px;  padding: 0px; color: black;
                    border: 2px solid #C4C4C4;">   
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
                <div style="display: none">
                    <asp:TextBox ID="txtCurrentNode" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtNewParentNode" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPostBackTrigger" runat="server" OnClick="btnPostBackTrigger_Click" />
                    <asp:Button ID="btnPostBackTrigger2" runat="server" OnClick="btnPostBackTrigger2_Click" />
                    <asp:Button ID="btnPostBackTrigger3" runat="server" OnClick="btnPostBackTrigger3_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" dir="ltr" style="background-color: #F9fdff" align="right" >
                <ct:ASTreeView ID="astvMyTree" runat="server" BasePath="~/Javascript/astreeview/"
                    DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="true" EnableCheckbox="false"
                    EnableDragDrop="true" EnableTreeLines="true" EnableNodeIcon="true" BackColor="#F9FDFF"
                    EnableCustomizedNodeIcon="true" EnableContextMenu="true" EnableDebugMode="false"
                    EnableContextMenuAdd="false" OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
                    OnNodeSelectedScript="dndCompletedHandler2(elem)" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                    OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                    EnableEscapeInput="false" ForeColor="#F9FDFF" OnOnSelectedNodeChanged="astvMyTree_OnSelectedNodeChanged" AutoPostBack="true"   />
            </td>
        </tr>
  </table> 
        
 </div>

