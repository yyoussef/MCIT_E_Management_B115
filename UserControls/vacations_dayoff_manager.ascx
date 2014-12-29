<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vacations_dayoff_manager.ascx.cs" Inherits="UserControls_vacations_dayoff_manager" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            alert('يرجى الإنتظار حتى يتم الانتهاء من تنفيذ طلبك السابق'); return false;
        }
        else
         {
            isFormSubmitted = true;
            return true;
        }
    }  
</script>

<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
        <tr>
            <td  align="center" colspan="2">
                <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                    Text="يوم عطلة"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2"  style="width: 144px; height: 36px;">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات" Width="95px"
                    Height="25px" />
            </td>
        </tr>
          <tr>
            <td align="left" style="direction: ltr">
                <asp:Button ID="Button1" runat="server" CssClass="Button" 
                    Text="طلبات سابقة" Width="117px" onclick="BtnVacationOld_Click" OnClientClick="return VerifySubmit();" />
            </td>
            <td align="right" style="direction: ltr">
                <asp:Button ID="Button2" runat="server" CssClass="Button" OnClientClick="return VerifySubmit();" 
                    onclick="Btn_AcceptRefuse_Click" Text="موافق" Width="104px" />
                <asp:Button ID="Button3" runat="server" CssClass="Button"  OnClientClick="return VerifySubmit();"
                    Text="طلب عمل يوم عطلة" Width="134px" onclick="BtnVacationRequest_Click" />
            </td>
            
        </tr>
        <tr>
            <td align="center" class="Text"  colspan="2">
                <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                    ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                    onrowcommand="requests_RowCommand" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="القائم بالطلب" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="15%" HeaderStyle-Width="15%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("pmp_name")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="15%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="15%"></ItemStyle>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="الجهة" HeaderStyle-Wrap="false" ItemStyle-Width="40%" HeaderStyle-Width="40%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("location")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="الغرض" HeaderStyle-Wrap="false" ItemStyle-Width="25%" HeaderStyle-Width="25%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("purpose")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="25%"></HeaderStyle>

<ItemStyle Font-Size="Large" Width="25%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="من" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("start_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إلى" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="5%" HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large"
                            ItemStyle-Font-Size="Large">
                            <ItemTemplate>
                                <%# Eval("end_date")%>
                            </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="5%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="قبول/رفض">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="AcceptRefuseRBList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" >قبول</asp:ListItem>
                                <asp:ListItem Value="2">رفض</asp:ListItem>
                            </asp:RadioButtonList>
                            
                            <asp:TextBox ID="txt_Data" runat="server" Text='<%# Eval("id")+ ","+ Eval("user_id")%>' Visible="false" >
                            </asp:TextBox>
          
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                        
                        
                           <%--
                      
                        
                        <asp:TemplateField HeaderText="موافقة">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                    CommandArgument='<%# Eval("id")+ ","+ Eval("user_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رفض">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                    Style="height: 22px;" CommandArgument='<%# Eval("id")  %>' />
                                              
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        --%>
                        
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
            <td align="center" class="Text" colspan="2" >
&nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="direction: ltr">
                <asp:Button ID="BtnVacationOld" runat="server" CssClass="Button" 
                    Text="طلبات سابقة" Width="117px" onclick="BtnVacationOld_Click" OnClientClick="return VerifySubmit();" />
            </td>
            <td align="right" style="direction: ltr">
                <asp:Button ID="Btn_AcceptRefuse" runat="server" CssClass="Button" OnClientClick="return VerifySubmit();" 
                    onclick="Btn_AcceptRefuse_Click" Text="موافق" Width="104px" />
                <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button"  OnClientClick="return VerifySubmit();"
                    Text="طلب عمل يوم عطلة" Width="134px" onclick="BtnVacationRequest_Click" />
            </td>
            
        </tr>
        <tr>
            <td align="center" class="Text" colspan="2" >
                &nbsp;</td>
        </tr>
    </table>
