<%@ Control Language="C#" AutoEventWireup="true" CodeFile="permission_manager.ascx.cs" Inherits="UserControls_permission_manager" %>
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

<asp:HiddenField ID="vacid_hidden"  Value="0" runat="server" />

<asp:HiddenField ID="permno_hidden"  Value="0" runat="server" />
<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Font-Bold="True"
                Text="إذن"></asp:Label>
        </td>
    </tr>
     <tr runat="server" id="trOldVac" visible="true">
        <td align="left" style="direction: ltr">
            <asp:Button ID="BtnVacationOld" runat="server" CssClass="Button" Text=" أذونات سابقة"  OnClientClick="return VerifySubmit();"
                Width="110px" OnClick="BtnVacationOld_Click" />
        </td>
        <td align="right" style="direction: ltr">
            <asp:Button ID="Btn_AcceptReject" runat="server" CssClass="Button"  OnClientClick="return VerifySubmit();"
                onclick="Btn_AcceptReject_Click" Text="موافق" Width="101px" />
            <asp:Button ID="BtnVacationRequest" runat="server" CssClass="Button" Text="طلب إذن" OnClientClick="return VerifySubmit();"
                Width="110px" OnClick="BtnVacationRequest_Click" />
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2" style="width: 144px; height: 36px;">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="طلبات أذونات" Width="95px"
                Height="25px" />
        </td>
       
        
    </tr>
    <tr>
        <td align="center" class="Text" colspan="2" >
            <asp:GridView ID="requests" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="3" CssClass="mGrid" 
                EmptyDataText="... عفوا لا يوجد بيانات ..." onrowdatabound="requests_urgent_RowDataBound"
                ForeColor="Black" PagerStyle-CssClass="pgr" Font-Size="10pt" 
                OnRowCommand="requests_RowCommand" Visible="False" GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="طالب الإذن" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("pmp_name")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                   
                   <%-- <asp:TemplateField HeaderText="المدة " HeaderStyle-Wrap="false" ItemStyle-Width="5%"
                        HeaderStyle-Width="5%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("permission_no")%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="اليوم" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_date")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="من الساعة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("start_hour")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="إلي" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <%# Eval("end_hour")%>
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الحالة" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                        ItemStyle-Width="10%" HeaderStyle-Width="10%" HeaderStyle-Font-Size="Large" ItemStyle-Font-Size="Large">
                        <ItemTemplate>
                            <asp:Label ID="VocStatus" runat="server" Text=""></asp:Label>
                          
                        </ItemTemplate>

<HeaderStyle Wrap="False" Font-Size="Large" Width="10%"></HeaderStyle>

<ItemStyle Wrap="False" Font-Size="Large" Width="10%"></ItemStyle>
                    </asp:TemplateField>
                    
                    
                     <asp:TemplateField HeaderText="قبول/رفض">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="AcceptRefuseRBList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" >قبول</asp:ListItem>
                                <asp:ListItem Value="2">رفض</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:TextBox ID="txt_Data" runat="server" Text='<%#Eval("id")+ ","+ Eval("user_id")+","+Container.DataItemIndex%>' Visible="false" >
                            </asp:TextBox>
          
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <%--
                    <asp:TemplateField HeaderText="موافقة">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg" OnClientClick="return VerifySubmit();"
                                CommandArgument='<%# Eval("id")+ ","+ Eval("user_id") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="رفض">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px;" OnClientClick="return VerifySubmit();" CommandArgument='<%# Eval("id")+","+ Eval("user_id") %>' />
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
        <td align="center" class="Text" colspan="2">
            &nbsp;
        </td>
    </tr>
    
</table>