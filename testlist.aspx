<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testlist.aspx.cs" Inherits="testlist" %>

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
                    <asp:Button ID="Sendmail" runat="server" Text="Test Send Mail" Width="700px" OnClick="Sendmail_Click" />
                    <asp:ListView ID="ListView1" runat="server" Visible=true OnItemDataBound="ListView1_ItemDataBound">
                        <LayoutTemplate>
                            <table >
                                <tr runat="server" id="itemPlaceholder">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("pmp_name")%>'  Font-Size="24px" ></asp:Label>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="ListView2" runat="server">
                     <LayoutTemplate>
                        <table >
                            <tr runat="server" id="itemPlaceholder">
                            </tr>
                            
                        </table>
                    </LayoutTemplate>
                     <ItemTemplate></ItemTemplate>
                    </asp:ListView>
                    <asp:ListView ID="ListView3" runat="server">
                     <LayoutTemplate>
                        <table >
                            <tr runat="server" id="itemPlaceholder">
                            </tr>
                        </table>
                    </LayoutTemplate>
                     <ItemTemplate></ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
