<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Department_manage.aspx.cs" Inherits="WebForms2_Department_manage" Title="  الهيكل التنظيمي للجهة" %>
<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" runat="Server">
    <link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css"
        rel="stylesheet" />
    <link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css"
        rel="stylesheet" />

    <script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>

    <script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>

    <script type="text/javascript">

        function dndStartHandler(elem) {

        }
        function dndCompletingHandler(elem, newParent) {

        }
        function dndCompletedHandler2(elem) {
            var curNodeValue = elem.parentNode.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=btnPostBackTrigger2.ClientID %>').click();
        }
        function dndCompletedHandler(elem, newParent) {
            var curNodeValue = elem.getAttribute("treeNodeValue");
            var newParentValue = newParent.getAttribute("treeNodeValue");
            document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
            document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
            document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
        }

        function fireClick() {
            alert('');
            document.getElementById('<%=btnPostBackTrigger3.ClientID %>').click();
            alert('');
        }
    
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table dir="rtl" style="line-height: 2; width: 99%;">
        <tr>
            <td align="center" colspan="4" style="height: 33px">
                <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text=" الهيكل التنظيمي للجهة " />
                      <input id="hid_id" type="hidden" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 5px">
                <asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
                <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="False" ForeColor="#EC981F" font-underline="false" CssClass="Label"></asp:Label>
                <div style="display: none">
                    <asp:TextBox ID="txtCurrentNode" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtNewParentNode" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPostBackTrigger" runat="server" OnClick="btnPostBackTrigger_Click" />
                    <asp:Button ID="btnPostBackTrigger2" runat="server" OnClick="btnPostBackTrigger2_Click" />
                    <asp:Button ID="btnPostBackTrigger3" runat="server" OnClick="btnPostBackTrigger3_Click" />
                    
                    <asp:TextBox ID="txt_update" runat="server" Visible="false" ></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" dir="ltr" style="background-color: #F9fdff" align="right" >
                <ct:ASTreeView ID="astvMyTree" runat="server" BasePath="~/Javascript/astreeview/"
                    DataTableRootNodeValue="0" EnableRoot="false" EnableNodeSelection="true" EnableCheckbox="false"
                    EnableDragDrop="true" EnableTreeLines="true" EnableNodeIcon="true" BackColor="#F9FDFF"
                    EnableCustomizedNodeIcon="true" EnableContextMenu="true" EnableDebugMode="false"
                    EnableContextMenuAdd="false" OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
                    OnNodeSelectedScript="dndCompletedHandler2(elem)" OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
                    OnNodeDragAndDropStartScript="dndStartHandler( elem )" EnableMultiLineEdit="false"
                    EnableEscapeInput="false" ForeColor="#F9FDFF"  OnOnSelectedNodeChanged="astvMyTree_OnSelectedNodeChanged"/>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
               
        </tr>
        <tr align="center">
        <td>
        <asp:Button ID="btn_New" runat="server" CssClass="Button" Text="جديد" OnClick="btn_New_Click"  />
         </td>
                     
           <td>
              <asp:Button ID="btn_Update" runat="server" Width="150px" CssClass="Button" Text="تعديل "
                     OnClick="btn_Update_Click" />
            </td>
           <td>
               <asp:Button ID="btn_New_Delete" runat="server" CssClass="Button" Text="حذف" OnClientClick="javascript:return confirm('هل أنت متأكد من الحذف')" OnClick="btn_New_Delete_Click" />
           </td>
        </tr>
           
           <tr>
            <td colspan="4" align="center">
               
        </tr>            
       
        <tr>
            <td>
                <asp:Label ID="Label27" runat="server" CssClass="Label" Text="الاسم  :" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="txt_name" Width="70%"  Rows="3" 
                    runat="server" CssClass="Text" />
            </td>
        </tr>
        
         <%-- <tr>
             <td>
                <asp:Label ID="Label11" runat="server" CssClass="Label" Text="إختر النوع  :" />
            </td>
            <td >
                 <asp:DropDownList ID="ddltype" runat="server"  CssClass="Button" 
                        Width="150px" >
                    </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td colspan="4" align="center" >
                <asp:Button ID="BtnSave" runat="server" CssClass="Button" Text="حفــــــظ" OnClick="BtnSave_Click"
                    ValidationGroup="A" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="A"
                    ShowMessageBox="true" ShowSummary="false" />
            </td>
            
             <td>
                            
        </tr>
      
       
    </table> 
</asp:Content>
