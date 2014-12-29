<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Bulliten_View.ascx.cs"
    Inherits="UserControls_Bulliten_View" %>

<script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('collapse') != -1) {
                img.src = "../Images/expand.gif";
            }
            else {
                img.src = "../Images/collapse.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
   
</script>

<table style="width: 100%">
    <tr bgcolor="#E6F3FF">
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr bgcolor="#E6F3FF">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1000','Img500');">
                        <img border="0" id="Img500" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div1000','Img500');">
                        <asp:Label ID="Label2" runat="server" Text="نشرات التعميم"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="div1000" style="display: none">
                <table>
                    <tr id="tr_Review_Emp_New" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image52" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="Td3" runat="server">
                            <asp:LinkButton ID="LinkButton74" OnClick="lnkbtn_Review_Emp_New_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnkbtn_Review_Emp_New" OnClick="lnkbtn_Review_Emp_New_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton77" OnClick="lnkbtn_Review_Emp_New_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="نشرة جديدة" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Review_emp_closed" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image55" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="LinkButton84" OnClick="lnkbtn_Review_emp_closed_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnkbtn_Review_emp_closed" OnClick="lnkbtn_Review_emp_closed_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton86" OnClick="lnkbtn_Review_emp_closed_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="نشرة مغلقة" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Review_new" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image57" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="Td6" runat="server">
                            <asp:LinkButton ID="lnk_btn_Review_new" OnClick="lnk_btn_Review_new_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="link_new_Review" OnClick="lnk_btn_Review_new_Click" runat="server"
                                    CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true" Text="0"
                                    ForeColor="red" />
                                <asp:LinkButton ID="LinkButton92" OnClick="lnk_btn_Review_new_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="نشرة" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
