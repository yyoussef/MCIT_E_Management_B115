<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectsUserControl.ascx.cs"
    Inherits="UserControls_ProjectsUserControl" %>

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
                    <td width="35" onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divproj','imageproj');">
                        <img border="0" id="imageproj" src="../Images/expand.gif" />
                    </td>
                    <td style="font-size: large; color: #0C6AC8; text-decoration: underline blink; font-weight: bold;"
                        onmouseover="this.style.cursor='hand'" onclick="ChangeMeCase('divproj','imageproj');">
                        <asp:Label ID="lbl_Project" runat="server" Text="المشروعات  "></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="right">
            <div id="divproj" style="display: block">
                <table>
                    <tr id="Current2" runat="server">
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="LinkButton20" OnClick="lnk_btn_Active_proj_2_Click" runat="server"
                                Font-Underline="True" Font-Size="20px" ForeColor="#275078" CssClass="link" Font-Bold="true"
                                Text="لديك عدد">
                                <asp:LinkButton ID="lnk_btn_Active_proj_2" OnClick="lnk_btn_Active_proj_2_Click"
                                    runat="server" CssClass="link" Font-Size="20px" Visible="true" Font-Underline="true"
                                    Text="0" ForeColor="red" />
                                <asp:LinkButton ID="LinkButton76" OnClick="lnk_btn_Active_proj_2_Click" runat="server"
                                    CssClass="link" Visible="true" Font-Underline="true" Text="مشروع جاري" Font-Size="20px"
                                    ForeColor="#275078" Font-Bold="true" /></asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr id="done_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image54" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" OnClick="lbtnProj_done_2_Click" ID="LinkButton78"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtnProj_done_2" OnClick="lbtnProj_done_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="LinkButton80" runat="server" Font-Underline="true" Font-Bold="true"
                                    OnClick="lbtnProj_done_2_Click" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع منتهى " />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="donefollow_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image56" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="LinkButton81" Text="لديك عدد" ForeColor="#275078"
                                Font-Size="20px" Font-Bold="true" OnClick="Lbdonefollow_2_Click">
                                <asp:LinkButton ID="Lb_Lbdonefollow_2" runat="server" Font-Bold="True" Font-Size="20px"
                                    Font-Underline="TRUE" ForeColor="Red" Visible="true" Text="0" OnClick="Lbdonefollow_2_Click" />
                                <asp:LinkButton ID="LinkButton83" runat="server" Font-Underline="true" Font-Bold="true"
                                    ForeColor="#275078" Font-Size="20px" Visible="true" Text=" مشروع منتهى تحت المتابعة"
                                    OnClick="Lbdonefollow_2_Click" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="stopped_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image58" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" OnClick="lbtnProj_stopped_2_Click" ID="LinkButton85"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtnProj_stopped_2" OnClick="lbtnProj_stopped_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="LinkButton88" runat="server" Font-Underline="true" Font-Bold="true"
                                    OnClick="lbtnProj_stopped_2_Click" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع متوقف" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_Commit_2" runat="server" visible="false" >
                        <td align="left" style="width: 368px">
                            <asp:Image ID="Image60" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right" id="tr_LBtnProj_ٍSuggest_2" runat="server">
                            <asp:LinkButton ID="LinkButton93" OnClick="LBtnProj_ٍSuggest_2_Click" runat="server"
                                Text="لديك عدد" ForeColor="#275078" Font-Bold="True" Font-Size="20px">
                                <asp:LinkButton ID="LBtnProj_ٍSuggest_2" OnClick="LBtnProj_ٍSuggest_2_Click" runat="server"
                                    ForeColor="Red" Font-Bold="True" Font-Size="22px" Visible="true" Text="0" Font-Underline="true" />
                                <asp:LinkButton runat="server" OnClick="LBtnProj_ٍSuggest_2_Click" ID="LinkButton95"
                                    Font-Size="20px" ForeColor="#275078" Font-Bold="True" CssClass="link" Text="مشروع جديد مقترح" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_Re_Update_2" runat="server" visible="false">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image61" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="LinkButton96" runat="server" OnClick="lbtnProj_Approved_2_Click"
                                Font-Bold="true" ForeColor="#275078" Font-Size="20px" Text="لديك عدد">
                                <asp:LinkButton ID="lbtnProj_Approved_2" OnClick="lbtnProj_Approved_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton runat="server" ID="LinkButton98" OnClick="lbtnProj_Approved_2_Click"
                                    Font-Bold="true" ForeColor="#275078" Font-Size="20px" Text="مشروع جديد معتمد" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_Repeted_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image62" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="LinkButton99" OnClick="lbtnProj_Repeted_2_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtnProj_Repeted_2" OnClick="lbtnProj_Repeted_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="LinkButton102" runat="server" OnClick="lbtnProj_Repeted_2_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع مطلوب إعادته" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_refused_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image63" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="LinkButton103" OnClick="lbtnProj_refused_2_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lbtnProj_refused_2" OnClick="lbtnProj_refused_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="LinkButton105" runat="server" OnClick="lbtnProj_refused_2_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع تم رفضه" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="tr_Canceled_2" runat="server">
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image461" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="LinkButton511" OnClick="lnkProj_Canceled_2_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lnkProj_Canceled_2" OnClick="lnkProj_Canceled_2_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="LinkButton621" runat="server" OnClick="lnkProj_Canceled_2_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="مشروع تم إلغائه" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    
                    
                     <tr id="tr_Project_Constraints" runat="server" visible="false" >
                        <td align="left" class="style7" style="width: 368px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/new_images/a1.gif" />
                        </td>
                        <td align="right">
                            <asp:LinkButton runat="server" ID="lnk_const" OnClick="lnk_const_Click"
                                Text="لديك عدد" ForeColor="#275078" Font-Size="20px" Font-Bold="true">
                                <asp:LinkButton ID="lnk_const_count" OnClick="lnk_const_Click" runat="server"
                                    Font-Bold="True" Font-Size="20px" Font-Underline="TRUE" ForeColor="Red" Visible="true"
                                    Text="0" />
                                <asp:LinkButton ID="lnk_const1" runat="server" OnClick="lnk_const_Click"
                                    Font-Underline="true" Font-Bold="true" ForeColor="#275078" Font-Size="20px" Visible="true"
                                    Text="   مشروعات بها معوقات وتحتاج لتدخل إدارة عليا" />
                            </asp:LinkButton>
                        </td>
                    </tr>
                    
                </table>
            </div>
        </td>
    </tr>
</table>
