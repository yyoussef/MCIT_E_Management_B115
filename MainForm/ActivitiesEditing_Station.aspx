<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true"
    CodeFile="ActivitiesEditing_Station.aspx.cs" Inherits="MainForm_ActivitiesEditing_Station"
    Title="تحديث موقف متابعة المشروع" %>

<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
    //isFormSubmitted variable is used to prevent the form submission while the server execution is in progress
    var isFormSubmitted = false;
    //If the form is already submitted, this function will return false preventing the form submission again.
    function SubmitForm(msg) {
        try {
            if (isFormSubmitted == true) {
                alert('A post back is already in progress. Please wait');
                return false;
            }
            else {
                var res = false;
                if (msg) {
                    res = confirm(msg);
                }
                if (res == true) {
                    isFormSubmitted = true;
                } return res;
            }
        } catch (ex) { }
    }

    function VerifySubmit() {
        if (isFormSubmitted == true) {
            alert('يرجى الإنتظار '); return false;
        }
        else
         {
            isFormSubmitted = true;
            return true;
        }
    }  
</script>

    <input id="RowIndex" type="hidden" runat="server" />
    <div id="divGrid" style="overflow: auto; height: 550px" width="100%">
        <table width="100%">
            <tr style="background: orange">
                <td align="center">
                    <asp:Label ID="lbl1" Text="نسبة انجاز المشروع :" runat="server" ForeColor="Red" Font-Bold="true"
                        Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblProgProgress" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Notes" runat="server" CssClass="Label" Text="لا يوجد شهر مفعل بعد"></asp:Label>
                    <asp:HiddenField runat="server" ID="hidden_month_id" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_error" runat="server" Visible="false" ForeColor="Red" Text="نسبة الانجاز تتعدى 100 %"
                        Font-Bold="true" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <asp:GridView ID="gvSub" runat="server" 
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                Width="95%" CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                                ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" Font-Strikeout="False"
                                Font-Underline="False" CaptionAlign="Top" 
                        OnPreRender="gvSub_PreRender1" OnRowCommand="GrdView_RowCommand" 
                        GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField HeaderText="م" HeaderStyle-Width="3px" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Eval("Parent_Actv_Num")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center" Width="3px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="parent" HeaderStyle-Width="150px" HeaderText="النشاط الرئيسى"
                                        HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PActv_Desc" HeaderStyle-Width="150px" HeaderText=" النشاط الفرعى"
                                        HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="تاريخ البدايه الفعلى" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActualStartDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_Start_Date")%>'
                                                Enabled="false"></asp:TextBox>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="تاريخ الانتهاء الفعلى" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActualEndDate" runat="server" Width="70px" Text='<%#Eval("PActv_Actual_End_Date")%>'
                                                Enabled="false"></asp:TextBox>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الوزن النسبى" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWeight" runat="server" Width="20px" Text='<%#Eval("PActv_wieght")%>'
                                                Enabled="false"></asp:TextBox>
                                            <asp:TextBox ID="txtLevel" runat="server" Visible="false" Text='<%#Eval("LVL")%>'></asp:TextBox>
                                            <asp:TextBox ID="txtPActv_Parent" runat="server" Visible="false" Text='<%#Eval("PActv_Parent")%>'></asp:TextBox>
                                            <asp:TextBox ID="txtPActv_ID" runat="server" Visible="false" Text='<%#Eval("PActv_ID")%>'></asp:TextBox>
                                            <asp:CheckBox ID="chk_chnged" Visible="false" runat="server" />
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="نسبة الانجاز %" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPregress" runat="server" OnClientClick="return VerifySubmit();" AutoPostBack="true" OnTextChanged="txtPregress_TextChanged"
                                                Width="35px" Text='<%#Eval("PActv_Progress")%>' MaxLength="3" ></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPregress_filtered" runat="server" FilterType="Custom"
                                                ValidChars="0987654321." TargetControlID="txtPregress" />
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPregress"
                                                MinimumValue="0" Type="Integer" MaximumValue="100" ValidationGroup="A"
                                                ErrorMessage="*"></asp:RangeValidator>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="الموقف" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtImplementingPerson" runat="server" AutoPostBack="true" OnTextChanged="txtImplementingPerson_TextChanged"
                                                TextMode="MultiLine" Rows="3" Width="180px" Text='<%#Eval("Notes")%>'></asp:TextBox>
                                        <%--    <asp:RequiredFieldValidator runat="server" ValidationGroup='<%#Eval("PActv_ID")%>'
                                                ControlToValidate="txtImplementingPerson" ErrorMessage="*">
                                            </asp:RequiredFieldValidator>--%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="حفظ" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                           <asp:Button ID="btnRowSave" runat="server" Text="حفظ" CommandName='<%#Container.DataItemIndex%>'
                                        ValidationGroup='<%#Eval("PActv_ID")%>' CommandArgument='<%#Eval("PActv_ID")%>' />
                                </ItemTemplate>
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
                       <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
          
        </table>
    </div>
    <div align="center" >
     <asp:Button ID="btnSave" runat="server" ValidationGroup="A" CssClass="Button" Text="حفظ" OnClientClick="return VerifySubmit();"  OnClick="btnSave_Click" />
    </div>
</asp:Content>
