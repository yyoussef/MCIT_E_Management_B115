<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PNeedsUserControl.ascx.cs"
    Inherits="UserControls_PNeedsUserControl" %>

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
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divneeds','Imgneeds');">
                        <img border="0" id="Imgneeds" src="../Images/collapse.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divneeds','Imgneeds');">
                        <asp:Label ID="lbl_needs" runat="server" Text=" الإحتياجات  "></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="divneeds" style="display: none">
                <table>
                    <tr id="trNeedsNoApproving_2" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td_lnkNeedsNoApprovingNo_2" runat="server">
                            <asp:LinkButton ID="LnkNeedsNoApproving_2" OnClick="lnkNeedsNoApprovingNo_2_Click"
                                runat="server" Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link"
                                Font-Bold="true" Text="لديك عدد">
                                <asp:LinkButton ID="lnkNeedsNoApprovingNo_2" OnClick="lnkNeedsNoApprovingNo_2_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="lnkNeedsNoApprovingTxt_2" OnClick="lnkNeedsNoApprovingNo_2_Click"
                                    runat="server" CssClass="link" Visible="true" Font-Underline="true" Text="مشروع له طلبات بدون تصديق"
                                    Font-Size="20px" ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="trNeedsNoAvailable_2" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td_lnkNeedsNo_Available_2" runat="server">
                            <asp:LinkButton ID="LinkButton1_2" OnClick="lnkNeedsNo_Available_2_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnkNeedsNo_Available_2" OnClick="lnkNeedsNo_Available_2_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton12_2" OnClick="lnkNeedsNo_Available_2_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="مشروع لها تصديق محتاج إتاحة"
                                    Font-Size="20px" ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="trNeeds_Recieve_2" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="td_lnkNeeds_Recieve_2" runat="server">
                            <asp:LinkButton ID="LnkNeedsExchanged_2" OnClick="lnkNeeds_Recieve_2_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnkNeeds_Recieve_2" OnClick="lnkNeeds_Recieve_2_Click" runat="server"
                                    CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true" Text="0"
                                    ForeColor="red" />
                                <asp:LinkButton ID="lnkNeedsExchangedTxt_2" OnClick="lnkNeeds_Recieve_2_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="مشروع تم الصرف " Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="tr_needs_approved" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image33" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="LinkButton39" OnClick="lbtnProj_Approve_Needs_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtnProj_Approve_Needs" OnClick="lbtnProj_Approve_Needs_Click"
                                    runat="server" Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red"
                                    Visible="true" Text="0" />
                                <asp:LinkButton ID="LinkButton45" runat="server" OnClick="lbtnProj_Approve_Needs_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع له طلبات مصدق عليها" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_Needs_Available_Recievable" runat="server" >
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image34" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="lbtn_project_Available123" OnClick="lbtn_project_Available_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtn_project_Available" OnClick="lbtn_project_Available_Click"
                                    runat="server" Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red"
                                    Visible="true" Text="0" />
                                <asp:LinkButton ID="LinkButton47" runat="server" OnClick="lbtn_project_Available_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع له إتاحة وتحتاج الصرف" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
