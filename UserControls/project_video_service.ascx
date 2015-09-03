<%@ Control Language="C#" AutoEventWireup="true" CodeFile="project_video_service.ascx.cs"
    Inherits="UserControls_project_video_service" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 397px;
    }
</style>

<script language="javascript" type="text/javascript">

function Get_Value()
{ 
var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;

var slashindex = file_Upload.lastIndexOf("\\");
var dotindex = file_Upload.lastIndexOf(".");

//alert(slashindex);
var name = file_Upload.substring(slashindex + 1, dotindex);

    document.getElementById('<%= txtFileName.ClientID %>').value = name;
//alert('you selected the file: '+ name);
}
</script>

<input id="Inbox_ID" runat="server" type="hidden" value="0" />
<input id="mode" runat="server" type="hidden" value="new" />
<input id="id2" runat="server" type="hidden" />
<input id="id3" runat="server" type="hidden" />
<input id="empId" runat="server" type="hidden" />
<input type="hidden" runat="server" id="hidden_Id" />
<table dir="rtl" style="line-height: 2; width: 99%;">

    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="ملفات فيديو المشروع" />
        </td>
    </tr>
    <tr>
        <td align="center" colspan="4" style="height: 5px">
            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
        </td>
    </tr>
     <tr>
        <td align="right" dir="rtl">
            <asp:Label ID="Label21" runat="server" CssClass="Label" Text="نوع الخدمة: " />
        </td>
        <td>
            <asp:DropDownList ID="ddl_service" AutoPostBack="true" runat="server" CssClass="drop" Width="200px" OnSelectedIndexChanged="ddl_service_SelectedIndexChanged">
                <asp:ListItem Text="خدمات مواطنين" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="خدمات جهة حكومية" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="150px">
            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="صورة الفيديو:" Width="135px" />
            <input type="hidden" runat="server" id="hidden_proj_img_serv_File_ID"></input>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td dir="rtl">
            <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                Width="700px" />
            <br />
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl">
            <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم صورة الفيديو: " />
        </td>
        <td>
            <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl">
            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="عنوان الفيديو: " />
        </td>
        <td>
            <asp:TextBox runat="server" CssClass="Text" ID="txtaddress" Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" dir="rtl">
            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="رابط الفيديو: " />
        </td>
        <td>
            <asp:TextBox runat="server" CssClass="Text" ID="txturl" Width="700px"></asp:TextBox>
        </td>
    </tr>
   
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="حفظ الفيديو" runat="server"
                CssClass="Button" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GrdView_Documents" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="100%" BackColor="White" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid"
                BorderWidth="1px" CssClass="mGrid" EmptyDataText="... عفوا لا يوجد بيانات ..."
                OnRowCommand="GrdView_Documents_RowCommand" Font-Size="17px" GridLines="Vertical">
                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="صورة الفيديو">
                        <ItemTemplate>
                            <a href='<%# "ALL_Document_Details.aspx?type=videoservice&id="+ Eval("proj_video_service_id") %>'>
                                <%# Eval("File_name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="نوع الخدمة">
                        <ItemTemplate>
                            <%# Get_Type(Eval("service_id"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عنوان الفيديو">
                        <ItemTemplate>
                            <%# Eval("video_header")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="عرض الصورة">
                        <ItemTemplate>
                            <a href='<%# "ALL_Document_Details.aspx?type=videoservice&id="+ Eval("proj_video_service_id") %>'>
                                <img src="../Images/Edit.jpg" id="img1" alt="عرض الوثيقة" style="border: 0" />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="تعديل">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnEdit" CommandName="EditItem" runat="server" ImageUrl="../Images/Edit.jpg"
                                CommandArgument='<%# Eval("proj_video_service_id") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgBtnDelete" CommandName="RemoveItem" runat="server" ImageUrl="../Images/delete.gif"
                                Style="height: 22px" CommandArgument='<%# Eval("proj_video_service_id") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle CssClass="pgr" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </td>
    </tr>
</table>
