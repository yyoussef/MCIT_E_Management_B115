<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.master" AutoEventWireup="true"
    CodeFile="Deprt_Documnts.aspx.cs" Inherits="WebForms_Deprt_Documnts" Title="الوثائق العامة" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
<link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css" rel="stylesheet" />
	<link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css" rel="stylesheet" />
	
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
	   // alert('');
        document.getElementById('<%=btnPostBackTrigger3.ClientID %>').click();
        // alert('');
    }
    
    function Get_Value()
    {
        var file_Upload =  document.getElementById('<%= FileUpload1.ClientID %>').value;
        var slashindex = file_Upload.lastIndexOf("\\");
        var dotindex = file_Upload.lastIndexOf(".");
        var name = file_Upload.substring(slashindex+1,dotindex);
        document.getElementById('<%= txtFileName.ClientID %>').value = name;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
    <table style="line-height: 2; width: 100%;">
        <tr>
            <td align="center" colspan="2">
                <asp:HiddenField ID="orderType" runat="server" Value="File_name" />
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="الوثائق العامة" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="Red" CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label29" runat="server" CssClass="Label" Text="الوثيقة الرئيسية :"
                    Width="135px" />
            </td>
            <td>
                <asp:DropDownList ID="ddl_Parent_ID" runat="server" CssClass="drop">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="150px">
                <asp:Label ID="Label19" runat="server" CssClass="Label" Text="الوثيقة:" Width="135px" />
                <input type="hidden" runat="server" id="hidden_File_ID" />
                <input type="hidden" runat="server" value="add" id="mode" />
            </td>
            <td dir="rtl">
                <asp:FileUpload ID="FileUpload1" runat="server" onchange="Get_Value()" ForeColor="Maroon"
                    Width="700px" />
                <a id="A2" runat="server" visible="False" style="font-weight: bold; font-size: medium" onclick="fireClick();">
                    عرض</a>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label20" runat="server" CssClass="Label" Text="اسم الوثيقة: " />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="txtFileName" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFileName"
                    runat="server" Text="*" ValidationGroup="A">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="ترتيب الوثيقة: " />
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="Text" ID="TheOrder" Width="700px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label21" runat="server" CssClass="Label" Text="وصف الوثيقة : " />
            </td>
            <td>
                <asp:TextBox ID="txt_File_Desc" runat="server" CssClass="Text" Height="70px" Width="90%"
                    Rows="6" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="نوع الوثيقة : " />
            </td>
            <td>
                <asp:DropDownList ID="ddl_File_Type" runat="server" CssClass="drop">
                    <asp:ListItem Text="Word" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Excel" Value="2"></asp:ListItem>
                    <asp:ListItem Text="PDF" Value="3" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="IMAGE" Value="4"></asp:ListItem>
                    <asp:ListItem Text="PowerPoint" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Microsoft Project" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Video" Value="7"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <%-- <tr>
            <td align="right" dir="rtl">
                <asp:Label ID="Label4" runat="server" CssClass="Label" Text="رفع علي موقع القطاع : " />
            </td>
            <td>
                <asp:CheckBox ID="chk_upload" runat="server" />
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_Doc" OnClick="btn_Doc_Click" Text="حفظ" ValidationGroup="A" runat="server" CssClass="Button" />
                <asp:Button ID="Button1" OnClick="btn_New_Click" Text="جديد" runat="server" CssClass="Button" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label30" runat="server" CssClass="Label" Text="ترتيب الوثائق:" />
            </td>
            <td align="right">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    CssClass="Label" Font-Bold="False" RepeatDirection="Horizontal" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="File_name">أبجدى</asp:ListItem>
                    <asp:ListItem Value="TheOrder">حسب الترتيب</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
                <div style="overflow: scroll; background-color: #F9fdff; color: #000000; height: 289px; width:400"
                     align="right">
                    <div>
		<table dir="ltr" style="background-color:#F9fdff">
			<tr valign="top">
				<td width="400"  dir="ltr" style="background-color:#F9fdff">
                    <ct:ASTreeView ID="astvMyTree" 
				    runat="server"
				    BasePath="~/Javascript/astreeview/"
				    DataTableRootNodeValue="0"
				    EnableRoot="false" 
				    EnableNodeSelection="true" 
				    EnableCheckbox="false" 
				    EnableDragDrop="true" 
				    EnableTreeLines="true"
				    EnableNodeIcon="true"
				    BackColor="#F9FDFF"
				    EnableCustomizedNodeIcon="true"
				    EnableContextMenu="true"
				    EnableDebugMode="false"
				    EnableContextMenuAdd="false"
				    OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
				    OnNodeSelectedScript="dndCompletedHandler2(elem)"
				    OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
				    OnNodeDragAndDropStartScript="dndStartHandler( elem )"
				    EnableMultiLineEdit="false"
				    EnableEscapeInput="false" ForeColor="#F9FDFF" />
				    </td>
				<td>
				
					<div id="div1" runat="server"></div>
				</td>
			</tr>
		</table>
                </div>
                <div style="display:none">
                    <asp:TextBox ID="txtCurrentNode" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtNewParentNode" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPostBackTrigger" runat="server" onclick="btnPostBackTrigger_Click" />
                    <asp:Button ID="btnPostBackTrigger2" runat="server" onclick="btnPostBackTrigger2_Click" />
                    <asp:Button ID="btnPostBackTrigger3" runat="server" onclick="btnPostBackTrigger3_Click" />
                 </div>
                 </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <input type="hidden" runat="server" id="hidden_File_Sytem_Name" />
                <input type="hidden" runat="server" id="hidden_Page_Count" />
                <input type="hidden" runat="server" id="hidden_File_ext" />
                
                <%--     <asp:Button ID="Button1" OnClick="btn_Upd_Click" Text="تعديل" 
                    runat="server" CssClass="Button" />--%>
                <asp:Button ID="Button3" Width="150px" OnClick="btn_Show_Click" Text="عرض الملفات التابعة"
                    runat="server" CssClass="Button" />
                <asp:Button ID="Button2" OnClick="btn_Delte_Click" Text="حذف" 
                 OnClientClick="if (confirm('هل تود الحذف نهائياً') == false) return false;"
                                 
                 runat="server" CssClass="Button" />
            </td>
        </tr>
    </table>
</asp:Content>
