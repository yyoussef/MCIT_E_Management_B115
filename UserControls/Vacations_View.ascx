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

    <tr>
        <td valign="top" align="right" width="95%">
            <table width="100%" cellpadding="0" cellspacing="0" style="height: 50px">
                <tr>
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div300','Img5');"  style="padding-top:7px;">
                        <img border="0" id="Img5" src="../Images/square_arrow_flipped.gif" />
                    </td>
                    <td
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('div300','Img5');">
                      <h1><asp:Label ID="lbl_Vcation" runat="server" Text="  الاجازات والمأموريات "></asp:Label></h1>  
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <tr>
        <td align="right">
            <div id="div300" style="display: none">
                <table>
                    <tr id="trVoc" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image2122" runat="server" ImageUrl="~/Images/arrow.gif" Style="padding-left: 5px" />
                        </td>
                        <td align="right" id="td_lnkVocationsNo" runat="server">
                            
                                <asp:LinkButton ID="lnkVocationsNo" OnClick="lnkVocationsNo_Click" runat="server"
                                    Font-Size="18px"  Font-Underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="trVocE" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image47" runat="server" ImageUrl="~/Images/arrow.gif" Style="padding-left: 5px" />
                        </td>
                        <td align="right" id="td_lnkVocationsErgentNo" runat="server">
                            
                                <asp:LinkButton ID="lnkVocationsErgentNo" OnClick="lnkVocationsErgentNo_Click" runat="server"
                                    Font-Size="18px"  Font-Underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="trErrand" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image29" runat="server" ImageUrl="~/Images/arrow.gif" Style="padding-left: 5px" />
                        </td>
                        <td align="right" id="td_lnkErrandNo" runat="server">
                           
                                <asp:LinkButton ID="lnkErrandNo" OnClick="lnkErrandNo_Click" runat="server"
                                    Font-Size="18px"  Font-Underline="false" />
                                
                            <br />
                        </td>
                    </tr>
                    <tr id="trDayOff" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image35" runat="server" ImageUrl="~/Images/arrow.gif" Style="padding-left: 5px" />
                        </td>
                        <td align="right" id="td_lnkDayOffNo" runat="server">
                           
                                <asp:LinkButton ID="lnkDayOffNo" OnClick="lnkDayOffNo_Click" runat="server"
                                    Font-Size="18px" Font-Underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_permission" runat="server" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image49" runat="server" ImageUrl="~/Images/arrow.gif" Style="padding-left: 5px" />
                        </td>
                        <td align="right" id="td1" runat="server">
                           
                                <asp:LinkButton ID="lnkpermNo" OnClick="lnkpermNo_Click" runat="server"
                                    Font-Size="18px"  Font-Underline="false" />
                               
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>





</table>
