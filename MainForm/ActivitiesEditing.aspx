<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="ActivitiesEditing.aspx.cs" Inherits="MainForm_ActivitiesEditing" Title="تعديل الخطط الزمنية" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script type="text/javascript">
        //variable that will store the id of the last clicked row
        var previousRow;
        
        function ChangeRowColor(row)
        {
            //If last clicked row and the current clicked row are same
            if (previousRow == row)
                return;//do nothing
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
     
    <input id="RowIndex" type="hidden" runat="server" />
    <div id="divGrid" style="overflow: auto; width: 1000px; height: 550px">
        <table>
            <tr style="background: orange">
                <td align="center">
                    <asp:Label ID="lbl1" Text="نسبة انجاز المشروع :" runat="server" ForeColor="Red" Font-Bold="true"
                        Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblProgProgress" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="السنة :  "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="lbl_Year" runat="server" CssClass="Label"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="الشهر :  "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="lbl_Month" runat="server" CssClass="Label"></asp:TextBox>
                            </td>
                              <td>
                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="ملاحظات :  "></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox Enabled="false" TextMode="MultiLine" Rows="1" Width="300px"  ID="lbl_Notes" runat="server" CssClass="Label" ></asp:TextBox>
                            
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvSub" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                        Width="1600px" CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                        ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" Font-Strikeout="False"
                        Font-Underline="False" CaptionAlign="Top" OnPreRender="gvSub_PreRender1" 
                        OnRowCommand="GrdView_RowCommand" GridLines="Vertical" 
                        
                        
                        onrowdatabound="gvSub_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
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
                            <asp:BoundField DataField="PActv_Desc" HeaderText=" النشاط الفرعى" HeaderStyle-Width="200px"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                <HeaderStyle Width="200px" />

<ItemStyle Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="تاريخ البدايه" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="70px" Text='<%#Eval("PActv_Start_Date")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtStartDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtStartDate" />
                                        
                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtStartDate"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                                        
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الانتهاء" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="70px" Text='<%#Eval("PActv_End_Date")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtEndDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtEndDate" />
                                        
                                               
                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtEndDate"
                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المـده" ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPeriod" runat="server" Width="35px" Text='<%#Eval("PActv_Period")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtPeriod_filtered" runat="server" FilterType="Numbers"
                                        TargetControlID="txtPeriod" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ البدايه الفعلى" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtActualStartDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_Start_Date")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtActualStartDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtActualStartDate" />
                                        
                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtActualStartDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الانتهاء الفعلى" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtActualEndDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_End_Date")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtActualEndDate_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321/\" TargetControlID="txtActualEndDate" />
                                        
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActualEndDate"

                                ValidationExpression="^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"

                                    ValidationGroup="A" ErrorMessage=" برجاء إدخال صيغة التاريخ بطريقة صحيحة " Text="تاريخ غير صحيح"  > </asp:RegularExpressionValidator>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الوزن النسبى" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWeight" runat="server" Width="20px" Text='<%#Eval("PActv_wieght")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtWeight_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321." TargetControlID="txtWeight" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="نسبة الانجاز %" ItemStyle-Width="35px" ItemStyle-Height="25px"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPregress" runat="server" Width="35px" Text='<%#Eval("PActv_Progress")%>'></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtPregress_filtered" runat="server" FilterType="Custom"
                                        ValidChars="0987654321." TargetControlID="txtPregress" />
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="35px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مسئول التنفيذ" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtImplementingPerson" runat="server" Width="100px" Text='<%#Eval("PActv_Implementing_person")%>'></asp:TextBox>
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
                                    <asp:TextBox ID="txtfunds" runat="server" Width="75px" Text='<%#Eval("funding_amount")%>'></asp:TextBox>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="75px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="حفظ" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <input id="RowIndex" runat="server" type="hidden" />
                                    <asp:TextBox ID="txtLevel" runat="server" Visible="false" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                    <asp:Button ID="btnRowSave" runat="server" Text="حفظ" CommandName='<%#Container.DataItemIndex%>'
                                        CommandArgument='<%#Eval("PActv_ID")%>'  ValidationGroup="A"/>
                                        
                                        
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle Width="5px" />
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
            
           
        </table>
    </div>
</asp:Content>
