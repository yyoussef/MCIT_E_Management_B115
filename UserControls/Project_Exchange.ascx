<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Project_Exchange.ascx.cs"
    Inherits="UserControls_Project_Exchange" %>
<table width="100%" style="line-height: 2; color: Black">
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblMastertitle" runat="server" CssClass="PageTitle" Text="أبواب الصرف"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="PageTitle" Text="السنة المالية"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddl_Year" runat="server" Font-Bold="False" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged"
                AutoPostBack="true" CssClass="drop" Width="300px" Height="39px">
     
         
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="divGrid" style="overflow: auto; width: 1000px; height: 450px">
                <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="95%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText=" مصدر التمويل الرئيسى">
                            <ItemTemplate>
                                <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_name1" Text='<%#Eval("Source_Name")%>' />
                                <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_Sources_ID" Visible="false"
                                    Text='<%#Eval("Sources_ID")%>' />
                                <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_Provider_ID" Visible="false"
                                    Text='<%#Eval("Provider_ID")%>' />
                                <asp:Label runat="server" Width="130px" CssClass="Label" ID="lbl_Project_Exchange_ID"
                                    Visible="false" Text='<%#Eval("Project_Exchange_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" مصدر التمويل الفرعى">
                            <ItemTemplate>
                                <asp:Label runat="server" Width="300px" CssClass="Label" ID="lbl_name2" Text='<%#Eval("Provider_Name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="قيمة التمويل">
                            <ItemTemplate>
                                <asp:Label runat="server" Width="100px" CssClass="Label" ID="lbl_Value" Text='<%#Eval("Value")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أجور ومكافئات">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Rewards")%>' ID="txt_Rewards"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="انتقالت">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Transitions")%>' ID="txt_Transitions"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حجز فنادق">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Hotels")%>' ID="txt_Hotels"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مستلزمات">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Requirements")%>' ID="txt_Requirements"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تدريب">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Training")%>' ID="txt_Training"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تطبيقات">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Application")%>' ID="txt_Application"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مناقصات/ممارسات">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Tenders")%>' ID="txt_Tenders"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="موارد">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Resources")%>' ID="txt_Resources"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="اتصالت">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Communication")%>' ID="txt_Communication"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="أعمال هندسية">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Engineering")%>' ID="txt_Engineering"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رخص برامج">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Licence")%>' ID="txt_Licence"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إعادة استثمار">
                            <ItemTemplate>
                                <asp:TextBox runat="server" CssClass="Text" Text='<%#Eval("Reinvestment")%>' ID="txt_Reinvestment"
                                    Width="100px" MaxLength="9"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center"></PagerStyle>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC"></AlternatingRowStyle>
                </asp:GridView>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_Save" OnClick="btn_Save_Click" Text="حفظ " runat="server" CssClass="Button" />
        </td>
    </tr>
</table>
