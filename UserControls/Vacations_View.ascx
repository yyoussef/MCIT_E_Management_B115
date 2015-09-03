<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vacations_View.ascx.cs" Inherits="UserControls_Vacations_View" %>

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
                                                        <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div300','Img5');">
                                                            <img border="0" id="Img5" src="../Images/square_arrow_flipped.gif" />
                                                        </td>
                                                        <td 
                                                            onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div300','Img5');">
                                                            <asp:Label ID="lbl_Vcation" runat="server" Text="  الاجازات والمأموريات "></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                         <tr>
                                            <td align="right">
                                                <div id="div300" style="display: none">
                                                    <table>
                                                        <tr id="trVoc" runat="server" visible="false">
                                                            <td align="left" style="width: 368px">
                                                                <asp:Image ID="Image2122" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                                            </td>
                                                            <td align="right" id="td_lnkVocationsNo" runat="server">
                                                                <asp:LinkButton ID="lnkVocations" OnClick="lnkVocationsNo_Click" runat="server" 
                                                                    Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                                                    <asp:LinkButton ID="lnkVocationsNo" OnClick="lnkVocationsNo_Click" runat="server"
                                                                         Font-Size="20px" Visible="true"  Text="0"
                                                                        ForeColor="#EC981F" font-underline="false" />
                                                                    <asp:LinkButton ID="lnkVocationsTxt" OnClick="lnkVocationsNo_Click" runat="server"
                                                                         Visible="true"  Text="طلب أجازة" Font-Size="20px"
                                                                        ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr id="trVocE" runat="server" visible="false">
                                                            <td align="left" style="width: 368px">
                                                                <asp:Image ID="Image47" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                                            </td>
                                                            <td align="right" id="td_lnkVocationsErgentNo" runat="server">
                                                                <asp:LinkButton ID="LinkButton59" OnClick="lnkVocationsErgentNo_Click" runat="server"
                                                                     Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true"
                                                                    Text="لديك عدد">
                                                                    <asp:LinkButton ID="lnkVocationsErgentNo" OnClick="lnkVocationsErgentNo_Click" runat="server"
                                                                         Font-Size="20px" Visible="true"  Text="0"
                                                                        ForeColor="#EC981F" font-underline="false" />
                                                                    <asp:LinkButton ID="LinkButton64" OnClick="lnkVocationsErgentNo_Click" runat="server"
                                                                         Visible="true"  Text="طلب أجازة عاجلة" Font-Size="20px"
                                                                        ForeColor="#808080" font-underline="false" Font-Bold="true" /></asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr id="trErrand" runat="server" visible="false">
                                                            <td align="left" style="width: 368px">
                                                                <asp:Image ID="Image29" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                                            </td>
                                                            <td align="right" id="td_lnkErrandNo" runat="server">
                                                                <asp:LinkButton ID="lnkErrand" OnClick="lnkErrandNo_Click" runat="server" 
                                                                    Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                                                    <asp:LinkButton ID="lnkErrandNo" OnClick="lnkErrandNo_Click" runat="server" 
                                                                        Font-Size="20px" Visible="true"  Text="0" ForeColor="#EC981F" font-underline="false" />
                                                                    <asp:LinkButton ID="lnkErrandTxt" OnClick="lnkErrandNo_Click" runat="server" 
                                                                        Visible="true"  Text="طلب مأمورية" Font-Size="20px" ForeColor="#808080" font-underline="false"
                                                                        Font-Bold="true" /></asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr id="trDayOff" runat="server" visible="false">
                                                            <td align="left" style="width: 368px">
                                                                <asp:Image ID="Image35" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                                            </td>
                                                            <td align="right" id="td_lnkDayOffNo" runat="server">
                                                                <asp:LinkButton ID="lnkDayOff" OnClick="lnkDayOffNo_Click" runat="server" 
                                                                    Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                                                    <asp:LinkButton ID="lnkDayOffNo" OnClick="lnkDayOffNo_Click" runat="server" 
                                                                        Font-Size="20px" Visible="true"  Text="0" ForeColor="#EC981F" font-underline="false" />
                                                                    <asp:LinkButton ID="lnkDayOfftxt" OnClick="lnkDayOffNo_Click" runat="server" 
                                                                        Visible="true"  Text="طلب يوم عطلة" Font-Size="20px" ForeColor="#808080" font-underline="false"
                                                                        Font-Bold="true" /></asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr_permission" runat="server" visible="false">
                                                            <td align="left" style="width: 368px">
                                                                <asp:Image ID="Image49" runat="server" ImageUrl="~/Images/arrow.gif"  style="padding-left:5px" />
                                                            </td>
                                                            <td align="right" id="td1" runat="server">
                                                                <asp:LinkButton ID="LinkButton67" OnClick="lnkpermNo_Click" runat="server" 
                                                                    Font-Size="20px" ForeColor="#808080" font-underline="false"  Font-Bold="true" Text="لديك عدد">
                                                                    <asp:LinkButton ID="lnkpermNo" OnClick="lnkpermNo_Click" runat="server" 
                                                                        Font-Size="20px" Visible="true"  Text="0" ForeColor="#EC981F" font-underline="false" />
                                                                    <asp:LinkButton ID="LinkButton70" OnClick="lnkpermNo_Click" runat="server" 
                                                                        Visible="true"  Text="طلب إذن" Font-Size="20px" ForeColor="#808080" font-underline="false"
                                                                        Font-Bold="true" /></asp:LinkButton>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>





</table> 
