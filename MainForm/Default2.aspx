<%@ Page Language="C#" MasterPageFile="~/Masters/MainformMaster.Master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="MainForm_Default2" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/Employee_data_new.ascx" TagName="emp_data" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Masterhead" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table >

  <tr>
  <td>
  <uc2:emp_data ID="smrt_emp" runat="server" />
  </td>
  </tr>
 </table>
</asp:Content>

