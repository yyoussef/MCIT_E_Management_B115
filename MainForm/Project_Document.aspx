<%@ Page Language="VB" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="false"
    CodeFile="Project_Document.aspx.vb" Inherits="WebForms_Project_Document" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
function Get_Value()
{
var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex+1,dotindex);

document.getElementById('<%= txtFileName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
    </script>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <input id="PDOC_ID" runat="server" type="hidden" value="0" />
            <input id="PDOC_ID2" runat="server" type="hidden" />
            <input id="PDOC_ID3" runat="server" type="hidden" />
            <div>
                <table dir="rtl" style="line-height: 2; width: 99%;">
                    <tr>
                        <td align="center" colspan="2" style="height: 33px">
                            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="وثائق المشـــــــــــروع" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 29px">
                            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px">
                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="ملف المشروع:" Width="135px" />
                        </td>
                        <td dir="rtl">
                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" Width="90%"
                                Height="26px" ForeColor="Maroon" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" dir="rtl">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="اسم الوثيقــــــــة: " />
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="height: 26px">
                            <asp:Button ID="UploadButton" Text="حفظ الوثيقة" runat="server" CssClass="Button" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="99%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" EmptyDataText="... عفوا لا يوجد بيانات ..." CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                    GridLines="Vertical">
                    <Columns>
                        <asp:TemplateField HeaderText="اسم الوثيقة" HeaderStyle-Width="90%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="90%">
                            <ItemTemplate>
                                <input id="PDOC_ID" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>' />
                                <a href='<%# "Peoject_Document_Details.aspx?PDOC_id=" & Eval("PDOC_id") %>'>
                                    <%# Eval("PDOC_FileName") %></a>
                                <%--<asp:LinkButton ID="LBtnPDocument" runat="server" Text='<%# Eval("PDOC_FileName")%>'  PostBackUrl='<%# "~/WebForms2/Peoject_Document_Details.aspx?PDOC_id=" & Eval("PDOC_id") %>'></asp:LinkButton>--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                            <ItemStyle Width="90%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تعديل" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="5%">
                            <ItemTemplate>
                                <input id="PDOC_ID2" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>' />
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg" OnClick="ImgBtnEdit_Click"
                                    CommandArgument='<%# Eval("PDOC_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="5%">
                            <ItemTemplate>
                                <input id="PDOC_ID3" runat="server" type="hidden" value='<%# Eval("PDOC_id") %>' />
                                <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../Images/delete.gif"
                                    OnClick="ImgBtnDelete_Click" Style="height: 22px" CommandArgument='<%# Eval("PDOC_id") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="UploadButton" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
