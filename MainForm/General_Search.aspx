<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="General_Search.aspx.cs" Inherits="WebForms2_General_Search" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table dir="rtl" style="line-height: 2; width: 99%;">
                <tr>
                    <td align="center" colspan="4" style="height: 33px">
                        <asp:Label ID="Label2" runat="server" CssClass="PageTitle" 
                            Text="بحث فى الوثائق العامة" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 29px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" dir="rtl" style="width: 151px; height: 35px;">
                        <asp:Label ID="Label4" runat="server" CssClass="Label" 
                            Text="كلمه فى اسم الوثيقة:" />
                    </td>
                    <td style="width:10px;">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox runat="server" CssClass="Text" ID="txt_file_name" 
                            Width="323px"></asp:TextBox>
                        <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                            AllowPaging="True" onpageindexchanging="gvMain_PageIndexChanging" 
                            PageSize="5" GridLines="Vertical" 
                            onselectedindexchanged="gvMain_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="م" ItemStyle-Width="3px" HeaderStyle-Width="3px">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>

<HeaderStyle Width="3px"></HeaderStyle>

<ItemStyle Width="3px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم الوثيقة" HeaderStyle-Width="80%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="80%" >
                                 <ItemTemplate  >
                                        <a href='<%# "ALL_Document_Details.aspx?type=deprtfile&id="+ Eval("File_Id") %>'  ><%# Eval("File_name")%></a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="80%" />
                                    <ItemStyle Width="80%" HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="نوع الوثيقة" HeaderStyle-Width="5%" 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" >
                                 <ItemTemplate  >
                                      <%# Eval("File_Type_Resolved")%>
                                 </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"/>
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
                    <td align="right" dir="rtl" style="width: 151px; height: 35px;">
                        <asp:Label ID="Label3" runat="server" CssClass="Label" 
                            Text="كلمه فى وصف الوثيقة:" />
                    </td>
                     <td style="width:10px;">
                         &nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="Text" ID="txt_file_discribtion" 
                            Width="324px"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td align="right" dir="rtl" style="width: 151px; height: 35px;">
                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="نوع الوثيقة:" />
                    </td>
                      <td style="width:10px;">
                          &nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddl_File_Type" runat="server" CssClass="drop" 
                            >
                            <asp:ListItem Text="أختر نوع الملف " Value ="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Word" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Excel" Value="2"></asp:ListItem>
                            <asp:ListItem Text="PDF" Value="3" ></asp:ListItem>
                            <asp:ListItem Text="IMAGE" Value="4"></asp:ListItem>
                            <asp:ListItem Text="PowerPoint" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Microsoft Project" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Video" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 26px">
                        <asp:Button ID="SearchButton" Text="بحث"  runat="server"
                            CssClass="Button" onclick="SearchButton_Click" />
                    </td>
                </tr>
                <tr runat="server" id="TrRows" visible="false">
                    <td colspan="1" align="right" style="height: 26px; width: 151px;" dir="rtl">
                        <asp:Label ID="Label6" runat="server" CssClass="Label" Text="نتيجة البحث:" />
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblrows" runat="server" CssClass="Label" Font-Bold="False" 
                            Font-Size="14pt" ForeColor="Black" />
                        <asp:Label ID="lblrows0" runat="server" CssClass="Label" Font-Bold="False" 
                            Font-Size="14pt" ForeColor="Black" >وثيقة</asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" class="Text" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
</asp:Content>

