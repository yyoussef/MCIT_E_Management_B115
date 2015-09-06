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
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divcom','Imgcom');"  style="padding-top:7px;">
                        <img border="0" id="Imgcom" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divcom','Imgcom');">
                      <h1>  <asp:Label ID="lbl_commission" runat="server" Text="التكليفات"></asp:Label></h1>
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
                           
                                <asp:LinkButton ID="link_new_com" OnClick="lnk_btn_com_new_Click" runat="server"
                                     Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image61" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                           
                                <asp:LinkButton ID="link_old_com" OnClick="lnk_btn_com_old_Click" runat="server"
                                     Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image62" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="td_com_late" runat="server">
                           
                                <asp:LinkButton ID="link_late_com" OnClick="lnk_btn_com_late_Click" runat="server"
                                     Font-Size="18px"  font-underline="false" />
                              
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image63" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right">
                            
                                <asp:LinkButton ID="link_closed_com" OnClick="lnk_btn_com_closed_Click" runat="server"
                                     Font-Size="18px" font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image1611" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                        </td>
                        <td align="right" id="tr_link_com_have_follow" runat="server">
                           
                                <asp:LinkButton ID="link_com_have_follow" OnClick="lnk_btn_com_have_follow_Click"
                                    runat="server"  Font-Size="18px"  font-underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
