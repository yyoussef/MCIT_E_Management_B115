<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommissionUserControl.ascx.cs"
    Inherits="UserControls_CommissionUserControl" %>

<script language="javascript" type="text/javascript">
        function ChangeMeCase(divid, imgid) {

            var divname = document.getElementById(divid);
            var img = document.getElementById(imgid);

            var imgsrc = img.src;


            if (imgsrc.lastIndexOf('square_arrow_flipped') != -1) {
                img.src = "../Images/square_arrow_down.gif";
            }
            else {
                img.src = "../Images/square_arrow_flipped.gif";
            }

            divname.style.display = divname.style.display == 'none' ? 'block' : 'none';
        }
   
</script>

<table style="width: 100%">
    <tr >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divcom','Imgcom');">
                        <img border="0" id="Imgcom" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divcom','Imgcom');">
                        <asp:Label ID="lbl_commission" runat="server" Text="التكليفات"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="divcom" style="display: none">
                <table>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image60" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="tr_link_new_com" runat="server">
                            <asp:LinkButton ID="lnk_btn_com_new" OnClick="lnk_btn_com_new_Click" runat="server"
                                 Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="link_new_com" OnClick="lnk_btn_com_new_Click" runat="server"
                                     Font-Size="20px" Visible="true"  Text="0"
                                    ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton95" OnClick="lnk_btn_com_new_Click" runat="server"
                                     Visible="true"  Text="تكليف جديد" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image61" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnk_btn_com_old" OnClick="lnk_btn_com_old_Click" runat="server"
                                 Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="link_old_com" OnClick="lnk_btn_com_old_Click" runat="server"
                                     Font-Size="20px" Visible="true"  Text="0"
                                    ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton98" OnClick="lnk_btn_com_old_Click" runat="server"
                                     Visible="true"  Text="تكليف جاري" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image62" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td_com_late" runat="server">
                            <asp:LinkButton ID="lnk_btn_com_late" OnClick="lnk_btn_com_late_Click" runat="server"
                                 Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="link_late_com" OnClick="lnk_btn_com_late_Click" runat="server"
                                     Font-Size="20px" Visible="true"  Text="0"
                                    ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton102" OnClick="lnk_btn_com_late_Click" runat="server"
                                     Visible="true"  Text="تكليف متأخر" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image63" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnk_btn_com_closed" OnClick="lnk_btn_com_closed_Click" runat="server"
                                 Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="link_closed_com" OnClick="lnk_btn_com_closed_Click" runat="server"
                                     Font-Size="20px" Visible="true"  Text="0"
                                    ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton4322" OnClick="lnk_btn_com_closed_Click" runat="server"
                                     Visible="true"  Text="تكليف منتهي" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image1611" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="tr_link_com_have_follow" runat="server">
                            <asp:LinkButton ID="lnk_btn_com_have_follow" OnClick="lnk_btn_com_have_follow_Click"
                                runat="server"  Font-Size="20px" ForeColor="#808080" font-underline="false" 
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_com_have_follow" OnClick="lnk_btn_com_have_follow_Click"
                                    runat="server"  Font-Size="20px" Visible="true" 
                                    Text="0" ForeColor="#EC981F" font-underline="false" />
                                <asp:LinkButton ID="LinkButton2332" OnClick="lnk_btn_com_have_follow_Click" runat="server"
                                     Visible="true"  Text="تكليف له متابعة" Font-Size="20px"
                                    ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
