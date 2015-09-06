<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Archiving_Inbox.ascx.cs"
    Inherits="UserControls_Archiving_Inbox" %>

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
    <tr  id="tr_archive" runat="server" >
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr >
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div_archive','image236');"  style="padding-top:7px;">
                        <img border="0" id="Img3" src="../Images/square_arrow_down.gif" />
                    </td>
                    <td 
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div_archive','image236');">
                      <h1>  <asp:Label ID="Label4" runat="server" Text="أرشيف الملفات "></asp:Label></h1>
                    </td>
                </tr>
            </table>
            <tr>
                <td align="right">
                    <div id="div_archive" style="display: block">
                        <table>
                            <tr id="tr_arch1" runat="server" visible="true">
                                <td align="left" style="width: 368px">
                                    <asp:Image ID="Image27" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                </td>
                                <td align="right">
                                   
                                        <asp:LinkButton ID="lnk_files_count" runat="server"  Font-Size="18px"
                                             font-underline="false" OnClick="lnk_files_Click" />
                                       
                                    <br />
                                </td>
                            </tr>
                            <tr id="tr_arch2" runat="server" visible="true">
                                <td align="left" style="width: 368px">
                                    <asp:Image ID="Image32" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                </td>
                                <td align="right">
                                   
                                        <asp:LinkButton ID="lnk_archive_count" runat="server"  Font-Size="18px"
                                            font-underline="false" OnClick="lnk_archive_Click" />
                                       
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </td>
    </tr>
</table>
