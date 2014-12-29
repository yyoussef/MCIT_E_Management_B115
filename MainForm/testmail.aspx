<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testmail.aspx.cs" Inherits="testmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txt_Mail" runat="server" Text="archiving@eri.sci.eg" Width="700px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Sendmail" runat="server" Text="Test Send Mail" Width="700px" OnClick="Sendmail_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
