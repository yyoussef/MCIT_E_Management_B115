<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_Activities.ascx.cs" Inherits="UserControls_Project_Activities" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>


 <link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css"
        rel="stylesheet" />
    <link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css"
        rel="stylesheet" />

    <script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>

    <script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>

    <script type="text/javascript">

	function dndStartHandler(elem) 
	{
	
	}
	function dndCompletingHandler(elem, newParent) 
	{
		
	}
	function dndCompletedHandler2(elem) 
	{
		var curNodeValue = elem.parentNode.getAttribute("treeNodeValue");
        document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
        document.getElementById('<%=btnPostBackTrigger2.ClientID %>').click();
	}
	function dndCompletedHandler(elem, newParent) 
	{
        var curNodeValue = elem.getAttribute("treeNodeValue");
        var newParentValue = newParent.getAttribute("treeNodeValue");
        document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
        document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
        document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
    }
    
    function fireClick() 
	{
	    alert('');
        document.getElementById('<%=btnPostBackTrigger3.ClientID %>').click();
        alert('');
    }
    
    
  </script>
   <script type="text/javascript">
       //variable that will store the id of the last clicked row
       var previousRow;

       function ChangeRowColor(row) {
           //If last clicked row and the current clicked row are same
           if (previousRow == row)
               return; //do nothing
           //If there is row clicked earlier
           else if (previousRow != null)
           //change the color of the previous row back to white
               document.getElementById(previousRow).style.backgroundColor = "#8AADC6";

           //change the color of the current row to light yellow

           document.getElementById(row).style.backgroundColor = "#B1B1B1";
           //assign the current row id to the previous row id 
           //for next row to be clicked
           previousRow = row;
       }
     </script>
  
  
   <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="أنشطة المشروع" />
            </td>
        </tr>
         <tr style="background: orange">
                <td align="center">
                    <asp:Label ID="lbl1" Text="نسبة انجاز المشروع :" runat="server" ForeColor="#EC981F" font-underline="false" Font-Bold="true"
                        Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblProgProgress" runat="server" ForeColor="#EC981F" font-underline="false" Font-Bold="true" Font-Size="Large"></asp:Label>
                </td>
            </tr>
        
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
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
            <td colspan="4" dir="ltr" style="background-color: #F9fdff" align="right">
                <ct:ASTreeView ID="astvMyTree" runat="server" BasePath="~/Javascript/astreeview/"
                    DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="true" EnableCheckbox="false"
                    EnableDragDrop="true" EnableTreeLines="true" EnableNodeIcon="true" BackColor="#F9FDFF"
                    EnableCustomizedNodeIcon="true" EnableContextMenu="true"  EnableDebugMode="false"
                    EnableContextMenuAdd="false" OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
                    OnNodeSelectedScript="dndCompletedHandler2(elem)" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                    OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                    EnableEscapeInput="false" ForeColor="#F9FDFF"    />
            </td>
        </tr>
        
        
         
            
            
         <tr>
            <td colspan="4" align="center">
                 <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Top" CellPadding="3" 
                        CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..." Font-Size="10pt" 
                        Font-Strikeout="False"  font-underline="false" ForeColor="Black" OnPreRender="gvSub_PreRender1"
                         PagerStyle-CssClass="pgr"     onrowdatabound="gvSub_RowDataBound" OnRowCommand="GrdView_RowCommand"
                     GridLines="Vertical"  >
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="3px" 
                                HeaderText="م" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3px">
                                <ItemTemplate>
                                    <%#Eval("Parent_Actv_Num")%>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="3px"></ItemStyle>
                            </asp:TemplateField>
                            
                                    <asp:BoundField DataField="parent" HeaderText="النشاط الرئيسى" HeaderStyle-Width="200px"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                <HeaderStyle Width="200px" />

<ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                        
                            <asp:BoundField DataField="PActv_Desc2" HeaderStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="200px" HeaderText=" النشاط الفرعى" ItemStyle-Width="200px">
                                <HeaderStyle Width="200px" />

<ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                         
                               <asp:TemplateField HeaderText="تاريخ البدايه" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="70px" Text='<%#Eval("PActv_Start_Date")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                         
                           <asp:TemplateField HeaderText="تاريخ الانتهاء" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="70px" Text='<%#Eval("PActv_End_Date")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtEndDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                      
                             <asp:TemplateField HeaderText="المـده" ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPeriod" runat="server" Width="35px" Text='<%#Eval("PActv_Period")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtPeriod_filtered" runat="server" FilterType="Numbers"
                                        TargetControlID="txtPeriod" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="35px" />
                            </asp:TemplateField>
                            
                         
                                  <asp:TemplateField HeaderText="تاريخ البدايه الفعلى" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtActualStartDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_Start_Date")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtActualStartDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtActualStartDate" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            
                         
                          <asp:TemplateField HeaderText="تاريخ الانتهاء الفعلى" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtActualEndDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_End_Date")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtActualEndDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtActualEndDate" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            
                         <asp:TemplateField HeaderText="الوزن النسبى" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWeight" runat="server" Width="20px" Text='<%#Eval("PActv_wieght")%>' AutoPostBack="false"  OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtWeight_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321." TargetControlID="txtWeight" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            
                       
                            <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="35px" ItemStyle-Height="25px"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPregress" runat="server" Width="35px" Text='<%#Eval("PActv_Progress")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtPregress_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321." TargetControlID="txtPregress" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="35px" />
                            </asp:TemplateField>
                       
                                <asp:TemplateField HeaderText="مسئول التنفيذ" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtImplementingPerson" runat="server" Width="100px" Text='<%#Eval("PActv_Implementing_person")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            
                                  <asp:TemplateField HeaderText="مصدر التمويل" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtfund_id" runat="server" Visible="false" Text='<%#Eval("funding_res_id")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtfund_source" runat="server" Visible="false" Text='<%#Eval("funding_res_source")%>'></asp:TextBox>
                                    <asp:DropDownList ID="ddlFundResource" runat="server" Width="300px" CssClass="Button">
                                    </asp:DropDownList>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المبلغ" ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtfunds" runat="server" Width="75px" Text='<%#Eval("funding_amount")%>' AutoPostBack="false" OnTextChanged="txtWeight_TextChanged"></asp:TextBox>
                                    
                                     <input id="RowIndex" runat="server" type="hidden" />
                                    <asp:TextBox ID="txtLevel" runat="server" Visible="false" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtdat" runat="server" Visible="false" Text='<%#Container.DataItemIndex%>'></asp:TextBox>
                                    <asp:CheckBox ID="chk_chnged" Visible="false" runat="server" />
                                    
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="75px" />
                            </asp:TemplateField>
                            
                            
                            
                            
                            
                            
                            
                            
                        <%--    <asp:TemplateField HeaderText="حفظ" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <input id="RowIndex" runat="server" type="hidden" />
                                    <asp:TextBox ID="txtLevel" runat="server" Visible="false" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtdat" runat="server" Visible="false" Text='<%#Container.DataItemIndex%>'></asp:TextBox>
                                    <asp:Button ID="btnRowSave" runat="server" Text="حفظ" CommandName='<%#Container.DataItemIndex%>'
                                        CommandArgument='<%#Eval("PActv_ID")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="5px" />
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
            
            <td align="center">
            <asp:Button ID="btnRowSave" runat="server" Text="حفظ"  OnClick="btnRowSave_Click" Visible="false"  CssClass="Button" />
            </td>
            </tr>
        
        
        </table> 
        
