<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="fttp.aspx.cs" Inherits="fttp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<form runat="server">
    <%--<asp:ListView ID="ListView1" runat="server">
        <asp:Label runat="server" id="File_Title"></asp:Label>
      
    </asp:ListView>--%>
    
     <asp:ListView ID="ListView1" runat="server" GroupItemCount="1"   >
                 <LayoutTemplate>
                    <table>
                        <tr>
                            <td>
                                <table cellpadding="2" runat="server" id="groupPlaceholderContainer" style="width: 100%;
                                    height: 100%; border-width: thin">
                                    <tr runat="server" id="groupPlaceholder">
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                    <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server">
                        </td>
                    </tr>
                </GroupTemplate>
                    <ItemTemplate>
                        <table id="Table1"  runat="server" align="left" cellpadding="10">
       
                            <tr id="Tr2" align="left"  runat="server" valign="top">
                                <td id="Td2"   align="left"  runat="server" >
                                  <asp:TextBox ID="txtid" runat="server"  Text='<%# Eval("found_backupfilename") %>'></asp:TextBox>
                                                  
                                   <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../Images/Edit.jpg"
                                                        CommandArgument='<%# Eval("found_backupfilename") %>' OnClick="ImgBtnEdit_Click"  />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                   
       
                </asp:ListView>
                </form>
</body>
</html>
