<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OutboxUserControl.ascx.cs"
    Inherits="UserControls_OutboxUserControl" %>

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
    <tr  id="inbox2">
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divoutbox','Imgoutbox');">
                        <img border="0" id="Imgoutbox" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divoutbox','Imgoutbox');">
                       <h1> <asp:Label ID="lbl_archive_forall" runat="server" Text="  الأرشيف الإلكترونى -  صادر "></asp:Label></h1>
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
                            <asp:Image ID="Image56" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td_link_new_Outbox_forall" runat="server">
                           
                                <asp:LinkButton ID="link_new_Outbox_forall" OnClick="lnk_btn_Outbox_new_forall_Click"
                                    runat="server"  Font-Size="18px" font-underline="false" />
                                
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_old_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image58" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" runat="server">
                            
                                <asp:LinkButton ID="link_old_Outbox_forall" OnClick="lnk_btn_Outbox_old_forall_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_late_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image54" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="link_late_Outbox_forall" OnClick="lnk_btn_Outbox_late_forall_Click"
                                    runat="server"  Font-Size="18px" font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_have_follow_all" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image60" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td_link_Outbox_have_follow_forall" runat="server">
                           
                                <asp:LinkButton ID="link_Outbox_have_follow_forall" OnClick="lnk_btn_have_follow_forall_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_closed_forall" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image59" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="link_closed_Outbox_forall" OnClick="lnk_btn_Outbox_closed_forall_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                              
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_Outbox_have_visa" runat="server" visible="false">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="tr_lnk_btn_Outboxhavevisa" runat="server">
                            
                                <asp:LinkButton ID="lnk_btn_Outboxhavevisa" OnClick="lnk_btn_Outbox_have_visa_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
