<%@ Page Language="C#" AutoEventWireup="true" CodeFile="org_structure.aspx.cs" Inherits="MainForm_org_structure" %>
<%@ Register Src="../UserControls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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

//        function PassValues() {
//            window.opener.document.forms(0).submit();
//            self.close();
        //        }

        function ReturnValue() {
            var newValue = document.getElementById("txtValue").value;
            if ((window.opener != null) && (!window.opener.closed)) {
                window.opener.document.getElementById("hfPopupValue").value = newValue;
            }
            window.close();
        }

        function validepopupform()
         {
            window.opener.document.text1.value = document.form2.text2.value; self.close();
         } 
    </script>
    
   
</head>
<body >
    <form id="form2" runat="server">
   
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
                    EnableEscapeInput="false" ForeColor="#F9FDFF" />
            </td>
        </tr>
        
        <tr>
        <td>
        
        </td>
        <td>
        <input type='text' id='text2' name='text2' />
        <input type='button' value='go' onclick='validepopupform()' /> 
        </td>
        </tr>
        </table> 
   
    </form>
</body>
</html>
