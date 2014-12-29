<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelimportMoataz.aspx.cs" Inherits="excelimportMoataz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center><table style="width: 70%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label">Choose file</asp:Label> &nbsp;
                </td>
                <td>
                    &nbsp;
                    <input id="File1" type="file" runat="server" /></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="GO" onclick="Button1_Click" />
                    &nbsp;
                </td>
            </tr>
        </table></center> 
    </div>
    </form>
</body>
</html>
