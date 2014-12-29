<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Planning_Stages.ascx.cs"
    Inherits="UserControls_Planning_Stages" %>
<%@ Register Src="Smart_Search.ascx" TagName="Smart_Search" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<link href="<%=ResolveUrl("~/javascript/astreeview/astreeview.css")%>" type="text/css"
    rel="stylesheet" />
<link href="<%=ResolveUrl("~/javascript/contextmenu/contextmenu.css")%>" type="text/css"
    rel="stylesheet" />

<script src="<%=ResolveUrl("~/javascript/astreeview/astreeview_packed.js")%>" type="text/javascript"></script>

<script src="<%=ResolveUrl("~/javascript/contextmenu/contextmenu_packed.js")%>" type="text/javascript"></script>

<script type="text/javascript">

{}
</script>

<table cellpadding="5px" align="center" style="height: 89px; width: 945px; line-height: 2;"
    dir="rtl">
    <tr>
        <td align="center" colspan="4" style="height: 33px">
            <asp:Label ID="Label2" runat="server" CssClass="PageTitle" Text="أنشطة مراحل المشروع" />
        </td>
    </tr>
    
     <tr>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="PageTitle" Text="مراحل المشروع" />
        </td>
        <td>
            <asp:DropDownList ID="drop_stage" AutoPostBack="true" DataTextField="stage_title"
                DataValueField="id" runat="server" Width="500" CssClass="Button" OnSelectedIndexChanged="drop_stage_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td align="right" dir="rtl" valign="top" class="style2" colspan="2">
        <div style="overflow: scroll; background-color: #F9fdff; color: #000000; width: 80%"
            dir="rtl" class="borderControl">
            <asp:TreeView ID="TreeView1" runat="server"  OnClientClickedCheckbox="CascadeCheckmarks(event)"
                OnTreeNodeCheckChanged="OnCheckChanged" OnAdaptedTreeNodeCheckChanged="OnCheckChanged"
                CssSelectorClass="SimpleEntertainmentTreeView" ExpandDepth="1" ShowCheckBoxes="All" ForeColor="black">
                <Nodes>
                    <asp:TreeNode Text="PActv_Desc" Checked="true" Value="PActv_ID">
                        <asp:TreeNode Text="PActv_Desc" Value="PActv_ID"/>
                        <asp:TreeNode>
                           
                        </asp:TreeNode>
                        <asp:TreeNode />
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </td>
   </tr> 
    <tr align="center">
        <td colspan="2">
            <asp:Button ID="btn" runat="server" Text="حفظ" OnClick="btn_Click" CssClass="Button" />
        </td>
    </tr>
    
</table>
