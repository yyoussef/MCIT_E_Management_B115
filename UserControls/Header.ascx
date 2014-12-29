<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Geekees.Common.Controls.Demo.Header" %>
<h2>ASTreeView Demo</h2>
<h5>by <a href="http://www.jinweijie.com">jinweijie.com</a> visit: <a href="http://www.astreeview.com">online sample</a> support:<a href="http://www.astreeview.com/astreeviewdemo/Support.aspx">http://www.astreeview.com/astreeviewdemo/Support.aspx</a></h5>

<hr />
<div>
	<h3>Current ASTreeView Version:<%=ASTreeViewVersion %></h3>
	<ul id="MainTabs">
		<li style="float:left;margin:4px;color:Green;" id="liASTreeViewDemo0" runat="server">Samples:</li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo1" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo1" runat="server" Text="General Tree" NavigateUrl="~/ASTreeViewDemo1.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo2" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo2" runat="server" Text="Server-Side Event" NavigateUrl="~/ASTreeViewDemo2.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo3" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo3" runat="server" Text="Add, Edit, Delete Nodes" NavigateUrl="~/ASTreeViewDemo3.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo4" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo4" runat="server" Text="Xml DataSouce" NavigateUrl="~/ASTreeViewDemo4.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo5" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo5" runat="server" Text="Dynamic Loading" NavigateUrl="~/ASTreeViewDemo5.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo6" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo6" runat="server" Text="Dropdown Tree" NavigateUrl="~/ASTreeViewDemo6.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo7" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo7" runat="server" Text="DragDrop Between Trees" NavigateUrl="~/ASTreeViewDemo7.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo8" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo8" runat="server" Text="Expand Node To Depth" NavigateUrl="~/ASTreeViewDemo8.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo9" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo9" runat="server" Text="Resolve Nodes Changes" NavigateUrl="~/ASTreeViewDemo9.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo10" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo10" runat="server" Text="Themes" NavigateUrl="~/ASTreeViewDemo10.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo11" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo11" runat="server" Text="Performance Test" NavigateUrl="~/ASTreeViewDemo11.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo12" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo12" runat="server" Text="Client Side Javascript" NavigateUrl="~/ASTreeViewDemo12.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo13" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo13" runat="server" Text="ASTreeView in Custom Control" NavigateUrl="~/ASTreeViewDemo13.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo14" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo14" runat="server" Text="Advanced Drag and Drop" NavigateUrl="~/ASTreeViewDemo14.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo15" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo15" runat="server" Text="Checkbox and Selection" NavigateUrl="~/ASTreeViewDemo15.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo16" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo16" runat="server" Text="Text/Html Node" NavigateUrl="~/ASTreeViewDemo16.aspx" /></li>
		<li style="float:left;margin:4px;" id="liASTreeViewDemo17" runat="server"><asp:HyperLink ID="ashlASTreeViewDemo17" runat="server" Text="Advanced Client Side JS" NavigateUrl="~/ASTreeViewDemo17.aspx" /></li>

	</ul>
</div>
<br />
<br />
<hr />
<br />