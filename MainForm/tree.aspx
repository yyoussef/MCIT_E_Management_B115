<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tree.aspx.cs" Inherits="WebForms2_tree" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc1" %>

<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASTreeViewDemo1</title>
	<link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css" rel="stylesheet" />
	<link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css" rel="stylesheet" />
	
	<script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>
	<script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>
<script type="text/javascript">

		//parameter must be "elem"
		function dndStartHandler(elem) {
		}

		//parameter must be "elem", "newParent"
		function dndCompletingHandler(elem, newParent) {
			
		}

		//parameter must be "elem", "newParent"
		function dndCompletedHandler2(elem, newParent) {
			 var curNodeValue = elem.getAttribute("treeNodeValue");
        var newParentValue = newParent.getAttribute("treeNodeValue");
        //set to the hidden fields
        document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
        document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
        //trigger the PostBack
        document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
		}
	
	
	function dndCompletedHandler(elem, newParent) 
	{
        var curNodeValue = elem.getAttribute("treeNodeValue");
        var newParentValue = newParent.getAttribute("treeNodeValue");
        //set to the hidden fields
        document.getElementById('<%=txtCurrentNode.ClientID %>').value = curNodeValue;
        document.getElementById('<%=txtNewParentNode.ClientID %>').value = newParentValue;
        //trigger the PostBack
        document.getElementById('<%=btnPostBackTrigger.ClientID %>').click();
    }

	</script>
</head>
<body>
    <form id="form1" runat="server">
    
	<asp:Literal ID="lASTreeViewThemeCssFile" runat="server"></asp:Literal>
		<h2>Themes</h2>
    <div>
		<table>
			<tr valign="top">
				<td width="400">
					<ct:ASTreeView ID="astvMyTree" 
				runat="server"
				BasePath="~/Javascript/astreeview/"
				DataTableRootNodeValue="0"
				EnableRoot="false" 
				EnableNodeSelection="false" 
				EnableCheckbox="false" 
				EnableDragDrop="true" 
				EnableTreeLines="true"
				EnableNodeIcon="true"
				EnableCustomizedNodeIcon="true"
				EnableContextMenu="true"
				EnableDebugMode="false"
				EnableContextMenuAdd="false"
				OnNodeDragAndDropCompletingScript="dndCompletingHandler( elem, newParent )"
				OnNodeSelectedScript="dndCompletingHandler2( elem, newParent )"
				OnNodeDragAndDropCompletedScript="dndCompletedHandler( elem, newParent )"
				OnNodeDragAndDropStartScript="dndStartHandler( elem )"
				EnableMultiLineEdit="false"
				EnableEscapeInput="false" />
						
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
     </div>
     
    </form>
    
</body>
</html>
