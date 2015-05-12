<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Eval_For_Employee.ascx.cs"
    Inherits="UserControls_Eval_For_Employee" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">

    function Set_Degree1(e, txt) 
    {
        var rowIndex = txt.offsetParent.parentNode.rowIndex;
       
        var cellIndex = txt.offsetParent.cellIndex;
        var txt_id = txt.id;
        var Dll_id = txt_id.replace("txt_Top_Emp_Degree", "ddl_Top_Emp_Degree_Id");
        var dll_cntrl = document.getElementById(Dll_id)
        //change the select value here
        
      //  dll_cntrl.value = 1;
       
       
         if (txt.value >= 0 && txt.value < 60) {

            dll_cntrl.value  = 5;

        }
        else if (txt.value >= 60 && txt.value < 70) {
            dll_cntrl.value = 4;

        }
        else if (txt.value >= 70 && txt.value < 80) {
            dll_cntrl.value = 3;

        }
        else if (txt.value >= 80 && txt.value < 90) {
            dll_cntrl.value = 2;

        }
        else if (txt.value >= 90 && txt.value <= 100) {
             dll_cntrl.value = 1;

        }
        
          else {
          alert('ادخل أرقام من 1 الي 100 فقط')
             dll_cntrl.value = 0;
             txt.value =0

        }
      
       
        //alert(txt_id + "," + Dll_id);
        //alert(dll_cntrl.id)
    }
    
    function Set_Degree(e, txt) 
    {
        var rowIndex = txt.offsetParent.parentNode.rowIndex;
        var cellIndex = txt.offsetParent.cellIndex;
        var txt_id = txt.id;
        var Dll_id = txt_id.replace("txt_Direct_Emp_Degree", "ddl_Direct_Emp_Degree_Id");
        var dll_cntrl = document.getElementById(Dll_id)
        //change the select value here
        
      //  dll_cntrl.value = 1;
       
       
         if (txt.value >= 0 && txt.value < 60) {

            dll_cntrl.value  = 5;

        }
        else if (txt.value >= 60 && txt.value < 70) {
            dll_cntrl.value = 4;

        }
        else if (txt.value >= 70 && txt.value < 80) {
            dll_cntrl.value = 3;

        }
        else if (txt.value >= 80 && txt.value < 90) {
            dll_cntrl.value = 2;

        }
        else if (txt.value >= 90 && txt.value <= 100) {
             dll_cntrl.value = 1;

        }
        
          else {
          alert('ادخل أرقام من 1 الي 100 فقط')
             dll_cntrl.value = 0;
             txt.value =0

        }
      
       
        //alert(txt_id + "," + Dll_id);
        //alert(dll_cntrl.id)
    }
   
</script>

<table width="100%" style="line-height: 2; color: Black">
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="نموذج تقييم الأداء لموظف "></asp:Label>
        </td>
    </tr>
    <tr>
        <td dir="rtl" align="center" colspan="2">
            <input type="hidden" runat="server" id="hidden_Evaluation_id" />
            <input type="hidden" runat="server" id="hidden_direct_mngr" />
            <input type="hidden" runat="server" id="hidden_top_mngr" />
            <input type="hidden" runat="server" id="hidden_hr" />
            <input type="hidden" runat="server" id="hidden_Direct_emp_id" />
        </td>
    </tr>
    <tr runat="server" id="tr3">
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="أولا : البيانات الاساسية " />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%">
                <tr>
                    <td runat="server" visible="false"> 
                        <asp:Label ID="Label12" runat="server" CssClass="Label" Text=" القطاع : " />
                    </td>
                    <td runat="server" visible="false">
                        <asp:DropDownList ID="Ddl_Sectors" CssClass="drop" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="Sec_name" DataValueField="Sec_id" Width="200px" OnSelectedIndexChanged="Ddl_Sectors_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand=" select Sec_id,Sec_name from Sectors "></asp:SqlDataSource>
                    </td>
                    <%--<td>
                        <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" الإدارة : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="Smart_Search_Departments" runat="server" />
                    </td>--%>
                    <td>
                        <asp:Label ID="Label16" runat="server" CssClass="Label" Text=" اسم الموظف : " />
                    </td>
                    <td>
                        <uc1:Smart_Search ID="Smart_Pmp_Id" runat="server" EnableTheming="True" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" CssClass="Label" Text=" تاريخ التعيين : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Hire_date" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" CssClass="Label" Text=" المسمى الوظيفي : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_pmp_title" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" CssClass="Label" Text=" الرقم الوظيفي : " />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_job_no" Enabled="false" runat="server" Height="26px" CssClass="Text"></asp:TextBox>
                    </td>
                </tr>
             <tr id="tr_grade" runat="server" visible="false" >
             <td>
                    <asp:Label ID="Label11" runat="server" CssClass="Label" Text=" كيفية التقييم : "   />
                    </td>
                   <td>
                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text=" 100:90  ممتاز"  ForeColor="Red" />
                    </td>
                    <td>
                      <asp:Label ID="Label7" runat="server" CssClass="Label" Text=" 80 : أقل من 90 جيد جدا    " ForeColor="Red"  />

                    </td>
                    <td>
                      <asp:Label ID="Label8" runat="server" CssClass="Label" Text=" 70 : أقل من 80 جيد " ForeColor="Red" />

                    </td>
                    <td>
                      <asp:Label ID="Label9" runat="server" CssClass="Label" Text=" 60 : أقل من 70  متوسط " ForeColor="Red"  />

                    </td>
                    <td>
                      <asp:Label ID="Label10" runat="server" CssClass="Label" Text=" أقل من 60 ضعيف  " ForeColor="Red" />

                    </td>
             </tr> 
               
                    

                
         
               
                
               
            </table>
        </td>
    </tr>
    <tr runat="server" id="tr_Grid" visible="false">
        <td colspan="2">
            <table>
                <tr runat="server" id="tr2">
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text=" ثانيا : التقييم بتحديد الكفاءات الفنيه والمهنية والصفات الشخصية للموظف " />
                        <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                            GridLines="Vertical">
                            <Columns>
                              <asp:TemplateField HeaderText="مسلسل">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
                                <asp:TemplateField HeaderText="العنصر الرئيسى">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_name1" Text='<%#Eval("Main_Name")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العنصر الفرعى">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_name2" ToolTip='<%#Eval("ToolTip").ToString().Trim()%>'
                                            Text='<%#Eval("Sub_Name")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدرجة للرئيس المباشر">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="Text" onchange="Set_Degree(event,this);"  Rows="2" ID="txt_Direct_Emp_Degree" Text='<%#Eval("Direct_Emp_Degree")%>'
                                            Width="150px" MaxLength="3" OnTextChanged="txt_Direct_Emp_Degree_TextChanged" onkeydown = "return (event.keyCode!=13);">
                                        </asp:TextBox>
                                      
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" ادخل ارقام من 1 : 100 فقط"
                                            ValidationExpression="[0-9]*" ControlToValidate="txt_Direct_Emp_Degree" ValidationGroup="C" />
                                           
                                        <cc1:FilteredTextBoxExtender ID="txtEndDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321" TargetControlID="txt_Direct_Emp_Degree" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدرجة للرئيس المباشر">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl_Main_Item_Id" Text='<%#Eval("Main_Item_Id")%>'
                                            Visible="false" />
                                        <asp:Label runat="server" ID="lbl_Sub_Item_Id" Text='<%#Eval("Sub_Item_Id")%>' Visible="false" />
                                        <asp:DropDownList ID="ddl_Direct_Emp_Degree_Id" Enabled="false" runat="server" Width="150px"
                                            CssClass="drop" DataValueField="Degree_Id" DataTextField="Name" DataSourceID="SqlDepartments">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ملاحظات الرئيس المباشر">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="Text" Enabled='<%#Get_Enabled() %>' Text='<%#Eval("Direct_Emp_Note")%>'
                                            TextMode="MultiLine" Rows="2" ID="txt_Direct_Emp_Note" Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدرجة للرئيس الأعلى">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="Text" Rows="2" ID="txt_Top_Emp_Degree" Text='<%#Eval("Top_Emp_Degree")%>'
                                            Width="150px" MaxLength="3"   onchange="Set_Degree1(event,this);"  OnTextChanged="txt_Top_Emp_Degree_TextChanged" onkeydown = "return (event.keyCode!=13);"> 
                                            
                                            </asp:TextBox>
                                            
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage=" ادخل ارقام من 1 : 100 فقط"
                                            ValidationExpression="[0-9]*" ControlToValidate="txt_Top_Emp_Degree" ValidationGroup="C" />
                                            
                                             <cc1:FilteredTextBoxExtender ID="txtEndDate_filtered2" runat="server" FilterType="Custom"
                                        ValidChars="0987654321" TargetControlID="txt_Top_Emp_Degree" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الدرجة للرئيس الأعلى">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_Top_Emp_Degree_Id" runat="server" Width="150px" CssClass="drop"
                                            DataValueField="Degree_Id" DataTextField="Name" DataSourceID="SqlDepartments"
                                            Enabled="false">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ملاحظات للرئيس الأعلى">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Top_Emp_Note")%>' TextMode="MultiLine"
                                            Rows="2" ID="txt_Top_Emp_Note" Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                            </PagerStyle>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div align="center" width="100%">
                        </div>
                        <asp:SqlDataSource ID="SqlDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="select 0 as Degree_Id,'-- اختر-- ' as Name union SELECT Degree_Id,Name FROM Evaluation_Degree ">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEvalCourses" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="select 0 as Eval_Course_Id,'-- اختر-- ' as Course_Name union SELECT Eval_Course_Id,Course_Name FROM Evaluation_Courses ">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr runat="server" id="tr4">
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text=" ثالثا  : 1- نقاط القوة " />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div align="center" width="100%">
                            <asp:GridView ID="Gridview_ٍstrength" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999"
                                BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText=" رأى الرئيس المباشر">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Enabled='<%#Get_Enabled() %>' Text='<%#Eval("Direct_Emp_Note")%>'
                                                TextMode="MultiLine" Rows="2" ID="txt_Direct_Emp_Note" Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="رأى للرئيس الأعلى">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Top_Emp_Note")%>' TextMode="MultiLine"
                                                Rows="2" ID="txt_Top_Emp_Note" Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                       
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                                </PagerStyle>
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr runat="server" id="tr1">
                    <td colspan="2">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text=" 2 - نقاط الضعف" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div align="center" width="100%">
                            <asp:GridView ID="GridWeaknes" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText=" رأى الرئيس المباشر">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Enabled='<%#Get_Enabled() %>' Text='<%#Eval("Direct_Emp_Note")%>'
                                                TextMode="MultiLine" Rows="2" ID="txt_WDirect_Emp_Note" Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="رأى للرئيس الأعلى">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Top_Emp_Note")%>' TextMode="MultiLine"
                                                Rows="2" ID="txt_WTop_Emp_Note" Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                     
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                                </PagerStyle>
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr runat="server" id="tr5">
                    <td colspan="2">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text=" رابعا  :  الاحتياجات التدريبية المقترحة" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div align="center" width="100%">
                            <asp:GridView ID="Gridview_training" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                GridLines="Vertical">
                                <Columns>
                                  
                                    <asp:TemplateField HeaderText=" رأى الرئيس المباشر">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Visible="false" Enabled='<%#Get_Enabled() %>'
                                                Text='<%#Eval("Name")%>' TextMode="MultiLine" Rows="2" ID="txt_Name" Width="150px"></asp:TextBox>
                                            <asp:TextBox runat="server" CssClass="Text" Enabled='<%#Get_Enabled_Direct_mngr() %>'
                                                Text='<%#Eval("Direct_Emp_Note")%>' TextMode="MultiLine" Rows="2" ID="txt_WDirect_Emp_Note"
                                                Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="رأى للرئيس الأعلى">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Top_Emp_Note")%>' TextMode="MultiLine"
                                                Rows="2" ID="txt_WTop_Emp_Note" Width="300px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center">
                                </PagerStyle>
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btn_Save" OnClick="btn_Save_Click" Text="حفظ " runat="server" ValidationGroup="C"
                            CssClass="Button" />
                        <asp:Button ID="btn_report" OnClick="btn_report_Click" Text="طباعة تقرير التقييم "
                            Visible="false"  runat="server" CssClass="Button" Width="150px" />
                        <asp:Button ID="btn_finish" OnClick="btn_finish_Click" Text="انهاء التقييم " runat="server"
                            Visible="false" CssClass="Button" Width="150px" />
                    </td>
                </tr>
               <%-- <tr>
                    <td colspan="2" align="left">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    </td>
                </tr>--%>
            </table>
        </td>
    </tr>
</table>
