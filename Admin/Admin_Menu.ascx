<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_Menu.ascx.cs" Inherits="UserControls_Site_Menu" %>

<script type="text/javascript" src="../Script/JScript.js">
  
</script>

<%--<table border="0" id="myMenu" class="nav" onmouseover="showmenu()" onmouseout="hidemenu()">--%>
<table border="0" id="myMenu" runat="server" class="nav" width="120px">
    <tr align="center" valign="middle">
        <td align="center" valign="middle">
            <table width="100%">
                <tr style="background-color: #E8F0FD;">
                    <td class="menu" onclick="document.location.href='Watch_Entry.aspx';" style="cursor: pointer;
                        cursor: hand">
                        <a href="addNewCase.aspx">رول القضايا </a>
                    </td>
                </tr>
                <tr style="background-color: #E8F0FD;">
                    <td class="menu" onclick="document.location.href='Watch_Entry.aspx';" style="cursor: pointer;
                        cursor: hand">
                        <a href="RollSearch.aspx">تقرير حاجب المحكمة </a>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </td>
    </tr>
</table>
