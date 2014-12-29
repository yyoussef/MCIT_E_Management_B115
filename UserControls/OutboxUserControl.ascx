<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OutboxUserControl.ascx.cs"
    Inherits="UserControls_OutboxUserControl" %>

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
    <tr bgcolor="#E6F3FF" id="inbox2">
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr bgcolor="#E6F3FF">
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divoutbox','Imgoutbox');">
                        <img border="0" id="Imgoutbox" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divoutbox','Imgoutbox');">
                        <asp:Label ID="lbl_archive_forall" runat="server" Text="  الأرشيف الإلكترونى -  صادر "></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="divoutbox" style="display: none">
                <table>
                    <tr id="tr_Outbox_new_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image56" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td_link_new_Outbox_forall" runat="server">
                            <asp:LinkButton ID="lnk_btn_Outbox_new_forall" OnClick="lnk_btn_Outbox_new_forall_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_new_Outbox_forall" OnClick="lnk_btn_Outbox_new_forall_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton80" OnClick="lnk_btn_Outbox_new_forall_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر جديد" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_old_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image58" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnk_btn_Outbox_old_forall" OnClick="lnk_btn_Outbox_old_forall_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_old_Outbox_forall" OnClick="lnk_btn_Outbox_old_forall_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton81" OnClick="lnk_btn_Outbox_old_forall_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر جاري" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_late_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image54" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnk_btn_Outbox_late_forall" OnClick="lnk_btn_Outbox_late_forall_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_late_Outbox_forall" OnClick="lnk_btn_Outbox_late_forall_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton79" OnClick="lnk_btn_Outbox_late_forall_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر متأخر" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_have_follow_all" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image60" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td_link_Outbox_have_follow_forall" runat="server">
                            <asp:LinkButton ID="lnk_btn_have_follow_forall" OnClick="lnk_btn_have_follow_forall_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_Outbox_have_follow_forall" OnClick="lnk_btn_have_follow_forall_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton83" OnClick="lnk_btn_have_follow_forall_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر له متابعة" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_closed_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image59" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lnk_btn_Outbox_closed_forall" OnClick="lnk_btn_Outbox_closed_forall_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="link_closed_Outbox_forall" OnClick="lnk_btn_Outbox_closed_forall_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton82" OnClick="lnk_btn_Outbox_closed_forall_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر منتهي" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_have_visa" runat="server" visible="false">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="tr_lnk_btn_Outboxhavevisa" runat="server">
                            <asp:LinkButton ID="lnk_btn_Outbox_have_visa" OnClick="lnk_btn_Outbox_have_visa_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnk_btn_Outboxhavevisa" OnClick="lnk_btn_Outbox_have_visa_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton20" OnClick="lnk_btn_Outbox_have_visa_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="صادر لة تأشيرة" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
